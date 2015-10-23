using System;

namespace DSPRJ1_1
{
    /// <summary>
    /// Student Class
    /// </summary>
    public class Student
    {
        private string m_firstName;
        private string m_lastName;
        private DateTime m_birthDate;
        private string m_city;

        /// <summary>
        /// Student ctor
        /// </summary>
        /// <param name="name">Student's first name</param>
        /// <param name="surname">Student's last name</param>
        /// <param name="birthdate">Student's birthday</param>
        /// <param name="city">Student's city</param>
        public Student(string name, string surname, DateTime birthdate, string city)
        {
            m_firstName = name;
            m_lastName = surname;
            m_birthDate = birthdate;
            m_city = city;
        }

        /// <summary>
        /// Gets Student's birth date
        /// </summary>
        public DateTime BirthDate
        {
            get { return m_birthDate; }
        }

        /// <summary>
        /// Gets Student's birth day in format dd-MM
        /// </summary>
        public string BirthDay
        {
            get { return m_birthDate.ToString("dd-MM"); }
        }

        /// <summary>
        /// Gets Student's full name
        /// </summary>
        public string FullName
        {
            get { return Utility.MakeFullName(m_firstName, m_lastName); }
        }

        /// <summary>
        /// Gets Student's City
        /// </summary>
        public string City
        {
            get { return m_city; }
        }
    }
}
