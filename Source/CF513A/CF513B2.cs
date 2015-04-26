using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodeForcesPractice
{
    class CF513B2
    {
        private static int n;
        private static long m;

        private static void Execute(string[] args)
        {
            var input = args.Select(s => Int64.Parse(s)).ToList();

            n = (int)input[0];
            m = input[1];

            var maxFpCount = (long)Math.Pow(2, n - 1);

            var permutation = Enumerable.Repeat(0, n).ToList();

            BuildPermutation(permutation, 1,0,n-1,0,maxFpCount);

            foreach (var i in permutation)
            {
                Console.Write(i + " ");
            }
        }


        private static void BuildPermutation(List<int> p, int number, int minPosition, int maxPosition, long min, long max)
        {
            if (number > n)
            {
                return;
            }

            var midpoint = (max - min)/2 + min;

            if ((m-1) < midpoint)
            {
                p[minPosition] = number;
                BuildPermutation(p, number+1,minPosition+1, maxPosition,min,midpoint);
            }
            else
            {
                p[maxPosition] = number;
                BuildPermutation(p, number + 1, minPosition, maxPosition-1, midpoint, max);
            }            
        }

        
        //static void Main(string[] args)
        //{
        //    var input = Console.ReadLine().Split(' ');
        //    Execute(input);
        //}
    }
}

