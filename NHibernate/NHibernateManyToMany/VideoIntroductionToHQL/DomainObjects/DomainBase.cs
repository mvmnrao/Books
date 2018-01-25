using System;
using System.Collections.Generic;
using System.Text;

namespace DomainObjects
{
    public class DomainBase
    {
        private int _id;
        private bool _isValid;

        public int Id
        {
            get { return _id; } 
        }

        protected virtual bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; } 
        }
    }
}
