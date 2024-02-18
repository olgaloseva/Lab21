using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
        //Имеется пустой участок земли(двумерный массив) и план сада, который необходимо реализовать.
        //Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
        //Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
        //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
        //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше.
        //Садовники должны работать параллельно. Создать многопоточное приложение, моделирующее работу садовников.
    {
        const int n = 10;
        const int m = 8;
        static int[,] path = new int[n,m];

        static void Main(string[] args)
        {
            path[0, 0] = -1;

            ThreadStart threadStart = new ThreadStart(Gartner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gartner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i,j]} ");
                }
                Console.WriteLine();    
            }

            Console.ReadKey();
        }
        static void Gartner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i,j] != -2)
                    {
                        path[i,j] = -1;
                        Thread.Sleep(10);
                    }
                }
            }
        }

        static void Gartner2()
        {
            for (int i = m-1; i > 0; i--)
            {
                for (int j = n-1; j  > 0; j--)
                {
                    if (path[j,i] != -1)
                    {
                        path[j,i] = -2;
                        Thread.Sleep(10);
                    }                    
                }
            }
        }
    }
}
