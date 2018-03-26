using System;
namespace Snake
{
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
        public  bool SetRandomPosition(Wall wall, Snake snake)
        {// приравниваем коордаинаты к каким-то случаным числам в диапозоне, за исключением позиций змейки и стен
            
            
            int x = new Random().Next(5, 55);
            int y = new Random().Next(5, 20);

            for (int i = 0; i < wall.body.Count; i++)
                if (wall.body[i].x == x && wall.body[i].y == y)
                    return false;
            for (int i = 0; i < snake.body.Count; i++)
                if (snake.body[i].x == x && snake.body[i].y == y)
                    return false;
            location = new Point(x, y);
            return true;
        }
       

        public void Draw()
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }

        public void Eat(Snake snake ,Wall wall){

                    score += 5;//когда змейка скушала, счет увеличивается на 5 очков
                               //пока наша функция не будет правдива , ищем случайную позицию для еды
            do SetRandomPosition(wall, snake);
                while (SetRandomPosition(wall, snake) != true);
               // SetRandomPosition(wall, snake);
            if (score == (wall.level + 1) * 10)
            {//меняем уровень при достижении определенного количества очkов
                Console.Clear();
                snake.NewLevel();
                wall.level++;
                if (wall.level > 4)
                {//пока всего 4 уровня поэтому при прохождении на 5 -возращаемся к первому и обнуляем счет
                    wall.level = 1;
                    score = 0;
                }

            }
        }
        public void Process(Wall wall)
        {
            int a = score;
            int aa = wall.level;
            string ss = "LEVEL " + aa;
            string s = "YOUR SCORE: " + a;
            Console.SetCursorPosition(65, 3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ss);
            Console.SetCursorPosition(65, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(s);
            Console.SetCursorPosition(61, 11);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("ENTER- new game");
            Console.SetCursorPosition(61, 12);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Q- quit the game");
        }
    }
}
