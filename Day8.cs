using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Challenge8
{
    class Program
    {

        /*
         * 1: 2 segments
         * 4: 4 segments 
         * 7: 3 segments
         * 8: 7 segments 
         * Part 1 answer 525
         */
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("input.txt").Replace("\r\n", "X").Split('X');
            //string[] input = File.ReadAllText("test.txt").Replace("\r\n", "X").Split('X');
            string[] outputValues = new string[input.Length];
            List<string> currentOutput = new List<string>();
            int total = 0;

            for(int i = 0; i < input.Length; i++)
            {
                outputValues[i] = input[i].Substring(input[i].IndexOf('|'), input[i].Length - input[i].IndexOf('|')).Remove(0, 2);
            }

            for(int i = 0; i < outputValues.Length; i++)
            {
                currentOutput = outputValues[i].Split(' ').ToList();

                for(int j = 0; j < currentOutput.Count(); j++)
                {
                    if(currentOutput[j].Length == 2 || currentOutput[j].Length == 4 || currentOutput[j].Length == 3 || currentOutput[j].Length == 7)
                    {
                        Console.WriteLine(currentOutput[j]);
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }

        /*The letter that 7 contains but a doesn't is the top val 
         * 
         * 
         * 
         */
        static void Part2()
        {
        }
    }
}
