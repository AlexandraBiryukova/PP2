using System;
using System.Collections.Generic;
using System.IO;
namespace Snake
{
    class MainClass
        {
            public static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"/Users/alexandra/Documents/LAB1/lab4/Snake/PLAYERS.txt",true); 
            bool g = true;
            Console.CursorVisible = false;

            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall();
            food.SetRandomPosition(wall,snake);
            while (g)
            {
                wall.LoadLevel();
                //Отображение текущего уровня и счета
                food.Process (wall);
                snake.Draw();
                wall.Draw();
                food.Draw();
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                    case ConsoleKey.Q:
                        g = false;
                        Console.Clear();
                        break;
                    case ConsoleKey.Enter:
                        wall.level = 1;
                        snake.body.Clear();
                        food.score = 0;
                        snake = new Snake();

                        Console.Clear();
                        break;
                        
                }
                snake.Borders(); 
                if (snake.CanEat(food))
                    food.Eat(snake, wall); 
                   
                if(snake.GameOver(wall)){//если игра окончена-возращаеся на первый уровень , обнуляем счет
                    Snake.END(); 
                    ConsoleKeyInfo bt = Console.ReadKey();
                    switch (bt.Key)
                    {
                        case ConsoleKey.Enter:
                            wall.level = 1;
                            //snake.body.Clear();
                            food.score = 0;
                            snake = new Snake();

                            Console.Clear();
                            break;
                        case ConsoleKey.Q:
                            g = false;
                            Console.SetCursorPosition(61,13); 
                            Console.WriteLine("USER NAME:");
                            Console.SetCursorPosition(61, 14);
                            string s=Console.ReadLine();
                            sw.WriteLine("USER:"+s+". Score:"+food.score);
                            sw.Close();

                            Console.Clear();
                            break;
                        
                        
                    }
                }
               
            }
            }
        }
    }
