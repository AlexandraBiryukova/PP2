using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Snake
{[Serializable]
    public class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;


        public void snakeSAVE()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/snake.asd", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, this);

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

        public void snakeRESUME()
        {
            FileStream fs = new FileStream(@"/Users/alexandra/Documents/LAB1/lab4/Snake Thread/snake.asd", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Snake s = bf.Deserialize(fs) as Snake;
                Game.snake = s;
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
        public Snake()
        {
            sign = '◎';
            color = ConsoleColor.Magenta;
            body = new List<Point>();
            body.Add(new Point(5, 10));
            body.Add(new Point(4, 10));
            body.Add(new Point(3, 10));
        }
        public void Move(int dx, int dy)
        {
            Point last = body[body.Count - 1];
            Console.SetCursorPosition(last.x, last.y);
            Console.Write(' ');
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;
            Game.snake.CanEat();
            Game.snake.Borders();
            Game.snake.GameOverCondition();
        }
        public bool CanEat()
        {
            if (Game.food.location.x == body[0].x && Game.food.location.y == body[0].y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                Game.food.SetRandomPosition();
                Game.food.score += 5;
                if (Game.food.score == (Game.wall.level + 1) * 10)
                {
                    Console.Clear();
                    MainClass.direction = 1;
                    Game.snake.HeadOnNewLevel();
                    Game.wall.level++;
                    if (Game.wall.level > 4)
                    {
                        Game.wall.level = 1;
                        Game.food.score = 0;
                    }

                }

                return true;
            }
            return false;
        }
        public void HeadOnNewLevel()
        {//при переходе на новый уровень меняем локацию головы и тела змейки, чтобы избежать наложения со стенами
            for (int i = 1; i <= body.Count - 1; i++)
            {
                body[i].x = 0;
                body[i].y = 0;
            }
            body[0].x = 1;
            body[0].y = 1;
        }


        public void GameOverCondition()
        {//игра окончена в случае:
            for (int i = 1; i < body.Count; i++)
            {//если змейка ест саму себя
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                {
                    Game.GameOver   = true;
                    break;
                }
            }
            if(Game.GameOver ==false){
                for (int i = 0; i < Game.wall.body.Count; i++)
                {//если змейка ударяется о стену
                    if (body[0].x == Game.wall.body[i].x && body[0].y == Game.wall.body[i].y)
                    {
                        Game.GameOver= true;
                        break;
                    }
                }

        }
    

            
        }
        public void Draw()
        {
            int i = 0;
            foreach (Point p in body)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow ;
                else
                    Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                i++;
            }
        }
        public void Borders()
        {
            if (body[0].x < 0)
                body[0].x = 59;
            if (body[0].x > 59)
                body[0].x = 0;
            if (body[0].y < 0)
                body[0].y = 23;
            if (body[0].y > 23)
                body[0].y = 0;
        }

    }
}