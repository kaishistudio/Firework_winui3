using Microsoft.UI.Xaml.Controls;

namespace Firework_winui3.Views.Fireworks
{
    public class MainFire_2:MainFire
    {
        public MainFire_2(Canvas canvas, TargetCircle targetCircle) : base(canvas, targetCircle)
        {

        }
        protected override void OnBoom()
        {
            List<Fire> fires = new List<Fire>();
            Fire fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 0;
            fire.Rate = fire.Rate;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 10;
            fire.Rate = fire.Rate * 0.95;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 20;
            fire.Rate = fire.Rate * 0.95;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 30;
            fire.Rate = fire.Rate * 0.95;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 40;
            fire.Rate = fire.Rate * 0.95;
            fires.Add(fire);


            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 50;
            fire.Rate = fire.Rate * 0.95;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 60;
            fire.Rate = fire.Rate * 0.98;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 70;
            fire.Rate = fire.Rate;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 80;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 90;
            fire.Rate = fire.Rate * 1.11;
            fires.Add(fire);

            


            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 270;
            fire.Rate = fire.Rate * 0.9;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 280;
            fire.Rate = fire.Rate * 1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 290;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 300;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 310;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 320;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 330;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 340;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 350;
            fire.Rate = fire.Rate * 1.05;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 95;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 85;
            fire.Rate = fire.Rate * 1.1;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 75;
            fire.Rate = fire.Rate * 1.15;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 70;
            fire.Rate = fire.Rate * 1.15;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 65;
            fire.Rate = fire.Rate * 1.2;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 60;
            fire.Rate = fire.Rate * 1.25;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 55;
            fire.Rate = fire.Rate * 1.25;
            fires.Add(fire);

            fire = new Fire(_TargetPoint, _ShowInCanvas);
            fire.Color = this.Color;
            fire.Degree = 50;
            fire.Rate = fire.Rate * 1.3;
            fires.Add(fire);

            for (int i = 0; i < fires.Count; i++)
            {
                fires[i].Fly();
            }
        }
    }

}
