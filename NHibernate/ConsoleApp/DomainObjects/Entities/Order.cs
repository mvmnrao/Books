using System;
using System.Collections.Generic;
using System.Text;

namespace DomainObjects.Entities
{
    public class Order
    {
        private int _id;
        private string _orderNumber;
        private Customer _customer;

        public Order()
        {
        }

        public Order(Customer customer)
        {
            _customer = customer; 
        }

        public virtual int ID
        {
            get { return _id; }
            set { _id = value; } 
        }

        public virtual string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; } 
        }

        public virtual Customer Customer
        {
            get { return _customer; } 
        }

    }
}
