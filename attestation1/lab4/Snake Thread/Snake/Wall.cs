using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Snake
{
    [Serializable ]
    public class Wall
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        public  int level;

        public Wall()
        {
            
            color =ConsoleColor.Red ;
            sign = '☐';
            body = new List<Point>();
            level = 1;

    
        }
        public  void wallSAVE()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/wall.asd", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, Game.wall);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

        }


        public void wallRESUME()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/wall.asd", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Wall s = bf.Deserialize(fs) as Wall;
                Game.wall = s;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        public void LoadLevel()
        {//загружаем уровень из существуещего тхт файла
            Console.Clear(); 
            body.Clear();
            string filePath = string.Format(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/L{0}.txt", level);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line ="";
            int i = 0;
            int row = 0;
            while (i < 24)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] =='☐')
                    {
                        body.Add(new Point(col, row));
                    }
                }
                i++;
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
          foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}
