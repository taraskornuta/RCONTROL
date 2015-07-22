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

void ch1_puls(int puls);
void ch2_puls(int puls);
void ch3_puls(int puls);
void ch4_puls(int puls);
void ch5_puls(int puls);
void ch6_puls(int puls);
void ch7_puls(int puls);
void ch8_puls(int puls);

void cppm_output(int ch1, int ch2, int ch3, int ch4, int ch5, int ch6, int ch7, int ch8 );


#endif
