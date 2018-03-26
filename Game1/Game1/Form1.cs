using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{

    public partial class Form1 : Form
    {
        public int sc = 0;
        public Form1()
        {


            InitializeComponent();
            timer1.Start();
        }

        bool game = true;
        private void gameover(Label l)
        {
            if (l.Location.X+l.Width > button1.Location.X && l.Location.X <= button1.Location.X + button1.Width && l.Location.Y+l.Height > button1.Location.Y && l.Location.Y <= button1.Location.Y + button1.Height)
                game = false;
        }
        private void setrandom()
        {
            Point p1 = new Point();
            p1.X = new Random().Next(0, 51);
            p1.Y = new Random().Next(0, 30);
            Point p2 = new Point();
            p2.X = new Random().Next(73, 124);
            p2.Y = new Random().Next(70, 90);
            Point p3 = new Point();
            p3.X = new Random().Next(146, 197);
            p3.Y = new Random().Next(20, 40);
            Point p4 = new Point();
            p4.X = new Random().Next(219, 270);
            p4.Y = new Random().Next(0, 10);
            Point p5 = new Point();
            p5.X = new Random().Next(292, 343);
            p5.Y = new Random().Next(40, 60);
            label1.Location = p1;
            label2.Location = p2;
            label3.Location = p3;
            label4.Location = p4;
            label5.Location = p5;


        }
        private void timer1_Tick(object sender, EventArgs e)
        {

           
            if (label1.Location.Y + 10 > Height)
            {

                sc += 10;
                label6.Text = "Score: " + sc.ToString();
                setrandom();
            }
            label1.Location = new Point(label1.Location.X, label1.Location.Y + 10);
            label2.Location = new Point(label2.Location.X, label2.Location.Y + 10);
            label3.Location = new Point(label3.Location.X, label3.Location.Y + 10);
            label4.Location = new Point(label4.Location.X, label4.Location.Y + 10);
            label5.Location = new Point(label5.Location.X, label5.Location.Y + 10);
                gameover(label1);
                gameover(label2);
                gameover(label3);
                gameover(label4);
                gameover(label5);

        
            if (game == false)
            {
                timer1.Stop();
                label7.Visible = true;
               
                button1.Text = "new";
               
            }



}

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game != false)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        if(button1.Location.X-10>=0)
                        button1.Location = new Point(button1.Location.X - 10, button1.Location.Y);
                        
                        break;
                    case Keys.D:
                        if (button1.Location.X + 10+button1.Width  <=372) 
                        button1.Location = new Point(button1.Location.X + 10, button1.Location.Y);
                        break;
                }
                gameover(label1);
                gameover(label2);
                gameover(label3);
                gameover(label4);
                gameover(label5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "Score: 0";
            sc = 0;
            label7.Visible = false;
            timer1.Start();
            setrandom();
            
            game = true;
            button1.Text = "";
        }
    }
}
