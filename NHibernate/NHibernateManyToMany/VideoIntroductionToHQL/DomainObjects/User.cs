using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace DomainObjects
{
    public class User : DomainBase
    {
      
        private string _firstName;
        private string _lastName;
        private IList<Exam> _exams = new List<Exam>();
        private Exam _exam;

        public User() { }
      
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public IList<Exam> Exams
        {
            get { return _exams; }
            set { _exams = value; }
        }

        public Exam Exam
        {
            get { return _exam; }
            set { _exam = value; }
        }

        public void AddExam(Exam exam)
        {
            if (_exams.Contains(exam)) return;

            _exams.Add(exam);
           
            exam.User = this; 
        }
    }
}
