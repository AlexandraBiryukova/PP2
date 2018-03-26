using System;
using System.IO;
namespace FAR
{
    class FAR
    {
        static void ShowState(DirectoryInfo cur, int pos)
        {            
            FileSystemInfo[] infos = cur.GetFileSystemInfos();
            int start = Console.WindowHeight * (pos / Console.WindowHeight);
            for (int i = start ;i<Math.Min(infos.Length,start+Console.WindowHeight-1 ); i++)
            {
                Console.BackgroundColor = i == pos ? ConsoleColor.Gray  : ConsoleColor.Black;
                Console.ForegroundColor = infos[i].GetType() == typeof(DirectoryInfo) ? ConsoleColor.Magenta : ConsoleColor.Blue ;
                Console.WriteLine(infos[i].Name);
            }
        }
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;
            ConsoleKeyInfo btn;
            DirectoryInfo dir = new DirectoryInfo(@"/Users/alexandra/Documents");
            while (btn.Key!=ConsoleKey.Spacebar)
            {
                if (pos == dir.GetFileSystemInfos().Length - 2||pos==0||pos==Console.WindowHeight-1)
                    Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PRESS SPACEBAR TO EXIT THE FAR MANAGER");
                ShowState(dir, pos);
                btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos >= dir.GetFileSystemInfos().Length)
                            pos = 0;
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        if (f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                            pos = 0;
                        }
                        if(f.GetType()==typeof(FileInfo) )
                        {
                           
                            string p = f.FullName;
                            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(sr.ReadToEnd());
                            ConsoleKeyInfo d = Console.ReadKey();
                            while(d.Key!=ConsoleKey.Q){
                                d = Console.ReadKey(); 
                            }


                            sr.Close();
                            fs.Close(); 
                        }
                        break;
                    case ConsoleKey.Backspace:
                        FileSystemInfo ff = dir.GetFileSystemInfos()[pos];
                        if (ff.GetType() == typeof(DirectoryInfo))
                        {
                            dir = dir.Parent;

                        }
                        if (ff.GetType() == typeof(FileInfo))
                        {
                            dir = new DirectoryInfo(Path.GetDirectoryName(ff.FullName));
                            dir = dir.Parent;
                            pos = 0;
                        }
                        break;
                    
                }
            }
        }
    }
}
