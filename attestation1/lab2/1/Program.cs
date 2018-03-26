using System;
using System.IO;
using System.Collections.Generic;
namespace lab2
{
    class Program
    {
        

        static void Far(string path)
        {
            Stack<DirectoryInfo> s = new Stack<DirectoryInfo>();
            DirectoryInfo dir = new DirectoryInfo(path);
            s.Push(dir);
            foreach (FileInfo file in dir.GetFiles() ){
                Console.WriteLine(file.Name); 
            }
            while(s.Count >0){
          
                DirectoryInfo dirs = s.Pop();
                foreach(DirectoryInfo d in dirs.GetDirectories() ){
                    Console.Write(" "); 
                    Console.WriteLine(d.Name);
                    s.Push(d);
                
                    foreach(FileInfo f in d.GetFiles() ){
                            Console.Write("   ");
                        Console.WriteLine(f.Name);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Far(@"/Users/alexandra/Documents/PP1");
            Console.ReadKey();
        }
    }
}