using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex
{
    class Calcbase
    {
       public double current, firstnum , secondnum,result,memory=0;
        public bool prov = true;
        
        public string operation = " ",one_operation="" ;
        public void calculate()
        {
            switch (operation)
            {

                case "+":
                   result  = firstnum + secondnum;
                    break;
                case "-":
                    result  = firstnum - secondnum;
                    break;
                case "*":
                    result  = firstnum * secondnum;
                    break;
                case "÷":
                    if (secondnum != 0)
                        result = firstnum / secondnum;
                    else MessageBox.Show("ERROR"+"\n"+"Denominator can't be 0");
                    break;
                case "x^y":
                    result = Math.Pow(firstnum, secondnum);
                    break;
                case "x^1/y":
                    if (secondnum != 0)
                        result = Math.Pow(firstnum, 1 / secondnum);
                    else MessageBox.Show("ERROR" + "\n" + "Denominator can't be 0");
                    break;
            }
        }
        public void num_one_function()
        {
           
            switch (one_operation)
            {
                case "√":
                    if (current >= 0)
                        current = Math.Sqrt(current);
                    else
                    {
                        MessageBox.Show("ERROR"+"\n"+"only for x>=0");
                        current *= -1;
                    }
                    break;
                case "%":
                    current  =current / 100;
                    break;
                case " x²":
                    
                        current *= current;
                    
                    break;
                case "1/x":
                    if(current!=0)
                    current = 1 / current; 
                    else MessageBox.Show("ERROR" + "\n" + "Denominator can't be 0");
                    break;
                case "10^x":
                    current = Math.Pow(10, current);
                    break;
                case "exp":
                    current = Math.Exp( current);
                    break;
                case "logx":
                    if (current> 0)
                        current = Math.Log10(current);
                    else MessageBox.Show("ERROR" + "\n" + "only for x>0");
                    break;
                case "mod":
                    current = Math.Abs(current);
                    break;
                case "!":
                    if (!current.ToString().Contains(',') && !current.ToString().Contains('-'))
                    {
                        for (int i = (int)current - 1; i > 1; i--)
                        {
                            current *= i;
                        }

                    }
                    else MessageBox.Show("ERROR"+"\n"+"Only integer numbers more than 0");
                    break;
                case "sinx":
                    current = Math.Sin(current * Math.PI / 180);
                    break;
                case "cosx":
                    current  = Math.Cos(current * Math.PI / 180);
                    break;
                case "tgx":
                    current = Math.Tan(current * Math.PI / 180);
                    break;
            }
        }
    }
}
