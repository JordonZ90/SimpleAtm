using System;

namespace ATMLab
{
    class Program
    {
        static void Main(string[] args)
        {
            AtmGreetingAndLogic();
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void AtmGreetingAndLogic()
        {
            ATM atm = new ATM(); // have to create the atm object NON Static methods MUST be tied to an object
            string name, password;

            // need the object to use the non static method
            Console.WriteLine("Welcome to the crappy atm! ");
            Console.WriteLine("Please register "); // testing the functionaility of the classes

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Password: ");
            password = Console.ReadLine();

            atm.Register(name, password); // repalce with the GetUserInput
            Console.WriteLine("Please Login ");

            name = GetUserInput("Enter Username: ");
            password = GetUserInput("Enter password please ");

            atm.Login(name, password);

            //atm.Register(GetUserInput("Enter Name: "), GetUserInput("Enter password: "));
            while (true)
            {

                if (atm.CurrentAccount != null) // then we know someone is logged in
                {

                    //display a menu
                    Menu();

                    string response = GetUserInput("Make a selection: ");
                    // 1. checkbalance
                    if (response == "1")
                    {
                        atm.CheckBalance();
                    }

                    // 2. deposit
                    if (response == "2")
                    {
                        Console.WriteLine("How much would you like to deposit? ");
                        double depositedAmount = Convert.ToDouble(Console.ReadLine());
                        atm.Deposit(depositedAmount);
                        Console.WriteLine($"You deposited {depositedAmount}");
                        atm.CheckBalance();
                    }

                    // 3 Withdraw
                    if (response == "3")
                    {
                        Console.WriteLine("How much would you like to withdraw? ");
                        double withdrawnAmount = Convert.ToDouble(Console.ReadLine());
                        atm.Withdraw(withdrawnAmount);
                        Console.WriteLine($"You withdrew {withdrawnAmount}");
                        atm.CheckBalance();
                    }
                    if (response == "4")
                    {
                        Console.WriteLine("Exiting the program");
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1. Check Balance ");
            Console.WriteLine("2. Deposit ");
            Console.WriteLine("3. Withdraw ");
            Console.WriteLine("4. Exit ");
        }
    }
}
