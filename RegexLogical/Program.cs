using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexLogical
{
    class Program
    {
        static void Main(string[] args)
        {
            //file input
            string path = @"C:\Users\thora\Source\Repos\Pankaj-Thorat\RegexLogical\RegexLogical\abc.txt";

            string lines;

            lines = File.ReadAllText(path);
            Console.WriteLine("Example input : " + lines);

            //regex pattern
            string pattern = @"<[^>]+>";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(lines);

            foreach (Match match in matches)
            {
                Console.WriteLine("Match found : " + match.Value);
            }
            Console.ReadLine();
        }
    }
}
