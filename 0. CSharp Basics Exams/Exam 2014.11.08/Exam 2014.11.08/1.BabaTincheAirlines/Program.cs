using System;
class Program
{
    static void Main()
    {
        int actualIncome = 0;
        int maxIncome = 0;
        int incomeDiff = 0;
        int[] ticketPrice = {7000, 3500, 1000};
        int[] maxPassengers = {12, 28, 50};
        for (int numClass = 0; numClass < 3; numClass++)
        {
            string input = Console.ReadLine();
            string[] parameters = input.Split(' ');
            int passengersAll = Convert.ToInt32(parameters[0]);
            int passengersFreq = Convert.ToInt32(parameters[1]);
            int passengersMeal = Convert.ToInt32(parameters[2]);
            int passengersNormal = passengersAll - passengersFreq;
            int normalIncome = (passengersNormal) * ticketPrice[numClass];
            int freqIncome = Convert.ToInt32(passengersFreq * ticketPrice[numClass] * 0.3);
            int mealIncome = Convert.ToInt32(passengersMeal * ticketPrice[numClass] * 0.005);
            actualIncome += normalIncome + freqIncome + mealIncome;
            maxIncome += Convert.ToInt32(maxPassengers[numClass] * ticketPrice[numClass] * 1.005);
            incomeDiff += (Convert.ToInt32(maxPassengers[numClass] * ticketPrice[numClass] * 1.005)) - (normalIncome + freqIncome + mealIncome);
        }
        Console.WriteLine(actualIncome);
        Console.WriteLine(incomeDiff);
    }
}
// 90 %
