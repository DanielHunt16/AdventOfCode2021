using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Challenge9
{
    class Program
    {
        //Not 1832
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("input.txt").Replace("\r\n","X").Split('X');
            //string[] input = File.ReadAllText("test.txt").Replace("\r\n","X").Split('X');
            int[][] arr = new int[100][];
            //int[][] arr = new int[5][];
            int total = 0;
            bool lowest;

            for(int i = 0; i < input.Length; i++)
            {
                arr[i] = Array.ConvertAll(input[i].ToCharArray(), s => int.Parse(s.ToString()));
            }

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    lowest = true;

                    try
                    {
                        if (arr[i][j] > arr[i][j+1])
                        {
                            lowest = false;
                        }
                        
                    }
                    catch (IndexOutOfRangeException)
                    {

                       
                    }

                    try
                    {
                        if (arr[i][j] > arr[i][j - 1])
                        {
                            lowest = false;
                        }

                    }
                    catch (IndexOutOfRangeException)
                    {


                    }

                    try
                    {
                        if (arr[i][j] > arr[i+1][j])
                        {
                            lowest = false;
                        }

                    }
                    catch (IndexOutOfRangeException)
                    {


                    }

                    try
                    {
                        if (arr[i][j] > arr[i-1][j])
                        {
                            lowest = false;
                        }

                    }
                    catch (IndexOutOfRangeException)
                    {


                    }

                    if (lowest)
                    {
                        Console.WriteLine(arr[i][j]);
                        total += arr[i][j] + 1;
                    }
                }
            }

            Console.WriteLine(total);
            Console.ReadLine();
            
        }
    }
}
