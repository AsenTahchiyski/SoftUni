using System;
using System.Linq;
using System.Collections.Generic;
public static class WeakStudents
{
    public static List<Student> Weak(this List<Student> allStudents)
    {
        var weaklings = (from stud in allStudents
               where stud.Marks != null && AreThereExactlyTwoGrades(stud.Marks, 2)
               select stud).ToList();
        return weaklings;
    }
    public static bool AreThereExactlyTwoGrades(IList<int> marks, int mark)
    {
        IList<int> temp = marks.ToList();
        if (temp.Contains(mark)) 
        {
            temp.Remove(mark);
            if (temp.Contains(mark)) 
            {
                temp.Remove(mark);
                {
                    if (!temp.Contains(mark))
	                {
		                return true;
	                }
                }
            }
        }
        return false;   
    }
}
