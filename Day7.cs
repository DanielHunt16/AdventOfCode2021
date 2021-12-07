using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Challenge7
{
    class Program
    {
        static void Main(string[] args)
        {
            part2();
            Console.ReadLine();            
            
            int target = 1;
            int smallestNum = int.MaxValue;
            int response = 0;
            for(int i = 0; i < 2000; i++)
            {
                response = calc(target);

                if(response < smallestNum)
                {
                    smallestNum = response;
                }

                target++;
            }

            Console.WriteLine(smallestNum);
            Console.ReadLine();
        }

        static int calc(int target)
        {
            string[] input = File.ReadAllText("input.txt").Split(',');
            int[] positions = Array.ConvertAll(input, s => int.Parse(s));
            int totalFuel = 0; 

            for(int i = 0; i < positions.Length; i++)
            {
                if(positions[i] > target)
                {
                    totalFuel += positions[i] - target;
                }
                else if (positions[i] < target)
                {
                    totalFuel += target - positions[i];
                }
                else
                {

                }
            }


            return totalFuel;
        }

        static void part2()
        {
            int target = 1;
            int smallestNum = int.MaxValue;
            int response = 0;
            for (int i = 0; i < 2000; i++)
            {
                response = calc2(target);

                if (response < smallestNum)
                {
                    smallestNum = response;
                }

                target++;
            }

            Console.WriteLine(smallestNum);
            Console.ReadLine();
        }

        static int calc2(int target)
        {
            string[] input = File.ReadAllText("input.txt").Split(',');
            int[] positions = Array.ConvertAll(input, s => int.Parse(s));
            int totalFuel = 0;
            int steps = 0;
            for(int i = 0; i < positions.Length; i++)
            {
                if (positions[i] > target)
                {
                    steps = positions[i] - target;

                    for(int j = 1; j < steps+1; j++)
                    {
                        totalFuel += j;
                    }
                }
                else if (positions[i] < target)
                {
                    steps = target - positions[i];

                    for (int j = 1; j < steps + 1; j++)
                    {
                        totalFuel += j;
                    }
                }
                else
                {

                }
            }
            

            return totalFuel;
        }
    }
}
