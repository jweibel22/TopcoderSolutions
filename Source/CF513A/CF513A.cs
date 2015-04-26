using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CF513A
{
    class CF513A
    {
        public static void Execute(string[] args)
        {
            var input = args.Select(s => Int32.Parse(s)).ToList();

            Console.WriteLine(input[0] > input[1] ? "First" : "Second");
        }
    }
}
