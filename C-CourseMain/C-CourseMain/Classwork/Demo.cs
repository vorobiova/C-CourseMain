using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML
{
    class Demo
    {
        List<Student> students = new List<Student>();

        public void LoadXml()
        {          
            XDocument xml = XDocument.Load("InputStudents.xml");
            XElement studentElement = xml.Element("Students");
            IEnumerable<XElement> studentElements = studentElement.Elements("Student");

            foreach (var item in studentElements)
            {
                Student student = new Student();
                var fName = item.Attribute("firstName");
                student.FirstName = fName.Value;
                fName = item.Attribute("lastName");
                student.LastName = fName.Value;
                int number = int.Parse(item.Element("PhoneNumber").Value);
                student.Number = number;
                student.Email = item.Element("Email").Value;
                student.BirthDate = DateTime.Parse(item.Element("BirthDate").Value);
                students.Add(student);

                student.ExtraData = new Dictionary<string, string>();
                var extra = item.Element("ExtraData")?.Elements("ExtraDataElement");

                if (extra != null)
                    foreach (var extraData in extra)
                    {
                        var key = extraData.Attribute("name").Value;
                        var value = extraData.Value;
                    //    student.ExtraData.Add(new ExtraData().Name = key, );
                    }

                IEnumerable<string> courseElements = item.Element("Courses")?.Elements("Course").Select(e=> e.Value);
                student.Courses = courseElements.ToList();
                students.Add(student);
                students.Add(new Student() { LastName = "tet", ExtraData = new Dictionary<string, string> { { "quality", "false" } } });
            }
        }

        private void SaveXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (var fileStream = File.Create("serialized.xml"))
            {
                xmlSerializer.Serialize(fileStream, students);
            }

            using (var fileStream = File.OpenRead("serialized.xml"))
            {
                var deserializedtudents = xmlSerializer.Deserialize(fileStream);
            }

            XDocument xDoc = new XDocument();
            var studentsElement = new XElement("Students");
            xDoc.Add(studentsElement);
            foreach (var item in students)
            {
                XElement studentElement = new XElement("Student");

                if(item.LastName != null)
                studentsElement.Add(new XAttribute("lastName", item.LastName));
                if (item.FirstName != null)
                    studentsElement.Add(new XAttribute("firstNAme", item.FirstName));
                if (item.Number != null)
                    studentsElement.Add(new XAttribute("PhoneNumber", item.Number));
                if (item.Email != null)
                    studentsElement.Add(new XAttribute("Email", item.Email));

                if (item.BirthDate != null)
                    studentsElement.Add(new XAttribute("BirthDate", item.BirthDate.ToString("dd.MM.yy")));

                studentsElement.Add(studentsElement);
            }
            xDoc.Save("new_InputStufdentsxml");
        }
    }
}
