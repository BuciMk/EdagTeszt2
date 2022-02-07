using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EdagTeszt2
{
    internal class Grafika
    {

        private double forgatasiSzog = 0.0;
        private double elozoForgatasiSzog = 0.0;
        private Canvas canvas;
        private Polygon haromszog;
        private RotateTransform rotateTransform;

        public Grafika(Canvas canvasBejovo)
        {
            canvas = canvasBejovo;
        }

        public void Rajz(Point pointA, Point pointB, Point pointC)
        {
            haromszog = new Polygon();
            rotateTransform = new RotateTransform();
            haromszog.Points.Add(pointA);
            haromszog.Points.Add(pointB);
            haromszog.Points.Add(pointC);
            haromszog.Stroke = Brushes.Black;
            canvas.Children.Add(haromszog);

        }

        public void haromszogForgatas(double bejovoForgatasiSzog)
        {
            if (haromszog == null)
            {
                return;
            }

            forgatasiSzog = elozoForgatasiSzog - bejovoForgatasiSzog;

            var centerX = (haromszog.Points[0].X + haromszog.Points[1].X + haromszog.Points[2].X) / 3;
            var centerY = (haromszog.Points[0].Y + haromszog.Points[1].Y + haromszog.Points[2].Y) / 3;

            rotateTransform.Angle = forgatasiSzog;
            rotateTransform.CenterX = centerX;
            rotateTransform.CenterY = centerY;
            haromszog.RenderTransform = rotateTransform;
        }

        public void Clear()
        {
            if (haromszog == null)
            {
                return;
            }
            canvas.Children.Clear();
            haromszog.Points.Clear();
            haromszog = null;
            rotateTransform = null;
        }
    }
}
