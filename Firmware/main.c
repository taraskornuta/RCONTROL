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
	USART_Configuration();

	//WIFI_Init();
	//WIFI_weit_connection();

	UART1_put_str("TEST STRING INPUT\r\n");
	UART1_put_str("YAKAS HUINya\r\n");
	LED_BLUE_ON;
	LED_GREEN_ON;
	//led_green_blink(50,300);
    while (1)
    {
   	UART1_put_str("TEST STRING INPUT");
   	delay_ms(500);

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