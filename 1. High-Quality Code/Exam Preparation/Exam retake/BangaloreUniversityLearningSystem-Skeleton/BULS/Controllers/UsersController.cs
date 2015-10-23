namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDatabase data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(GlobalMessages.PasswordsDoNotMatch);
            }

            this.EnsureNoLoggedInUser();
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format(GlobalMessages.UsernameAlreadyExists, username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();
            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format(GlobalMessages.UsernameDoesNotExist, username));
            }

            if (existingUser.PasswordHash != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(GlobalMessages.WrongPassword);
            }

            this.User = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(GlobalMessages.NoUserLogged);
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                throw new AuthorizationFailedException(GlobalMessages.AuthorizationFailed);
            }

            var user = this.User;
            this.User = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException(GlobalMessages.AlreadyLoggedIn);
            }
        }
    }
}