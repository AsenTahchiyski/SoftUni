using System;
using System.Collections.Generic;

namespace BunnyWars.Core
{
    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var check = string.Compare(x, y, StringComparison.Ordinal);
            if (check == 0)
            {
                return x.Length > y.Length ? 1 : -1;
            }

            return check;
        }
    }
}
