using System;
class PrintCompanyInfo
{
    static void Main()
    {
        Console.Write("{0, -20}", "Company name:");
        string companyName = Console.ReadLine();
        Console.Write("{0, -20}", "Company address:");
        string companyAddress = Console.ReadLine();
        Console.Write("{0, -20}", "Phone number:");
        string companyPhone = Console.ReadLine();
        Console.Write("{0, -20}", "Fax number:");
        string companyFax = Console.ReadLine();
        bool in21Century = companyFax == "";
        Console.Write("{0, -20}", "Web site:");
        string companySite = Console.ReadLine();
        Console.Write("{0, -20}", "Manager first name:");
        string managerFirstName = Console.ReadLine();
        Console.Write("{0, -20}", "Manager last name:");
        string managerLastName = Console.ReadLine();
        Console.Write("{0, -20}", "Manager age:");
        int managerAge = int.Parse(Console.ReadLine());
        Console.Write("{0, -20}", "Manager phone:");
        string managerPhone = Console.ReadLine();
        Console.Clear();
        Console.WriteLine(companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Tel. " + companyPhone);
        Console.WriteLine("Fax: {0}", in21Century == true ? "(no fax)" : companyFax);
        Console.WriteLine("Web site: " + companySite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", 
            managerFirstName, managerLastName, managerAge, managerPhone);
    }
}
