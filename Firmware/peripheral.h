#ifndef PERIPHERAL_H
#define PERIPHERAL_H

#include "stm32f10x.h"
#include <stdint.h>
#include <peripheral.h>


#define LED_GREEN GPIOB, GPIO_Pin_3
#define LED_BLUE  GPIOA, GPIO_Pin_15
#define LED_GREEN_ON  GPIO_SetBits(LED_GREEN);
#define LED_GREEN_OFF GPIO_ResetBits(LED_GREEN);
#define LED_BLUE_ON  GPIO_SetBits(LED_BLUE);
#define LED_BLUE_OFF GPIO_ResetBits(LED_BLUE);


void GPIO_Configuration(void);
void TIMERS_Configuration(void);
void delay_ms(uint16_t ms);
void led_green_blink(uint32_t time, uint8_t quantiti);




#endif
