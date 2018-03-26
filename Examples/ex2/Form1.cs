using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

        }

       

        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            g.FillEllipse(Brushes.Purple, e.Location.X - 20, e.Location.Y - 20, 40, 40);

        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            g.FillEllipse(Brushes.Blue, e.Location.X - 20, e.Location.Y - 20, 40, 40);

        }
    }
}
