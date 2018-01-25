using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace DomainObjects
{
    public class Question : DomainBase
    {
       
        private string _text;
        private double _point;
        private Exam _exam = new Exam();
        private IList<Choice> _choices = new List<Choice>();

        public Question(Exam exam)
        {
            _exam = exam; 
        }

        public Question() { }    

        public Question(string text, double point)
        {
            _text = text;
            _point = point; 
        }      

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public double Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public Exam Exam
        {
            get { return _exam; }
            set { _exam = value; } 
        }

        public IList<Choice> Choices
        {
            get { return new ReadOnlyCollection<Choice>(_choices); } 
        }

        public void AddChoice(Choice choice)
        {
            if (_choices.Contains(choice)) return;

            _choices.Add(choice);

            choice.Question = this; 
        }

    }
}
