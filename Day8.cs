using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021AdventOfodeQ8
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

            Part2();
            Console.ReadLine();

            string[] input = File.ReadAllText("input.txt").Replace("\r\n", "X").Split('X');
            //string[] input = File.ReadAllText("test.txt").Replace("\r\n", "X").Split('X');
            string[] outputValues = new string[input.Length];
            List<string> currentOutput = new List<string>();
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                outputValues[i] = input[i].Substring(input[i].IndexOf('|'), input[i].Length - input[i].IndexOf('|')).Remove(0, 2);
            }

            for (int i = 0; i < outputValues.Length; i++)
            {
                currentOutput = outputValues[i].Split(' ').ToList();

                for (int j = 0; j < currentOutput.Count(); j++)
                {
                    if (currentOutput[j].Length == 2 || currentOutput[j].Length == 4 || currentOutput[j].Length == 3 || currentOutput[j].Length == 7)
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
            string[] input = File.ReadAllText("input.txt").Replace("\r\n", "X").Split('X');
            //string[] input = File.ReadAllText("test.txt").Replace("\r\n", "X").Split('X');
            string[] temp = new string[2];
            List<string[]> ls = new List<string[]>();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            bool contains = false;
            int total = 0;

            for(int i = 0; i < input.Length; i++)
            {
                temp = input[i].Split('|');
                ls.Add(temp[0].Split(' '));
                ls.Add(temp[1].Split(' '));
                
            }

            for(int i = 0; i < ls.Count(); i +=2)
            {
                string[] currentSignalPat = ls[i];
                string[] output = ls[i + 1];
                string num = string.Empty;
                dict.Clear();
                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    //Finding pattern for 1
                    if(currentSignalPat[j].Length == 2)
                    {                        
                        dict.Add(1, SortString(currentSignalPat[j]));                        
                    }
                    //Finding pattern for 4
                    else if (currentSignalPat[j].Length == 4)
                    {
                        dict.Add(4, SortString(currentSignalPat[j]));
                    }
                    //Finding pattern for 7
                    else if (currentSignalPat[j].Length == 3)
                    {
                        dict.Add(7, SortString(currentSignalPat[j]));
                    }
                    //Finding pattern for 8
                    else if (currentSignalPat[j].Length == 7)
                    {
                        dict.Add(8, SortString(currentSignalPat[j]));
                    }
                }

                //3 contains all of 1 and 7 and has length 5
                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    if(currentSignalPat[j].Length == 5)
                    {
                        if(ContainsAllLetters(currentSignalPat[j], dict[1]) && ContainsAllLetters(currentSignalPat[j], dict[7])){
                            dict.Add(3, SortString(currentSignalPat[j]));
                        }
                    }
                }

                //9 Contains all of 3 and has length 6
                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    if (currentSignalPat[j].Length == 6)
                    {
                        if (ContainsAllLetters(currentSignalPat[j], dict[3]))
                        {
                            dict.Add(9, SortString(currentSignalPat[j]));
                        }
                    }
                }
                ;

                //0 is the other 6 length and contains 7               

                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    if(currentSignalPat[j].Length == 6)
                    {
                        if(dict[9] != SortString(currentSignalPat[j]) && ContainsAllLetters(currentSignalPat[j], dict[7]))
                        {
                            dict.Add(0, SortString(currentSignalPat[j]));
                        }
                    }
                }

                
                //Find 6
                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    if (currentSignalPat[j].Length == 6)
                    {
                        if (dict[9] != SortString(currentSignalPat[j]) && dict[0] != SortString(currentSignalPat[j]))
                        {
                            dict.Add(6, SortString(currentSignalPat[j]));
                        }
                    }
                }
                //Find 5 and 2
                for(int j = 0; j < currentSignalPat.Length; j++)
                {
                    if(currentSignalPat[j].Length == 5)
                    {
                        int amount = 0;
                        foreach(var letter in dict[6])
                        {
                            if (currentSignalPat[j].Contains(letter))
                            {
                                amount++;
                            }
                        }

                        if(amount == 5)
                        {
                            dict.Add(5, SortString(currentSignalPat[j]));
                        }
                        if(amount == 4 && SortString(currentSignalPat[j]) != dict[3])
                        {
                            dict.Add(2, SortString(currentSignalPat[j]));
                        }
                    }
                }
                for(int j = 0; j < output.Length; j++)
                {
                    output[j] = SortString(output[j]);
                }

                for (int j = 0; j < output.Length;j++)
                {                   

                    for (int l = 0; l < 10; l++)
                    {
                        if(dict[l] == output[j])
                        {
                            num += l;
                            l = 11;
                        }
                    }
                }

                total += int.Parse(num);                
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        static bool ContainsAllLetters(string input, string check)
        {
            foreach(var letter in check)
            {
                if (!input.Contains(letter))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
