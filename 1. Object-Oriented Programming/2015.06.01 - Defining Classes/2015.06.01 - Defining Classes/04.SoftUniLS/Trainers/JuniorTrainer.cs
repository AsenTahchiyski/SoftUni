using System;

namespace SULS.Trainers
{
    class JuniorTrainer : Trainer
    {
        private string firstName;
        private string lastName;
        private int age;

        public JuniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
