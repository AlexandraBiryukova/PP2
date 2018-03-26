using System;

namespace LAB1
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            int s;
            if (args.Length > 0)//если введены какие-то значения
            {
                for (int i = 0; i < args.Length; i++)//пробегаемся по полученному массиву типа int
                {
                    s = 0;
                    for (int k = 2; k * k <= int.Parse(args[i]); k++)//используем К в качестве делителя для каждого члена массива
                    {
                        if (int.Parse(args[i]) % k == 0)
                        {//проверяем на делимость
                            s = 1;
                            break;//сразу выходим из данного цикла
                        }
                    }
                    if (s == 0)//если значение не поменялось, выводим элемент массива с новой строки
                        Console.WriteLine(args[i], "/n");

                }


            }


            Console.ReadKey();






        }
    }
}
