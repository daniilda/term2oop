using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Lab3
{
    class GraphicsCanv
    {


        internal List<Line> getGridListOfLines(double width, double height, int cellsAmountW, int cellsAmountH, Brush gridColor, double thickness)
        {
            

            double cellSizeW = width / cellsAmountW;
            double cellSizeH = height / cellsAmountH;

            var LineList = new List<Line>();
            {
                for (int i = 0; i <= cellsAmountW; i++)
                {
                    LineList.Add(createLine(0, i*cellSizeW, width, i * cellSizeW, gridColor, thickness));
                }

                for(int i = 0; i <= cellsAmountH; i++)
                {
                    LineList.Add(createLine(i*cellSizeH, 0, i*cellSizeH, height, gridColor, thickness));
                }

            }


            return LineList;

        }

        internal Ellipse getZeroDrawing(double cellX, double cellY, double width, double height, int cellsAmountW, int cellsAmountH)
        {
            var __zero = new Ellipse();
            {
                double cellSizeW = width / cellsAmountW;
                double cellSizeH = height / cellsAmountH;
                __zero.Height = height / cellsAmountH - 10;
                __zero.Width = width / cellsAmountW - 10;
                __zero.SetValue(Canvas.LeftProperty, (double)(cellX*cellSizeW + 5));
                __zero.SetValue(Canvas.TopProperty, (double)(cellY*cellSizeH + 5));
                __zero.Stroke = Brushes.Blue;
                __zero.StrokeThickness = 8;
            }
            return __zero;
        }

        internal List<Line> getCrossDrawing(double cellX, double cellY, double width, double height, int cellsAmountW, int cellsAmountH)
        {
            const double ALIGNMENT = 10;
            double cellSizeW = width / cellsAmountW;
            double cellSizeH = height / cellsAmountH;
            double crossSize = (cellSizeW + cellSizeH)/2 - ALIGNMENT; 

            var __cross = new List<Line>();
            {
                __cross.Add(createLine(cellX*cellSizeW+ ALIGNMENT, cellY*cellSizeH+ALIGNMENT, cellX*cellSizeW+ crossSize, cellY*cellSizeH+ crossSize, Brushes.Red, 10));
                __cross.Add(createLine(cellX * cellSizeW+ ALIGNMENT, cellY * cellSizeH+crossSize, cellX * cellSizeW+ crossSize, cellY * cellSizeH+ ALIGNMENT, Brushes.Red, 10));
            }
            return __cross;
        }

        internal Line winLine(double x1, double y1, double x2, double y2) //not adaptive method
        {
            var __color1 = new Color();
            {
                __color1.R = 108; 
                __color1.G = 83;
                __color1.B = 122;
                __color1.A = 255;
            }
            var __color2 = new Color();
            {
                __color2.R = 202;
                __color2.G = 188;
                __color2.B = 209;
                __color2.A = 255;
            }
            var __line = new Line();
            var __brush = new RadialGradientBrush(__color2, __color1);
            __line = createLine(x1*60+30, y1*60+30, x2*60+30, y2*60+30, Brushes.Black, 7);
            __line.Opacity = 0.95;
            __line.Stroke = __brush;
            return __line;
        }

        Line createLine(double x1, double y1, double x2, double y2, Brush color, double thikness)
        {
            var __line = new Line();
            __line.X1 = x1;
            __line.Y1 = y1;
            __line.X2 = x2;
            __line.Y2 = y2;
            __line.StrokeThickness = thikness;
            __line.Stroke = color;
            return __line;
        }

    }
}
