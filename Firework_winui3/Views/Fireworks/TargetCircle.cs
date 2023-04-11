using Windows.UI;
using Windows.Foundation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml;
using Microsoft.UI;

namespace Firework_winui3.Views.Fireworks
{
    public class TargetCircle
    {
        private bool isStop = false;
        private Color _Color;
        private Ellipse _Ellipse = new Ellipse() { Width = 12, Height = 12, StrokeThickness = 2 };
        private Storyboard _Storyboard = new Storyboard() { AutoReverse = false };
        private DoubleAnimation _OpacityAnimation = new DoubleAnimation();
        private DoubleAnimation _WidthAnimation = new DoubleAnimation();
        private DoubleAnimation _HeightAnimation = new DoubleAnimation();
        //private ThicknessAnimation _ThicknessAnimation = new ThicknessAnimation();
        private Canvas _ShowInCanvas;
        private Point _Point;
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; _Ellipse.Stroke = new SolidColorBrush(value); }
        }
        public TargetCircle(Point point)
        {
            _Point = point;
            Color = Colors.DeepSkyBlue;
            _OpacityAnimation.From = 1;
            _OpacityAnimation.To = 0;
            _OpacityAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.8));
            _WidthAnimation.From = 12;
            _WidthAnimation.To = 2;
            _WidthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.8));
            _HeightAnimation.From = 12;
            _HeightAnimation.To = 2;
            _HeightAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.8));
            //_ThicknessAnimation.From = new Thickness() { Left = _Point.X - 12 / 2, Top = _Point.Y - 12 / 2 };
            //_ThicknessAnimation.To = new Thickness() { Left = _Point.X, Top = _Point.Y };
            //_ThicknessAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.8));
            _Storyboard.Children.Add(_OpacityAnimation);
            _Storyboard.Children.Add(_WidthAnimation);
            _Storyboard.Children.Add(_HeightAnimation);
            //_Storyboard.Children.Add(_ThicknessAnimation);
            _Storyboard.Completed += _Storyboard_Completed;

            
        }

        private void _Storyboard_Completed(object sender, object e)
        {

            if (isStop == false)
            {
                _Storyboard.Begin();
            }
            else
            {
                _Storyboard.Stop();
                _ShowInCanvas.Children.Remove(_Ellipse);
            }

        }
        public void Show(Canvas canvas)
        {
            _ShowInCanvas = canvas;
            _ShowInCanvas.Children.Add(_Ellipse);
            _Ellipse.Margin = new Thickness() { Left = _Point.X - _Ellipse.Width / 2, Top = _Point.Y - _Ellipse.Height / 2 };
            Storyboard.SetTarget(_OpacityAnimation, this._Ellipse);
            Storyboard.SetTargetProperty(_OpacityAnimation, "Opacity");
            Storyboard.SetTarget(_WidthAnimation, this._Ellipse);
            Storyboard.SetTargetProperty(_WidthAnimation, "Width");
            Storyboard.SetTarget(_HeightAnimation, this._Ellipse);
            Storyboard.SetTargetProperty(_HeightAnimation, "Height");
            //Storyboard.SetTarget(_ThicknessAnimation, this._Ellipse);
            //Storyboard.SetTargetProperty(_ThicknessAnimation, new PropertyPath("Margin"));
            _Storyboard.Begin();
        }
        public void Hide()
        {
            isStop = true;
        }
    }
}
