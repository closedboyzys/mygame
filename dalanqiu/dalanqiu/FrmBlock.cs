using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dalanqiu
{
    public partial class FrmBlock : Form
    {
        int z = 1;
        int cc = 0;
        int m;int  n=0;//m为发球时x值   n为总得分
        public FrmBlock()
        {
            InitializeComponent();
        }
        //显示背景图
        Bitmap bmpBackground;
        Bitmap bmplan;
        private void LoadPictures()
        {
            bmpBackground = LoadBitmap.LoadBmp("Background");
            bmplan = LoadBitmap.LoadBmp("lan");
            Bitmap bmpBreak = LoadBitmap.LoadBmp("man");
            bmpPaddle = bmpBreak.Clone(GamePaddleRect, bmpBreak.PixelFormat);
            Bitmap bmpBreak1 = LoadBitmap.LoadBmp("ball");
            bmpBall = bmpBreak1.Clone(GameBallRect, bmpBreak1.PixelFormat);
        }
        private void FrmBlock_Load(object sender, EventArgs e)
        {
            this.LoadPictures();
            centerOfPaddle.X = this.ClientRectangle.Width / 2;
            centerOfPaddle.Y = this.ClientRectangle.Height - 30;

            /*BallClass.BallRect = new Rectangle(centerOfPaddle.X
                - 36 / 2+65, centerOfPaddle.Y - 120, 60, 60);
            BallClass.BallDirection = new Vector2(1.0f, -1.0f);
            this.TimerRefreshScreen.Start();*/
        }
        private void DrawGame(Graphics graphic)
        {
            graphic.DrawImage(bmpBackground, new Rectangle(0, 0,
                this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
            graphic.DrawString("时间:"+n,new Font("Arial Black",24),new SolidBrush(Color.White),new Point(5,5));
                      
            if (z == 1)
            {
                graphic.DrawImage(bmpBall, new Rectangle(
                centerOfPaddle.X - 93 / 2+65, centerOfPaddle.Y-120, 60, 60));
                k = 6;l = 4.5;
            }
            if (z == 0)
            {
                graphic.DrawImage(bmpBall, BallClass.BallRect);
            }
            graphic.DrawImage(bmpPaddle, new Rectangle(centerOfPaddle.X - 93 / 2,
                    centerOfPaddle.Y - 120, 93, 100));
                graphic.DrawImage(bmplan, new Rectangle(700, 100,
                this.ClientRectangle.Width/8, this.ClientRectangle.Height/6));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bufferBmp = new Bitmap(this.ClientRectangle.Width - 1,
                this.ClientRectangle.Height - 1);
            Graphics g = Graphics.FromImage(bufferBmp);
            this.DrawGame(g);
            e.Graphics.DrawImage(bufferBmp, 0, 0);
            g.Dispose();
            base.OnPaint(e);
        }
        //jia zai ren lan kuang 
        static readonly Rectangle GamePaddleRect = new Rectangle(0,0,300,450);
        Bitmap bmpPaddle;
        Point centerOfPaddle;

        private void FrmBlock_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void FrmBlock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Keys.A.ToString()|| e.KeyChar.ToString() == Keys.Left.ToString())
            {
                if (centerOfPaddle.X > 50)
                {
                    centerOfPaddle.X = centerOfPaddle.X - 10;
                }
            }
            if (e.KeyChar.ToString() == Keys.D.ToString())
            {
                if (centerOfPaddle.X < 750)
                {
                    centerOfPaddle.X = centerOfPaddle.X + 10;
                }
            }
            if (e.KeyChar.ToString() == Keys.S.ToString())
            {
                z = 1;
            }
            this.Invalidate();
        }
        //篮球显示与运动
        static readonly Rectangle GameBallRect = new Rectangle(35, 35, 450, 450);
        Bitmap bmpBall;
        double k = 6, l = 4;
        private void TimerRefreshScreen_Tick(object sender, EventArgs e)//时间
        {
            //double k = 8, l = 6;
            if (k > 0)
            {
                BallClass.BallRect.X += (int)(BallClass.BallDirection.X * k);
                BallClass.BallRect.Y += (int)(BallClass.BallDirection.Y * l);
                k = k - 0.01;
                IsHit();
                IsKill();
                IsWin();
                if (z == 1)
                {
                    this.Invalidate();
                }
            }
            if (l > 0)
            {
                BallClass.BallRect.X += (int)(BallClass.BallDirection.X * k);
                BallClass.BallRect.Y += (int)(BallClass.BallDirection.Y * l);
                if (BallClass.BallDirection.Y > 0)
                {
                    l = l + 0.05;
                }
                else
                    l = l - 0.075;
                IsHit();
                IsKill();
                IsWin();
                /*if (z == 1)
                {
                    this.TimerRefreshScreen.Stop();
                    this.Invalidate();
                }*/
            }
            if (l <=0)
            {
                if(BallClass.BallRect.Y< centerOfPaddle.Y - 40)
                {
                    BallClass.BallDirection.Y = -BallClass.BallDirection.Y;
                    l = l + 0.05;
                    IsWin();
                }
            }
                this.Invalidate();
        }
        private bool IsHit()
        {
            if (BallClass.BallRect.X <= 3)
            {
                BallClass.BallDirection.X = -BallClass.BallDirection.X;
                return true;
            }
            if (BallClass.BallRect.X >= this.ClientRectangle.Width - 130)
            {
                BallClass.BallDirection.X = -BallClass.BallDirection.X;
                return true;
            }
            if (BallClass.BallRect.Y <= 3)
            {
                BallClass.BallDirection.Y = -BallClass.BallDirection.Y;
                return true;
            }
            if (BallClass.BallRect.Y >= this.ClientRectangle.Height-100)
            {
                BallClass.BallDirection.Y = -BallClass.BallDirection.Y;
                return true;
            }
            //centerOfPaddle.X - 93 / 2+65, centerOfPaddle.Y-120, 60, 60
            if (BallClass.BallRect.X> centerOfPaddle.X - 93 / 2 + 45&& BallClass.BallRect.X < centerOfPaddle.X - 93 / 2 + 85
                && BallClass.BallRect.Y< centerOfPaddle.Y - 50&& BallClass.BallRect.Y> centerOfPaddle.Y - 130)
            {
                if (cc == 0)
                {
                    cc = 1;
                    BallClass.BallRect.Y = BallClass.BallRect.Y + 21;
                }
                if (cc == 1)
                {
                    z = 1;
                }
                return true;
            }
            return false;
        }

        int zzz = 0;
        int aaa, bbb;
        private void FrmBlock_MouseDown(object sender, MouseEventArgs e)
        {
            zzz = 1;
        }

        /*private void FrmBlock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }*/

        private void FrmBlock_MouseUp(object sender, MouseEventArgs e)
        {
            if (z == 1)
            {
                zzz = 0;
                z = 0;
                double a, b, c;
                BallClass.BallRect = new Rectangle(centerOfPaddle.X
                    - 36 / 2 + 65, centerOfPaddle.Y - 120, 60, 60);
                /*if ((centerOfPaddle.X - 93 / 2 + 90 - e.X) == 0) { a = 0; }
                else
                    a = System.Math.Abs(centerOfPaddle.X - 93 / 2 + 90 - e.X) / (centerOfPaddle.X - 93 / 2 + 90 - e.X);
                if ((e.Y - centerOfPaddle.Y + 90) == 0) { b = 0; c = 0; }
                else
                {
                    b = -System.Math.Abs(e.Y - centerOfPaddle.Y + 90) / (e.Y - centerOfPaddle.Y + 90);
                    c = System.Math.Abs(centerOfPaddle.X - 93 / 2 + 90 - e.X) / (e.Y - centerOfPaddle.Y + 90);
                }*/
                a = (float)((centerOfPaddle.X - 93 / 2 + 90 - e.X)) / 50;
                b = (double)((e.Y - centerOfPaddle.Y + 90)) / 50;
                BallClass.BallDirection = new Vector2(a, -b);
                this.TimerRefreshScreen.Start();
            }
        }

        private void FrmBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (zzz == 1)
            {
                Graphics g = this.CreateGraphics();
                Pen pen1 = new Pen(Color.Red);
                g.DrawLine(pen1, centerOfPaddle.X - 93 / 2 + 90, centerOfPaddle.Y - 90,e.X,e.Y );
            }
        }
        private bool IsKill()
        {//篮筐位置(700, 100,this.ClientRectangle.Width / 8, this.ClientRectangle.Height / 6)
            //球 信息：centerOfPaddle.X - 93 / 2+65, centerOfPaddle.Y-120, 60, 60
            //BallClass.BallRect
            if (System.Math.Sqrt((BallClass.BallRect.X-700)* (BallClass.BallRect.X - 700) +(BallClass.BallRect.Y-100)* (BallClass.BallRect.Y - 100)) <= 50&&
                BallClass.BallRect.X<700&&BallClass.BallRect.Y<80)
            {
                BallClass.BallDirection.X = -1 * BallClass.BallDirection.X;
                BallClass.BallDirection.Y = -1 * BallClass.BallDirection.Y;
                return true;
            }
            return false;
        }
        private bool IsWin()
        {
            if (BallClass.BallDirection.Y > 0 && BallClass.BallRect.X > 620 && BallClass.BallRect.Y == 90) ;
            {
                n++;
                return true ;
            }
            return false;
        }
    }

}
class LoadBitmap       //bei jing
{
    public static Bitmap LoadBmp(string bmpFileName)
    {
        return new Bitmap(Application.StartupPath
            + "\\GamePictures\\" + bmpFileName + ".bmp");
    }
}
class Vector2 {                         //蓝球显示与运动
    private double x, y;
    public Vector2() { }
    public Vector2(double setX, double setY)
    {
        x = setX;y = setY;
    }
    public double X {
        get { return x; }
        set { x = value; }
    }
    public double Y
    {
        get { return y; }
        set { y = value; }
    }
    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }
    public static Vector2 operator -(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
    }
    public static double operator *(Vector2 v1, Vector2 v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }
    public static Vector2 operator *(Vector2 v, float f)
    {
        return new Vector2(f * v.X, f * v.Y);
    }
    public float Moudle()
    {
        return (float)(Math.Sqrt(x * x + y * y));
    }
}
class BallClass
{
    public static Rectangle BallRect;
    public static Vector2 BallDirection;
}
