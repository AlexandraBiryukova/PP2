using System;
using System.IO;
namespace lab2
{
    class MainClass
    {
        public static bool IsPrime(int a)
        {
            if (a == 1)
                return false;
            for (int i = 2; i * i <= a; i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
        
        public static void Main(string[] args)
        {
            int mini=-1,k=-1,p=-1;
            //string line = File.ReadAllText (@"/Users/alexandra/Documents/LAB1/lab2/example.txt");
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab2/example.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string a = sr.ReadLine();
            string[] arr = a.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                    if (IsPrime(int.Parse(arr[i])) == true)
                    {
                        k = i;
                        mini = int.Parse(arr[i]);
                        break;
                    }

            }
            sr.Close();
            fs.Close(); 
            if (k != -1)
            {
                
                for (int i = k; i < arr.Length; i++)
                {
                    
                        if (IsPrime(int.Parse(arr[i])) == true && mini > int.Parse(arr[i]))
                        {
                            mini = int.Parse(arr[i]);
                            p = i;
                        }
                }
              

                    //File.WriteAllText(@"/Users/alexandra/Documents/LAB1/lab2/prime.txt", arr[p]);
                FileStream fw = new FileStream(@"/Users/alexandra/Documents/LAB1/lab2/prime.txt", FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fw);
                sw.WriteLine(arr[p]);
               Console.WriteLine(arr[p]); 
                sw.Close();
                fw.Close();
                Console.ReadKey();
            }

            
        }
    }
}
