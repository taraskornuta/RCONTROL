#ifndef CHANNELS_H
#define CHANNELS_H

#include "stm32f10x.h"
#include "stm32f10x_conf.h"

#include <stdint.h>

#define MAX_COMMAND 2000
#define MIN_COMMAND 1000
#define MAX_PULSE   3450
#define MIN_PULSE   1700

void CHANNELS_Configuration(void);

void ch1_puls(uint16_t puls);
void ch2_puls(uint16_t puls);
void ch3_puls(uint16_t puls);
void ch4_puls(uint16_t puls);
void ch5_puls(uint16_t puls);
void ch6_puls(uint16_t puls);
void ch7_puls(uint16_t puls);
void ch8_puls(uint16_t puls);

#endif
