using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1lab9b
{
    public class StudentCardReport
    {

        public event EventHandler Passing;
        private List<Subject> listOfSubjects;
        public List<Subject> ListOfSubjects
        {
            get
            {
                return new List<Subject>(listOfSubjects);
            }
            set
            {
                var list  = value??new List<Subject>();

                listOfSubjects= new List<Subject>(list);
            }

        }
        public StudentCardReport(List<Subject> subjects )
        {
            ListOfSubjects = subjects;
        }

        public void ProcessReport()
        {
            foreach (var subject in listOfSubjects)
            {
                var avg = subject.Grades.Average();
                    if (avg >=75)
                    {   // fire Passing event
                        Passing?.Invoke(this, subject);
                    }
                }
            }
        }
    }
}
