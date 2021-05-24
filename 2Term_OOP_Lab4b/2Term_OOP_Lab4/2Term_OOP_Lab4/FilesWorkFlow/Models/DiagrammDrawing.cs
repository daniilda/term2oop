using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2Term_OOP_Lab4
{
    public static class DiagramDrawing
    {
        /// <summary>
        /// A simple canvas initialization
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color">Background color of canvas</param>
        /// <returns></returns>
        public static Canvas CreateCanvas(double width, double height, Brush color)
        {
            var canv = new Canvas {Background = color, Width = width, Height = height};
            return canv;
        }

        /// <summary>
        /// Draws a piechart on Canvas by the data in Charts[] then returns that Canvas
        /// </summary>
        /// <param name="charts">Charts[]</param>
        /// <param name="pieWidth">The Width of pieChart</param>
        /// <param name="pieHeight">The Height of pieChart</param>
        /// <returns></returns>
        public static Canvas GetPieChart(Charts[] charts, double pieWidth, double pieHeight)
        {
            var outGrid = new Canvas();
            var back = new Ellipse()
            {
                Width = pieWidth,
                Height = pieHeight,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            
            outGrid.Height = pieHeight;
            outGrid.Width = pieWidth;
            outGrid.Background = Brushes.Transparent;
            outGrid.Children.Add(back);
            double centerX = pieWidth / 2, 
                centerY = pieHeight / 2, 
                radius = pieWidth / 2;
            double angle = 0, prevAngle = 0;
            foreach (var chart in charts)
            {
                var line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                var line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = chart.Value * 360 / 100 + prevAngle;
                var realAngle = chart.Value *  360 / 100;
                Debug.WriteLine(angle);

                var arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                var arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                var isLargeArc = chart.Value > 50;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() {pathFigure,};
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = chart.Color(),
                    Data = pathGeometry,
                };
                outGrid.Children.Add(path);

                prevAngle = angle;



                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                };
                var textPoint = new Point();
                {
                    textPoint.X = ((radius * Math.Cos((angle - realAngle / 2) * Math.PI / 180)) + centerX);
                    textPoint.Y = ((radius * Math.Sin((angle - realAngle / 2) * Math.PI / 180)) + centerY);
                }

                var valueMark = new TextBlock();
                {
                    if (textPoint.X >= pieWidth / 2 && textPoint.Y <= pieHeight/2)
                    {
                        Canvas.SetLeft(valueMark, textPoint.X+20);
                        Canvas.SetTop(valueMark, textPoint.Y-20);
                    }
                    else if (textPoint.X <= pieWidth / 2 && textPoint.Y <= pieHeight/2)
                    {
                        Canvas.SetLeft(valueMark, textPoint.X-20);
                        Canvas.SetTop(valueMark, textPoint.Y-20);
                    } else if (textPoint.X >= pieWidth / 2 && textPoint.Y >= pieHeight / 2)
                    {
                        Canvas.SetLeft(valueMark, textPoint.X);
                        Canvas.SetTop(valueMark, textPoint.Y);
                    }
                    else
                    {
                        Canvas.SetLeft(valueMark, textPoint.X-20);
                        Canvas.SetTop(valueMark, textPoint.Y);
                    }

                    
                    
                    
                    valueMark.FontSize = 14;
                    valueMark.Text = Convert.ToString(chart.RealValue, CultureInfo.InvariantCulture);
                }

                
                outGrid.Children.Add(outline1);
                outGrid.Children.Add(outline2);
                outGrid.Children.Add(valueMark);
                
            }
            var outline3 = new Ellipse()
            {
                Width = pieWidth,
                Height = pieHeight,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = null,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            
            outGrid.Children.Add(outline3);
            return outGrid;
        }

        /// <summary>
        /// Generates Charts[] with random values 
        /// </summary>
        /// <returns>Charts[]</returns>
        public static Charts[] GetRandomCharts()
        {
            var random = new Random();
            var charts = new Charts[random.Next(2, 10)];
            for (var i = 0; i < charts.Length; i++)
                charts[i] = new Charts();
            foreach (var chart in charts)
            {
                chart.RealValue = random.Next(1, 100);
                chart.RColor = random.Next(1, 225);
                chart.GColor = random.Next(1, 225);
                chart.BColor = random.Next(1, 225);
            }
            var chartSum = charts.Sum(t => t.RealValue);

            foreach (var t in charts)
            {
                t.Value = (t.RealValue / chartSum) * 100;
            }

            return charts;
        }
    }
}