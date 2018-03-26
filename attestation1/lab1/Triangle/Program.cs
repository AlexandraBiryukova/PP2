using System;

namespace Triangle
{
    class Triangle
    {
        int a, b, c, per;
        double area;
        double pper;
        public Triangle(){
            a=3;
            b=4;
            c=5;
            per = 12;
            area = 6;
        }
        public Triangle(int aa,int bb,int cc)
        {
            a = aa;
            b = bb;
            c = cc;
        }
        public void PER()
        {
            per = a + b + c;
        }
        public void PPER(){
            pper = per / 2;  
        }
        public void AREA()
        {
            area = Math.Sqrt(pper * (pper - a) * (pper - b) * (pper - c));
        }

        public override string ToString()
        {
            return "Triangle with sides: " + a + "," + b + "," + c + ", " + "has area = " + area + " and perimeter = " + per;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Triangle a = new Triangle ();
            a.PER();
            a.PPER();
            a.AREA(); 
            Console.WriteLine(a);
            Triangle b = new Triangle (3,4,5);
            Console.WriteLine(b);
            Console.ReadKey();

        }
    }


}
