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

        void Update_condition()
        {
            //bool condition;
		    if (MinOrMax == true)
            {
                maxvalue = MAX_VALUE;
                minvalue = MID_VALUE;
            }
            else
            {
                maxvalue = MIN_VALUE;
                minvalue = MID_VALUE;
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
            Update_condition();
            i = Convert.ToInt16(textBox1.Text);
            //maxvalue = Convert.ToInt16(textBox1.Text);
            if (maxvalue==MAX_VALUE)
            {

            }
            else
            {
                i--;
                textBox1.Text = Convert.ToString(i);
            }
        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            Update_condition();
            i = Convert.ToInt16(textBox1.Text);
            //maxvalue = Convert.ToInt16(textBox1.Text);
            if (maxvalue == MAX_VALUE)
            {

            }
            else
            {
                i++;
                textBox1.Text = Convert.ToString(i);
            }
        }
    }
}
