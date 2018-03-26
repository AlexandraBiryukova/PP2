using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        int x = 0, y = 0;
        int kx = -1, ky = -1;
     
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button b = new Button();
                    b.Click += but_click;
                    b.Location = new Point(x, y);
                    b.Size = new Size(50, 50);
                    b.BackColor = Color.Gray;
                    b.Name = (i * 10 + j).ToString();
                    Controls.Add(b);
                    x += 55;
                }
                x = 0;
                y += 55;
            }
            
        }
           
            private void but_click(object sender, EventArgs e)
            {
            Button b = sender as Button;
              kx = int.Parse(b.Name) / 10;
              ky = int.Parse(b.Name) % 10;
            foreach(Button s in Controls)
            {
                if(int.Parse(s.Name)/10==kx||int.Parse(s.Name)%10==ky)
                s.BackColor = Color.Red;
                else s.BackColor = Color.Gray;
            }
           

            
            

            }

       
    }
    }

