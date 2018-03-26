using System;

namespace Circle
{
    class Circle
    {
        public int r;
        public int d;
        public double area;
        public double CR;

        public void FindArea(){
            area = Math.PI * r * r;
        }
        public void FindDia(){
            d = 2 * r;
        }
        public void FindCR(){
            CR = d * Math.PI;
        }
        public Circle(){
            r = 5;
        }
        public Circle(int a){
            r = a;
        }
        public override string ToString()
        {
            return "Circle with radius = "+r+ " has the diameter = " + d + " ,the area = " + area + " and circumference = " + CR;
        }
        
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Circle  a = new Circle();
           
            a.FindDia();
            a.FindArea(); 
            a.FindCR();
            Console.WriteLine(a);
            Circle b = new Circle (2);
            b.FindArea();
           
            b.FindDia(); 
            b.FindCR();
            Console.WriteLine(b);
            Console.ReadKey();

        }
    }
}
