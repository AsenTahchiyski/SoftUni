using System;
using System.IO;
using System.Linq;
using ExcelLibrary;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ExcelLibrary.SpreadSheet;
using System.Data;
class LINQinExcel
{
    static void Main()
    {
        List<Student> allStudents = new List<Student>();
        string pattern = @"(\d+)\s+([a-zA-z]+)\s+([a-zA-z]+)\s+(\S+@\S+)\s+(Male|Female)\s+(Online|Onsite)\s+(\d+)\s+(\d+)\s+(\d+)\s+([\d.]+)\s+(\d+)\s+([\d.]+)";
        using (StreamReader reader = new StreamReader("../../Students-data.txt"))
        {
            string line = reader.ReadLine();
            line = reader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                Student currentStudent = new Student();
                string[] columns = Regex.Split(line, pattern);
                currentStudent.ID = int.Parse(columns[1]);
                currentStudent.FirstName = columns[2];
                currentStudent.LastName = columns[3];
                currentStudent.Email = columns[4];
                currentStudent.Gender = columns[5];
                currentStudent.StudentType = columns[6];
                currentStudent.ExamResult = int.Parse(columns[7]);
                currentStudent.HomeWsent = int.Parse(columns[8]);
                currentStudent.HomeWEval = int.Parse(columns[9]);
                currentStudent.Teamwork = double.Parse(columns[10]);
                currentStudent.Attendances = int.Parse(columns[11]);
                currentStudent.Bonus = double.Parse(columns[12]);
                currentStudent.Result = CalculateResult(currentStudent);
                allStudents.Add(currentStudent);
                line = reader.ReadLine();
            }
        }
        var onlineStudents = from student in allStudents
                             where student.StudentType == "Online"
                             orderby student.Result descending
                             select student;
        // add to excel file
        string file = "../../Students-data.xls";
        Workbook workbook = new Workbook();
        Worksheet worksheet = new Worksheet("SoftUni Students");
        // create columns
        worksheet.Cells[0, 0] = new Cell("ID");
        worksheet.Cells[0, 1] = new Cell("First Name");
        worksheet.Cells[0, 2] = new Cell("Last Name");
        worksheet.Cells[0, 3] = new Cell("Email");
        worksheet.Cells[0, 4] = new Cell("Gender");
        worksheet.Cells[0, 5] = new Cell("Student Type");
        worksheet.Cells[0, 6] = new Cell("Exam Result");
        worksheet.Cells[0, 7] = new Cell("Homeworks Sent");
        worksheet.Cells[0, 8] = new Cell("Homeworks Evaluated");
        worksheet.Cells[0, 9] = new Cell("Teamwork");
        worksheet.Cells[0, 10] = new Cell("Attendances");
        worksheet.Cells[0, 11] = new Cell("Bonus");
        worksheet.Cells[0, 12] = new Cell("Result");
        workbook.Worksheets.Add(worksheet);
        workbook.Save(file);
        // open file and add data
        Workbook book = Workbook.Load(file);
        Worksheet sheet = book.Worksheets[0];
        int counter = 1;
        foreach (var currentStudent in onlineStudents)
        {
            worksheet.Cells[counter, 0] = new Cell(currentStudent.ID);
            worksheet.Cells[counter, 1] = new Cell(currentStudent.FirstName);
            worksheet.Cells[counter, 2] = new Cell(currentStudent.LastName);
            worksheet.Cells[counter, 3] = new Cell(currentStudent.Email);
            worksheet.Cells[counter, 4] = new Cell(currentStudent.Gender);
            worksheet.Cells[counter, 5] = new Cell(currentStudent.StudentType);
            worksheet.Cells[counter, 6] = new Cell(currentStudent.ExamResult);
            worksheet.Cells[counter, 7] = new Cell(currentStudent.HomeWsent);
            worksheet.Cells[counter, 8] = new Cell(currentStudent.HomeWEval);
            worksheet.Cells[counter, 9] = new Cell(currentStudent.Teamwork);
            worksheet.Cells[counter, 10] = new Cell(currentStudent.Attendances);
            worksheet.Cells[counter, 11] = new Cell(currentStudent.Bonus);
            worksheet.Cells[counter, 12] = new Cell(currentStudent.Result);
            counter++;
        }
        // save file
        workbook.Worksheets.Add(worksheet);
        workbook.Save(file);
        Console.WriteLine("Done, please check your project folder for the xls file.");
    }
    static double CalculateResult(Student student)
    {
        return (student.ExamResult + student.HomeWsent + student.HomeWEval + student.Teamwork + student.Attendances + student.Bonus) / 5.0;
    }
}
