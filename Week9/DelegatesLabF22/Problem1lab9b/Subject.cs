using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Problem1lab9b
{
    public class Subject:EventArgs
    {
        private int[] grades;
        public const int MAX_GRDES = 150;

        public Subject(int[] grades, string title)
        {
            Grades = grades;
            Title = title;
             
        }

        public string Title
        {
            get;
            set;
        }
        public int[] Grades
        {
            get
            {
                int[] temp = new int[grades.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = grades[i];
                }
                return temp;
            }
            set
            {
                grades = value?? new int[0];
                for (int i = 0; i < grades.Length; i++)
                {
                    grades[i] = value![i];
                }
            }
        }

        public override string ToString()
        {
            return $"Subject: {Title}\n" +
                   $"Grades:{string.Join(", ", grades)}";
        }

    }
}
