using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2();
        }

        // Answer 1676
        static void Part1()
        {
            string input = File.ReadAllText("input.txt");
            int bigger = 0;
            int[] nums = Array.ConvertAll(input.Split('\n'), s => int.Parse(s));
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < nums[i + 1]) bigger++;
                }
            }
            catch (IndexOutOfRangeException)
            {

            }

            Console.WriteLine(bigger);
            Console.ReadLine();
        }

        //1706
        static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            int bigger = 0;            
            int total;
            int[] nums = Array.ConvertAll(input.Split('\n'), s => int.Parse(s));

            int prevSum = nums[0] + nums[1] + nums[2];

            try
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    total = nums[i] + nums[i + 1] + nums[i + 2];                  
                    
                    if (total > prevSum) { bigger++; }                 
                                                               

                    prevSum = total;

                }
            }
            catch (IndexOutOfRangeException)
            {
                               
            }

            Console.WriteLine(bigger);
            Console.ReadLine();
        }
    }
}
