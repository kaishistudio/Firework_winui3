using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace Firework_winui3.Views.Fireworks
{
    public class DrawFunction
    {
        public static double JuLi(Point p1, Point p2)//计算两点之间的距离
        {
            return Math.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
        }
        public static double Jiao(Point p1, Point p2)//计算任意线段与X轴角，弧度
        {
            double jiao = 0.0;
            if (p1.X == p2.X && p1.Y < p2.Y)
            {
                jiao = Math.PI / 2;
            }
            else if (p1.X == p2.X && p1.Y > p2.Y)
            {
                jiao = 3 * Math.PI / 2;
            }
            else if (p1.X < p2.X && p1.Y == p2.Y)
            {
                jiao = 0;
            }
            else if (p1.X > p2.X && p1.Y == p2.Y)
            {
                jiao = Math.PI;
            }
            else if (p1.X < p2.X && p1.Y < p2.Y)
            {
                jiao = Math.Atan((p2.Y - p1.Y) / (p2.X - p1.X));
            }
            else if (p1.X > p2.X && p1.Y < p2.Y)
            {
                jiao = Math.PI - Math.Atan((p2.Y - p1.Y) / (p1.X - p2.X));
            }
            else if (p1.X > p2.X && p1.Y > p2.Y)
            {
                jiao = Math.PI + Math.Atan((p2.Y - p1.Y) / (p2.X - p1.X));
            }
            else if (p1.X < p2.X && p1.Y > p2.Y)
            {
                jiao = 2 * Math.PI - Math.Atan((p1.Y - p2.Y) / (p2.X - p1.X));
            }
            return jiao;
        }
        public static double Jiao_LineToLine(Point Op, Point p1, Point p2, double FangXiang) //返回角度的绝对值，FangXiang=1 顺时针，FangXiang=-1 逆时针
        {
            double result = 0;
            double r = DrawFunction.JuLi(Op, p1);//弧
            double thita1 = DrawFunction.Jiao(Op, p1);
            double thita2 = DrawFunction.Jiao(Op, p2);
            switch (FangXiang)
            {
                case 1:
                    if (thita1 <= thita2)
                    {
                        result = Math.Round(((thita2 - thita1) * (180.0 / Math.PI)), 2);
                    }
                    else if (thita1 > thita2)
                    {
                        result = Math.Round(((thita2 - (thita1 - 2 * Math.PI)) * (180.0 / Math.PI)), 2);
                    }
                    break;
                case -1:
                    if (thita1 >= thita2)
                    {

                        result = Math.Round(((thita1 - thita2) * (180.0 / Math.PI)), 2);
                    }
                    else if (thita1 < thita2)
                    {

                        result = Math.Round(((thita1 + 2 * Math.PI - thita2) * (180.0 / Math.PI)), 2);
                    }
                    break;
            }
            return result;
        }
        public static Point XuanZhuan(Point Op, Point point, double ZhuanJiao)//将p2以p1为圆心旋转ZhuanJiao弧度
        {
            double r;
            double thita1;
            double thita2;
            if (ZhuanJiao == 0)
            {
                return new Point(point.X, point.Y);
            }
            else
            {
                Point result = new Point();
                thita1 = Jiao(Op, point);
                thita2 = ZhuanJiao;
                r = JuLi(Op, point);
                result.X = Math.Cos(thita1 + thita2) * r + Op.X;
                result.Y = Math.Sin(thita1 + thita2) * r + Op.Y;
                return result;

            }
        }

        public static double Juli_Point_To_Line(Point Op, Point p1, Point p2) //Op到向量（p1，p2）的距离
        {
            double thita1 = DrawFunction.Jiao(p1, Op);
            double thita2 = DrawFunction.Jiao(p1, p2);
            double thita = Math.Abs(thita1 - thita2);
            return Math.Abs(Math.Sin(thita) * DrawFunction.JuLi(p1, Op));
        }
    }
}
