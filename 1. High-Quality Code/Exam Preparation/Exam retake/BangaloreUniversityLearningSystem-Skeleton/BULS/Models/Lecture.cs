namespace BangaloreUniversityLearningSystem.Models
{
    using System;

    public class Lecture
    {
        private const int MinLectureNameLength = 3;

        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value.Length < MinLectureNameLength)
                {
                    throw new ArgumentException(string.Format(GlobalMessages.ModelNameLengthAtLeast, "lecture name", MinLectureNameLength));
                }

                this.name = value;
            }
        }
    }
}
