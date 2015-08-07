#include "stm32f10x.h"
#include "esp8266.h"
#include "PWM.h"
#include <stdio.h>
#include <string.h>


int Channel[CH_QUANTITI] = {MIN_COMMAND, MIN_COMMAND, MIN_COMMAND, MIN_COMMAND, MIN_COMMAND, MIN_COMMAND, MIN_COMMAND, MIN_COMMAND};

void WIFI_Init(void)
{
	CH_PD_ON;
	WIFI_command("AT+RST\r\n", "ready");
	WIFI_command("ATE0\r\n", "OK");
	WIFI_command("AT+CWMODE=2\r\n", "OK");
	WIFI_command("AT+CWSAP=\"RCONTROL\",\"rcontrol\",3,3\r\n", "OK");
	WIFI_command("AT+CIPMODE=0\r\n", "OK");
	WIFI_command("AT+CIPMUX=1\r\n", "OK");
	WIFI_command("AT+CIPSERVER=1,8000\r\n", "OK");
	WIFI_command("AT+CIPSTART=0,\"UDP\",\"192.168.4.1\",8000,8000,2\r\n", "OK");
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
	    WIFI_connect();
	    UART1_read_str(Buffer);
	}
	while((!strstr(Buffer,"0,CONNECT")) && (!strstr(Buffer,"ERROR")) && (!strstr(Buffer,"busy")));
	if (strstr(Buffer, "0,CONNECT"))
	{
	    WIFI_connect();
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

void WIFI_connect(void)
{
	do
	{
	    UART1_read_str(Buffer);
	}
	while((!strstr(Buffer,"\n+IPD,0,39:"))&& (!strstr(Buffer,"0,CLOSED")));
	if (strstr(Buffer, "\n+IPD,0,39:"))
	{
	    do
	    {
	        UART1_read_str(Buffer);
	        sscanf (Buffer,"\n+IPD,0,39: %4d,%4d,%4d,%4d,%4d,%4d,%4d,%4d",&Channel[0], &Channel[1],&Channel[2],&Channel[3],&Channel[4],&Channel[5],&Channel[6],&Channel[7]);

//	        ch1_puls(channel[0]);
//	        ch2_puls(channel[1]);
//	        ch3_puls(channel[2]);
//	        ch4_puls(channel[3]);
//	        ch5_puls(channel[4]);
//	        ch6_puls(channel[5]);
//	        ch7_puls(channel[6]);
//	        ch8_puls(channel[7]);
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
