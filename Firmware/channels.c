#include "stm32f10x.h"
#include "channels.h"


void CHANNELS_Configuration(void)
{
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	TIM_OCInitTypeDef  TIM_OCInitStructure;

	/* TIM3 clock enable */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3|RCC_APB1Periph_TIM4, ENABLE);

	/* GPIOA and GPIOB clock enable */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB | RCC_APB2Periph_AFIO, ENABLE);

	GPIO_InitTypeDef GPIO_InitStructure;

    /* GPIOA, B Configuration:TIM3 Channel1, 2, 3 and 4 as alternate function push-pull */
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_6 | GPIO_Pin_7;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;

    GPIO_Init(GPIOA, &GPIO_InitStructure);

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 | GPIO_Pin_1| GPIO_Pin_6| GPIO_Pin_7| GPIO_Pin_8;
    GPIO_Init(GPIOB, &GPIO_InitStructure);

	 /* Time base configuration */
   TIM_TimeBaseStructure.TIM_Period = 34000; 				//Частота PWM
   TIM_TimeBaseStructure.TIM_Prescaler = 13;				//Період в мсек
   TIM_TimeBaseStructure.TIM_ClockDivision = 0;
   TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

   TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);

   /* PWM1 Mode configuration: Channel1 */
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
   TIM_TimeBaseStructure.TIM_Period = 34000; 				//Частота PWM
   TIM_TimeBaseStructure.TIM_Prescaler = 13;				//Період в мсек
   TIM_TimeBaseStructure.TIM_ClockDivision = 0;
   TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

   TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);

   /* PWM1 Mode configuration: Channel1 */
   TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM2;
   TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_Low;

   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC1Init(TIM4, &TIM_OCInitStructure);
   TIM_OC1PreloadConfig(TIM4, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel2 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
    TIM_OC2Init(TIM4, &TIM_OCInitStructure);
   TIM_OC2PreloadConfig(TIM4, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel3 */
   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
   TIM_OC3Init(TIM4, &TIM_OCInitStructure);
   TIM_OC3PreloadConfig(TIM4, TIM_OCPreload_Enable);

   /* PWM1 Mode configuration: Channel4 */
//   TIM_OCInitStructure.TIM_OutputState = TIM_OutputState_Enable;
//   TIM_OC4Init(TIM4, &TIM_OCInitStructure);
//   TIM_OC4PreloadConfig(TIM4, TIM_OCPreload_Enable);

   TIM_ARRPreloadConfig(TIM4, ENABLE);

   /* TIM4 enable counter */
   TIM_Cmd(TIM4, ENABLE);

}

double coeff= (double) MAX_PULSE / MAX_COMMAND; //Розрахунок коефіцієнта множення для задання періоду пульсації PWM


void ch1_puls(uint16_t puls)
{
	TIM3->CCR1 = (uint16_t)(coeff * puls);
}
void ch2_puls(uint16_t puls)
{
	TIM3->CCR2 = (uint16_t)(coeff * puls);
}
void ch3_puls(uint16_t puls)
{
	TIM3->CCR3 = (uint16_t)(coeff * puls);
}
void ch4_puls(uint16_t puls)
{
	TIM3->CCR4 = (uint16_t)(coeff * puls);
}
void ch5_puls(uint16_t puls)
{
	TIM4->CCR1 = (uint16_t)(coeff * puls);
}
void ch6_puls(uint16_t puls)
{
	TIM4->CCR2 = (uint16_t)(coeff * puls);
}
void ch7_puls(uint16_t puls)
{
	TIM4->CCR3 = (uint16_t)(coeff * puls);
}
void ch8_puls(uint16_t puls)
{
	TIM4->CCR4 = (uint16_t)(coeff * puls);
}
