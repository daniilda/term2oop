
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace S2Term_OOP_Lab6b
{
    public abstract class GeometricFigure
    {

        private Point _center;
        private Brush _color;
        private double _size;
        private string _name;

        public abstract double Area();
        
        public abstract Canvas Draw();

        public virtual bool IsItIn(Point point)
        {
            return false;
        }

        public virtual Label GetInfo()
        {
            var text = new Label();
            text.Content = this._name + this.Area();
            return text;
        }

        protected GeometricFigure(double x, double y)
        {
            var rnd = new Random();
            _center.X = x;
            _center.Y = y;
            _name = this.ToString();
            _size = rnd.Next(1, 100);
        }

    }
}