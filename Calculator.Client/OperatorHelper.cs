using System.Collections.Generic;

namespace Calculator.Client
{
    public static class OperatorHelper
    {
        public static IEnumerable<string> AllowedOperators() 
        {
            return new string[] { "add", "multiply", "subtract", "divide", "apply" };
        }        
    }
}
