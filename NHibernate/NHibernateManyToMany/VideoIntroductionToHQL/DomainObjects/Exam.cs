using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using DomainObjects.Managers;

namespace DomainObjects
{
    public class Exam : DomainBase
    {        
        private string _title;
                       
        private IList<Question>  _questions = new List<Question>();
        private IList<User> _users = new List<User>(); 
        private User _user;
        private Grade _grade = new Grade();

        public string Title
        {
            get { return _title; }
            set { _title = value; } 
        }

        public void AddQuestion(Question question)
        {
            if (_questions.Contains(question)) return;

            _questions.Add(question);

            question.Exam = this; 
        }

        public void RemoveQuestion(Question question)
        {
            _questions.Remove(question);
            question.Exam = null; 
        }

        public double TotalPoint
        {
            get
            {
                double sum = 0.0;
                IEnumerator<Question> enumerator = _questions.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    sum += enumerator.Current.Point;
                }

                return sum; 
            }
        }
      
        public IList<Question> Questions
        {
            get { return new ReadOnlyCollection<Question>(_questions); }           
        }

        public virtual IList<User> Users
        {
            get {

                return _users;             
            }

            set { _users = value; }
        }

        public void AddUser(User user)
        {
            if (_users.Contains(user)) return;

            _users.Add(user);

            user.Exam = this; 
        }

        public void AddGrade(Grade grade)
        {
            _grade = grade;

            _grade.Exam = this; 
        }

        public User User
        {
            get { return _user; }
            set {               
                _user = value; }
        }

        public Grade Grade
        {
            get {
              
                return _grade;
            
            }
            set { _grade = value; } 
        }

        protected override bool IsValid
        {
            get
            {
                return (_questions.Count > 0); 
            }
            set
            {
                base.IsValid = value;
            }
        }
    }
}
