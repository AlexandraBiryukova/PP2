using System;

namespace Point
{
    class Point {
        public int x;
        public int y;
        public string c;

        public override string ToString()
        {
            return "Point "+c+"("+x+","+y+")";
        }
        public Point(int a,int b,string ch){
            x = a;
            y = b;
            c = ch;
        }
        public Point(){
            x = 0;
            y = 0;
            c = "O";
        }

    }   
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine() );
            string c = Console.ReadLine();
            Point bb = new Point();
            Console.WriteLine(bb.ToString());
            Point aa = new Point(a,b,c);
            Console.WriteLine(aa.ToString() );
            Console.ReadKey();
        }
    }
}
