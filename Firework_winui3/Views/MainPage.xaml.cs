
using System.Numerics;
using System.Reflection;
using Firework_winui3.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using SharpDX.WIC;
using Windows.Foundation;
using Windows.System.Power.Diagnostics;
using Windows.UI;
using static Firework_winui3.Views.Fireworks.Firework;

namespace Firework_winui3.Views;

public sealed partial class MainPage : Page
{
    List<Drawline> _ListFireLines = new();
    List<DrawCircle> _ListDrawCircles = new();
    List<Firework1> _ListFirework1 = new();
    DispatcherTimer _Timer = new DispatcherTimer();
    int _DrawIndex = 0;
    Random _rand = new Random();
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        _Timer.Interval = new TimeSpan(1);
        _Timer.Tick += _Timer_Tick;
        _Timer.Start();
        _DrawIndex = 1;
    }

    private void _Timer_Tick(object? sender, object e)
    {
        var i = 0;
        while (i < _ListFirework1.Count)
        {
            var l = _ListFirework1[i];
            if (l.FlyDistance <= l.MaxFlyDistance)
            {
                //空中飞翔时间
                _ListFireLines.Add(new Drawline()
                {
                    PointStart = new Vector2(
                        (float)(l.PointStart.X - l.FlyDistance * Math.Cos(GetAngle(l.RadianAngle))),
                        (float)(l.PointStart.Y - l.FlyDistance * Math.Sin(GetAngle(l.RadianAngle)))
                    ),
                    PointEnd = new Vector2(
                        (float)(l.PointStart.X - (l.FlyDistance + l.Size.Height) * Math.Cos(GetAngle(l.RadianAngle))),
                        (float)(l.PointStart.Y - (l.FlyDistance + l.Size.Height) * Math.Sin(GetAngle(l.RadianAngle)))
                    ),
                    Color = l.Color,
                    size = l.Size,
                });
                l.FlyDistance += l.IsBoom? l.Flyspeed:l.BoomSpeed;
                i++;
            }
            else
            {
                //爆炸时间
                if (l.IsBoom)
                {
                    for (var ii = 0; ii < 2000; ii++)
                    {
                        var p = GetBoomEndPoint(l.PointEnd,l.BoomRadius);
                        var firework1 = CreatFirework1(p, new Point(p.X,p.Y+30) , false, l.Color, new Size(1, 1));
                        _ListFirework1.Add(firework1);
                    }
                }
                _ListFirework1.RemoveAt(i);
            }

        }
        MainCanvas.Invalidate();
    }
    private void MainCanvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
    {
        switch (_DrawIndex)
        {
            case 0://清空画布
                break;
            case 1://绘制图形
                foreach (var l in _ListFireLines)
                {
                    args.DrawingSession.DrawLine(l.PointStart, l.PointEnd, l.Color, (float)l.size.Width);
                }
                _ListFireLines.Clear();
                foreach (var l in _ListDrawCircles)
                {
                    args.DrawingSession.DrawCircle(l.PointCenter, l.Radius, l.Color, 2);
                }
                _ListDrawCircles.Clear();
                break;
        }
    }
    private void MainCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        if (e.GetCurrentPoint(MainCanvas).Properties.IsLeftButtonPressed == true)
        {
            Point p1 = new Point(MainCanvas.ActualWidth / 2, MainCanvas.ActualHeight);
            Point p2 = e.GetCurrentPoint(MainCanvas).Position;
            var firework1 = CreatFirework1(p1, p2, true, Colors.Transparent, Size.Empty);
            _ListFirework1.Add(firework1);
            _ListDrawCircles.Add(new DrawCircle()
            {
                PointCenter = new Vector2((float)p2.X, (float)p2.Y),
                Radius = 5,
                Color = firework1.Color,
            });
            //Point point = e.GetCurrentPoint(canvas).Position;
            //Color color = RandomColor();
            //TargetCircle targetCircle = new TargetCircle(point);
            //targetCircle.Color = color;
            //targetCircle.Show(canvas);
            //MainFire mainFire = new MainFire(canvas, targetCircle);
            //mainFire.Color = color;
            //mainFire.Fly(point);
        }
        else if (e.GetCurrentPoint(MainCanvas).Properties.IsRightButtonPressed == true)
        {
            List<Point> list = new();
            Point point = e.GetCurrentPoint(MainCanvas).Position;
            list.Add(point);
            list.Add(new Point(point.X + 100, point.Y));
            list.Add(new Point(point.X + 200, point.Y));
            list.Add(new Point(point.X + 300, point.Y));
            foreach (var l in list)
            {
                Point p1 = new Point(MainCanvas.ActualWidth / 2, MainCanvas.ActualHeight);
                Point p2 = l;
                var firework1 = CreatFirework1(p1, p2, true, Colors.Transparent, Size.Empty);
                _ListFirework1.Add(firework1);
                _ListDrawCircles.Add(new DrawCircle()
                {
                    PointCenter = new Vector2((float)p2.X, (float)p2.Y),
                    Radius = 5,
                    Color = firework1.Color,
                });
                _ListDrawCircles.Add(new DrawCircle()
                {
                    PointCenter = new Vector2((float)p2.X, (float)p2.Y),
                    Radius = 5,
                    Color = firework1.Color,
                });
            }
            //#region
            //Point point = e.GetCurrentPoint(canvas).Position;
            //Color color = RandomColor();
            //TargetCircle targetCircle = new TargetCircle(point);
            //targetCircle.Color = color;
            //targetCircle.Show(canvas);
            //MainFire mainFire = new MainFire_2(canvas, targetCircle);
            //mainFire.Color = color;
            //mainFire.Fly(point);

            //point = new Point(e.GetCurrentPoint(canvas).Position.X + 180, e.GetCurrentPoint(canvas).Position.Y);
            //color = RandomColor();
            //targetCircle = new TargetCircle(point);
            //targetCircle.Color = color;
            //targetCircle.Show(canvas);
            //mainFire = new MainFire_0(canvas, targetCircle);
            //mainFire.Color = color;
            //mainFire.Fly(point);

            //point = new Point(e.GetCurrentPoint(canvas).Position.X + 320, e.GetCurrentPoint(canvas).Position.Y);
            //color = RandomColor();
            //targetCircle = new TargetCircle(point);
            //targetCircle.Color = color;
            //targetCircle.Show(canvas);
            //mainFire = new MainFire_2(canvas, targetCircle);
            //mainFire.Color = color;
            //mainFire.Fly(point);

            //point = new Point(e.GetCurrentPoint(canvas).Position.X + 460, e.GetCurrentPoint(canvas).Position.Y);
            //color = RandomColor();
            //targetCircle = new TargetCircle(point);
            //targetCircle.Color = color;
            //targetCircle.Show(canvas);
            //mainFire = new MainFire_3(canvas, targetCircle);
            //mainFire.Color = color;
            //mainFire.Fly(point);
            //#endregion
        }
    }
    Point GetBoomEndPoint(Point p1, double MaxBoomRadius)
    {
        var BoomRadius = _rand.Next(0, (int)MaxBoomRadius);
        var RadianAngle = _rand.Next(0,360);
        var x1 = p1.X;
        var y1 = p1.Y;
        double x2 = 0, y2 = 0;
        if (RadianAngle <= 90)
        {
            x2 = -Math.Cos(GetAngle(RadianAngle)) * BoomRadius + x1;
            y2 = Math.Sin(GetAngle(RadianAngle)) * BoomRadius + y1;
        }
        else if (RadianAngle <= 180)
        {
            x2 = Math.Sin(GetAngle(RadianAngle - 90)) * BoomRadius + x1;
            y2 = Math.Cos(GetAngle(RadianAngle - 90)) * BoomRadius + y1;
        }
        else if (RadianAngle <= 270)
        {
            x2 = Math.Cos(GetAngle(RadianAngle - 180)) * BoomRadius + x1;
            y2 = -Math.Sin(GetAngle(RadianAngle - 180)) * BoomRadius + y1;
        }
        else if (RadianAngle <= 360)
        {
            x2 = -Math.Sin(GetAngle(RadianAngle - 270)) * BoomRadius + x1;
            y2 = -Math.Cos(GetAngle(RadianAngle - 270)) * BoomRadius + y1;
        }
        return new Point(x2, y2);
    }
    Firework1 CreatFirework1(Point p1, Point p2, bool IsBoom, Color BoomColor, Size BoomSize)
    {
        var x1 = p1.X;
        var y1 = p1.Y;
        var x2 = p2.X;
        var y2 = p2.Y;
        var firework1 = new Firework1()
        {
            PointStart = p1,
            PointEnd = p2,
            RadianAngle = x2 <= x1
                             ? GetRadianAngle(Math.Atan((y1 - y2) / (x1 - x2)))
                             : 180 - GetRadianAngle(Math.Atan((y1 - y2) / (x2 - x1))),
            Color = IsBoom ?  RandomColor() :BoomColor,
            FlyDistance = 0,
            BoomRadius = _rand.Next(50,150),
            IsBoom = IsBoom,
            Flyspeed = 10,
            BoomSpeed = 50/(double)_rand.Next(1,100),
            Size = IsBoom ? new Size(_rand.Next(1, 3), _rand.Next(5, 20)) :BoomSize ,
        };
        firework1.MaxFlyDistance = GetDistance(p1, p2);
        firework1.BoomRadius = _rand.Next(50, 150);
        return firework1;
    }
    double GetAngle(double value)
    {
        return Math.PI / (180 / value);
    }
    double GetRadianAngle(double value)
    {
        return 180 * value / Math.PI;
    }
    double GetDistance(Point startPoint, Point endPoint)
    {
        var x = Math.Abs(endPoint.X - startPoint.X);
        var y = Math.Abs(endPoint.Y - startPoint.Y);
        return Math.Sqrt(x * x + y * y);
    }
    private Color RandomColor()
    {
        Color color = new Color();
        int iSeed = 10;
        Random ro = new Random(10);
        long tick = DateTime.Now.Ticks;
        Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

        int R = ran.Next(255);
        int G = ran.Next(255);
        int B = ran.Next(255);
        B = (R + G > 400) ? R + G - 400 : B;//0 : 380 - R - G;
        B = (B > 255) ? 255 : B;
        color = Color.FromArgb(255, (byte)R, (byte)G, (byte)B);
        return color;
    }


}
