using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DiffMatchPatch;

namespace WordCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine, patternline;
            string mode;
           
            Console.WriteLine("Type 1 for run programm in first mode");
            Console.WriteLine("Type 2 for run programm in second mode");
            Console.WriteLine("Type 3 for run programm in third mode");

            while ((mode = Console.ReadLine()) != "q")
            {
                switch (mode)
                {
                    case "1":
                        Console.WriteLine("Case 1");
                        System.IO.StreamReader input = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\input.txt");
                        while ((inputLine = input.ReadLine()) != null)
                        {
                            System.IO.StreamReader patterns = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\patterns.txt");
                            while ((patternline = patterns.ReadLine()) != null)
                            {
                                if(String.Compare(inputLine, patternline) == 0)
                                    Console.WriteLine(inputLine);
                            }
                            patterns.Close();
                        }
                        input.Close();
                        break;
                    case "2":
                        Console.WriteLine("Case 2");
                        System.IO.StreamReader inputMode2 = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\input.txt");
                        while ((inputLine = inputMode2.ReadLine()) != null)
                        {
                            System.IO.StreamReader patternsMode2 = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\patterns.txt");
                            while ((patternline = patternsMode2.ReadLine()) != null)
                            {
                                Regex regex = new Regex(@patternline+"(\\w*)");

                                if (regex.IsMatch(inputLine))
                                {
                                    Console.WriteLine(inputLine);
                                }
                            }
                            patternsMode2.Close();
                        }
                        inputMode2.Close();
                        break;
                    case "3":
                        //var inputArray = new List<string>();
                        string[] inputArray, patternArray;
                        string[] stringSeparators = new string[] { " " };
                        Console.WriteLine("Case 3");
                        System.IO.StreamReader inputMode3 = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\input.txt");
                        
                        while ((inputLine = inputMode3.ReadLine()) != null)
                        {
                            System.IO.StreamReader patternsMode3 = new System.IO.StreamReader(@Environment.CurrentDirectory + "\\patterns.txt");

                            while ((patternline = patternsMode3.ReadLine()) != null)
                            {
                                var dmp = new diff_match_patch();
                                var diffs = dmp.diff_main(inputLine, patternline);
                                if (diffs.Count == 3 && diffs[1].text.Length < 2)
                                {                                    
                                        Console.WriteLine(inputLine);
                                }
                                    
                                if (diffs.Count == 1)
                                {                                    
                                        Console.WriteLine(inputLine);
                                }
                            }
                            patternsMode3.Close();
                        }
                        
                        inputMode3.Close();
                               
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }
    }
}
