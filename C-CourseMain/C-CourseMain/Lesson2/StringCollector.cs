using System;
using System.Collections.Generic;

namespace C_CourseMain
{
    class StringCollector
    {
        private List<string> _inputs = new List<string>();

        public void AddListeners()
        {
            AlphaNumbericCollector.OnInputString += OnInputNumberHandler;
        }

        public void RemoveListeners()
        {
            AlphaNumbericCollector.OnInputString -= OnInputNumberHandler;
        }

        private void OnInputNumberHandler(string input)
        {
            _inputs.Add(input);
            Console.WriteLine("This Line has not Number: " + input);
        }
    }
}
