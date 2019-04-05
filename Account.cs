using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank_ex
{
    public class Account
    {
        private static int numberOfAcc=1;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public float Balance { get; private set; }
        public Customer AccountOwner
        {
            get
            {
                return this.accountOwner;
            }
        }
        public int MaxMinusAllowed
        {
            get
            {
                return this.maxMinusAllowed;
            }
        }
        public Account(Customer c1,int monthlyincome,float balance)
        {
            //Account a = new Account(c1,monthlyincome);
            accountNumber=numberOfAcc;
            numberOfAcc++;
            this.accountOwner = c1;
            this.maxMinusAllowed = (3 * monthlyincome)*-1;
            this.Balance = balance;
        }
        public void Add(int amount)
        {
            this.Balance += amount;
        }
        public void Subtract(float amount)
        {
            this.Balance -= amount;
        }
        public static bool operator ==(Account a1, Account a2)
        {
            if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null))
                return true;
            if (ReferenceEquals(a1, null) || ReferenceEquals(a2, null))
                return false;
            if (a1.AccountNumber==a2.AccountNumber)
                return true;
            else
            {
                return false;
            }
        }
        public static bool operator !=(Account a1, Account a2)
        {
            return !(a1 == a2);
        }
        public override bool Equals(object obj)
        {
            Account other = obj as Account;
            if (ReferenceEquals(obj, null))
                return false;
            return this.AccountNumber == other.AccountNumber;
        }
        public override int GetHashCode()
        {
            return this.AccountNumber;
        }
        public static Account operator +(Account a1, Account a2)
        {   
            Account a3 = new Account(a1.accountOwner,a1.maxMinusAllowed/3+ a2.maxMinusAllowed / 3, a1.Balance + a2.Balance);
            return a3;
        }
        public override string ToString()
        {
            return $"Account owner's name:{this.accountOwner.Name}\nPossible minus allowed: {MaxMinusAllowed}";
        }
    }
}