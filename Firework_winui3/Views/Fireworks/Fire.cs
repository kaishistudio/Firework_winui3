using Windows.UI;
using Windows.Foundation;
using System.Numerics;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;

namespace Firework_winui3.Views.Fireworks
{
    public class Fire
    {
        private Color _Color;
        private double _Degree = 0;
        public double Degree
        {
            get { return _Degree; }
            set { _Degree = value; }
        }
        private double _Rate = 10;
        private double _Time = 0;
        public double Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }
        private Vector2 _RateVector;
        private Point _StartPoint;
        private Vector2 _Vector_g = new Vector2(0, 0.4F);
        private Line _Line = new Line() { StrokeThickness = 1 };
        private Storyboard _Storyboard = new Storyboard() { AutoReverse = false };
        private Storyboard _Storyboard_Opacity = new Storyboard() { AutoReverse = false };
        private Canvas _ShowInCanvas;
        private DoubleAnimation _Animation1_X = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation1_Y = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation2_X = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation2_Y = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _OpacityAnimation = new DoubleAnimation() { EnableDependentAnimation = true };
        public Color Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                _Line.Stroke = new SolidColorBrush(value);
            }
        }
        public Fire(Point startPoint, Canvas canvas)
        {
            Color = Colors.LightSkyBlue;
            _StartPoint = startPoint;
            _ShowInCanvas = canvas;
            _Storyboard.Completed += _Storyboard_Completed;
        }
        public void Fly()
        {
            _ShowInCanvas.Children.Add(_Line);
            Point point = DrawFunction.XuanZhuan(new Point(0, 0), new Point(Rate, 0), Degree / 180 * Math.PI);
            _RateVector = new Vector2((float)point.X, (float)point.Y);
            _Line.X1 = _StartPoint.X;
            _Line.Y1 = _StartPoint.Y;
            _Line.X2 = _StartPoint.X;
            _Line.Y2 = _StartPoint.Y;

            _Animation1_X.From = _Line.X1;
            _Animation1_X.To = _Line.X1 + _RateVector.X;
            _Animation1_Y.From = _Line.Y1;
            _Animation1_Y.To = _Line.Y1 + _RateVector.Y;
            _Animation1_X.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            _Animation1_Y.Duration = new Duration(TimeSpan.FromMilliseconds(100));

            _Animation2_X.From = _Line.X2;
            _Animation2_X.To = _Line.X1 + _RateVector.X * (-1.5);
            _Animation2_Y.From = _Line.Y2;
            _Animation2_Y.To = _Line.Y1 + _RateVector.Y * (-1.5);
            _Animation2_X.Duration = new Duration(TimeSpan.FromMilliseconds(100));
            _Animation2_Y.Duration = new Duration(TimeSpan.FromMilliseconds(100));

            _Storyboard.Children.Add(_Animation1_X);
            _Storyboard.Children.Add(_Animation1_Y);
            _Storyboard.Children.Add(_Animation2_X);
            _Storyboard.Children.Add(_Animation2_Y);
            Storyboard.SetTarget(_Animation1_X, this._Line);
            Storyboard.SetTargetProperty(_Animation1_X, "X1");
            Storyboard.SetTarget(_Animation1_Y, this._Line);
            Storyboard.SetTargetProperty(_Animation1_Y, "Y1");
            Storyboard.SetTarget(_Animation2_X, this._Line);
            Storyboard.SetTargetProperty(_Animation2_X,"X2");
            Storyboard.SetTarget(_Animation2_Y, this._Line);
            Storyboard.SetTargetProperty(_Animation2_Y, "Y2");
            _Storyboard.Begin();

            _OpacityAnimation.From = 1;
            _OpacityAnimation.To = 0.4;
            _OpacityAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1500));
            _Storyboard_Opacity.Children.Add(_OpacityAnimation);
            Storyboard.SetTarget(_OpacityAnimation, this._Line);
            Storyboard.SetTargetProperty(_OpacityAnimation, "Opacity");
            _Storyboard_Opacity.Begin();
        }
        private void _Storyboard_Completed(object sender, object e)
        {
            _Time = _Time + 100;
            if (_Time <= 1500)
            {
                Vector2 aVector = new Vector2(_RateVector.X/_RateVector.Length()*1, _RateVector.Y / _RateVector.Length() * 1);
                if (_RateVector.Length() > 1)
                {
                    _RateVector = _RateVector - aVector;
                }
                _RateVector = _RateVector + _Vector_g;
                _Animation1_X.From = _Line.X1;
                _Animation1_X.To = _Line.X1 + _RateVector.X;
                _Animation1_Y.From = _Line.Y1;
                _Animation1_Y.To = _Line.Y1 + _RateVector.Y;

                _Animation2_X.From = _Line.X2;
                _Animation2_X.To = _Line.X1 + _RateVector.X * (-1.5);
                _Animation2_Y.From = _Line.Y2;
                _Animation2_Y.To = _Line.Y1 + _RateVector.Y * (-1.5);

                _Storyboard.Begin();
            }
            else
            {
                _Storyboard.Stop();
                _ShowInCanvas.Children.Remove(_Line);
            }
        }
    }
}
