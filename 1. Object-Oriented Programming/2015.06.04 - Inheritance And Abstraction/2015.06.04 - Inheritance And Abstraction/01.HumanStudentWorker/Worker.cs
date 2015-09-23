using System;

namespace _01.HumanStudentWorker
{
    class Worker : Human
    {
        public double MoneyPerHour()
        {
            return this.WeeklySalary / (7 * this.WorkHoursPerDay);
        }

        public double WeeklySalary { get; set; }
        public double WorkHoursPerDay { get; set; }

        public Worker(string fName, string lName, double weeklySalary, double workHperDay)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHperDay;
            this.FirstName = fName;
            this.LastName = lName;
        }
    }
}
