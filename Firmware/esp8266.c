#include "stm32f10x.h"
#include "esp8266.h"
#include <stdio.h>
#include <string.h>

int ch1=1000;
int ch2=1000;
int ch3=1000;
int ch4=1000;
int ch5=1000;
int ch6=1000;
int ch7=1000;
int ch8=1000;

void WIFI_Init(void)
{
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
	UART2_put_str(command);
	do
	{
		UART2_read_str(Buffer);
    }
    while((!strstr(Buffer,answer)));
	if (strstr(Buffer, answer))
	{
		led_green_blink(30,1);
	}
}

void WIFI_weit_connection(void)
{
	do
	{
		WIFI_CONNECT();
		//UART2_read_str(Buffer);
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
			UART2_read_str(Buffer);

		}
		while((!strstr(Buffer,"\n+IPD,0,39:"))&& (!strstr(Buffer,"0,CLOSED")));
		if (strstr(Buffer, "\n+IPD,0,39:"))
		{
			do{
				UART2_read_str(Buffer);
				sscanf (Buffer,"\n+IPD,0,39: %4d,%4d,%4d,%4d,%4d,%4d,%4d,%4d",&ch1,&ch2,&ch3,&ch4,&ch5,&ch6,&ch7,&ch8);
				ch1_puls(ch1);
				ch2_puls(ch2);
				ch3_puls(ch3);
				ch4_puls(ch4);
				ch5_puls(ch5);
				ch6_puls(ch6);
				ch7_puls(ch7);
				ch8_puls(ch8);
				}
				while((!strstr(Buffer,"0,CLOSED")));
		}
		if (strstr(Buffer, "0,CLOSED"))
			{
				WIFI_weit_connection();
			}
}

