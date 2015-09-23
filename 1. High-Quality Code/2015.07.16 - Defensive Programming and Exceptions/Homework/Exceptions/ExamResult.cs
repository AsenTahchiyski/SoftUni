using System;

public class ExamResult
{
    private const int DefaultMinimumGrade = 0;
    
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < this.MinGrade || value > this.MaxGrade)
            {
                throw new ArgumentOutOfRangeException(string.Format("Grade must be between {0} and {1}.", this.minGrade, this.maxGrade));
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < DefaultMinimumGrade)
            {
                throw new ArgumentOutOfRangeException(string.Format("Minimum grade must be bigger than {0}.", DefaultMinimumGrade));
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.minGrade)
            {
                throw new ArgumentOutOfRangeException(string.Format("Maximum grade must be bigger than {0}.", this.minGrade));
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide comments.");
            }

            this.comments = value;
        }
    }
}
