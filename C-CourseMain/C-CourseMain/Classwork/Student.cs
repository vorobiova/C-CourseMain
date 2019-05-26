using System;
using System.Collections.Generic;

namespace XML
{
    public class Student
    {
        public string FirstName { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string LastName { get;  set; }
        public int Number { get;  set; }
        public string Email { get;  set; }
        public Dictionary<string, string> ExtraData { get;  set; }
        public List<string> Courses { get;  set; }
    }

    public class ExtraData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

}