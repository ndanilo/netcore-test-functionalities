using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Directives
{
    public class LineDirective
    {
        public void WriteLines()
        {
            Console.WriteLine("Normal line #1."); // Set break point here.
#line hidden
            Console.WriteLine("Hidden line.");
#line default
            Console.WriteLine("Normal line #2.");
        }
    }
}
