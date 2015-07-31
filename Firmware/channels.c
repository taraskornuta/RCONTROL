#include "stm32f10x.h"
#include "channels.h"
#include "peripheral.h"

void CPPM_Configuration(void)
{
	/* GPIOA and GPIOB clock enable */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);

	GPIO_InitTypeDef GPIO_InitStructure;

	/* GPIOA Configuration*/
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;

	GPIO_Init(GPIOA, &GPIO_InitStructure);

}
void CHANNELS_Configuration(void)
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



double coeff= (double) MAX_PULSE / MAX_COMMAND; //Розрахунок коефіцієнта множення для задання періоду пульсації PWM


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

void cppm_puls(int ch_mas[])			//Добавити вхідні данні і цикл пропахунку значень з масиву
{
	uint8_t ch_number = 0;

	PPM_PIN_HI;
	ch_number++;
	if(ch_number > CHANNELS)
	{
		ch_number = 0;
		delay_us(900); //Sync impulse
		PPM_PIN_LO;
	}
	else
	{
		for(uint8_t i=0; i>CHANNELS; i++)
		{
    	//PPM_PIN_HI;		//CH1
    	delay_us(ch_mas[i]);
    	PPM_PIN_LO;
    	delay_us(50);
		}
	}
}
