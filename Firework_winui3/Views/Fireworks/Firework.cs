using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Input;
using Windows.Foundation;
using Windows.UI;

namespace Firework_winui3.Views.Fireworks;
internal class Firework
{
    public class Drawline
    {
        public Vector2 PointStart;
        public Vector2 PointEnd;
        public Color Color;
        public Size size;
    }
    public class DrawCircle
    {
        public Vector2 PointCenter;
        public float Radius;
        public Color Color;
    }
    public class Firework1
    {
        public Point PointStart;//起始坐标
        public Point PointEnd;//终点坐标
        public double RadianAngle;//发射角度 从左侧开始0-180
        public Color Color;//烟花颜色
        public double FlyDistance;//实时飞翔距离
        public double MaxFlyDistance;//最大飞翔距离
        public double BoomRadius;//爆炸半径
        public bool IsBoom;//是否可爆炸
        public double Flyspeed;//飞翔速度
        public double BoomSpeed;//爆炸速度
        public Size Size;//烟花尺寸

    }
}
