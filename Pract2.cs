using System;
using System.Collections.Generic;

namespace EmployeePayrollSystem
{
    interface IPayable
    {
        double CalculateSalary();
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            EmployeeId = id;
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Employee ID : " + EmployeeId);
            Console.WriteLine("Employee Name : " + Name);
        }
    }

    class FullTimeEmployee : Employee, IPayable
    {
        public double MonthlySalary { get; set; }

        public FullTimeEmployee(int id, string name, double salary)
            : base(id, name)
        {
            MonthlySalary = salary;
        }

        public double CalculateSalary()
        {
            return MonthlySalary;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Employee Type : Full Time");
            Console.WriteLine("Salary : " + CalculateSalary());
        }
    }

    class PartTimeEmployee : Employee, IPayable
    {
        public int HoursWorked { get; set; }
        public double HourlyRate { get; set; }

        public PartTimeEmployee(int id, string name, int hours, double rate)
            : base(id, name)
        {
            HoursWorked = hours;
            HourlyRate = rate;
        }

        public double CalculateSalary()
        {
            return HoursWorked * HourlyRate;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Employee Type : Part Time");
            Console.WriteLine("Hours Worked : " + HoursWorked);
            Console.WriteLine("Hourly Rate : " + HourlyRate);
            Console.WriteLine("Salary : " + CalculateSalary());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            employees.Add(new FullTimeEmployee(101, "Rahul Kava", 50000));
            employees.Add(new FullTimeEmployee(102, "Amit Dave", 60000));
            employees.Add(new PartTimeEmployee(103, "Neha Joshi", 60, 450));

            Console.WriteLine("===== Employee Payroll System =====");

            foreach (Employee emp in employees)
            {
                emp.Display();
                Console.WriteLine("-----------------------------");
            }

            Console.ReadKey();
        }
    }
}
