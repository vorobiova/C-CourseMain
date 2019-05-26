using System;
using System.Collections.Generic;
using System.Linq;

namespace C_CourseMain
{
    class StringConverter
    {
        private const string _test1 = 
            "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
        private const string _test2 = 
            "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
        private const string _test3 = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

       string[] stringSeparators = new string[] { ",", " " };

        public void ConvertStringToList(string value = _test1)
        {
            var list = new List<string>();
            list.AddRange(value.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries));

            if (list.Count < 0)
                return;

            int index = 1;
            list[0] = index++ + "." + list[0];
            Console.WriteLine(list.Aggregate((s1, s2) => s1 + ", " + index++ + "." + s2));
            Console.ReadKey();
        }

        public void ConvertStringToDictionary(string value = _test2)
        {
            Dictionary<string, int> dict = value.Split(';')
            .Select(x => x.Split(','))
            .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim())
             && !String.IsNullOrEmpty(x[1].Trim()))
            .ToDictionary(x => x[0].Trim(), x => GetAge(Convert.ToDateTime(x[1].Trim())));

            var sortedDict = from item in dict orderby item.Value ascending select item;

            foreach (var item in sortedDict)
                Console.WriteLine(item.Key + " = " + item.Value);
            Console.ReadKey();
        }

        public void GetTotalLength(string value = _test3)
        {
            var list = new List<TimeSpan>();
            list.AddRange(value.Split(',').Select(x => TimeSpan.Parse("00:" + x)));
            Console.WriteLine(new TimeSpan(list.Sum(r => r.Ticks)));
            Console.ReadKey();
        }

        private static int GetAge(DateTime customDateOfBirth)
        {
            var now = DateTime.UtcNow;
            var customerAge = now.Year - customDateOfBirth.Year;
            if (customDateOfBirth > now.AddYears(-customerAge))
                customerAge--;
            return customerAge;
        }

    }
}
