using System;
using System.Text.RegularExpressions;
class ReplaceATag
{
    static void Main()
    {
        string text = @"
<ul>
    <li>
        <a href=http://softuni.bg>SoftUni</a>;
    </li>
</ul>";
        // first way to solve
        string pattern = @"<a href=([a-z:\/.]*)>(\w*)<\/a>"; // Angel Georgiev
        string replacement = @"[URL href=$1]$2[/URL]$0"; 
        // $x - placeholder for matches, $0 is the whole match expression
        string result = Regex.Replace(text, pattern, replacement);
        Console.WriteLine(result);
        // second way to solve
        Regex getURLandName = new Regex(pattern);
        Match matches = getURLandName.Match(text);
        Console.WriteLine(matches.Groups[0].Value); // prints same as $0, gets the value for whole pattern
        Console.WriteLine(matches.Groups[1].Value); // prints same as $1, gets the value of match 1
        Console.WriteLine(matches.Groups[2].Value); // prints same as $2, gets the value of match 2
    }
}
