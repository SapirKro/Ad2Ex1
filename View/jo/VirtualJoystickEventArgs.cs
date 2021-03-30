using System;

namespace ad2ex1.View.jo
{
    public class VirtualJoystickEventArgs:EventArgs
    {
        public double Angle { get; set; }
        public double Distance { get; set; }
    }
}
