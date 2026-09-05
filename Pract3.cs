using System;
using System.Collections.Generic;

class Expense
{
    public string Category;
    public double Amount;
    public DateTime Date;

    public Expense(string category, double amount, DateTime date)
    {
        Category = category;
        Amount = amount;
        Date = date;
    }
}

class Program
{
    static List<Expense> expenseList = new List<Expense>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n========== Expense Tracking System ==========");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Total Expense");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    AddExpense();
                }
                else if (choice == 2)
                {
                    ShowExpenses();
                }
                else if (choice == 3)
                {
                    ShowTotalExpense();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Thank you for using the Expense Tracking System.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Only numbers are allowed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void AddExpense()
    {
        try
        {
            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            Console.Write("Enter amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than zero.");
            }

            Console.Write("Enter date (dd/mm/yyyy): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Expense expense = new Expense(category, amount, date);
            expenseList.Add(expense);

            Console.WriteLine("Expense added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid amount or date.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ShowExpenses()
    {
        try
        {
            if (expenseList.Count == 0)
            {
                throw new Exception("No expenses available.");
            }

            Console.WriteLine("\n------ Expense List ------");

            foreach (Expense item in expenseList)
            {
                Console.WriteLine("Category : " + item.Category);
                Console.WriteLine("Amount   : $" + item.Amount);
                Console.WriteLine("Date     : " + item.Date.ToShortDateString());
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ShowTotalExpense()
    {
        try
        {
            if (expenseList.Count == 0)
            {
                throw new Exception("No expenses found.");
            }

            double total = 0;

            foreach (Expense item in expenseList)
            {
                total += item.Amount;
            }

            Console.WriteLine("Total Expense: $" + total);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
