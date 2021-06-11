using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            int incr = 0;

            args = new string[1];
            Console.WriteLine("Enter argument below: ");
            args[0] = Console.ReadLine();

            Dictionary<PeriodStatus, List<DateTime>> timePeriodListsDict = new Dictionary<PeriodStatus, List<DateTime>>();

            if (args != null && args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    timePeriodListsDict.Add(PeriodStatus.Start, new List<DateTime>());
                    timePeriodListsDict.Add(PeriodStatus.End, new List<DateTime>());

                    string[] timeTempAr = File.ReadAllLines(args[0]);
                    foreach (string timePeriod in timeTempAr)
                    {
                        if (timePeriod == "")
                        {
                            continue;
                        }
                        else
                        {
                            var timePeriodSplit = timePeriod.Split();

                            string valueNoN = String.Empty;
                            for (int j = 0; j < timePeriod.Length; j++)
                            {
                                if (Char.IsDigit(timePeriod[j]))
                                    valueNoN += timePeriod[j];
                                else if (timePeriod[j] == '.')
                                    valueNoN += ".";
                            }

                            var timePeriodStartSplit = timePeriodSplit[0].Split(':');
                            var timePeriodEndSplit = timePeriodSplit[1].Split(':');

                            timePeriodListsDict[PeriodStatus.Start].Add(new DateTime(2000, 1, 1,
                                int.Parse(timePeriodStartSplit[0]),
                                int.Parse(timePeriodStartSplit[1]), 0));

                            timePeriodListsDict[PeriodStatus.End].Add(new DateTime(2000, 1, 1,
                                int.Parse(timePeriodEndSplit[0]),
                                int.Parse(timePeriodEndSplit[1]), 0));
                        }
                    }
                }
            }

            for (int j = 0; j < timePeriodListsDict[PeriodStatus.Start].Count; j++)
            {
                for (int i = 0; i < timePeriodListsDict[PeriodStatus.Start].Count; i++)
                {
                    int rt = CompareTimeframes(timePeriodListsDict[PeriodStatus.Start][j],
                        timePeriodListsDict[PeriodStatus.End][j],
                        timePeriodListsDict[PeriodStatus.Start][i],
                        timePeriodListsDict[PeriodStatus.End][i]);
                    incr++;
                    if (rt == 1)
                        Console.WriteLine("xoba");
                    else if (rt == 3)
                        Console.WriteLine("net");
                    else
                        Console.WriteLine("da");                   
                }
            }

            Console.WriteLine(incr);
        }

        //1 - Identical periods
        //2 - Periods crosed
        //3 = Periods separate
        public static int CompareTimeframes(DateTime startTimeFirst, DateTime endTimeFirst, DateTime startTimeSecond, DateTime endTimeSecond)
        {
            if (startTimeFirst == startTimeSecond && endTimeFirst == endTimeSecond)
                return 1;

            if (startTimeFirst > endTimeSecond || endTimeFirst < startTimeSecond)
                return 3;

            if ((startTimeFirst > startTimeSecond && startTimeFirst < endTimeSecond) ||
                (endTimeFirst < endTimeSecond && endTimeFirst > startTimeSecond))
                return 2;


            return default;
        }

        public enum PeriodStatus
        {
            Start,
            End
        }

    }
}
    


          
    

    public class TimePeriod
    {
        int crossStatus;
        DateTime startTime;
        DateTime endTime;

        public int CrossStatus
        {
            get { return crossStatus; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
        }

        public TimePeriod(int status, DateTime st, DateTime et)
        {
            crossStatus = status;
            startTime = st;
            endTime = et;
        }
    }
        



