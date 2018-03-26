using System;

namespace Rectangle
{
    class Rectangle
    {
        public int width;
        public int height;
        public int area;
        public int per;

        public Rectangle()
        {
            width = 1;
            height = 1;
        }

        public Rectangle(int a, int b)
        {
            width = a;
            height = b;
        }

        public Rectangle(int c)
        {
            width = 10;
            height = c;
        }
       
        public void fArea()
        {
            area = width * height;
        }

        public void fPer()
        {
            per = (width + height) * 2;
        }

        public override string ToString()
        {
            return width + "\n" + height + "\n" + area + "\n" + per;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Rectangle  a = new Rectangle ();
            a.fArea();
            a.fPer();

            Console.WriteLine(a);
            Rectangle  b = new Rectangle (4,5);
            b.fArea();
            b.fPer();  
            Console.WriteLine(b);
            Console.ReadKey();

        }
    }

}
