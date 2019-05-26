using System;
using System.Linq;

namespace C_CourseMain
{
    public class AlphaNumbericCollector
    {
        public delegate void InputHasNumber(string input);
        public static event InputHasNumber OnInputNumber;

        public static Action<string> OnInputString;

        private delegate bool CheckInput(string input);
        private CheckInput _checkFunction;

        public AlphaNumbericCollector()
        {
            _checkFunction = HasNumber;
        }

        public void Add(string input)
        {
            if (_checkFunction(input))
            {
                if (OnInputNumber != null)
                    OnInputNumber(input);
            }
            else
                OnInputString(input);
        }

        private bool HasNumber(string input)
        {
            return input.Where(x => Char.IsDigit(x)).Any();
        }       

    }
}
