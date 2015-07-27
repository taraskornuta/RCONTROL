#include "stm32f10x.h"
#include "esp8266.h"
#include <stdio.h>
#include <string.h>

#define CH_QUANTITI 8

int channel[CH_QUANTITI] = {1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000};

void WIFI_Init(void)
{
	CH_PD_ON;
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+RST\r\n",(unsigned char *) "ready");
	WIFI_command((unsigned char *)"ATE0\r\n",(unsigned char *) "OK");
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+CWMODE=2\r\n", (unsigned char *)"OK");
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+CWSAP=\"RCONTROL\",\"rcontrol\",3,3\r\n", (unsigned char *)"OK");
	delay_ms(500);
	WIFI_command((unsigned char *)"AT+CIPMODE=0\r\n", (unsigned char *)"OK");
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+CIPMUX=1\r\n", (unsigned char *)"OK");
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+CIPSERVER=1,8000\r\n", (unsigned char *)"OK");
	delay_ms(200);
	WIFI_command((unsigned char *)"AT+CIPSTART=0,\"UDP\",\"192.168.4.1\",8000,8000,2\r\n", (unsigned char *)"OK");
}

void WIFI_command(unsigned char *command, unsigned char *answer)
{
	UART1_put_str(command);
	do
	{
	    UART1_read_str(Buffer);
        }
        while((!strstr(Buffer,answer)));
	if (strstr(Buffer, answer))
	{
	    led_red_blink(30,1);
	}
}

void WIFI_weit_connection(void)
{
	do
	{
	    WIFI_CONNECT();
	    UART1_read_str(Buffer);
	}
	while((!strstr(Buffer,"0,CONNECT")) && (!strstr(Buffer,"ERROR")) && (!strstr(Buffer,"busy")));
	if (strstr(Buffer, "0,CONNECT"))
	{
	    WIFI_CONNECT();
	}
	else if (strstr(Buffer, "ERROR"))
	{
	    WIFI_Init();
	}
	else if (strstr(Buffer, "busy"))
	{
	    delay_ms(100);
	    WIFI_weit_connection();
	}
}

void WIFI_CONNECT(void)
{
	do
	{
	    UART1_read_str(Buffer);
	}
	while((!strstr(Buffer,"\n+IPD,0,39:"))&& (!strstr(Buffer,"0,CLOSED")));
	if (strstr(Buffer, "\n+IPD,0,39:"))
	{
	    do{
	        UART1_read_str(Buffer);
	        sscanf (Buffer,"\n+IPD,0,39: %4d,%4d,%4d,%4d,%4d,%4d,%4d,%4d",&channel[0], &channel[1],&channel[2],&channel[3],&channel[4],&channel[5],&channel[6],&channel[7]);
	        ch1_puls(channel[0]);
	        ch2_puls(channel[1]);
	        ch3_puls(channel[2]);
	        ch4_puls(channel[3]);
	        ch5_puls(channel[4]);
	        ch6_puls(channel[5]);
	        ch7_puls(channel[6]);
	        ch8_puls(channel[7]);
	      }
	    while((!strstr(Buffer,"0,CLOSED")));
	}
	if (strstr(Buffer, "0,CLOSED"))
	{
	    WIFI_weit_connection();
	}
}


void WIFI_hard_reset(void)
{
	CH_PD_OFF;
	delay_ms(50);
	WIFI_Init();
}
