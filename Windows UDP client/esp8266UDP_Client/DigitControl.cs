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
       // private bool minormax = true;

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
        
        public string Value
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        //public bool MinOrMax
        //{
        //    get { return minormax; }
        //    set { minormax = value; }
        //}
        private double ParseDouble(string value)
        {
            double d = 0;
            if (!double.TryParse(value, out d))
            {
                return 0;
            }
            return d;
        }
        public enum State { MAX_State, MID_State, MIN_State };

        private State chosenState = State.MAX_State;

        public State StateValue
        {
            get
            {
                return chosenState;
            }
            set
            {
                this.chosenState = (State)value;
            }
        } 

        public double i;
        private void btn_Minus_Click(object sender, EventArgs e)
        {
            if (Update_condition() == "MAX_State")
            {
                i = ParseDouble(textBox1.Text);
                
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

            else if (Update_condition() == "MIN_State")
            {
                i = Convert.ToDouble(textBox1.Text);
            
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
            else if (Update_condition() == "MID_State")
            {
                i = Convert.ToDouble(textBox1.Text);

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
            if (Update_condition() == "MAX_State")
            {
                i = Convert.ToDouble(textBox1.Text);
             
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
            else if (Update_condition() == "MIN_State")
            {
                i = Convert.ToDouble(textBox1.Text);
               
                if (i == maxvalue)
                {

                }
                else
                {
                    i--;
                    textBox1.Text = Convert.ToString(i);
                }
            }
            else if (Update_condition() == "MID_State")
            {
                i = Convert.ToDouble(textBox1.Text);

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
