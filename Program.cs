using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_ex
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Customer c1 = new Customer(305303893, "Tal", 0506674362);
            Customer c2 = new Customer(574654885,"Itay", 0544879985);
            Customer c3 = new Customer(556445845, "Orly", 053318457);
            Customer c4 = new Customer(125423518, "Donna", 0558865471);
            Account a1 = new Account(c1,12000,15000);
            Account a2 = new Account(c1, 8000,10000);
            Console.WriteLine($"Customer number of {c1.Name} is:{c1.CustomerNumber}");
            Console.WriteLine($"Customer number of {c2.Name} is:{c2.CustomerNumber}");
            Console.WriteLine($"Customer number of {c3.Name} is:{c3.CustomerNumber}");
            Console.WriteLine($"Customer number of {c4.Name} is:{c4.CustomerNumber}");
            if (c1 == c2) Console.WriteLine($"{c1.Name} and {c2.Name} are euqal!");
            else Console.WriteLine($"{c1.Name} and {c2.Name} arn't equal!");
            if (c1 != c2) Console.WriteLine($"{c1.Name} and {c2.Name} arn't equal!");
            Console.WriteLine($"{a1.AccountOwner.Name}'s account number is: {a1.AccountNumber} ");
            Console.WriteLine($"{a2.AccountOwner.Name}'s account number is: {a2.AccountNumber} ");
            if (a1 == a2) Console.WriteLine($"{a1.AccountOwner.Name} first account and {a2.AccountOwner.Name} second account are equal");
            else Console.WriteLine($"{a1.AccountOwner.Name } first account and {a2.AccountOwner.Name } second account and aren't equal!");
            Console.WriteLine($"{a1}");
            Account a3 = a1 + a2;
            Console.WriteLine($"{a3.AccountOwner.Name} account details:"+a3);
            
            Console.WriteLine($"first maxminus = {a1.MaxMinusAllowed} second maxminus = {a2.MaxMinusAllowed}");
            Console.WriteLine(a1);
            Console.WriteLine(a2);*/
            Customer t1 = new Customer(132456789, "Idan", 0506587548);
            Account firstAcc = new Account(t1, 12000, 35000);
            Account secAcc = new Account(t1, 14500, 6000);
            Account thirdAcc = new Account(t1, 42000, 30220);
            Account fourthAcc = new Account(t1, 10000, 4500);
            Bank Poalot = new Bank();
            Poalot.AddNewCustomer(t1);
            
            Poalot.OpenNewAccount(firstAcc, t1);
            Console.WriteLine($"{firstAcc.AccountOwner.Name}"); //works
            Poalot.OpenNewAccount(secAcc, t1);
            Console.WriteLine($"{secAcc.AccountOwner.Name}");
            Poalot.OpenNewAccount(thirdAcc, t1);
            Console.WriteLine($"{thirdAcc.AccountOwner.Name}");
            Console.WriteLine(Poalot.CustomerCount);
            Console.WriteLine(Poalot.numberOfAccounts);
            Console.WriteLine($"{Poalot.GetCustomerByID(t1.CustomerID).Name}");
            Console.WriteLine($"{Poalot.GetCustomerTotalBalance(t1)}");


        }
    }
}
