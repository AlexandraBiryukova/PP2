using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 0, y = 0, cnt = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int h =0; h < 3; h++)
                {
                    Button b = new Button();
                    b.Size = new Size(100, 100);
                    b.Location = new Point(x, y);
                   b.Click += but_click;
                    b.Name = (i*3 + h).ToString();
                    b.Text = " ";
                    b.Font=new Font(FontFamily.GenericMonospace ,70);
                    x += 105;
                    
                    Controls.Add(b);
                }
                x = 0;
                y += 105;
            }
        }

        private void gameover(Button b)
        {
            if (cnt != 9)
            {
                int cnt1 = 0, cnt2 = 0, cnt3 = 0, cnt4 = 0;
                int a = int.Parse(b.Name) / 3;
                int aa = int.Parse(b.Name) % 3;
                foreach (Button c in Controls)
                {
                    if (int.Parse(c.Name) / 3 == a && c.Text == b.Text)
                        cnt1++;
                    if (int.Parse(c.Name) % 3 == aa && c.Text == b.Text)
                        cnt2++;
                    if (int.Parse(c.Name) % 4 == 0 && c.Text == b.Text)
                        cnt3++;
                    if (int.Parse(c.Name) % 2 == 0 && c.Name != "8" && c.Name!= "0"&& c.Text == b.Text)
                        cnt4++;



                }
                if (cnt1 == 3 || cnt2 == 3 || cnt3 == 3 || cnt4 == 3)
                {
                    MessageBox.Show(b.Text + " WINS");
                    foreach(Button q in Controls)
                    {
                        q.Enabled = true;
                        q.Text = "";
                        cnt = 0;
                    }
                }

            }
        }
        private void but_click(object sender, EventArgs e)
        {
            cnt++;
            Button b = sender as Button;
            if (cnt % 2 == 1)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            
            if (cnt == 9)
                MessageBox.Show("Game over" );
            
            gameover(b);
            
            

            

        }
    }
}
