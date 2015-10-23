using System;
using System.Linq;

namespace DSPRJ1_2
{
    class Program
    {
        static Lesson[] Lessons;
        static Student[] Students;
        static void Main(string[] args)
        {
            FillLessonArray();

            Console.WriteLine("Enter N (1-36): ");
            int N = Convert.ToInt32(Console.ReadLine());

            while(N < 1 || N > 36)
            {
                Console.WriteLine("Enter N (1-36): ");
                N = Convert.ToInt32(Console.ReadLine());
            }

            FillStudentArray(N);
            GiveStudentsLessons(N);
            PrintMatchTable();

            Console.ReadLine();
        }

        /// <summary>
        /// Fills lesson array
        /// </summary>
        static void FillLessonArray()
        {
            Lessons = new Lesson[10];
            Lessons[0] = new Lesson("Genetik Algoritmalar", 4);
            Lessons[1] = new Lesson("Bulanik Mantik", 4);
            Lessons[2] = new Lesson("Makine Ogrenmesi", 4);
            Lessons[3] = new Lesson("Ongoruye Dayali Analitik", 4);
            Lessons[4] = new Lesson("Zeki Sistemler", 4);
            Lessons[5] = new Lesson("Uzman Sistemler", 4);
            Lessons[6] = new Lesson("Dogal Dil Isleme", 3);
            Lessons[7] = new Lesson("Robotbilimde Yapay Zeka", 3);
            Lessons[8] = new Lesson("Veri Madenciligi", 3);
            Lessons[9] = new Lesson("Karinca Kolonisi Algoritmalari", 3);
        }

        /// <summary>
        /// Fills student array with random names & surnames
        /// </summary>
        /// <param name="N">Student count</param>
        static void FillStudentArray(int N)
        {
            Students = new Student[N];

            for (int i = 0; i < N; i++)
            {
                string name = Utility.GetRandomFirstName();
                string surname = Utility.GetRandomLastName();

                while (Students.Any(p => p != null && p.FullName == Utility.MakeFullName(name, surname))) //check name overlaps
                {
                    name = Utility.GetRandomFirstName();
                    surname = Utility.GetRandomLastName();
                }

                Students[i] = new Student(name, surname, DateTime.Now, null);
            }
        }

        static void GiveStudentsLessons(int N)
        {
            int nextLessonToGive = 0;

            for (int i = 0; i < N; i++)
            {
                if (nextLessonToGive >= 10)
                    nextLessonToGive = 0;

                if (Lessons[nextLessonToGive].IsRegisterable)
                    Lessons[nextLessonToGive].Add(Students[i]);

                nextLessonToGive++;
            }
        }

        static void PrintMatchTable()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[*]Lesson: {0} (Registered {1} of {2})", Lessons[i].m_Name, Lessons[i].Capacity, Lessons[i].Count);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("=>Registered Students: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                foreach (var it in Lessons[i])
                    Console.WriteLine("->{0}", it.FullName);

                Console.WriteLine();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
