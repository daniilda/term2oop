using System;
using System.Windows.Input;
using System.Windows.Media;

namespace _2Term_OOP_Lab4
{
    public class Charts
    {
        private double _value;

        public double Value
        {
            get => _value;
            set => this._value = value;
        }

        private double _realValue;

        public double RealValue
        {
            get => _realValue;
            set => _realValue = value;
        }
        
        public Brush Color()
        {
            var color = new Color {R = Convert.ToByte(RColor), G = Convert.ToByte(GColor), B = Convert.ToByte(BColor), A = 100};
            var brush = new SolidColorBrush(color);
            return brush;
        }

        private int _rColor;

        public int RColor
        {
            get => _rColor;
            set => _rColor = value;
        }

        private int _gColor;

        public int GColor
        {
            get => _gColor;
            set => _gColor = value;
        }

        private int _bColor;

        public int BColor
        {
            get => _bColor;
            set => _bColor = value;
        }

        public Charts()
        {
            _value = 0;
            _realValue = 0;
            _rColor = 0;
            _gColor = 0;
            _bColor = 0;
        }
    }
}