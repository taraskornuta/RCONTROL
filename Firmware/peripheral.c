#include "stm32f10x.h"
#include "misc.h"
#include <stdint.h>
#include <stdlib.h>
#include "peripheral.h"


void GPIO_Configuration(void)
{
	/* GPIOC clock enable */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);

	//LED_GREEN, LED_BLUE
   	GPIO_InitTypeDef GPIO_InitStructure;

    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8 | GPIO_Pin_9;
   	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
   	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
   	GPIO_Init(GPIOC, &GPIO_InitStructure);
}

void TIMERS_Configuration(void)
{
	//Delay function timer
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2,ENABLE);
	TIM2->PSC = 23999; // f timer = fclk / 24000 => 1kHz
	TIM2->ARR = 0xFFFF;
	TIM2->CR1 = TIM_CR1_CEN;
	DBGMCU->CR = DBGMCU_CR_DBG_TIM2_STOP;


}

void delay_ms(uint16_t ms)
{
 TIM2->ARR = ms;
 TIM2->CNT = 0;
 while((TIM2->SR & TIM_SR_UIF)==0){}
 TIM2->SR &= ~TIM_SR_UIF;
}

void led_green_blink(uint32_t time, uint8_t quantiti)
{
	uint8_t i=0;
	while(i<=quantiti)
	{
		i++;
		LED_GREEN_ON;
		delay_ms(time);
		LED_GREEN_OFF;
		delay_ms(time);
	}
}


