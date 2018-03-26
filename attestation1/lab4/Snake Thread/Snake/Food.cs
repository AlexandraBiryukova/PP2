using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Snake
{[Serializable]
    public class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;
        public int score;
        public Food()
        {
            sign ='✤';
            color = ConsoleColor.Green;
           

        }
        public  void foodSAVE()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/food.asd", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, Game.food);

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


        public void foodRESUME()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/food.asd", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Food s = bf.Deserialize(fs) as Food;
                Game.food = s;
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
        public void SetRandomPosition()
        {// приравниваем коордаинаты к каким-то случаным числам в диапозоне, за исключением позиций змейки и стен

            int qq = 1;
            int x = new Random().Next(5, 55);
            int y = new Random().Next(5, 20);

            while (qq!=0) 
            {
                bool q = false;
                for (int i = 0; i < Game.wall.body.Count; i++){
                    if (Game.wall.body[i].x == x && Game.wall.body[i].y == y)
                    {
                        q = true;
                        break;
                    }
                    }
            
                for (int i = 0; i < Game.snake.body.Count; i++){
                    if (Game.snake.body[i].x == x && Game.snake.body[i].y == y){
                        q = true;
                        break;
                    }
                    }
                if (q == false)
                {
                    qq = 0;
                    break;
                }
                x = new Random().Next(5, 55);
                y = new Random().Next(5, 20);

             
            }
            location = new Point(x, y); 
        }
       

        public void Draw()
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }

    }
}
