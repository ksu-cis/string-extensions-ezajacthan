using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static int WordCount(this String str) //this keyword adds the functionality to a string obj
        {
            return str.Split(new char[] { ' ', '.', '?', '\t', '\n', '!', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Capitalize(this String str)
        {
            string first = str[0].ToString().ToUpper();
            return first + str.Substring(1);
        }

        public static string Decapitalize(this string str)
        {
            //THIS DOESN'T WORK
            /*
            string first = str[0].ToString().ToLower();
            str = first + str.Substring(1);*/

            string first = str[0].ToString().ToLower();
            return first + str.Substring(1);
        }

        public static string Titlize(this string title)
        {
            List<string> words = new List<string>(title.Split(" "));
            List<string> articles = new List<string>() { "a", "an", "the" };
            string first = words[0].Capitalize();

            if (articles.Contains(words[0].ToLower()))
            {
                words.RemoveAt(0);
                words.Add(", " + first);
                first = words[0].Capitalize();
                while (articles.Contains(words[0].ToLower()))
                {
                    words.RemoveAt(0);
                    words.Add(first);
                    first = words[0];
                    //return words.Aggregate((acc, word) => acc + word + " ");
                }
            }
            string result = "";

            foreach (string s in words)
            {
                result += s + " ";
            }
            return result;
        }
    }
}
