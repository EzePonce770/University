using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Interfaces;

namespace UniversityService
{
    public class PangramService : IPangramService
    {
        public string IsPangram( List<string> pangrams)
        {

            string result = CheckPangrams(pangrams);
            return result;
        }

        private string CheckPangrams(List<string> pangrams)
        {
            string result = "";

            foreach (var sentence in pangrams)
            {
                result += IsPangram(sentence) ? "1" : "0";
            }

            return result;
        }

        private bool IsPangram(string sentence)
        {
            HashSet<char> letters = new HashSet<char>();

            foreach (var ch in sentence)
            {
                if (char.IsLetter(ch))
                {
                    letters.Add(char.ToLower(ch)); 
                }
            }

            return letters.Count == 26; 
        }
    }
}
