using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank_ex
{
    public class Customer:IComparable<Customer>
    {
        private static int numberOfCust=0;
        private readonly int customerID;
        private readonly int customerNumber=1;
        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
        }
        public int CustomerNumber
        {
            get
            {
                return customerNumber;
            }
        }

        public Customer(int id, string name, int phone)
        {
            //Customer c = new Customer(id, name, phone);
            customerNumber=numberOfCust;
            numberOfCust++;
            this.customerID = id;
            this.Name = name;
            this.PhNumber = phone;
        }
        public static bool operator ==(Customer c1, Customer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            if (c1.CustomerNumber==c2.CustomerNumber)
                return true;
            else
            {
                return false;
            }
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }
        public static Customer operator +(Customer c1,Customer c2)
        {
            Customer c3 = c1 + c2;
            return c3;
        }

        public override bool Equals(object obj)
        {
            Customer other = obj as Customer;
            if (ReferenceEquals(obj, null))
                return false;
            return this.CustomerNumber == other.CustomerNumber;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public int Compare(Customer x, Customer y)
        {
            throw new System.NotImplementedException();
        }

        public int CompareTo(Customer other)
        {
            if (this == other) return 1;
            else return 0;
        }
    }
}