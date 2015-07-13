namespace RCONTROL
{
    public class Mixer
    {
        public static int LimitsMin = 0;
        public static int LimitsMid = 500;
        public static int LimitsMax = 1000;

        public static int LimitMin(int MinControl)
        {
            var i = LimitsMin + MinControl;
            return i;
        }
    }
}