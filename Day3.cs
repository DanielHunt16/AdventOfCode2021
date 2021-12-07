using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            three();

            string input = File.ReadAllText("input.txt").Replace("\r\n", "X");           
            string[] binary = input.Split('X');

            int one = 0;
            int zero = 0;

            string gammaRateBin = "";
            string epsilonRateBin = "";

            for(int i = 0; i < binary[0].Length; i++)
            {
                one = 0;
                zero = 0;
                for(int j = 0; j < binary.Length; j++)
                {
                    string binaryval = binary[j][i].ToString();
                    if(binaryval == "1")
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                if(one > zero)
                {
                    gammaRateBin = gammaRateBin + "1";
                    epsilonRateBin = epsilonRateBin + "0";
                }
                else
                {
                    gammaRateBin = gammaRateBin + "0";
                    epsilonRateBin = epsilonRateBin + "1";
                }                
            }

            Console.WriteLine(Convert.ToInt32(gammaRateBin, 2) * Convert.ToInt32(epsilonRateBin, 2));
            Console.ReadLine();
        }
        static void three()
        {
            string input = File.ReadAllText("input.txt").Replace("\r\n", "X");
            string[] binary = input.Split('X');
            string oxBinary = string.Empty;
            string coBinary = string.Empty;
            
            List<string> l = binary.ToList();

            int ones;
            int zeros;
            int keepVal = 0;
            int pos;

            for(int j = 0; j < 12; j++)
            {
                ones = 0;
                zeros = 0;
                for(int i = 0; i < l.Count(); i++)
                {
                    if(l[i][j].ToString() == "1")
                    {
                        ones++;
                    }
                    else if(l[i][j].ToString() == "0")
                    {
                        zeros++;
                    }
                }

                if(ones > zeros)
                {
                    keepVal = 1;
                }
                else if (ones < zeros)
                {
                    keepVal = 0;
                }
                else if (ones == zeros)
                {
                    keepVal = 1;
                }

                pos = 0;
                try
                {
                    while (true)
                    {
                        if(l[pos][j].ToString() != keepVal.ToString())
                        {
                            l.RemoveAt(pos);
                        }
                        else
                        {
                            pos++;
                        }
                    }
                }
                catch
                {

                }

                if (l.Count() == 1)
                {
                    oxBinary = l[0];
                    break;
                    j = 1000;
                }
            }


            l = binary.ToList();

            for(int j = 0; j < 12; j++)
            {
                ones = 0;
                zeros = 0;
                for(int i = 0; i < l.Count; i++)
                {
                    if (l[i][j].ToString() == "1")
                    {
                        ones++;
                    }
                    else if (l[i][j].ToString() == "0")
                    {
                        zeros++;
                    }
                }

                if(ones < zeros)
                {
                    keepVal = 1;
                }
                else if ( ones > zeros)
                {
                    keepVal = 0;
                }
                else if (ones == zeros)
                {
                    keepVal = 0;
                }

                pos = 0;
                try
                {
                    while (true)
                    {
                        if (l[pos][j].ToString() != keepVal.ToString())
                        {
                            l.RemoveAt(pos);
                        }
                        else
                        {
                            pos++;
                        }
                    }
                }
                catch
                {

                }

                if (l.Count() == 1)
                {
                    coBinary = l[0];
                    break;
                    j = 1000;
                }
            }

            Console.WriteLine(Convert.ToInt32(oxBinary, 2) * Convert.ToInt32(coBinary, 2));
            Console.ReadLine();
        }
    }
}
