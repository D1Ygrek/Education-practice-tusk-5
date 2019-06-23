using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void RanArray(double[,] arr)
        {
            Random r = new Random();
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    arr[i, j] = r.Next(-100000,100000)/100.0;
                }
            }
            Console.WriteLine("Готовый массив:");
            for (int i = 0; i < 9; i++)
            {
                
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(arr[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        static void HandArray(double[,] arr)
        {
            for(int i = 0; i < 9; i++)
            {
                Console.WriteLine("Заполнение {0} строки массива", i + 1);
                for(int j = 0; j < 9; j++)
                {
                    Console.WriteLine("Заполнение {0} элемента строки", j + 1);
                    arr[i, j] = DoubleCheck();
                }
            }
            Console.WriteLine("Готовый массив:");
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string s1 = "Как ввести массив?";
            string s2 = "Рандомное заполнение";
            string s3 = "С клавиатуры посимвольно";
            int n = 0;
            double[,] arr = new double[9, 9];
            do
            {
                Menu(ConsoleKey.Enter, out n, s1, s2, s3);
                if (n == 1)
                {
                    RanArray(arr);
                    n = 3;
                }
                else
                {
                    HandArray(arr);
                    n = 3;
                }
            }while(n != 3);
            int[,] readyarr = new int[9, 9];
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (arr[i, j] > arr[i,i])
                    {
                        readyarr[i, j] = 1;
                    }
                    else
                    {
                        readyarr[i, j] = 0;
                    }
                }
            }
            Console.WriteLine("Ответ:");
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(readyarr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        static double DoubleCheck()
        {
            double n;
            bool ok = false;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string s = Console.ReadLine();
            do
            {
                ok = double.TryParse(s, out n);
                if (ok == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ввод неправильный. Повторите.");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    s = Console.ReadLine();
                }
            } while (!ok);
            Console.ForegroundColor = ConsoleColor.White;
            return (n);
        }
        static void Menu(ConsoleKey ExitKey, out int n, params string[] Strings) //процедура организации меню из переданных строк и ключа-выхода, а также переменной - положения курсора.
        {
            ConsoleKeyInfo k; //переменная, в которую считывается нажатая клавиша
            n = 1;              //положение курсора
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < Strings.Length; i++)     //печать меню с курсором на нужной строке
                {
                    if (i == n) { Console.Write(">"); }
                    Console.WriteLine(Strings[i]);
                }
                k = Console.ReadKey();       //считывание перемещения курсора или выхода из меню
                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:  //обработка перемещения курсора на нажатие стрелки вниз
                        {
                            n++;
                            if (n == Strings.Length) { n--; }
                        }
                        break;
                    case ConsoleKey.UpArrow:  //обработка перемещения курсора на нажатие стрелки вверх
                        {
                            n--;
                            if (n == 0) { n++; }
                        }
                        break;
                    case ConsoleKey.Escape: System.Diagnostics.Process.GetCurrentProcess().Kill(); break; //закрытие программы на escape
                    case ConsoleKey.Backspace: n = 0; break; //откат назад, если нажат backspace(если это предусмотрено запуском)
                }
            } while ((k.Key != ExitKey) & (k.Key != ConsoleKey.Backspace));
        }
    }
}
