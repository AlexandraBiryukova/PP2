using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
namespace Snake
{
    class MainClass
    {
        public static int direction = 1;
        public static int speed = 200;

        static void MoveSnakeThread(object state)
        {
            while (!Game.GameOver)
            {
                switch (direction)
                {
                    case 1:
                        Game.snake.Move(1, 0);
                        break;
                    case 2:
                        Game.snake.Move(0, 1);
                        break;
                    case 3:
                        Game.snake.Move(-1, 0);
                        break;
                    case 4:
                        Game.snake.Move(0, -1);
                        break;
                    
                }
                Game.Process();
                Game.Draw();
                Thread.Sleep(speed);
                Game.wall.LoadLevel();
                if (Game.GameOver == true)
                {
                    Game.Process(); 
                    Game.END();
                    Game.Draw();

                }

            }
        }
        public static void Main(string[] args)
        {
            int g=0;
            Game.Init();
            Game.food.SetRandomPosition();

            Thread t = new Thread(MoveSnakeThread);
            t.Start();
            ConsoleKeyInfo btt;
            while (!Game.GameOver||btt.Key!=ConsoleKey.Q)
            {
                 btt = Console.ReadKey();

                switch (btt.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = 4;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = 2;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = 3;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = 1;
                        break;



                    case ConsoleKey.N:
                        Console.Clear();
                        Game.wall.level =1;
                        Game.food.score = 0;
                        Game.snake = new Snake();
                         
                        Game.Draw();
                        Game.Process();
                        direction = 1;
                        if (Game.GameOver == true)
                        {
                            Game.GameOver = false;
                            t = new Thread(MoveSnakeThread);
                            t.Start();
                        }
                        break;
                    case ConsoleKey.Q:
                        Game.GameOver = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.S:
                         g = direction;
                        if(Game.GameOver!=true)
                        Game.SAVE();
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.R:
                        if (Game.GameOver == false)
                        {
                            Console.Clear();
                            Game.RESUME();
                            direction = g;
                            Game.Draw();

                        }
                        break;
                }

            }
        }
    }

}