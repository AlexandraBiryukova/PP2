﻿using System;

namespace lab2
{
    class Complex{
       
        public int x;
        public int y;

        public Complex(){
            x = 1;
            y = 1;
        }
        public Complex(int a,int b){
            x = a;
            y = b;
        }
        public  int NOD(int a, int b)
        {
            if (b == 0)
                return a;
            return NOD(b, a % b);
        }
        public void Socr(){
            int n = NOD(x, y);
            x /= n;
            y /= n;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex n = new Complex();
            n.y = c2.y * c1.y;
            n.x = c1.x * n.y / c1.y + c2.x * n.y / c2.y;

            n.Socr();

            
            return n;
        }
        public override string ToString()
        {
            if (y != 1)
                return x + "/" + y;
            else return x+" ";
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Complex a = new Complex(int.Parse(Console.ReadLine()) , int.Parse(Console.ReadLine() ));
         Complex b = new Complex(int.Parse(Console.ReadLine() ),int.Parse(Console.ReadLine() ));
            Complex n = a + b;
            Console.WriteLine(a+"+"+b+"="+n);
            Console.ReadKey(); 
            
        }
    }
}
