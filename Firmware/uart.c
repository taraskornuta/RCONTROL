#include "uart.h"

// USART1 Receiver buffer
#define      UART1_RX_BUFFER_SIZE 128
uint8_t      UART1_rx_buffer[UART1_RX_BUFFER_SIZE];
unsigned int UART1_rx_wr_index = 0,
             UART1_rx_rd_index = 0,
             UART1_rx_counter  = 0;
uint8_t      UART1_rx_buffer_overflow=0;

// USART1 Transmitter buffer
#define      UART1_TX_BUFFER_SIZE 128
uint8_t      UART1_tx_buffer[UART1_TX_BUFFER_SIZE];
unsigned int UART1_tx_wr_index=0,
             UART1_tx_rd_index=0,
             UART1_tx_counter=0;

// USART2 Receiver buffer
#define      UART2_RX_BUFFER_SIZE 128
uint8_t      UART2_rx_buffer[UART2_RX_BUFFER_SIZE];
unsigned int UART2_rx_wr_index = 0,
             UART2_rx_rd_index = 0,
             UART2_rx_counter  = 0;
uint8_t      UART2_rx_buffer_overflow=0;

// USART2 Transmitter buffer
#define      UART2_TX_BUFFER_SIZE 128
uint8_t      UART2_tx_buffer[UART2_TX_BUFFER_SIZE];
unsigned int UART2_tx_wr_index=0,
             UART2_tx_rd_index=0,
             UART2_tx_counter=0;

void USART_Configuration(void)
{
    GPIO_InitTypeDef GPIO_InitStructure;
	USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA | RCC_APB2Periph_USART1,ENABLE);
	/*
	 *  USART1_TX -> PA9 , USART1_RX ->	PA10
	 */
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	USART_InitStructure.USART_BaudRate = UART1_BAUD;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;
	USART_InitStructure.USART_StopBits = USART_StopBits_1;
	USART_InitStructure.USART_Parity = USART_Parity_No;
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
	USART_Init(USART1, &USART_InitStructure);

	USART_Cmd(USART1, ENABLE);

	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2,ENABLE);
	/*
	 *  USART2_TX -> PA2 , USART2_RX ->	PA3
	*/
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

	USART_InitStructure.USART_BaudRate = UART2_BAUD;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;
	USART_InitStructure.USART_StopBits = USART_StopBits_1;
	USART_InitStructure.USART_Parity = USART_Parity_No;
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
	USART_Init(USART2, &USART_InitStructure);

	USART_Cmd(USART2, ENABLE);

//------------------------------------USART INTERUPT VECTORS------------------------------//
    NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);  /* Enable Receive interrupts */
    USART_ITConfig(USART1, USART_IT_TXE, ENABLE);


    NVIC_InitStructure.NVIC_IRQChannel = USART2_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
    NVIC_Init(&NVIC_InitStructure);

    USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);  /* Enable Receive interrupts */
    USART_ITConfig(USART2, USART_IT_TXE, ENABLE);

}

//---------------------------------UART 1 Interrupt vector ---------------------------------//
void USART1_IRQHandler(void)
{
  LED_BLUE_ON;
  if(USART_GetITStatus(USART1, USART_IT_RXNE) == SET)
  {
       if ((USART1->SR & (USART_FLAG_NE|USART_FLAG_FE|USART_FLAG_PE|USART_FLAG_ORE)) == 0)
       {
          UART1_rx_buffer[UART1_rx_wr_index++]=(uint8_t)(USART_ReceiveData(USART1)& 0xFF);
          if (UART1_rx_wr_index == UART1_RX_BUFFER_SIZE) UART1_rx_wr_index=0;
          if (++UART1_rx_counter == UART1_RX_BUFFER_SIZE)
          {
              UART1_rx_counter=0;
              UART1_rx_buffer_overflow=1;
          }
        }
        else USART_ReceiveData(USART1);
   }

  if(USART_GetITStatus(USART1, USART_IT_ORE) == SET) //прерывание по переполнению буфера
  {
      USART_ReceiveData(USART1); //в идеале пишем здесь обработчик переполнения буфера, но мы просто сбрасываем этот флаг прерывания чтением из регистра данных.
  }

  if(USART_GetITStatus(USART1, USART_IT_TXE) == SET)
  {
     if (UART1_tx_counter)
     {
         --UART1_tx_counter;
         USART_SendData(USART1,UART1_tx_buffer[UART1_tx_rd_index++]);
         if (UART1_tx_rd_index == UART1_TX_BUFFER_SIZE) UART1_tx_rd_index=0;
     }
     else
     {
        USART_ITConfig(USART1, USART_IT_TXE, DISABLE);
     }
  }
  LED_BLUE_OFF;
}


//---------------------------------UART 1 functions ---------------------------------//

uint8_t UART1_get_char(void)
{
   uint8_t data;
   while (UART1_rx_counter == 0);
   data = UART1_rx_buffer[ UART1_rx_rd_index++ ];
   if (UART1_rx_rd_index == UART1_RX_BUFFER_SIZE) UART1_rx_rd_index = 0;
   USART_ITConfig(USART1, USART_IT_RXNE, DISABLE);
   --UART1_rx_counter;
   USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);
   return data;
}

void UART1_put_char(uint8_t c)
{

   while (UART1_tx_counter == UART1_TX_BUFFER_SIZE);
   USART_ITConfig(USART1, USART_IT_TXE, DISABLE);

   if (UART1_tx_counter || (USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET))
      {
         UART1_tx_buffer[UART1_tx_wr_index++]=c;
         if (UART1_tx_wr_index == UART1_TX_BUFFER_SIZE) UART1_tx_wr_index=0;
         ++UART1_tx_counter;
         USART_ITConfig(USART1, USART_IT_TXE, ENABLE);
      }
   else USART_SendData(USART1,c);

}

void UART1_put_str(unsigned char *s)
{
  while (*s != 0)
  UART1_put_char(*s++);
}


void UART1_put_int(int32_t data)
{
   unsigned char temp[10],count=0;
   if (data<0)
      {
      data=-data;
      UART1_put_char('-');
      }

   if (data)
      {
       while (data)
          {
         temp[count++]=data%10+'0';
         data/=10;
          }

       while (count)
         {
         UART1_put_char(temp[--count]);
         }
        }
          else UART1_put_char('0');

}
void buff_clear()															//	очищаем буфер
{
  int i;
  for(i=0;i<UART2_STRING_BUFFER_SIZE;i++)
    {
	Buffer[i]=0;
    }
}

//	читаем текстовую строку с UART, до ввода <enter>. Максимальная длина строки 512Байт
void UART1_read_str(unsigned char* s)
{
	buff_clear();
  unsigned char temp;
  unsigned int index=0;
  while(index<UART2_STRING_BUFFER_SIZE)
    {
	temp=UART1_get_char();
	if(temp!=13)
	{
	    *s++=temp;
	}
	else
	{
	    index=UART2_STRING_BUFFER_SIZE;
	}
	index++;
    }
}

//---------------------------------UART 2 Interrupt vector ---------------------------------//

void USART2_IRQHandler(void)
{
  LED_BLUE_ON;
  if(USART_GetITStatus(USART2, USART_IT_RXNE) == SET)
  {
       if ((USART2->SR & (USART_FLAG_NE|USART_FLAG_FE|USART_FLAG_PE|USART_FLAG_ORE)) == 0)
       {
          UART2_rx_buffer[UART2_rx_wr_index++]=(uint8_t)(USART_ReceiveData(USART2)& 0xFF);
          if (UART2_rx_wr_index == UART2_RX_BUFFER_SIZE) UART2_rx_wr_index=0;
          if (++UART2_rx_counter == UART2_RX_BUFFER_SIZE)
          {
              UART2_rx_counter=0;
              UART2_rx_buffer_overflow=1;
          }
        }
        else USART_ReceiveData(USART2);
                 //вообще здесь нужен обработчик ошибок, а мы просто пропускаем битый байт
   }

  if(USART_GetITStatus(USART2, USART_IT_ORE) == SET) //прерывание по переполнению буфера
  {
      USART_ReceiveData(USART2); //в идеале пишем здесь обработчик переполнения буфера, но мы просто сбрасываем этот флаг прерывания чтением из регистра данных.
  }

  if(USART_GetITStatus(USART2, USART_IT_TXE) == SET)
  {
     if (UART2_tx_counter)
     {
         --UART2_tx_counter;
         USART_SendData(USART2,UART2_tx_buffer[UART2_tx_rd_index++]);
         if (UART2_tx_rd_index == UART2_TX_BUFFER_SIZE) UART2_tx_rd_index=0;
     }
     else
     {
        USART_ITConfig(USART2, USART_IT_TXE, DISABLE);
     }
  }
  LED_BLUE_OFF;
}


//---------------------------------UART 2 functions ---------------------------------//
unsigned char UART2_get_char(void)
{
   unsigned char data;
   while (UART2_rx_counter == 0);
   data = UART2_rx_buffer[ UART2_rx_rd_index++ ];
   if (UART2_rx_rd_index == UART2_RX_BUFFER_SIZE) UART2_rx_rd_index = 0;
   USART_ITConfig(USART2, USART_IT_RXNE, DISABLE);
   --UART2_rx_counter;
   USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);
   return data;
}

void UART2_put_char(unsigned char c)
{
   while (UART2_tx_counter == UART2_TX_BUFFER_SIZE);
   USART_ITConfig(USART2, USART_IT_TXE, DISABLE);

   if (UART2_tx_counter || (USART_GetFlagStatus(USART2, USART_FLAG_TXE) == RESET))
      {
         UART2_tx_buffer[UART2_tx_wr_index++]=c;
         if (UART2_tx_wr_index == UART2_TX_BUFFER_SIZE) UART2_tx_wr_index=0;
         ++UART2_tx_counter;
         USART_ITConfig(USART2, USART_IT_TXE, ENABLE);
      }
       else
          USART_SendData(USART2,c);
}

void UART2_put_str(unsigned char *s)
{
  while (*s != 0)
  UART2_put_char(*s++);

}


void UART2_put_int(int32_t data)
{
   unsigned char temp[10],count=0;
   if (data<0)
      {
      data=-data;
      UART2_put_char('-');
      }

   if (data)
      {
       while (data)
          {
         temp[count++]=data%10+'0';
         data/=10;
          }

       while (count)
         {
         UART2_put_char(temp[--count]);
         }
        }
    else UART2_put_char('0');

}
void UART2_read_str(unsigned char* s) //Читає строку до ввода Enter
{
  buff_clear();
  unsigned char temp;
  unsigned int index=0;
  while(index<UART2_STRING_BUFFER_SIZE)
    {
	temp=UART2_get_char();
	if((temp!=13) )              //Enter 13-символ по таблиці ANSII
	{
	    *s++=temp;
	}
	else
	{
	    index=UART2_STRING_BUFFER_SIZE;
	}
	index++;
    }
}
