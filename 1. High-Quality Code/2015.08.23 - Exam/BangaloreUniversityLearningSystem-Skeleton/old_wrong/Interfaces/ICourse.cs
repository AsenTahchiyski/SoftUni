namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; set; }

        IList<ILecture> Lectures { get; set; }

        IList<IUser> Students { get; set; }

        void AddLecture(ILecture lecture);

        void AddStudent(IUser student);
    }
}
