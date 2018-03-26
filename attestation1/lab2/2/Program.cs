using System;
using System.IO;

namespace lab2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //string line = File.ReadAllText(@"/Users/alexandra/Documents/LAB1/lab2/example.txt");
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab2/example.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs); 
            string a = sr.ReadLine();
            sr.Close();
            fs.Close(); 
            string[] arr = a.Split(' ');
            int maxi = int.Parse(arr[0]);
            int mini = int.Parse(arr[0]);
            for (int i = 0; i < arr.Length; i++)
            {
                if (int.Parse(arr[i]) > maxi)
                    maxi = int.Parse(arr[i]);
                if (int.Parse(arr[i]) < mini)
                    mini = int.Parse(arr[i]);

            }
            Console.WriteLine("Максимум равен "+maxi);
            Console.WriteLine("Минимум равен "+ mini);
            Console.ReadKey();
        }
    }
}
