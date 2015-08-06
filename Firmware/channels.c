#include "stm32f10x.h"
#include "channels.h"
#include "peripheral.h"
#include "esp8266.h"

double coeff= (double) MAX_PULSE / MAX_COMMAND; //Розрахунок коефіцієнта множення для задання періоду пульсації PWM

#define PPM_ELEMENTS 18
uint16_t PPM_Buffer[PPM_ELEMENTS] = {400, 1400, 1800, 3000, 3400, 4700, 5100, 6500, 6900, 8400, 8800, 10800, 11200, 13200, 13600, 16000, 16400, 21999};



void CPPM_Configuration(void)
{
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA |RCC_APB2Periph_AFIO, ENABLE);
    RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2, ENABLE);

    TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure ;
    TIM_OCInitTypeDef TIM_OCInitStructure;
    GPIO_InitTypeDef GPIO_InitStructure;

    TIM_TimeBaseStructure.TIM_Period = 22000 - 1;
    TIM_TimeBaseStructure.TIM_Prescaler = 72 - 1;    // 72 MHz / 72 (1 MHz tick)
    TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;
    TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

    TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);

    TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_Toggle;
    TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
    TIM_OCInitStructure.TIM_Pulse = 0;
    TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;

    TIM_OC1Init(TIM2, &TIM_OCInitStructure);

    TIM_DMAConfig(TIM2, TIM_DMABase_CCR1, TIM_DMABurstLength_1Transfer);
    // "connecting" DMA and TIM2
    TIM_DMACmd(TIM2, TIM_DMA_CC1, ENABLE);

    TIM_ITConfig(TIM2, TIM_IT_Update, ENABLE);


    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_Init(GPIOA, &GPIO_InitStructure);

    // turning on TIM2 and PWM outputs
    TIM_Cmd(TIM2, ENABLE);

    NVIC_InitTypeDef NVIC_InitStructure;
    // Enable the TIM2 gloabal Interrupt
    NVIC_InitStructure.NVIC_IRQChannel = TIM2_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);
}

void DMA_Configuration(void)
{
	//enable DMA1 clock
	    RCC_AHBPeriphClockCmd(RCC_AHBPeriph_DMA1, ENABLE);

	    //create DMA structure
	    DMA_InitTypeDef  DMA_InitStructure;

	    //reset DMA1 channe1 to default values;
	    DMA_DeInit(DMA1_Channel5);
	    //channel will be used for memory to memory transfer
	    DMA_InitStructure.DMA_M2M = DMA_M2M_Disable;
	    //setting normal mode (non circular)
	    DMA_InitStructure.DMA_Mode = DMA_Mode_Circular;
	    //medium priority
	    DMA_InitStructure.DMA_Priority = DMA_Priority_High;
	    //source and destination data size word=32bit
	    DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_HalfWord;
	    DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_HalfWord;
	    //automatic memory destination increment enable.
	    DMA_InitStructure.DMA_MemoryInc = DMA_MemoryInc_Enable;
	    //source address increment disable
	    DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;

	    DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralDST;
	    DMA_InitStructure.DMA_BufferSize = PPM_ELEMENTS;                            // 8 channels + 9 space + end
	    DMA_InitStructure.DMA_PeripheralBaseAddr = (uint32_t)&TIM2->CCR1;
	    DMA_InitStructure.DMA_MemoryBaseAddr = (uint32_t)PPM_Buffer;
	    DMA_Init(DMA1_Channel5, &DMA_InitStructure);

	    // turning DMA on
	    DMA_Cmd(DMA1_Channel5, ENABLE);
}

void TIM2_IRQHandler(void)
{
    int i;

    for (i = 1; i < PPM_ELEMENTS - 1; ++i)  // Ignore first and last ppm value. Should always be 400 and 21999 respectively
    {
        if (i % 2 == 1)
        {

        	PPM_Buffer[i] = PPM_Buffer[i - 1] + (Channel[(i - 1) / 2]-1000) + 600;
        }
        else
        {
            PPM_Buffer[i] = PPM_Buffer[i - 1] + 400;
        }
    }

    TIM_ClearFlag(TIM2, TIM_FLAG_Update);
}

void PWM_Configuration(void)
{
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	TIM_OCInitTypeDef  TIM_OCInitStructure;

	/* TIM3 clock enable */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2|RCC_APB1Periph_TIM3, ENABLE);

	/* GPIOA and GPIOB clock enable */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB | RCC_APB2Periph_AFIO, ENABLE);

	GPIO_InitTypeDef GPIO_InitStructure;

    /* GPIOA, B Configuration:TIM3 Channel1, 2, 3 and 4 as alternate function push-pull */
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 |GPIO_Pin_1 |GPIO_Pin_2 |GPIO_Pin_3 |GPIO_Pin_6 | GPIO_Pin_7;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
    GPIO_Init(GPIOA, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_1;
    GPIO_Init(GPIOB, &GPIO_InitStructure);

	 /* Time base configuration */
   TIM_TimeBaseStructure.TIM_Period = 41100; 				//Частота PWM
   TIM_TimeBaseStructure.TIM_Prescaler = 34;				//Період в мсек
   TIM_TimeBaseStructure.TIM_ClockDivision = 0;
   TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

   TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);

   /* PWM1 Mode configuration: Channel1 */
   TIM_OCInitStructure.TIM_Pulse =
   TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;
   TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;

   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC1Init(TIM3, &TIM_OCInitStructure);
   TIM_OC1PreloadConfig(TIM3, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel2 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC2Init(TIM3, &TIM_OCInitStructure);
   TIM_OC2PreloadConfig(TIM3, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel3 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC3Init(TIM3, &TIM_OCInitStructure);
   TIM_OC3PreloadConfig(TIM3, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel4 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC4Init(TIM3, &TIM_OCInitStructure);
   TIM_OC4PreloadConfig(TIM3, TIM_OCPreload_Enable);

   TIM_ARRPreloadConfig(TIM3, ENABLE);

   /* TIM3 enable counter */
   TIM_Cmd(TIM3, ENABLE);

   /* Time base configuration */
   TIM_TimeBaseStructure.TIM_Period = 41100; 				//Частота PWM
   TIM_TimeBaseStructure.TIM_Prescaler = 34;				//Період в мсек
   TIM_TimeBaseStructure.TIM_ClockDivision = 0;
   TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

   TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);

   /* PWM1 Mode configuration: Channel1 */
   TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;
   TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;

   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC1Init(TIM2, &TIM_OCInitStructure);
   TIM_OC1PreloadConfig(TIM2, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel2 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
    TIM_OC2Init(TIM2, &TIM_OCInitStructure);
   TIM_OC2PreloadConfig(TIM2, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel3 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC3Init(TIM2, &TIM_OCInitStructure);
   TIM_OC3PreloadConfig(TIM2, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel4 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC4Init(TIM2, &TIM_OCInitStructure);
   TIM_OC4PreloadConfig(TIM2, TIM_OCPreload_Enable);

   TIM_ARRPreloadConfig(TIM2, ENABLE);

   /* TIM4 enable counter */
   TIM_Cmd(TIM2, ENABLE);

}






void ch1_puls(int puls)
{
	TIM3->CCR1 = (uint16_t)(coeff * puls);
}
void ch2_puls(int puls)
{
	TIM3->CCR2 = (uint16_t)(coeff * puls);
}
void ch3_puls(int puls)
{
	TIM3->CCR3 = (uint16_t)(coeff * puls);
}
void ch4_puls(int puls)
{
	TIM3->CCR4 = (uint16_t)(coeff * puls);
}
void ch5_puls(int puls)
{
	TIM2->CCR1 = (uint16_t)(coeff * puls);
}
void ch6_puls(int puls)
{
	TIM2->CCR2 = (uint16_t)(coeff * puls);
}
void ch7_puls(int puls)
{
	TIM2->CCR3 = (uint16_t)(coeff * puls);
}
void ch8_puls(int puls)
{
	TIM2->CCR4 = (uint16_t)(coeff * puls);
}


