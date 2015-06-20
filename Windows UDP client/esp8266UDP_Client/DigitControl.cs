using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace esp8266UDP_Client
{
    public partial class DigitControl : UserControl
    {
        private const int MAX_VALUE = 100;
        private const int MID_VALUE = 0;
        private const int MIN_VALUE = -100;
        private int maxvalue = MAX_VALUE;
        private int minvalue = MIN_VALUE;
        private bool minormax = true;

        public DigitControl()
        {
            InitializeComponent();

        }

        public bool Update_condition()
        {           
		    if (MinOrMax == true)
            {
                maxvalue = MAX_VALUE;
                minvalue = MID_VALUE;
                return true;
            }
            else
            {
                maxvalue = MIN_VALUE;
                minvalue = MID_VALUE;
                return false;
            }
            
        }
        
        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public bool MinOrMax
        {
            get { return minormax; }
            set { minormax = value; }
        }

        public int i;
        private void btn_Minus_Click(object sender, EventArgs e)
        {
            if (Update_condition() == true)
            {
                i = Convert.ToInt16(textBox1.Text);
                
                if (i == maxvalue)
                {
                    i--;
                    textBox1.Text = Convert.ToString(i);
                }
                else if (i == minvalue)
                {
                
                }
                else
                {
                    i--;
                    textBox1.Text = Convert.ToString(i);
                } 
            }

            else
            {
                i = Convert.ToInt16(textBox1.Text);
            
                if (i == maxvalue)
                {
                    i++;
                    textBox1.Text = Convert.ToString(i);
                }
                else if (i == minvalue)
                {

                }
                else
                {
                    i++;
                    textBox1.Text = Convert.ToString(i);
                } 
            }                        
        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            if (Update_condition() == true)
            {
                i = Convert.ToInt16(textBox1.Text);
             
                if (i == maxvalue)
                {
                    //i++;
                    //textBox1.Text = Convert.ToString(i);
                }
                else
                {
                    i++;
                    textBox1.Text = Convert.ToString(i);
                }
            }
            else
            {
                i = Convert.ToInt16(textBox1.Text);
               
                if (i == maxvalue)
                {

                }
                else
                {
                    i--;
                    textBox1.Text = Convert.ToString(i);
                }
            }
        }
    }
}
