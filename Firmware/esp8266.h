#ifndef ESP8266_H
#define ESP8266_H

#include "stm32f10x.h"
#include "peripheral.h"
#include "uart.h"
#include <stdio.h>
#include <string.h>

void WIFI_Init(void);
void WIFI_command(unsigned char *command, unsigned char *answer);
void WIFI_weit_connection(void);
void WIFI_CONNECT(void);
void WIFI_CLOSED(void);

#endif
