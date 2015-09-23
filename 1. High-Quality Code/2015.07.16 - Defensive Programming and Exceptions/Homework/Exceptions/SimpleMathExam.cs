using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 10;
    
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || value > MaxProblemsSolved)
            {
                throw new ArgumentOutOfRangeException(string.Format("Problems solved must be between {0} and {1}.", MinProblemsSolved, MaxProblemsSolved));
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 1: 
            case 2:
                return new ExamResult(2, 2, 6, string.Format("Weak result: {0} problems solved out of {1}.", this.ProblemsSolved, MaxProblemsSolved));
            case 3:
            case 4:
                return new ExamResult(3, 2, 6, string.Format("Average result: {0} problems solved out of {1}.", this.ProblemsSolved, MaxProblemsSolved));
            case 5:
            case 6:
                return new ExamResult(4, 2, 6, string.Format("Good result: {0} problems solved out of {1}.", this.ProblemsSolved, MaxProblemsSolved));
            case 7:
            case 8:
                return new ExamResult(5, 2, 6, string.Format("Very good result: {0} problems solved out of {1}.", this.ProblemsSolved, MaxProblemsSolved));
            case 9:
            case 10:
                return new ExamResult(6, 2, 6, string.Format("Excellent result: {0} problems solved out of {1}.", this.ProblemsSolved, MaxProblemsSolved));
            default:
                throw new ArgumentOutOfRangeException(string.Format("Problems solved must be between {0} and {1}.", MinProblemsSolved, MaxProblemsSolved));
        }
    }
}
