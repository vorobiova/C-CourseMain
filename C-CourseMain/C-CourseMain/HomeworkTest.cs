using System;
using System.Collections.Generic;
using System.Linq;

namespace C_CourseMain
{
    public static class HomeworkTest
    {
        #region Lesson1Test
        public static void Lesson1Test()
        {
            Console.WriteLine("Lesson 1");
            Console.WriteLine("----------------------------------------------------------------------------");
            DataList<string> students = new DataList<string>();

            students.Add("Inna");
            students.Add("Andryi");
            students.Add("Lukiian");
            students.Add("Taras");
            students.Add("Oles");

            foreach (var item in students)
                Console.WriteLine(item);

            students.Remove("Oles");
            Console.WriteLine("Remove Oles");

            foreach (var item in students.BackEnumerator())
                Console.WriteLine(item);

            Console.ReadLine();
        }
        #endregion

        #region Lesson2Test
        public static void Lesson2Test()
        {
            Console.WriteLine("Lesson 2");
            Console.WriteLine("----------------------------------------------------------------------------");
            AlphaNumbericCollector alphaNumbericCollector = new AlphaNumbericCollector();
            NumberCollector numberCollector = new NumberCollector();
            StringCollector stringCollector = new StringCollector();
            numberCollector.AddListeners();
            stringCollector.AddListeners();

            Console.WriteLine("Press ESC to stop");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                alphaNumbericCollector.Add(Console.ReadLine());

            numberCollector.RemoveListeners();
            stringCollector.RemoveListeners();
        }
        #endregion

        #region TestClassLesson3
        public static void TestClassLesson3()
        {
            Console.WriteLine("TestClassLesson3");
            Console.WriteLine("----------------------------------------------------------------------------");
            Owner ownerMax = new Owner() { Country = "Usa", Name = "Max" };
            Owner ownerPetro = new Owner() { Country = "Ukraine", Name = "Petro" };
            Owner ownerSuzy = new Owner() { Country = "Belarus", Name = "Suzy" };
            List<Car> myCars = new List<Car>() {
                                                      new Car()
                                                          {
                                                              VIN="A1", Make = "BMW", Model= "550i", StickerPrice=55000, Year=2019,
                                                              Owner = ownerSuzy,
                                                          },
                                                      new Car()
                                                          {
                                                              VIN="B2", Make="Toyota", Model="4Runner", StickerPrice=35000, Year=2015,
                                                              Owner = ownerSuzy
                                                          },
                                                      new Car()
                                                          {
                                                              VIN="C3", Make="BMW", Model = "745li", StickerPrice=75000, Year=2018,
                                                              Owner = ownerMax
                                                          },
                                                      new Car()
                                                          {
                                                              VIN="D4", Make="Ford", Model="Escape", StickerPrice=25000, Year=2018,
                                                              Owner = ownerPetro
                                                          },
                                                      new Car()
                                                          {
                                                              VIN="E5", Make="BMW", Model="55i", StickerPrice=57000, Year=2010,
                                                              Owner = ownerMax
                                                          }
                                                  };

            var simpleQuery = from element in myCars
                              where element.Make == "BMW" && element.Year >= 2015
                              select new { Vin = element.VIN, Price = element.StickerPrice};

            //alternative
            var bmws = myCars.Where(element => { return element.Make == "BMW"; });

            var simpleQuery2 = from element in myCars
                              where element.Make != "BMW" 
                              select new { Vin = element.VIN, Price = element.StickerPrice };

            //alternative
            var bmws2 = myCars.Select(element => new {Make = element.Make, IsNew = element.Year >= 2019 });
            Console.Write(myCars.Any(C => C.StickerPrice > 100000));
            int x = default(int);
            Console.ReadKey();
        }
        #endregion

        #region Lesson3Test
        public static void Lesson3Test()
        {
            Console.WriteLine("Lesson 3");
            Console.WriteLine("----------------------------------------------------------------------------");
            StringConverter stringConverter = new StringConverter();
            Console.WriteLine("Task 1");
            Console.WriteLine("----------------------------------------------------------------------------");
            stringConverter.ConvertStringToList();
            Console.WriteLine("Task 2");
            Console.WriteLine("----------------------------------------------------------------------------");
            stringConverter.ConvertStringToDictionary();
            Console.WriteLine("Task 3");
            Console.WriteLine("----------------------------------------------------------------------------");
            stringConverter.GetTotalLength();
        }
        #endregion
    }
}
