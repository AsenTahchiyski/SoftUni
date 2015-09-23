namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Enumerations;
    using Interfaces;
    using Utilities;

    public class User : IUser
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<ICourse>();
        }

        public string UserName
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The username must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    string message = "The password must be at least 6 symbols long.";
                    throw new ArgumentException(message);
                }

                string currentPasswordHash = HashUtilities.HashPassword(value);
                this.passwordHash = currentPasswordHash;
            }
        }

        public Role Role { get; private set; }

        public IList<ICourse> Courses { get; private set; }

        public bool IsInRole(Role role)
        {
            return this.Role == role;
        }
    }
}
