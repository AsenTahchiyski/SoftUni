using System;
class PinValidation
{
    static void Main()
    {
        // check names
        string[] names = Console.ReadLine().Split(' ');
        if (names.Length < 2 || char.IsLower(names[0][0]) || char.IsLower(names[1][0]))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check gender
        string gender = Console.ReadLine();
        if (gender.ToLower() != "male" && gender.ToLower() != "female")
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check PIN:
        string pin = Console.ReadLine();
        // check PIN length
        if (pin.Length != 10)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check month of birth validity
        int month = int.Parse(pin.Substring(2, 2));
        if (month == 0 || (month > 12 && month < 21) || (month > 32 && month < 41) || month > 52)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check for day of birth validity
        int dayOfBirth = int.Parse(pin.Substring(4, 2));
        if (dayOfBirth == 0 || dayOfBirth > 31)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check for PIN gender validity
        int genderPinNum = (int)char.GetNumericValue(pin[8]);
        if ((gender == "male" && genderPinNum % 2 != 0) || (gender == "female" && genderPinNum % 2 != 1))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // check PIN checksum
        int[] checkNums = { 2,4,8,5,10,9,7,3,6 };
        int checkSumBeforeDiv = 0;
        
        for (int i = 0; i < 9; i++)
        {
            checkSumBeforeDiv += (int)char.GetNumericValue(pin[i]) * checkNums[i];
        }
        if ((checkSumBeforeDiv % 11) % 10 != (int)char.GetNumericValue(pin[9]))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }
        // print valid output
        else Console.WriteLine("{{\"name\":\"{0} {1}\",\"gender\":\"{2}\",\"pin\":\"{3}\"}}", names[0], names[1], gender, pin);
    }
}
