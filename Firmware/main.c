#include "stm32f10x.h"
#include "stm32f10x_conf.h"
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include "peripheral.h"
#include "channels.h"
#include "uart.h"
#include "esp8266.h"


int main(void)
{
	SystemInit();
	TIMERS_Configuration();
	GPIO_Configuration();
	CHANNELS_Configuration();
	CPPM_Configuration();
	USART_Configuration();

	WIFI_Init();
	WIFI_weit_connection();


    while (1)
    {

//    	PPM_PIN_HI;
//    	delay_us(900);
//
//    	PPM_PIN_HI;		//CH1
//    	delay_us(100);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH2
//    	delay_us(150);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH3
//    	delay_us(170);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH4
//    	delay_us(150);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH5
//    	delay_us(180);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH6
//    	delay_us(150);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH7
//    	delay_us(130);
//    	PPM_PIN_LO;
//    	delay_us(50);
//
//    	PPM_PIN_HI;		//CH8
//    	delay_us(200);
//    	PPM_PIN_LO;
//    	delay_us(50);


    }
}






#ifdef  USE_FULL_ASSERT

/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t* file, uint32_t line)
{
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */

  while (1)
  {}
}
#endif
