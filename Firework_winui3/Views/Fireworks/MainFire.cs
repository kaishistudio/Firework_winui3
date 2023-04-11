using Windows.UI;
using Windows.Foundation;
using System.Numerics;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;

namespace Firework_winui3.Views.Fireworks
{
    public class MainFire
    {
        protected TargetCircle _TargetCircle;
        private Color _Color;
        private Line _Line1 = new Line() { StrokeThickness = 1.5, StrokeEndLineCap = PenLineCap.Round };
        private Line _Line2 = new Line() { StrokeThickness = 1, StrokeEndLineCap = PenLineCap.Round, Opacity = 0.8 };
        private Line _Line3 = new Line() { StrokeThickness = 0.5, StrokeEndLineCap = PenLineCap.Round, Opacity = 0.6 };
        protected Point _TargetPoint;
        private Storyboard _Storyboard = new Storyboard() { AutoReverse = false };
        protected Canvas _ShowInCanvas;
        private DoubleAnimation _Animation1_X1 = new DoubleAnimation() { EnableDependentAnimation =true};
        private DoubleAnimation _Animation1_Y1 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation1_X2 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation1_Y2 = new DoubleAnimation() { EnableDependentAnimation = true };

        private DoubleAnimation _Animation2_X1 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation2_Y1 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation2_X2 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation2_Y2 = new DoubleAnimation() { EnableDependentAnimation = true };

        private DoubleAnimation _Animation3_X1 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation3_Y1 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation3_X2 = new DoubleAnimation() { EnableDependentAnimation = true };
        private DoubleAnimation _Animation3_Y2 = new DoubleAnimation() { EnableDependentAnimation = true };
        private Vector2 _dVector;
        public Color Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                _Line1.Stroke = new SolidColorBrush(value);
                _Line2.Stroke = new SolidColorBrush(value);
                _Line3.Stroke = new SolidColorBrush(value);

            }
        }
        public MainFire(Canvas canvas, TargetCircle targetCircle)
        {
            Color = Colors.DeepSkyBlue;
            _TargetCircle = targetCircle;
            _ShowInCanvas = canvas;
            canvas.Children.Add(_Line1);
            canvas.Children.Add(_Line2);
            canvas.Children.Add(_Line3);

            _Line1.Width = canvas.ActualWidth;
            _Line1.Height = canvas.ActualHeight;
            _Line2.Width= canvas.ActualWidth;
            _Line2.Height= canvas.ActualHeight;
            _Line3.Width= canvas.ActualWidth;
            _Line3.Height= canvas.ActualHeight;
        }
        public void Fly(Point targetPoint)
        {
            _TargetPoint = targetPoint;
            Point Op = new Point(_ShowInCanvas.ActualWidth / 2, _ShowInCanvas.ActualHeight);
            Vector2 vector = new Vector2((float)(targetPoint.X - Op.X), (float)(targetPoint.Y-Op.Y));
            Vector2 vector2 = vector / vector.Length() * (-20);
            Point p = new Point(Op.X + vector2.X,Op.Y+vector2.Y);
            _Line1.X1 = Op.X;
            _Line1.Y1 = Op.Y;
            _Line1.X2 = p.X;
            _Line1.Y2 = p.Y;

            _Line2.X1 = p.X;
            _Line2.Y1 = p.Y;
            _Line2.X2 = Op.X + vector2.X * 2;
            _Line2.Y2 = Op.Y + vector2.Y * 2;

            _Line3.X1 = Op.X + vector2.X * 2;
            _Line3.Y1 = Op.Y + vector2.Y * 2;
            _Line3.X2 = Op.X + vector2.X * 3.5;
            _Line3.Y2 = Op.Y + vector2.Y * 3.5;

            _dVector = vector / vector.Length() * 12;
            _Animation1_X1.From = _Line1.X1;
            _Animation1_X1.To = _Line1.X1 + _dVector.X;
            _Animation1_Y1.From = _Line1.Y1;
            _Animation1_Y1.To = _Line1.Y1 + _dVector.Y;
            _Animation1_X1.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation1_Y1.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Animation1_X2.From = _Line1.X2;
            _Animation1_X2.To = _Line1.X2 + _dVector.X;
            _Animation1_Y2.From = _Line1.Y2;
            _Animation1_Y2.To = _Line1.Y2 + _dVector.Y;
            _Animation1_X2.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation1_Y2.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Animation2_X1.From = _Line2.X1;
            _Animation2_X1.To = _Line2.X1 + _dVector.X;
            _Animation2_Y1.From = _Line2.Y1;
            _Animation2_Y1.To = _Line2.Y1 + _dVector.Y;
            _Animation2_X1.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation2_Y1.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Animation2_X2.From = _Line2.X2;
            _Animation2_X2.To = _Line2.X2 + _dVector.X;
            _Animation2_Y2.From = _Line2.Y2;
            _Animation2_Y2.To = _Line2.Y2 + _dVector.Y;
            _Animation2_X2.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation2_Y2.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Animation3_X1.From = _Line3.X1;
            _Animation3_X1.To = _Line3.X1 + _dVector.X;
            _Animation3_Y1.From = _Line3.Y1;
            _Animation3_Y1.To = _Line3.Y1 + _dVector.Y;
            _Animation3_X1.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation3_Y1.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Animation3_X2.From = _Line3.X2;
            _Animation3_X2.To = _Line3.X2 + _dVector.X;
            _Animation3_Y2.From = _Line3.Y2;
            _Animation3_Y2.To = _Line3.Y2 + _dVector.Y;
            _Animation3_X2.Duration = new Duration(TimeSpan.FromMilliseconds(30));
            _Animation3_Y2.Duration = new Duration(TimeSpan.FromMilliseconds(30));

            _Storyboard.Children.Add(_Animation1_X1);
            _Storyboard.Children.Add(_Animation1_Y1);
            _Storyboard.Children.Add(_Animation1_X2);
            _Storyboard.Children.Add(_Animation1_Y2);

            _Storyboard.Children.Add(_Animation2_X1);
            _Storyboard.Children.Add(_Animation2_Y1);
            _Storyboard.Children.Add(_Animation2_X2);
            _Storyboard.Children.Add(_Animation2_Y2);

            _Storyboard.Children.Add(_Animation3_X1);
            _Storyboard.Children.Add(_Animation3_Y1);
            _Storyboard.Children.Add(_Animation3_X2);
            _Storyboard.Children.Add(_Animation3_Y2);

            _Storyboard.Completed += _Storyboard_Completed;
            Storyboard.SetTarget(_Animation1_X1, this._Line1);
            Storyboard.SetTargetProperty(_Animation1_X1, "X1");
            Storyboard.SetTarget(_Animation1_Y1, this._Line1);
            Storyboard.SetTargetProperty(_Animation1_Y1, "Y1");
            Storyboard.SetTarget(_Animation1_X2, this._Line1);
            Storyboard.SetTargetProperty(_Animation1_X2, "X2");
            Storyboard.SetTarget(_Animation1_Y2, this._Line1);
            Storyboard.SetTargetProperty(_Animation1_Y2, "Y2");

            Storyboard.SetTarget(_Animation2_X1, this._Line2);
            Storyboard.SetTargetProperty(_Animation2_X1, "X1");
            Storyboard.SetTarget(_Animation2_Y1, this._Line2);
            Storyboard.SetTargetProperty(_Animation2_Y1, "Y1");
            Storyboard.SetTarget(_Animation2_X2, this._Line2);
            Storyboard.SetTargetProperty(_Animation2_X2, "X2");
            Storyboard.SetTarget(_Animation2_Y2, this._Line2);
            Storyboard.SetTargetProperty(_Animation2_Y2, "Y2");

            Storyboard.SetTarget(_Animation3_X1, this._Line3);
            Storyboard.SetTargetProperty(_Animation3_X1, "X1");
            Storyboard.SetTarget(_Animation3_Y1, this._Line3);
            Storyboard.SetTargetProperty(_Animation3_Y1, "Y1");
            Storyboard.SetTarget(_Animation3_X2, this._Line3);
            Storyboard.SetTargetProperty(_Animation3_X2, "X2");
            Storyboard.SetTarget(_Animation3_Y2, this._Line3);
            Storyboard.SetTargetProperty(_Animation3_Y2, "Y2");
            _Storyboard.Begin();
        }

        private void _Storyboard_Completed(object sender, object e)
        {
            Vector2 vector1 = new Vector2((float)_Line1.X1, (float)_Line1.Y1) - new Vector2((float)_ShowInCanvas.ActualWidth / 2, (float)_ShowInCanvas.ActualHeight);
            Vector2 vector2 = _TargetPoint.ToVector2() - new Vector2((float)_ShowInCanvas.ActualWidth / 2, (float)_ShowInCanvas.ActualHeight);
            if (vector2.Length() - vector1.Length() < 12 || vector1.Length() >= vector2.Length())
            {
                _Storyboard.Stop();
                _TargetCircle.Hide();
                _ShowInCanvas.Children.Remove(_Line1);
                _ShowInCanvas.Children.Remove(_Line2);
                _ShowInCanvas.Children.Remove(_Line3);
                Boom();
            }
            else
            {
                _dVector.X= _dVector.X * 1.1F;
                _dVector.Y = _dVector.Y * 1.1F;
                _Animation1_X1.From = _Line1.X1;
                _Animation1_X1.To = _Line1.X1 + _dVector.X;
                _Animation1_Y1.From = _Line1.Y1;
                _Animation1_Y1.To = _Line1.Y1 + _dVector.Y;

                _Animation1_X2.From = _Line1.X2;
                _Animation1_X2.To = _Line1.X2 + _dVector.X;
                _Animation1_Y2.From = _Line1.Y2;
                _Animation1_Y2.To = _Line1.Y2 + _dVector.Y;

                _Animation2_X1.From = _Line2.X1;
                _Animation2_X1.To = _Line2.X1 + _dVector.X;
                _Animation2_Y1.From = _Line2.Y1;
                _Animation2_Y1.To = _Line2.Y1 + _dVector.Y;

                _Animation2_X2.From = _Line2.X2;
                _Animation2_X2.To = _Line2.X2 + _dVector.X;
                _Animation2_Y2.From = _Line2.Y2;
                _Animation2_Y2.To = _Line2.Y2 + _dVector.Y;

                _Animation3_X1.From = _Line3.X1;
                _Animation3_X1.To = _Line3.X1 + _dVector.X;
                _Animation3_Y1.From = _Line3.Y1;
                _Animation3_Y1.To = _Line3.Y1 + _dVector.Y;

                _Animation3_X2.From = _Line3.X2;
                _Animation3_X2.To = _Line3.X2 + _dVector.X;
                _Animation3_Y2.From = _Line3.Y2;
                _Animation3_Y2.To = _Line3.Y2 + _dVector.Y;

                _Storyboard.Begin();

            }
        }
        protected virtual void OnBoom()
        {
            List<Fire> fires = new List<Fire>();
            Random rnd = new Random();
            for (int i = 0; i <= 36; i++)
            {
                Fire fire = new Fire(_TargetPoint, _ShowInCanvas);
                fire.Rate = fire.Rate + rnd.Next(-2, 3);
                fire.Degree = i * 10 + rnd.Next(-2, 2);
                fire.Color = this.Color;
                fires.Add(fire);
            }
            for (int i = 0; i < fires.Count; i++)
            {
                fires[i].Fly();
            }
        }
        public void Boom()
        {
            OnBoom();
        }

    }
}
