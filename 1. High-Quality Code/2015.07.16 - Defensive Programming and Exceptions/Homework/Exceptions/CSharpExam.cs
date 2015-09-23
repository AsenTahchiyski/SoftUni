using System;

public class CSharpExam : Exam
{
    private const int DefaultMinScore = 0;
    private const int DefaultMaxScore = 100;
    
    private int score;
    
    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(string.Format("Score must be between {0} and {1}", DefaultMinScore, DefaultMaxScore));
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
