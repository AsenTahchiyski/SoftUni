using System;

namespace CompanyHierarchy
{
    class Project
    {
        public string ProjectName
        {
            get
            {
                return this.ProjectName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Project name cannot be empty.");
                }
                this.ProjectName = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.StartDate;
            }
            set
            {
                DateTime dateIn;
                if (!DateTime.TryParse(value.ToString(), out dateIn))
                {
                    throw new FormatException("Invalid date format.");
                }
                this.StartDate = dateIn;
            }
        }

        public string Details { get; set; }

        public string State
        {
            get
            {
                return this.State;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Project state cannot be empty.");
                }
                else if (value != "Open" && value != "Closed")
                {
                    throw new ArgumentOutOfRangeException("Project state can be either Open or Closed.");
                }
                this.State = value;
            }
        }

        public void CloseProject()
        {
            this.State = "Closed";
        }
    }
}
