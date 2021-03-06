﻿namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Enumerations;
    using Interfaces;

    public abstract class Controller
    {
        public IData Data { get; set; }

        public IUser User { get; set; }

        public bool HasCurrentUser
        {
            get { return this.User != null; }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            if (fullNamespace == null)
            {
                throw new ArgumentNullException("fullNamespace", "Full namespace missing.");
            }

            int firstSeparatorIndex = fullNamespace.IndexOf(".", StringComparison.Ordinal);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            if (viewType == null)
            {
                return null;
            }

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            // TODO: foreach probably not needed
            //foreach (var user in this.Data.Users.GetAll()) 
            //{
                if (!roles.Any(role => this.User.IsInRole(role)))
                {
                    throw new DivideByZeroException(
                        "The current user is not authorized to perform this operation.");
                //}
            }
        }
    }
}
