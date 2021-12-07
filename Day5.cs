using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5
{
    class Program
    {
        //Not 16675
        //Answer is 4745
        static void Main(string[] args)
        {

            PartTwo();
            //Test();
            Console.ReadLine();
                        
            int[,] grid = new int[1000, 1000];
            int[] x1 = new int[500];
            int[] y1 = new int[500];
            int[] x2 = new int[500];
            int[] y2 = new int[500];

            int total = 0;

            string[] buffer = new string[4];

            string[] input = File.ReadAllText("input.txt").Replace("\r\n", "X").Split('X');
            //string[] input = File.ReadAllText("test.txt").Replace("\r\n", "X").Split('X');

            for(int i = 0; i < input.Length; i++)
            {
                buffer = input[i].Replace(" -> ", ",").Split(',');
                
                x1[i] = Int32.Parse(buffer[0]);
                y1[i] = Int32.Parse(buffer[1]);
                x2[i] = Int32.Parse(buffer[2]);
                y2[i] = Int32.Parse(buffer[3]);
            }

            for(int i = 0; i < x1.Length; i++)
            {
                if(y1[i] == y2[i])
                {
                    if(x1[i] < x2[i])
                    {
                        IncreaseX(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (x1[i] > x2[i])
                    {
                        DecreaseX(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                }
                else if (x1[i] == x2[i])
                {
                    if(y1[i] < y2[i])
                    {
                        IncreaseY(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if(y1[i] > y2[i])
                    {
                        DecreaseY(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                }
                else
                {

                }
            }

            for(int i = 0; i < 1000; i++)
            {
                for(int j = 0; j < 1000; j++)
                {
                    if(grid[j, i] >= 2)
                    {
                        total++;
                    }
                }
            }            

            Console.WriteLine(total);
            Console.ReadLine();
        }

        static void IncreaseX(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 + offset <= x2)
            {
                grid[y1, x1 + offset]++;
                offset++;
            }           
        }

        static void DecreaseX(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 - offset >= x2)
            {
                grid[y1, x1 - offset]++;
                offset++;
            }
        }

        static void IncreaseY(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (y1 + offset <= y2)
            {
                grid[y1 + offset, x1]++;
                offset++;
            }                              
        }

        static void DecreaseY(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while(y1 - offset >= y2)
            {
                grid[y1 - offset, x1]++;
                offset++;
            }
        }

        //Left to Right up
        static void Diagonal1(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 + offset <= x2)
            {
                grid[y1 + offset, x1 + offset]++;
                offset++;
            }

        }

        //Left to Right down
        static void Diagonal2(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 + offset <= x2)
            {
                grid[y1 - offset, x1 + offset]++;
                offset++;
            }
        }

        //Right to Left up
        static void Diagonal3(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 - offset >= x2)
            {
                grid[y1 + offset, x1 - offset]++;
                offset++;
            }
        }

        //Right to left down
        static void Diagonal4(ref int[,] grid, int x1, int y1, int x2, int y2)
        {
            int offset = 0;
            while (x1 - offset >= x2)
            {
                grid[y1 - offset, x1 - offset]++;
                offset++;
            }
        }

        static void Test()
        {
            int[,] grid = new int[10, 10];
            //IncreaseX(ref grid, 0, 9, 5, 9);
            Diagonal3(ref grid, 8, 0, 0, 8);           
            //DecreaseX(ref grid, 9, 4, 3, 4);
            //DecreaseY(ref grid, 2, 2, 2, 1);
            //IncreaseY(ref grid, 7, 0, 7, 4);
            Diagonal4(ref grid, 6, 4, 2, 0);
            //IncreaseX(ref grid, 0, 9, 2, 9);
            //DecreaseX(ref grid, 3, 4, 1, 4);
            //Diagonal1(ref grid, 0, 0, 8, 8);
            //Diagonal2(ref grid, 5, 5, 8, 2);
           
            PrintGrid(grid);

            Console.ReadLine();

        }

        static void PrintGrid(int[,] grid)
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine();
            }
        }


        //Not 10689
        //Answer is 18442
        static void PartTwo()
        {            
            int[,] grid = new int[1000, 1000];
            int[] x1 = new int[500];
            int[] y1 = new int[500];
            int[] x2 = new int[500];
            int[] y2 = new int[500];

            int total = 0;

            string[] buffer = new string[4];

            string[] input = File.ReadAllText("input.txt").Replace("\r\n", "X").Split('X');            

            for (int i = 0; i < input.Length; i++)
            {
                buffer = input[i].Replace(" -> ", ",").Split(',');

                x1[i] = Int32.Parse(buffer[0]);
                y1[i] = Int32.Parse(buffer[1]);
                x2[i] = Int32.Parse(buffer[2]);
                y2[i] = Int32.Parse(buffer[3]);
            }

            for (int i = 0; i < x1.Length; i++)
            {
                if (y1[i] == y2[i])
                {
                    if (x1[i] < x2[i])
                    {
                        IncreaseX(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (x1[i] > x2[i])
                    {
                        DecreaseX(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                }
                else if (x1[i] == x2[i])
                {
                    if (y1[i] < y2[i])
                    {
                        IncreaseY(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (y1[i] > y2[i])
                    {
                        DecreaseY(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                }
                else
                {
                    if(x1[i] < x2[i] && y1[i] < y2[i])
                    {
                        Diagonal1(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (x1[i] < x2[i] && y1[i] > y2[i])
                    {
                        Diagonal2(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (x1[i] > x2[i] && y1[i] < y2[i])
                    {
                        Diagonal3(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                    else if (x1[i] > x2[i] && y1[i] > y2[i])
                    {
                        Diagonal4(ref grid, x1[i], y1[i], x2[i], y2[i]);
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[j, i] >= 2)
                    {
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}
