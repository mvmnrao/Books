using System;
using System.Collections.Generic;
using System.Text;

namespace DomainObjects.Entities
{
    public class Customer
    {  
        private int _id;
        private string _firstName;
        private string _lastName;

      
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }

        }

        public virtual string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; } 
        }

        public virtual string LastName
        {
            get { return _lastName; }
            set { _lastName = value; } 
        }

               
    }
}
