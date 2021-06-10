using System;
using System.Collections.Generic;
using System.IO;

namespace task2
{

    class Point
    {
        float X;
        float Y;

        public float Xcord
        {
            get { return X; }
        }

        public float Ycord
        {
            get { return Y; }
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            args = new string[2];
            Console.WriteLine("Enter arguments below: ");
            args[0] = Console.ReadLine();
            args[1] = Console.ReadLine();
            Console.ReadKey();                      


            Dictionary<int, Point> heightsDict = new Dictionary<int, Point>();
            Dictionary<int, Point> pointsDict = new Dictionary<int, Point>();

            if (args != null && args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    string[] heights = File.ReadAllLines(args[0]);
                    int increment = 0;
                    foreach(string height in heights)
                    {
                        var value = height.Split();
                        if (float.TryParse(value[0], out float textToFloatValue1) && float.TryParse(value[1], out float textToFloatValue2))
                        {
                            heightsDict.Add(increment, new Point(textToFloatValue1, textToFloatValue2));
                        }
                        increment++;
                    }

                }

                if (File.Exists(args[1]))
                {
                    string[] points = File.ReadAllLines(args[1]);
                    int increment = 0;
                    foreach (string point in points)
                    {
                        var value = point.Split();
                        if (float.TryParse(value[0], out float textToFloatValue1) && float.TryParse(value[1], out float textToFloatValue2))
                        {
                            pointsDict.Add(increment, new Point(textToFloatValue1, textToFloatValue2));
                        }
                        increment++;
                    }

                }
            }

            for(int i = 0; i < pointsDict.Keys.Count; i++)
            {
                string tempString = LocatePoint(heightsDict, pointsDict[i]);
                Console.WriteLine(tempString + "\n");
            }
            Console.ReadKey();
        }


        static String LocatePoint(Dictionary<int, Point> heightsDict, Point point)
        {
            for (int i = heightsDict.Keys.Count - 1; i >= 0 ; i--)
            {
                if(point.Xcord == heightsDict[i].Xcord && point.Ycord == heightsDict[i].Ycord)
                {
                    return "0";
                }

                float A = 0, B = 0, C = 0;
                if (i != 0)
                {
                    A = -Subtract(heightsDict[i - 1].Ycord, heightsDict[i].Ycord);
                    B = Subtract(heightsDict[i - 1].Xcord, heightsDict[i].Xcord);
                    C = -(A * heightsDict[i].Xcord + B * heightsDict[i].Ycord);
                }
                else if(i == 0)
                {
                    A = -Subtract(heightsDict[heightsDict.Count - 1].Ycord, heightsDict[i].Ycord);
                    B = Subtract(heightsDict[heightsDict.Count - 1].Xcord, heightsDict[i].Xcord);
                    C = -(A * heightsDict[i].Xcord + B * heightsDict[i].Ycord);
                }

                float D = A * point.Xcord + B * point.Ycord + C;
                if (D > 0)
                {
                    continue;
                }
                if(D < 0)
                {
                    return "3";
                }
                if(D == 0)
                {
                    return "1"; ;
                }
            }

            return "2";
        }

        static float Subtract(float value1, float value2)
        {
            float result = value1 - value2;
            return result;
        }
        
    }
}
