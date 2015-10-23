namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Enumerations;
    using Utilities;

    public class User
    {
        private const int MinPasswordLength = 6;
        private const int MinUsernameLength = 5;

        private string username;
        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinUsernameLength)
                {
                    throw new ArgumentException(string.Format(GlobalMessages.ModelNameLengthAtLeast, "username", MinUsernameLength));
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinPasswordLength)
                {
                    throw new ArgumentException(string.Format(GlobalMessages.ModelNameLengthAtLeast, "password", MinPasswordLength));
                }

                this.passwordHash = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}
