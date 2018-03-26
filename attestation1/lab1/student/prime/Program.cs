using System;

namespace LAB1
{


    class MainClass
    {
        public static bool IsPrime(int a)//создаем функцию, которая будет проверять на простоту 
        {
            for (int i = 2; i * i <= a; i++)
            {
                if (a % i == 0)
                    return false;//если найдет , сразу выйдет из цикла
            }
            return true;
        }
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();//вводим данные с консоли 
            string[] arr = line.Split(' ');//заполняем массив элементами

            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPrime(int.Parse(arr[i])) == true)
                    Console.WriteLine(arr[i], "/n");//если простое-будет выводить с новой строки

            }

            Console.ReadKey();//программа ждет нажатия любой клавиши для завершения программы







        }
    }
}
