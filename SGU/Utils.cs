﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGU
{
    static internal class Utils
    {
        public static UsersContext db = new UsersContext();

        public static bool checkEmail(string input)
        {
            return Regex.IsMatch(input, "/^[A-Z0-9._%+-]+@[A-Z0-9-]+.+.[A-Z]{2,4}$/i");
        }

        public static bool checkPhone(string input)
        {
            return Regex.IsMatch(input, "/^\\+?(\\d{1,3})?[- .]?\\(?(?:\\d{2,3})\\)?[- .]?\\d\\d\\d[- .]?\\d\\d\\d\\d$/");
        }
    }
}
