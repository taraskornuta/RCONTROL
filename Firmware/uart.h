#ifndef UART_H
#define UART_H

#include "stm32f10x.h"
#include "stm32f10x_conf.h"
#include "stm32f10x_usart.h"
#include "misc.h"
#include "peripheral.h"


#define UART1_BAUD 115200
#define UART3_BAUD 115200

void USART_Configuration(void);

#define UART3_STRING_BUFFER_SIZE 128
unsigned char Buffer[UART3_STRING_BUFFER_SIZE];

uint8_t UART1_get_char(void);
void UART1_put_char(uint8_t c);
void UART1_put_str(unsigned char *s);
void UART1_put_int(int32_t data);
void UART1_read_str(unsigned char* s);
void buff_clear();

uint8_t UART3_get_char(void);
void UART3_put_char(uint8_t c);
void UART3_put_str(unsigned char *s);
void UART3_put_int(int32_t data);
void UART3_read_str(unsigned char* s);



#endif //UART_H
