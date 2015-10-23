using System;
using System.Collections.Generic;

namespace DSPRJ1_2
{
    /// <summary>
    /// Lesson class
    /// </summary>
    public class Lesson : List<Student>
    {
        public string m_Name;

        public Lesson(string name, int max)
            : base (max)
        {
            m_Name = name;
        }

        public bool IsRegisterable
        {
            get { return this.Count < this.Capacity; }
        }
    }
}
