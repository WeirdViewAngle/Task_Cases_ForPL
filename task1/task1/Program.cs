using System;
using System.Collections.Generic;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[1];
            Console.WriteLine("Enter arguments below: ");
            args[0] = Console.ReadLine();


            //taking arg
            List<decimal> numValues = new List<decimal>();
            if (args != null && args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    foreach (string line in lines)
                    {
                        if (decimal.TryParse(line, out decimal textToDecimalValue))
                        {
                            numValues.Add((textToDecimalValue));
                        }
                    }
                }
            }
            
            //convert to array
            decimal[] readyNumbers = numValues.ToArray();

            Console.WriteLine(PercentileCalc(readyNumbers, 0.9f).ToString("n2") + "\n");
            Console.WriteLine(MedianCalc(readyNumbers).ToString("n2") + "\n");
            Console.WriteLine(MaxValue(readyNumbers).ToString("n2") + "\n");
            Console.WriteLine(MinValue(readyNumbers).ToString("n2") + "\n");
            Console.WriteLine(AverageValue(readyNumbers).ToString("n2") + "\n");
            Console.ReadKey();
        }

        static decimal PercentileCalc(decimal[] parseValues, float percent)
        {
            float rank = percent * parseValues.Length;
            return parseValues[(int)rank];
        }

        static decimal MedianCalc(decimal[] parseValues)
        {
            Array.Sort(parseValues);
            decimal medianResult;
            if (parseValues.Length % 2 == 0)
            {
                decimal midValue1 = parseValues[(parseValues.Length / 2) - 1];
                decimal midValue2 = parseValues[(parseValues.Length / 2)];
                medianResult = (midValue1 + midValue2) / 2;
            }
            else
            {
                medianResult = parseValues[parseValues.Length / 2];
            }

            return medianResult;
        }

        static decimal MaxValue(decimal[] parseValues)
        {
            decimal maxValue = Int16.MinValue;
            for(int i = 0; i < parseValues.Length; i++)
            {
                if (parseValues[i] > maxValue)
                    maxValue = parseValues[i];
            }
            return maxValue;
        }

        static decimal MinValue(decimal[] parseValues)
        {
            decimal minValue = Int16.MaxValue;
            for (int i = 0; i < parseValues.Length; i++)
            {
                if (parseValues[i] < minValue)
                    minValue = parseValues[i];
            }
            return minValue;
        }

        static decimal AverageValue(decimal[] parseValues)
        {
            decimal result = 0;
            foreach (decimal value in parseValues)
            {
                result += value;
            }
            return result / parseValues.Length;
        }

        
    }
}
