using System;

namespace student
{
    class Student
    {
        public string name;
        public string sname;
        public int age;
        public double gpa;
        public string univ;

        public Student()
        {
            name = "Ivan";
            sname = "Ivanov";
            age = 18;
            gpa = 4;
            univ = "KBTU";
        }
        public Student( string a,string b,int f,double d, string u)
        {
            name = a;
            sname = b;
            age = f;
            gpa = d;
            univ = u;
        }
        public Student (string a, int b){
            name = a;
            age = b;
        }


        public override string ToString()
        {
            return sname + " " + name + " " + "(" + age + ")" + " with gpa = " + gpa+" from "+univ;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Student a = new Student();
            Console.WriteLine(a);
            Student b = new Student("Alexandra", 17);
            Console.WriteLine(b);
            Console.ReadKey();

        }
    }

}