using System;
using System.Collections.Generic;

namespace C_CourseMain
{
    class NumberCollector
    {
        private List<string> _inputs = new List<string>();

        public void AddListeners()
        {
            AlphaNumbericCollector.OnInputNumber += OnInputNumberHandler;
        }

        public void RemoveListeners()
        {
            AlphaNumbericCollector.OnInputNumber -= OnInputNumberHandler;
        }

        private void OnInputNumberHandler(string input)
        {
            _inputs.Add(input);
            Console.WriteLine("This Line has Number: " + input);
        }
    }
}
