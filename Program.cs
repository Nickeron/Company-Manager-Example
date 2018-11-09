using System;

namespace CompanyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Company Tesla = new Company(2500, 100);

            Tesla.Hire("George Clooney", TypeOfEmployee.Hourly);
            Tesla.Hire("Matt Damon", TypeOfEmployee.Hourly);
            Tesla.Hire("Pierce Brosnan", TypeOfEmployee.Salaried);
            Tesla.Hire("My Grandma", TypeOfEmployee.Manager);
            Tesla.Hire("Elon Musk", TypeOfEmployee.Executive);

            Tesla.Fire("My Grandma", TypeOfEmployee.Manager);

            Tesla.Raise("Matt Damon", TypeOfEmployee.Hourly);
            Tesla.Raise("Pierce Brosnan", TypeOfEmployee.Salaried);

            Tesla.ShowEmployeeInfo();
            Console.ReadKey();
        }
    }
}
