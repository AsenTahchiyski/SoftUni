using System;
class FriendBits
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        string num = Convert.ToString(n, 2);
        string friends = "0", alone = "0";
        if (num[0] == num[1])
        {
            friends = string.Concat(friends, num[0]);
        }
        else
        {
            alone = string.Concat(alone, num[0]);
        }
        for (int i = 1; i < num.Length - 1; i++)
        {
            if (num[i] == num[i - 1])
            {
                friends = string.Concat(friends, num[i]);
            }
            else
            {
                if (num[i] == num[i + 1])
                {
                    friends = string.Concat(friends, num[i]);
                }
                else
                {
                    alone = string.Concat(alone, num[i]);
                }
            }
        }
        if (num[num.Length - 1] == num[num.Length - 2])
        {
            friends = string.Concat(friends, num[num.Length - 1]);
        }
        else
        {
            alone = string.Concat(alone, num[num.Length - 1]);
        }
        Console.WriteLine("{0}\n{1}", Convert.ToInt64(friends, 2), Convert.ToInt64(alone, 2));
    }
}
