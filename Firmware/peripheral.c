#include "stm32f10x.h"
#include "misc.h"
#include <stdint.h>
#include <stdlib.h>
#include "peripheral.h"


void GPIO_Configuration(void)
{
    /* Port PB3, PA15 JTAG pins, mast be disabled */
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_AFIO, ENABLE);		//JTAG disabling
    GPIO_PinRemapConfig(GPIO_Remap_SWJ_JTAGDisable, ENABLE);	//JTAG disabling

    /* GPIOC clock enable */
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_GPIOB, ENABLE);

    //LED_GREEN, LED_BLUE
    GPIO_InitTypeDef GPIO_InitStructure;

   GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
   GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
   GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
   GPIO_Init(GPIOB, &GPIO_InitStructure);

   GPIO_InitStructure.GPIO_Pin = GPIO_Pin_15;
   GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
   GPIO_InitStructure.GPIO_Speed = GPIO_Speed_2MHz;
   GPIO_Init(GPIOA, &GPIO_InitStructure);
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


