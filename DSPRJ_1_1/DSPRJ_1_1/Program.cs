using System;
using System.Linq;

namespace DSPRJ1_1
{
    class Program
    {
        public static Student[] Students;
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter N: (enter 0 for test with default values (100, 250, 1000))");
            int N = Convert.ToInt32(Console.ReadLine());

            if (N == 0)
            {
                var overlaps_N_100 = BirthdayParadoxTest(100);
                var overlaps_N_100_city = BirthdayParadoxTest(100, true);

                var overlaps_N_250 = BirthdayParadoxTest(250);
                var overlaps_N_250_city = BirthdayParadoxTest(250, true);

                var overlaps_N_1000 = BirthdayParadoxTest(1000);
                var overlaps_N_1000_city = BirthdayParadoxTest(1000);

                float sumAvg100 = 0, sumAvg250 = 0, sumAvg1000 = 0;

                Console.WriteLine("Avg table w/o city check");
                Console.WriteLine("Tests    100    250    1000");
                Console.WriteLine("------   ----   ----   -----");
                for (int i = 0; i < 10; i++)
                {
                    float avg100 = CalculateAvgOverlap(overlaps_N_100, i), avg250 = CalculateAvgOverlap(overlaps_N_250, i), avg1000 = CalculateAvgOverlap(overlaps_N_1000, i);
                    sumAvg100 += avg100;
                    sumAvg250 += avg250;
                    sumAvg1000 += avg1000;
                    Console.Write("{0:00}", i + 1);
                    Console.Write("{0, 7}", "");
                    Console.Write("{0:0.00}   ", avg100);
                    Console.Write("{0:0.00}   ", avg250);
                    Console.Write("{0:0.00}   ", avg1000);
                    Console.WriteLine();
                }
                Console.Write("Avg");
                Console.Write("{0, 6}", "");
                Console.Write("{0:0.00}   ", sumAvg100 / 10);
                Console.Write("{0:0.00}   ", sumAvg250 / 10);
                Console.Write("{0:0.00}   ", sumAvg1000 / 10);
                Console.WriteLine();
                Console.WriteLine();

                sumAvg100 = sumAvg250 = sumAvg1000 = 0;

                Console.WriteLine("Avg table w/ city check");
                Console.WriteLine("Tests    100    250    1000");
                Console.WriteLine("------   ----   ----   -----");
                for (int i = 0; i < 10; i++)
                {
                    float avg100 = CalculateAvgOverlap(overlaps_N_100_city, i), avg250 = CalculateAvgOverlap(overlaps_N_250_city, i), avg1000 = CalculateAvgOverlap(overlaps_N_1000_city, i);
                    sumAvg100 += avg100;
                    sumAvg250 += avg250;
                    sumAvg1000 += avg1000;
                    Console.Write("{0:00}", i + 1);
                    Console.Write("{0, 7}", "");
                    Console.Write("{0:0.00}   ", avg100);
                    Console.Write("{0:0.00}   ", avg250);
                    Console.Write("{0:0.00}   ", avg1000);
                    Console.WriteLine();
                }
                Console.Write("Avg");
                Console.Write("{0, 6}", "");
                Console.Write("{0:0.00}   ", sumAvg100 / 10);
                Console.Write("{0:0.00}   ", sumAvg250 / 10);
                Console.Write("{0:0.00}   ", sumAvg1000 / 10);
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Press any key to show overlap tables");
                Console.ReadKey(true);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 100 w/o City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_100, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 100 w/ City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_100_city, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 250 w/o City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_250, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 250 w/ City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_250_city, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 1000 w/o City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_1000, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = 1000 w/ City check (Table {0})", i + 1);
                    Console.WriteLine();
                    PrintOverlaps(overlaps_N_1000_city, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

            }
            else
            {
                var overlaps = BirthdayParadoxTest(N);

                Console.WriteLine("Avg table w/o city check");
                Console.WriteLine("Tests    N = {0}", N);
                Console.WriteLine("------   -------");
                float sumAvg = 0;
                for (int i = 0; i < 10; i++)
                {
                    float avg = CalculateAvgOverlap(overlaps, i);
                    sumAvg += avg;
                    Console.Write("{0:00}", i + 1);
                    Console.Write("{0, 7}", "");
                    Console.Write("{0:0.00}", avg);
                    Console.WriteLine();
                }

                Console.Write("Avg");
                Console.Write("{0, 6}", "");
                Console.Write("{0:0.00}   ", sumAvg / 10);
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Press any key to show overlap tables");
                Console.ReadKey(true);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = {1} w/o City check (Table {0})", i + 1, N);
                    Console.WriteLine();
                    PrintOverlaps(overlaps, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }

                overlaps = BirthdayParadoxTest(N, true);

                Console.WriteLine("Avg table w/ city check");
                Console.WriteLine("Tests    N = {0}", N);
                Console.WriteLine("------   -------");
                sumAvg = 0;
                for (int i = 0; i < 10; i++)
                {
                    float avg = CalculateAvgOverlap(overlaps, i);
                    sumAvg += avg;
                    Console.Write("{0:00}", i + 1);
                    Console.Write("{0, 7}", "");
                    Console.Write("{0:0.00}", avg);
                    Console.WriteLine();
                }

                Console.Write("Avg");
                Console.Write("{0, 6}", "");
                Console.Write("{0:0.00}   ", sumAvg / 10);
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Press any key to show overlap tables");
                Console.ReadKey(true);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Overlap result table for N = {1} w/ City check (Table {0})", i + 1, N);
                    Console.WriteLine();
                    PrintOverlaps(overlaps, i);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to show next table");
                    Console.ReadKey(true);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Birthday paradox test itself
        /// </summary>
        /// <param name="N">Student count</param>
        /// <param name="checkCity">if true, only counts as overlap when same city too</param>
        /// <returns>Overlap result with jagged array</returns>
        public static int[][][] BirthdayParadoxTest(int N, bool checkCity = false)
        {
            int[][][] Overlaps = new int[10][][];

            for (int i = 0; i < 10; i++)
            {
                Overlaps[i] = new int[12][];
                for (int j = 0; j < 12; j++)
                    Overlaps[i][j] = new int[DateTime.DaysInMonth(1200, j + 1)]; //selected 1200 cuz 1200 is leap year

                Students = new Student[N];
                FillStudentArray(N);

                foreach (var overlap in Students.GroupBy(p => p.BirthDay + (checkCity ? "-" + p.City : String.Empty)).Where(q => q.Count() > 1).Select(r => r))
                {
                    string[] str = overlap.Key.Split('-');
                    int day = Convert.ToInt32(str[0]);
                    int month = Convert.ToInt32(str[1]);
                    Overlaps[i][month - 1][day - 1] = overlap.Any() ? overlap.Count() - 1 : 0;

                    //Console.WriteLine("Overlap in try {0}, birth date {1}, city {3}, overlap count {2}", i, overlap.Key, Overlaps[i][month - 1][day - 1], checkCity ? str[2] : "-");
                }
            }

            return Overlaps;
        }

        /// <summary>
        /// Fills student array with random birthdates
        /// </summary>
        /// <param name="N">Student count</param>
        public static void FillStudentArray(int N)
        {
            for (int i = 0; i < N; i++)
                Students[i] = new Student(null, null, Utility.GetRandomBirthdate(), Utility.GetRandomCityName());
        }

        /// <summary>
        /// Prints overlap results as table
        /// </summary>
        /// <param name="Overlaps">Overlap result which returned from BirthdayParadoxTest</param>
        /// <param name="tryNum">Test number (1-10)</param>
        public static void PrintOverlaps(int[][][] Overlaps, int tryNum)
        {
            Console.Write("Months ");
            for (int i = 0; i < 31; i++)
                Console.Write("{0:00} ", i + 1);
            Console.WriteLine();

            Console.Write("------ ");
            for (int i = 0; i < 31; i++)
                Console.Write("-- ");
            Console.WriteLine();

            for (int i = 0; i < 12; i++)
            {
                Console.Write("{0:00} ", i + 1);
                Console.Write("{0, 4}", "");
                for (int j = 0; j < 31; j++)
                {
                    if (j >= Overlaps[tryNum][i].Length)
                        Console.Write("{0, 2}", "-");
                    else
                    {
                        if (Overlaps[tryNum][i][j] > 0)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkGreen; //feels like matrix

                        Console.Write("{0, 2} ", Overlaps[tryNum][i][j]);

                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Calculates average overlap count
        /// </summary>
        /// <param name="overlaps">Overlap result which returned from BirthdayParadoxTest</param>
        /// <param name="testNum">Test number (1-10)</param>
        /// <returns>Average overlap count</returns>
        public static float CalculateAvgOverlap(int[][][] overlaps, int testNum)
        {
            int sumOverlap = 0;
            for (int i = 0; i < 12; i++)
                sumOverlap += overlaps[testNum][i].Sum(p => p);
            return sumOverlap / 365f;
        }
    }
}