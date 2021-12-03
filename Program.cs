string input = File.ReadAllText("input.txt").Replace("\r\n", "X");
            string[] binary = input.Split('X');
            List<string> binaryL = binary.ToList();

            int one = 0;
            int zero = 0;
            int keepVal = 0;

            string oxval = "";
            string coval = "";
            for (int i = 0; i < 12; i++)
            {
                one = 0;
                zero = 0;
                for (int j = 0; j < binaryL.Count; j++)
                {
                    string binaryval = binary[j][i].ToString();
                    if (binaryval == "1")
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                if (one > zero)
                {
                    keepVal = 1;
                }
                else if (zero > one)
                {
                    keepVal = 0;
                }
                else
                {
                    keepVal = 1;
                }
                
                try
                {
                    int pos = 0;
                    while (true)
                    {
                        if (binaryL[pos][i].ToString() != keepVal.ToString())
                        {
                            binaryL.RemoveAt(pos);
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
                
                if(binaryL.Count == 1)
                {
                    oxval = binaryL[0];
                }
            }
            
            binaryL = binary.ToList();

            for (int i = 0; i < 12; i++)
            {
                one = 0;
                zero = 0;
                for (int j = 0; j < binaryL.Count; j++)
                {
                    string binaryval = binary[j][i].ToString();
                    if (binaryval == "1")
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                if (one > zero)
                {
                    keepVal = 0;
                }
                else if (one < zero)
                {
                    keepVal = 1;
                }
                else
                {
                    keepVal = 0;
                }

                try
                {
                    int pos = 0;
                    while (true)
                    {
                        if (binaryL[pos][i].ToString() != keepVal.ToString())
                        {
                            binaryL.RemoveAt(pos);
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

                if (binaryL.Count == 1)
                {
                    coval = binaryL[0];
                }
            }

            Console.WriteLine(Convert.ToInt32(oxval, 2) * Convert.ToInt32(coval, 2));

            Console.ReadLine();
