﻿using System;
using System.Globalization;
using System.Threading;

class ShoppingCenterMain
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var center = new ShoppingCenterFast();

        int commands = int.Parse(Console.ReadLine());
        for (int i = 1; i <= commands; i++)
        {
            string command = Console.ReadLine();
            string commandResult = center.ProcessCommand(command);
            Console.WriteLine(commandResult);
        }
    }
}