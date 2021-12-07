using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6
{
    class Program
    {
        //Not 11465499
        static void Main(string[] args)
        {
            Part3();
            //Part2();
            List<int> laternFish = new List<int>();
            int quantityToAdd = 0;
            //string input = File.ReadAllText("input.txt");
            string input = File.ReadAllText("test.txt");

            laternFish = Array.ConvertAll(input.Split(','), s => int.Parse(s)).ToList();            

            for(int i = 0; i < 200; i++)
            {
                quantityToAdd = 0;
                for (int j = 0; j < laternFish.Count; j++)
                {
                    if (laternFish[j] == 0)
                    {
                        quantityToAdd++;
                        laternFish[j] = 6;
                    }
                    else
                    {
                        laternFish[j]--;
                    } 
                }

                for(int l = 0; l < quantityToAdd; l++)
                {
                    laternFish.Add(8);
                }

               // Console.WriteLine($"{i + 1}, {laternFish.Count}");
            }

            Console.WriteLine(laternFish.Count);
            Console.ReadLine();
        }

        //Too big 3205774618860855113268989643513603866551095930914555738165613996062159765204804347493449847470555136
        static void Part2()
        {
            BigInteger num = (BigInteger)(361 * Math.Pow(Math.E, 0.872 * 255));
            Console.WriteLine(num);
            Console.ReadLine();
        }

        //Answer is 1749945484935
        static void Part3()
        {
            List<int> time = new List<int>();
            List<long> amount = new List<long>();
            string input = File.ReadAllText("input.txt");
            long quantityToAdd = 0;
            time  = Array.ConvertAll(input.Split(','), s => int.Parse(s)).ToList();

            for(int i = 0; i < time.Count; i++)
            {
                amount.Add(1);
            }

            for (int i = 0; i < 256; i++)
            {
                quantityToAdd = 0;
                for (int j = 0; j < time.Count; j++)
                {
                    if (time[j] == 0)
                    {
                        quantityToAdd += amount[j];
                        time[j] = 6;
                    }
                    else
                    {
                        time[j]--;
                    }
                }

                if (0 < quantityToAdd)
                {
                    time.Add(8);
                    amount.Add(quantityToAdd);
                }              
                                              
            }
            BigInteger num = 0;

            for(int i = 0; i < amount.Count(); i++)
            {
                num += amount[i];
            }

            Console.WriteLine(num);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
