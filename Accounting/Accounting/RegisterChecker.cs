using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accounting
{
    public static class RegisterChecker
    {
        public static bool CheckDigit(string text)
        {
            string pattern = "^\\-?\\d*\\.?\\d*$";
            if (Regex.IsMatch(text, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
