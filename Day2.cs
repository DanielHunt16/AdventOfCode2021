using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    class Program
    {
        struct coords 
        {
            public int horz;
            public int vert;
            public int aim;
        }


        //Part 1: 2147104
        static void Main(string[] args)
        {
            coords coord = new coords();
            coord.horz = 0;
            coord.vert = 0;
            coord.aim = 0;
            string[] input = File.ReadAllText("input.txt").Split('\n');
            string[] direct;

            for(int i = 0; i < input.Length; i++)
            {
                input[i].Replace('\r', ' ');
                direct = input[i].Split(' ');

                if (direct[0] == "forward")
                {
                    coord.horz += Int32.Parse(direct[1]);
                    coord.vert += coord.aim * Int32.Parse(direct[1]);
                }
                else if (direct[0] == "up")
                {
                    //coord.vert -= Int32.Parse(direct[1]);
                    coord.aim -= Int32.Parse(direct[1]);
                }
                else if (direct[0] == "down") 
                { 
                    //coord.vert += Int32.Parse(direct[1]);
                    coord.aim += Int32.Parse(direct[1]);
                }
                
            }

            Console.WriteLine(coord.horz * coord.vert);

            Console.ReadLine();



        }
    }
}
