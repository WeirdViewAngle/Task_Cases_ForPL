using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[5];
            Console.WriteLine("Enter argument path below: ");
            args = Directory.GetFiles(Console.ReadLine());

            Dictionary<CashNum, List<float>> cashTimings = new Dictionary<CashNum, List<float>>();

            if (args != null && args.Length > 0)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (File.Exists(args[i]))
                    {
                        string[] valuesTempAr = File.ReadAllLines(args[i].Trim('\n'));
                        cashTimings.Add((CashNum)i, new List<float>());
                        foreach (string value in valuesTempAr)
                        {
                            if (value == "" || value == null)
                            {
                                continue;
                            }
                            else
                            {
                                if (float.TryParse(value, out float textToFloatValue))
                                {
                                    cashTimings[(CashNum)i].Add(textToFloatValue);
                                }

                            }
                        }
                    }
                }                
            }
            foreach (CashNum key in cashTimings.Keys)
            {
                int index = 0;
                float tempVar = 0;
                foreach (float item in cashTimings[key])
                {                    
                    if (item > tempVar)
                    {
                        tempVar = item;
                        index = cashTimings[key].IndexOf(item);
                    }
                }                

                Console.WriteLine(index + "\n");
            }
            Console.ReadKey();
        }

        public enum CashNum
        {
            Cash1,
            Cash2,
            Cash3,
            Cash4,
            Cash5
        }
    }
}
