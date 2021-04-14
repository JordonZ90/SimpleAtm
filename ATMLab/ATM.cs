using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLab
{
    class ATM
    {
        public static List<Account> Accounts = new List<Account>();

        public Account CurrentAccount { get; set; }


        public void Register (string name, string password)
        {
            Account account = new Account(); // creating an account obj
            account.Name = name;
            account.Password = password;
            Accounts.Add(account);

        }

        public void Login(string username, string password)
        {
            if(CurrentAccount == null)
            {
                foreach (Account account in Accounts)
                {
                    if (account.Name == username && account.Password == password)
                    {
                        CurrentAccount = account;
                    }
                }
            }
            else
            {
                Console.WriteLine("User is logged in! ");
            }
        }
        public void Logout()
        {
            CurrentAccount = null;
        }
        public void CheckBalance()
        {
            Console.WriteLine($"{CurrentAccount.Balance}"); // culture info formatting : C2}
        }
        public void Deposit(double value) // or int value
        {
            CurrentAccount.Balance += value;
        }
        public void Withdraw(double value) // or int value
        {
            if (CurrentAccount.Balance - value > 0) // checking to make sure they have more than 0 dollars
            {
                CurrentAccount.Balance -= value;
            }
            else
            {
                Console.WriteLine("Not enough money yo! ");
            }
        }
    }
}
