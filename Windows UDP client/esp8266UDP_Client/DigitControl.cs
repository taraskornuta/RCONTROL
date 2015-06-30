using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RCONTROL
{
    public partial class DigitControl : UserControl
    {
        private const double MAX_VALUE = 100.0;
        private const double MID_VALUE = 0.0;
        private const double MIN_VALUE = -100.0;
        private double maxvalue = MAX_VALUE;
        private double minvalue = MIN_VALUE;


        public DigitControl()
        {
            InitializeComponent();

        }

        public string Update_condition()
        {           
		    if (StateValue == State.MAX_State)
            {
                maxvalue = MAX_VALUE;
                minvalue = MID_VALUE;
                return "MAX_State";
            }
            else if (StateValue == State.MIN_State)
            {
                maxvalue = MIN_VALUE;
                minvalue = MID_VALUE;
                return "MIN_State";
            }
            else //if (StateValue == State.MID_State)
            {
                maxvalue = MAX_VALUE;
                minvalue = MIN_VALUE;
                return "MID_State";
            }
          
        }
        private double ParseDouble(string value)
        {
            double d = 0;
            if (!double.TryParse(value, out d))
            {
                return 0;
            }
            return d;
        }

        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public enum State { MAX_State, MID_State, MIN_State };
        private State chosenState = State.MAX_State;
        public State StateValue
        {
            get { return chosenState; }
            set { chosenState = (State) value; }
        } 

        public double i;
        private void btn_Minus_Click(object sender, EventArgs e)
        {
            MinusingValue();
        }

        private void btn_Minus_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void btn_Minus_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MinusingValue();
        }

        private void MinusingValue()
        {
            if (Update_condition() == "MAX_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {
                    i = i - 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
                else if (i == minvalue)
                {
                }
                else
                {
                    i = i - 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }

            else if (Update_condition() == "MIN_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {
                    i = i + 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
                else if (i == minvalue)
                {
                }
                else
                {
                    i = i + 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }
            else if (Update_condition() == "MID_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {
                    i = i - 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
                else if (i == minvalue)
                {

                }
                else
                {
                    i = i - 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }
        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            PlusingValue();
        }

        private void btn_Plus_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Enabled = true;
            timer2.Start();
        }

        private void btn_Plus_MouseUp(object sender, MouseEventArgs e)
        {
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PlusingValue();
        }
        private void PlusingValue()
        {
            if (Update_condition() == "MAX_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {
                }
                else
                {
                    i = i + 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }
            else if (Update_condition() == "MIN_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {

                }
                else
                {
                    i = i - 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }
            else if (Update_condition() == "MID_State")
            {
                i = ParseDouble(textBox1.Text);

                if (i == maxvalue)
                {

                }
                else
                {
                    i = i + 0.1;
                    textBox1.Text = Convert.ToString(i);
                }
            }
        }
    }
}
