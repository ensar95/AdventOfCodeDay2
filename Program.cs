using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] sep = { "\n" };
            string[] text = File.ReadAllText("C:\\Users\\ensar.skopljak\\source\\repos\\AdventOfCodeDay2\\AdventOfCodeDay2\\Passwords.txt").Split(sep, StringSplitOptions.RemoveEmptyEntries);
            List<string> passwords = text.OfType<string>().ToList();
            for (int i = 0; i < passwords.Count; i++)
            {
                if (passwords[i].Contains("\r"))
                {
                    passwords[i] = passwords[i].Replace("\r", "");
                }
            }

            string[] delimiters = { "-", ":", " " };
            int goodAttempts = 0;
            foreach (string password in passwords)
            {
                string[] passwordParts = password.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                int min = Int32.Parse(passwordParts[0]);
                int max = Int32.Parse(passwordParts[1]);
                string rule = passwordParts[2];
                string attempt = passwordParts[3];
                char[] rules = rule.ToCharArray();

                if (attempt.Contains(rule))
                {
                    int counterOfOccurencies = 0;
                    foreach (char c in attempt)
                    {
                        if (c == rules[0])
                        {
                            counterOfOccurencies += 1;
                        }
                    }

                    if (!(counterOfOccurencies < min || counterOfOccurencies > max))
                    {
                          
                                goodAttempts += 1;
                     
                    }
                }
            }
            Console.WriteLine(goodAttempts);

            int goodAttempts2 = 0;
            foreach(string password in passwords)
            {
                string[] passwordParts = password.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                int min = Int32.Parse(passwordParts[0]);
                int max = Int32.Parse(passwordParts[1]);
                string rule = passwordParts[2];
                string attempt = passwordParts[3];
                char[] rules = rule.ToCharArray();

                bool validFirst = attempt[min - 1] == rules[0];
                bool validSecond = attempt[max - 1] == rules[0];

                if(validFirst ^ validSecond)
                {
                    goodAttempts2 += 1;
                }
            }
            Console.WriteLine(goodAttempts2);

        }
    }
}