using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lengthwise
{
    class Program
    {
        static int val = 0;
        static string code = "";

        static List<string> codes = new List<string>();

        static int running = 0;

        static string printed = "";
        static void Main(string[] args)
        {
            code = File.ReadAllText(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\" + "LengthwiseScript.lhwi").Trim();
            Console.Title = "Lengthwise Interpreter Default";
            foreach (char c in code)
            {
                codes.Add(c.ToString());
            }

            while (running < codes.Count)
            {
                string command = codes[running];

                switch(command)
                {
                    case "+":
                        val += 1;
                        if (val > 512)
                        {
                            val = 0;
                        }
                        break;
                    case ".":
                        switch(val)
                        {
                            case 0:
                                running += codes.Count;
                                break;
                            case 1:
                                running -= 5;
                                break;
                            case 2:
                                running += 5;
                                break;
                            case 3:
                                Console.Write("\n");
                                break;
                            case 4:
                                val = (int)Console.ReadLine()[0];
                                break;
                            case 5:
                                Console.Title = printed;
                                Console.Clear();
                                printed = "";
                                break;

                            default:
                                Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(val) }));
                                printed += Encoding.ASCII.GetString(new byte[] { (byte)(val) });
                                break;
                        }
                        break;
                }

                running += 1;
            }

            Console.Write("\n\nThis program has ended.");

            Console.ReadLine();
        }
    }
}
