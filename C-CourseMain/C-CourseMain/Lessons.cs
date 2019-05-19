using System;

namespace C_CourseMain
{
    public static class Lessons
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
    }
}
