﻿namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;
    using Models;

    public class BangaloreUniversityDatabase : IBangaloreUniversityDatabase
    {
        public BangaloreUniversityDatabase()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }
        
        public UsersRepository Users { get; internal set; }

        public IRepository<Course> Courses { get;  protected set; }
    }
}
