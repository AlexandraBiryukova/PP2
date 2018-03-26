using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
      

        Calcbase s = new Calcbase();
        private void number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (label1.Text == "0" && btn.Text == "0")
                label1.Text = "0";
            else
            {
                if (label1.Text == "0"&&btn.Text!=",")
                    label1.Text = "";


                if (label1.Text.Contains(',') && btn.Text == ",")
                {
                    MessageBox.Show("ERROR");

                }
                else
                    label1.Text += btn.Text;
            }
            
        }
       private void Clear_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "CE":
                    label1.Text = "0";
                    break;
                case "C":
                    label1.Text = "0";
                    s.operation = "";
                    s.memory = 0;
                    break;
                case "«":
                    
                        if (label1.Text.Length != 1)
                            label1.Text = label1.Text.Remove(label1.Text.Length - 1, 1);
                        else label1.Text = "0";
                    
                    break;
            }
        }
        bool pr = true;
        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            s.operation = btn.Text;            
                pr = false;
                s.firstnum = double.Parse(label1.Text);
                label1.Text = "";           
        }
        private void one_operation_click(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            s.one_operation = btn.Text;
            s.current = double.Parse(label1.Text);
                s.num_one_function();
                label1.Text = s.current.ToString();
            if (pr != false)
                s.firstnum = s.current;
                
                
            

        }
        private void result_operation(object sender, EventArgs e)
        {
            if (s.operation != "")
            {
                if (label1.Text  == "")
                    s.secondnum = s.firstnum;
                else
                {
                    if (pr == false)
                    {
                       
                         s.secondnum = double.Parse(label1.Text);
                    }
                    
                }
                s.calculate();
                label1.Text = s.result.ToString();
                s.firstnum = s.result;
                pr = true;
                
                

                
            }
           
            
            
        }
    
    private   void znak(object sender, EventArgs e)
        {
            label1.Text = (double.Parse(label1.Text) * (-1)).ToString();
        }

        private void memory_working(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch(b.Text){
                case "MS":
                    s.memory = double.Parse(label1.Text);
                    break;
                case "MR":
                    label1.Text = s.memory.ToString();
                    break;
                case "MC":
                    s.memory = 0;
                    break;
                case "M+":
                    s.memory += double.Parse(label1.Text);
                    break;
                case "M-":
                    s.memory -= double.Parse(label1.Text);

                    break;
            }

        }

        
    }
    }

