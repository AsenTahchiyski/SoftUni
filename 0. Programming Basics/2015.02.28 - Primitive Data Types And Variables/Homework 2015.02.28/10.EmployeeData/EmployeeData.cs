using System;
class EmployeeData
{
    static void Main()
    {
        string FirstName = "Stamat";
        string LastName = "Florentinov";
        byte age = 31;
        char gender = 'm'; // Char can accomodate other possible gender interpretations as opposed to Bool
        long IDnumber = 8306112507;
        uint EmployeeID = 27569999;

        Console.WriteLine("Name: {0} {1} \nAge: {2}\nGender: {3}\nPersonal ID: {4}\nEmployee ID: {5}",
                          FirstName, LastName, age, char.ToUpper(gender), IDnumber, EmployeeID);
    }
}
