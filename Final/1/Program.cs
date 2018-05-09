using System;

namespace Application
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int chc=0, cnt = 0;
           string s= Console.ReadLine();
            string[] a = s.Split(' ');
            if (a.Length == 1)
                Console.WriteLine(1);
            else
            Console.WriteLine(a.Length);
            
            for (int i = 0; i < a.Length;i++){
                int f = a[i].Length - 1;
                for (int j = 0; j < a[i].Length / 2; j++)
                {
                    if (a[i][j] == a[i][f])
                    {
                        chc++;
                        f--;
                    }

                        if (chc == a[i].Length / 2||a[i].Length==1)
                            cnt++;
                    
                    
                }
                chc = 0;
            }
            Console.WriteLine(cnt); 
            Console.ReadKey(); 
        }
    }
}
