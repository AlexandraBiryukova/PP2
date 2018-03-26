using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            timer1.Start();
            timer2.Start();
        }
       
        int sp=300,//стрелка и корабль
            x = 7,//звезды
            yy=45,//астероиды
            xx=55;
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {            
            Point[] ship ={
                new Point(sp, 300),
                new Point(sp-30, 310),
                new Point(sp-30, 330),
                new Point(sp, 340),
                new Point(sp+30, 330),
                new Point(sp+30, 310)
            };
            Point[] str ={
                new Point(sp,305),
            new Point(sp-10, 320),
            new Point(sp-5,320),
            new Point(sp-5,330),
            new Point(sp+5,330),
            new Point(sp+5,320),
            new Point(sp+10,320)

            };
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, 0, 0, Width, Height);
            b = new SolidBrush(Color.White);
                g.FillEllipse(b, 10, 30, x, x);
                g.FillEllipse(b, 100, 180, x, x);
                g.FillEllipse(b, 230, 80, x, x);
                g.FillEllipse(b, 330, 150, x, x);
                g.FillEllipse(b, 520, 50, x, x);
                g.FillEllipse(b, 60, 280, x, x);
                g.FillEllipse(b, 180, 250, x, x);
                g.FillEllipse(b, 280, 320, x, x);
                g.FillEllipse(b, 400, 280, x, x);
                g.FillEllipse(b, 480, 220, x, x);
            // b = new SolidBrush(Color.Blue);
            PathGradientBrush p = new PathGradientBrush(ship);
            p.CenterColor = Color.FromArgb(255, 0, 255, 255);
            Color[] colors = { Color.FromArgb(255, 0, 0, 255) };
            p.SurroundColors = colors;
            g.FillPolygon(p, ship);

            b = new SolidBrush(Color.Yellow);
            g.FillPolygon(b, str);
            b = new SolidBrush(Color.Red);
            
          
            xx = 55;
            for (int i = 0; i < 4; i++)
            {
                Point[] tr =
                 {
                new Point(xx,yy),
            new Point(xx-20,yy+30),
            new Point(xx+20,yy+30)
            };
                Point[] tr1 =
                {
                new Point(xx,yy+40),
                new Point(xx-20,yy+10),
                new Point(xx+20,yy+10)
            };
                g.FillPolygon(b, tr);
                g.FillPolygon(b, tr1);
                    xx +=140;
            }

        }
        int w = 290;
        private void timer3_Tick(object sender, EventArgs e)
        {
            
            g.FillEllipse(Brushes.Yellow, sp - 5, w, 10, 10);
            w -= 10;
            Refresh();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (x == 7)
                x = 5;
            else x = 7;
           
            Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (sp - 30 > 0)
                        sp -= 10;
                    break;
                case Keys.D:
                    if (sp + 50 < Width)
                        sp += 10;
                    break;
                case Keys.Space:

                    timer3.Start();
                    break;
                    
            }
            Refresh();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            yy += 5;
            if (yy + 5 > Height)
            {
                yy = new Random().Next(0, 50);
                
            }
            Refresh();
        }
    }
}
