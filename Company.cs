using System;
using System.Collections.Generic;

namespace CompanyManager
{
    class Company
    {
        private List<Employee> CompanyEmployeesList;
        private readonly double BasicMonthlyIncome, BasicHourlyIncome;

        public Company(double CompanyMonthlyIncome, double CompanyHourlyIncome)
        {
            BasicHourlyIncome = CompanyHourlyIncome;
            BasicMonthlyIncome = CompanyMonthlyIncome;
            CompanyEmployeesList = new List<Employee>();
        }

        public void Hire(Employee NewEmployee)
        {
            CompanyEmployeesList.Add(NewEmployee);
        }

        public void Hire(string Name, TypeOfEmployee EmployeeType = TypeOfEmployee.Hourly, double NewIncome = 0)
        {
            if (NewIncome == 0)
            {
                NewIncome = (EmployeeType == TypeOfEmployee.Hourly) ? BasicHourlyIncome : BasicMonthlyIncome;
            }

            switch (EmployeeType)
            {
                case TypeOfEmployee.Hourly:
                default:
                    Hire(new HourlyEmployee(Name, NewIncome));
                    break;
                case TypeOfEmployee.Salaried:
                    Hire(new SalariedEmployee(Name, NewIncome));
                    break;
                case TypeOfEmployee.Manager:
                    Hire(new Manager(Name, NewIncome));
                    break;
                case TypeOfEmployee.Executive:
                    Hire(new Executive(Name, NewIncome));
                    break;
            }
        }

        public void Fire(string Name, TypeOfEmployee EmployeeType = TypeOfEmployee.Hourly)
        {
            foreach (Employee WorkingEmployee in CompanyEmployeesList)
            {
                if (WorkingEmployee.EmployeeType == EmployeeType && WorkingEmployee.Name == Name)
                {
                    Console.WriteLine($"{Name}, who was a {EmployeeType}, got fired");
                    CompanyEmployeesList.Remove(WorkingEmployee);
                    return;
                }
            }
            Console.WriteLine("No Employee was found matching those characteristics");
        }

        public void Raise(string Name, TypeOfEmployee EmployeeType = TypeOfEmployee.Hourly)
        {
            for (int EmployeeIndex = 0; EmployeeIndex < CompanyEmployeesList.Count; EmployeeIndex++)
            {
                if (CompanyEmployeesList[EmployeeIndex].EmployeeType == EmployeeType && CompanyEmployeesList[EmployeeIndex].Name == Name)
                {
                    CompanyEmployeesList[EmployeeIndex] = CompanyEmployeesList[EmployeeIndex].Raise();
                    return;
                }
            }
            Console.WriteLine("No Employee was found matching those characteristics");
        }

        public void ShowEmployeeInfo(string Name = "All Employees")
        {
            foreach (Employee WorkingEmployee in CompanyEmployeesList)
            {
                if (Name.Equals("All Employees") || WorkingEmployee.Name == Name)
                {
                    Console.WriteLine($"{WorkingEmployee.Name}, is a {WorkingEmployee.EmployeeType}, and makes {WorkingEmployee.CalculateSalary()}");
                }
            }
        }
    }

    enum TypeOfEmployee
    {
        Hourly,
        Salaried,
        Manager,
        Executive
    }
}
