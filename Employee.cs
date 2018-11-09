using System;

namespace CompanyManager
{
    // This is an ABSTRACT class it cannot create OBJECTS
    abstract class Employee
    {
        // Properties
        public TypeOfEmployee EmployeeType;
        public string Name;
        protected double Income;
        protected DateTime DayOfHire;

        // ABSTRACT Methods they have to be created in Children Classes
        public abstract double CalculateSalary();
        public abstract Employee Raise(double NewIncome = 1000);
    }

    // First Child Of EMPLOYEE
    class HourlyEmployee : Employee
    {
        // Properties are INHERITED

        // Constructor
        internal HourlyEmployee(string EmployeeName, double HourlyIncome, TypeOfEmployee NewEmployeeType = TypeOfEmployee.Hourly)
        {
            DayOfHire = DateTime.Now;
            Name = EmployeeName;
            Income = HourlyIncome;
            EmployeeType = NewEmployeeType;
            Console.WriteLine($"{Name}, was hired as {EmployeeType}, with income {Income}");
        }

        // Creates the ABSTRACT methods
        public override double CalculateSalary()
        {
            Console.WriteLine("So far the employee has made: " + Math.Round(DateTime.Now.Subtract(DayOfHire).TotalHours * Income, 2));
            return Income;
        }

        public override Employee Raise(double NewIncome)
        {
            return new SalariedEmployee(Name, NewIncome);
        }
    }

    class SalariedEmployee : HourlyEmployee
    {
        internal SalariedEmployee(string EmployeeName, double MonthlyIncome, TypeOfEmployee NewEmployeeType = TypeOfEmployee.Salaried)
            : base(EmployeeName, MonthlyIncome, NewEmployeeType) { }

        public override double CalculateSalary()
        {
            Console.WriteLine("So far the employee has made: " + Math.Round(DateTime.Now.Subtract(DayOfHire).TotalDays * Income / 30, 2));
            return Income;
        }

        public override Employee Raise(double NewIncome)
        {
            return new Manager(Name, Income);
        }
    }

    class Manager : SalariedEmployee
    {
        internal Manager(string EmployeeName, double MonthlyIncome, double RaiseOfManager = 1.1, TypeOfEmployee NewEmployeeType = TypeOfEmployee.Manager)
            : base(EmployeeName, MonthlyIncome * RaiseOfManager, NewEmployeeType) { }

        public override Employee Raise(double NewIncome)
        {
            return new Executive(Name, Income);
        }
    }

    sealed class Executive : Manager
    {
        internal Executive(string EmployeeName, double MonthlyIncome, double RaiseOfExecutive = 1.25) 
            : base(EmployeeName, MonthlyIncome, RaiseOfExecutive, TypeOfEmployee.Executive) { }

        public override Employee Raise(double NewIncome)
        {
            Console.WriteLine("Cannot get any higher");
            return this;
        }
    }
}
