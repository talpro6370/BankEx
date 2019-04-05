using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bank_ex
{
    public class Bank : IBank
    {
        private List<Account> accList;
        private List<Customer> custList;
        public int numberOfAccounts=0;
        private Dictionary<int, Customer> CustomerIdDic = new Dictionary<int, Customer>(); // CuscusttmerID
        private Dictionary<int, Customer> CustomerNumDic = new Dictionary<int, Customer>(); // CustomerNumber
        private Dictionary<int, Account> accNumDic = new Dictionary<int, Account>(); // AccountNumber
        private Dictionary<Customer, Account> AccDicByCust = new Dictionary<Customer, Account>();
        private Dictionary<Customer, List<Account>> AccountListsDic = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private float profits;
        public string Name { get;private set; }
        public string Address { get; private set; }
        public int CustomerCount
        {
            get
            {
                return this.custList.Count();
            }
            set
            {
                
            }
        }
        public Bank()
        {
            accList = new List<Account>();
            custList = new List<Customer>();
            
            
        }
        internal Customer GetCustomerByID(int customerId)
        {
            if (CustomerIdDic.TryGetValue(customerId, out Customer res) == true)
                return res;
            return null;
        }
        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (CustomerNumDic.TryGetValue(customerNumber, out Customer res) == true)
                return res;
            return null;
        }
        internal Account GetAccountByNumber(int AccountNumber)
        {
            if (accNumDic.TryGetValue(AccountNumber, out Account res) == true)
                return res;
            return null;
        }
        internal List<Account> GetAccountsByCustomer(Customer c)
        {
            if (AccountListsDic.TryGetValue(c, out List<Account> res) == true)
                return res;
            return null;
        }
        internal bool AddNewCustomer(Customer c)
        {
            try
            {
                int count1 = 0, count2 = 0;
                count1 = custList.Count();
                if (custList.Contains(c)||CustomerIdDic.ContainsKey(c.CustomerID)||CustomerNumDic.ContainsKey(c.CustomerNumber))
                    throw new CustomerAlrdyExistException("This customer is alrdy exist in list.");
                custList.Add(c);
                count2 = custList.Count();
                CustomerIdDic.Add(c.CustomerID, c);
                CustomerNumDic.Add(c.CustomerNumber, c);
                CustomerCount++;
                if (count1 < count2) return true;
                return false;
            }
            catch (CustomerAlrdyExistException cu)
            {
                Console.WriteLine(cu.Message);
            }
            return false;
        }
        internal void OpenNewAccount(Account a,Customer c)
        {

            
            accNumDic.Add(a.AccountNumber,a);
            AccountListsDic.TryGetValue(c, out List<Account> Accoks);
            if (Accoks==null)
            Accoks = new List<Account>();
            Accoks.Add(a);
            if(AccountListsDic.ContainsKey(c) && GetAccountsByCustomer(c)!=null)
            {
                accList.Add(a);
            }
            if (AccountListsDic.ContainsKey(c) && AccountListsDic.Count()==0)
            {
                accList.Add(a);
            }
            if (AccountListsDic.ContainsKey(c) && GetAccountsByCustomer(c) == null)
            {
                accList = new List<Account>();
            }
            AccountListsDic.Add(c, Accoks);
            numberOfAccounts++;
        }
        internal float Deposit(Account a, int amount)
        {
            try
            {
                if (amount > 0)
                {
                    a.Add(amount);
                    this.totalMoneyInBank += amount;
                }
                if (a.Balance < a.MaxMinusAllowed)
                    throw new BalanceException("There is no more balance in this account!!");
                if (amount < 0)
                    throw new AmountIsLessThanZeroException("Less than zero");
            }
            catch(AmountIsLessThanZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"The stack trace is here:\n{ex.StackTrace}");
            }
            catch (BalanceException b)
            {
                Console.WriteLine(b.Message);
                Console.WriteLine($"The stack trace is here:\n{b.StackTrace}");
            }
            return a.Balance; // returning the updated balance in this account.
        }
        internal float WithDraw(Account a, int amount)
        {
            try
            {
                if (amount > 0)
                {
                    a.Subtract(amount);
                    this.totalMoneyInBank -= amount;
                }
                if (a.Balance < a.MaxMinusAllowed)
                    throw new BalanceException("There is no more balance in this account!!");
                if (amount < 0)
                    throw new AmountIsLessThanZeroException("Less than zero");
            }
            catch (AmountIsLessThanZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"The stack trace is here:\n{ex.StackTrace}");
            }
            catch (BalanceException b)
            {
                Console.WriteLine(b.Message);
                Console.WriteLine($"The stack trace is here:\n{b.StackTrace}");
            }
            return a.Balance;
        }
        internal float GetCustomerTotalBalance(Customer c)
        {
            try
            {
                if (c == null)
                    throw new ArgumentNullException("Customer was NULL!!");
                float result = 0;
                
                AccountListsDic.TryGetValue(c, out List<Account> acc);
                if(acc==null)
                acc = new List<Account>();
              
                acc.ForEach(m => result+=m.Balance);
                
                return result;
            }
            catch(ArgumentNullException d)
            {
                Console.WriteLine(d.Message);
            }
            return 0;
        }
        internal void CloseAccount(Account a,Customer c)
        {
            accList.Remove(a);
            AccountListsDic.Remove(c);
            
        }
        internal void ChargeAnnualCommission(float percentage)
        {
            for (int i = 0; i < accList.Count(); i++)
            {
                if (accList[i].Balance < 0)
                {
                    accList[i].Subtract((percentage * accList[i].Balance / 100)*2);
                    profits += (percentage * accList[i].Balance / 100)*2;
                }
                accList[i].Subtract((percentage * accList[i].Balance / 100));
            }
        }
        internal void JoinAccounts(Account a1,Account a2)
        {
            Account a3 = a1 + a2;
            accList.Remove(a1);
            accList.Remove(a2);
            AccountListsDic.Remove(a1.AccountOwner);
            AccountListsDic.Remove(a2.AccountOwner);
            accNumDic.Remove(a1.AccountNumber);
            accNumDic.Remove(a2.AccountNumber);
            accList.Add(a3);
            accNumDic.Add(a3.AccountNumber, a3);    
        }
        public override string ToString()
        {
            
           // Console.WriteLine($"{this.Name} has {this.accList.Count()} accounts:");
            foreach (Account item in accList)
            {
                Console.WriteLine($"account number:{item.AccountNumber,1}      Balance:{item.Balance}      Max minus allowed:{item.MaxMinusAllowed}");
            }
            return null;
        }
    }
    interface IBank
    {
        string Name { get; }
        string Address { get; }
        int CustomerCount { get; }
    }
}
