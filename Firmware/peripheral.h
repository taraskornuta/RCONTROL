#ifndef PERIPHERAL_H
#define PERIPHERAL_H

#include "stm32f10x.h"
#include <stdint.h>

extern uint8_t jumper;

#define LED_GREEN GPIOA, GPIO_Pin_15
#define LED_RED  GPIOB, GPIO_Pin_3
#define LED_GREEN_ON  GPIO_SetBits(LED_GREEN);
#define LED_GREEN_OFF GPIO_ResetBits(LED_GREEN);
#define LED_RED_ON  GPIO_SetBits(LED_RED);
#define LED_RED_OFF GPIO_ResetBits(LED_RED);

#define CH_PD GPIOB, GPIO_Pin_9
#define CH_PD_ON  GPIO_SetBits(CH_PD);
#define CH_PD_OFF GPIO_ResetBits(CH_PD);

void Periph_Init(void);
void GPIO_Configuration(void);
void TIMERS_Configuration(void);
void delay_ms(uint16_t ms);
void led_red_blink(uint16_t time, uint8_t quantiti);
void led_green_blink(uint16_t time, uint8_t quantiti);
uint8_t jumper_state(void);

#endif
