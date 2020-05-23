using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionExampleApp
{
    class Fibonacci
    {
        public int calculate(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("a");

            if (number == 1 || number == 0)
            {
                return number;
            }
            else
            {
                return calculate(number - 1) + calculate(number - 2);
            }
        }
    }
}
