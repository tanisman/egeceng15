using System;

namespace DSPRJ1_2
{
    /// <summary>
    /// Utility Class
    /// </summary>
    public static class Utility
    {
        private static readonly Random rnd = new Random();
        private static readonly string[] firstNames = new[] { "Ahmet", "Mehmet", "Ayşe", "Ali", "Fatma", "Hayriye", "Emin", "Emine", "Nuri", "Nuriye", "Cemil", "Alper", "Emre", "Bogac", "Veli" };
        private static readonly string[] lastNames = new[] { "Demir", "Kur", "Say", "Yarbas", "Varli", "Uzunirmak", "Uz", "Uzun", "Urganci", "Turul", "Torol", "Su", "Seyfi", "Sever", "Palut" };
        private static readonly string[] cityNames = new[] { "Istanbul", "New York", "Berlin" };

        /// <summary>
        /// Gets Random First Name from array defined in source
        /// </summary>
        /// <returns>A random first name</returns>
        public static string GetRandomFirstName()
        {
            return firstNames[rnd.Next(0, 15)];
        }

        /// <summary>
        /// Gets Random Last Name from array defined in source
        /// </summary>
        /// <returns>A random last name</returns>
        public static string GetRandomLastName()
        {
            return lastNames[rnd.Next(0, 15)];
        }

        /// <summary>
        /// Gets Random City Name from array defined in source
        /// </summary>
        /// <returns>A random city name</returns>
        public static string GetRandomCityName()
        {
            return cityNames[rnd.Next(0, 3)];
        }

        /// <summary>
        /// Gets Random Birth Date between year 1990 - 1998
        /// </summary>
        /// <returns>A random birth date in DateTime format</returns>
        public static DateTime GetRandomBirthdate()
        {
            int year = rnd.Next(1990, 1999);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Makes full name from first & last name
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <returns>Full name in format firstname lastname</returns>
        public static string MakeFullName(string firstName, string lastName)
        {
            return String.Format("{0} {1}", firstName, lastName);
        }
    }
}
