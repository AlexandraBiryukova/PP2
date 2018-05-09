using System;
using System.IO;
namespace Application
{
    class MainClass
    {
        static bool IsPrime(int a){
            if (a == 1)
                return true;
            
                for (int i = 2; i <= Math.Sqrt(a); i++)
                {
                    if (a % i == 0)
                        return false;
                    
                }
            return true;

            
        }
        public static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"/Users/alexandra/Documents/something");
            FileInfo[] f = d.GetFiles();
            for (int i = 0; i < f.Length;i++){
                if(f[i].FullName.Contains(".txt")){
                    FileStream fs = new FileStream(f[i].FullName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string a=sr.ReadToEnd();
                    string[] aa = a.Split(' ');
                    for (int j = 0; j < aa.Length;j++){
                        if (IsPrime(int.Parse(aa[j])) == true)
                        {
                            Console.WriteLine(f[i].Name);
                            break;
                        }
                    }
                    sr.Close();
                    fs.Close();
                }


            }
            Console.ReadKey(); 
        }
    }
}
