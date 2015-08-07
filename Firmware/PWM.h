#ifndef PWM_H
#define PWM_H

#include "stm32f10x.h"
#include "stm32f10x_conf.h"

#include <stdint.h>

#define MAX_COMMAND 2000
#define MIN_COMMAND 1000
#define MAX_PULSE   4100
#define MIN_PULSE   1700

#define CHANNELS    8


void PWM_Configuration(void);

void ch1_puls(int puls);
void ch2_puls(int puls);
void ch3_puls(int puls);
void ch4_puls(int puls);
void ch5_puls(int puls);
void ch6_puls(int puls);
void ch7_puls(int puls);
void ch8_puls(int puls);




#endif
