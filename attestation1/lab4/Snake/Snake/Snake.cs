using System;
using System.Collections.Generic;
namespace Snake
{
    public class Snake
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public static void END(){
            Console.SetCursorPosition(61, 9);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("GAME OVER");



        }

        public Snake()
        {
            sign = '◎';
            color = ConsoleColor.Magenta;
            body = new List<Point>();
            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
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


            // TODO check for can eat
            // TODO check for collision with wall and itself
            // TODO wall borders
        }
        public bool CanEat(Food food)
        {
            if (food.location.x == body[0].x && food.location.y == body[0].y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));

                return true;
            }
            return false;
        }
        public void NewLevel(){//при переходе на новый уровень меняем локацию головы и тела змейки, чтобы избежать наложения со стенами
            for (int i = 1; i <= body.Count - 1; i++)
            {
                body[i].x = 0;
                body[i].y = 0;
            }
            body[0].x = 1;
            body[0].y = 1;
        }


        public bool GameOver(Wall wall){//игра окончена в случае:
            for (int i = 1; i < body.Count;i++){//если змейка ест саму себя
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            for (int i = 0; i < wall.body.Count; i++)
            {//если змейка ударяется о стену
                if (body[0].x == wall.body[i].x && body[0].y == wall.body[i].y)
                    return true;
                    }
            return false;
            
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