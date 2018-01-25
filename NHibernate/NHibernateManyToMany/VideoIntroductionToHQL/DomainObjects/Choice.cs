using System;
using System.Collections.Generic;
using System.Text;

namespace DomainObjects
{
    public class Choice : DomainBase
    {
       
        private string _text;
        private bool _isCorrect;
        private Question _question = new Question(); 

        public Choice() { } 

        public Choice(string text,bool isCorrect) 
        {
            _text = text; 
            _isCorrect = IsCorrect; 
        }     

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        public Question Question
        {
            get { return _question; }
            set { _question = value; } 
        }

       

       
    }
}
