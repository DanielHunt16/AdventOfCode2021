using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4
{
    class Program
    {
        //\n83 11 47 61 45\r\n30 74 73 14 66\r\n53 52 10 57 15\r\n64 50 54 28 87\r\n26 85 63 25 86
        static void Main(string[] args)
        {   //\r\n\r -represents a new board

            ThirdPart();
            ;
            
            
            List<int[]> l = new List<int[]>();

            bool win = false;
            int pos = 0;
            int offset = 0;

            string[] input = File.ReadAllText("input.txt").Replace("\r\n\r","X").Split('X');            
            int[] drawnNumbers = Array.ConvertAll(input[0].Split(','), s => Int32.Parse(s));            
            
            for (int j = 1; j < input.Length; j++)
            {
                string[] board = input[j].Remove(0, 1).Replace("\r\n", "X").Split('X');

                for (int i = 0; i < board.Length; i++)
                {
                    try
                    {
                        l.Add(Array.ConvertAll(board[i].Replace("  ", " ").Split(' '), s => Int32.Parse(s)));
                    }
                    catch
                    {
                        
                    }
                }
            }

            while (!win)
            {
                int currentNum = drawnNumbers[pos];
                
                for (int i = 0; i < l.Count(); i++)
                {
                    for (int j = 0; j < l[i].Length; j++)
                    {
                        if(l[i][j] == currentNum)
                        {
                            l[i][j] = -1;
                        }
                    }
                }

                (bool, int) winCheck = CheckWin(l);
                if (winCheck.Item1)
                {

                    win = true;
                    offset = winCheck.Item2;
                    break;
                }
                else
                {
                    pos++;
                }               
            }
            
            Console.WriteLine(GetFinalScore(l, offset, drawnNumbers[pos]));
            Console.ReadLine();

        }

        //check if each row or coloumn of five contains 5 -1's
        //Returns if their is a winner and the offset 
        static (bool, int) CheckWin(List<int[]> l)
        {
            bool winner = true;
            //Each block of 5 arrays
            for(int i = 0; i < l.Count; i += 5)
            {
                //This checks rows 
                for(int j = 0; j < 5; j++)
                {
                    winner = true;
                    for(int p = 0; p < 5; p++)
                    {
                        if(l[i+j][p] != -1)
                        {
                            winner = false;
                        }
                        
                    }
                    if (winner)
                    {
                        return (true, i);
                    }                    
                }

                //This checks columns 
                for(int p = 0; p < 5; p++)
                {
                    winner = true;
                    for(int j = 0; j < 5; j++)
                    {
                        if (l[i + j][p] != -1)
                        {
                            winner = false;
                        }
                    }

                    if (winner)
                    {
                        return (true, i);
                    }

                }
            }
            
            return (false, -1);
        }

        static int GetFinalScore(List<int[]> l, int offset, int calledNum)
        {
            int finalScore = 0;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < l[offset+i].Length; j++)
                {
                    if(l[offset+i][j] != -1)
                    {
                        finalScore += l[offset + i][j];
                    }
                }
            }
            
            
            return finalScore * calledNum;
        }

        //Not 19845
        //This one doesn't work and I have no idea why?
        static void SecondPart()
        {
            //\r\n\r -represents a new board
            List<int[]> l = new List<int[]>();

            bool win = false;
            bool lastBoard = false;
            int pos = 0;
            (bool, int) winCheck;
            int offset = 0;

            string[] input = File.ReadAllText("input.txt").Replace("\r\n\r", "X").Split('X');
            int[] drawnNumbers = Array.ConvertAll(input[0].Split(','), s => Int32.Parse(s));

            for (int j = 1; j < input.Length; j++)
            {
                string[] board = input[j].Remove(0, 1).Replace("\r\n", "X").Split('X');

                for (int i = 0; i < board.Length; i++)
                {
                    try
                    {
                        l.Add(Array.ConvertAll(board[i].Replace("  ", " ").Split(' '), s => Int32.Parse(s)));
                    }
                    catch
                    {

                    }
                }
            }

            while (!win)
            {
                int currentNum = drawnNumbers[pos];

                for (int i = 0; i < l.Count(); i++)
                {
                    for (int j = 0; j < l[i].Length; j++)
                    {
                        if (l[i][j] == currentNum)
                        {
                            l[i][j] = -1;
                        }
                    }
                }

                do
                {
                    winCheck = CheckWin(l);
                    if (winCheck.Item1)
                    {
                        if (lastBoard)
                        {
                            win = true;
                            break;
                            
                        }
                        else
                        {
                            l.RemoveAt(winCheck.Item2);
                            l.RemoveAt(winCheck.Item2);
                            l.RemoveAt(winCheck.Item2);
                            l.RemoveAt(winCheck.Item2);
                            l.RemoveAt(winCheck.Item2);
                        }
                       
                    }            
                } while (winCheck.Item1);
                
                if(l.Count == 5)
                {
                    lastBoard = true;
                }
                else
                {
                    pos++;
                }     
                                
            }

            Console.WriteLine(GetFinalScore(l, 0, drawnNumbers[pos]));
            Console.ReadLine();
        }

        //This one works 
        // Answer 20774
        static void ThirdPart()
        {
            List<int[]> l = new List<int[]>();

            int pos = 0;
            int currentNum;
            int offset = 0;
            (bool, int) cWin;
            bool lastBoard = false;

            string[] input = File.ReadAllText("input.txt").Replace("\r\n\r", "X").Split('X');
            int[] drawnNumbers = Array.ConvertAll(input[0].Split(','), s => Int32.Parse(s));

            for (int j = 1; j < input.Length; j++)
            {
                string[] board = input[j].Remove(0, 1).Replace("\r\n", "X").Split('X');

                for (int i = 0; i < board.Length; i++)
                {
                    try
                    {
                        l.Add(Array.ConvertAll(board[i].Replace("  ", " ").Split(' '), s => Int32.Parse(s)));
                    }
                    catch
                    {

                    }
                }
            }

            do
            {
                currentNum = drawnNumbers[pos];
                for(int i = 0; i < l.Count(); i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        if(l[i][j] == currentNum)
                        {
                            l[i][j] = -1;
                        }
                    }
                }

                while (true)
                {
                    cWin = CheckWin(l);
                    if (!cWin.Item1)
                    {
                        break;
                    }
                    else
                    {
                        if (lastBoard)
                        {
                            Console.WriteLine(GetFinalScore(l, 0, currentNum));
                            Console.ReadLine();
                            Environment.Exit(0);                            
                        }
                        offset = cWin.Item2;
                        l.RemoveAt(offset);
                        l.RemoveAt(offset);
                        l.RemoveAt(offset);
                        l.RemoveAt(offset);
                        l.RemoveAt(offset);
                    }
                }

                if(l.Count() == 5)
                {
                    lastBoard = true;
                }     
                
                pos++;
            } while (true);




        }
    }
}
