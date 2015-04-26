using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace CodeForcesPractice
{
    class CF513B1
    {
        private static int n;
        private static int m;

        private static void Execute(string[] args)
        {
            var input = args.Select(s => Int32.Parse(s)).ToList();

            n = input[0];
            m = input[1];

            var allPermutations = Permutations(Enumerable.Range(1, n).ToList());
            var maxFp = allPermutations.Max(p => F(p));
            var result = allPermutations.Where(p => F(p) == maxFp).Skip(m - 1).First();           

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
        }

        private static IEnumerable<List<int>> Permutations(List<int> elements)
        {
            if (elements.Count == 1)
            {
                yield return elements;
                yield break;
            }

            for (int i = 0; i < elements.Count; i++)
            {
                var ex = elements.Except(new[] {elements[i]}).ToList();

                foreach (var p in Permutations(ex))
                {
                    p.Insert(0,elements[i]);
                    yield return p;
                }
            }
        }

        private static int F(List<int> p)
        {
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    sum += min(p, i, j);
                }
            }

            return sum;
        }

        private static int min(List<int> p, int i, int j)
        {
            int min = p[i];

            for (int x = i+1; x <= j; x++)
            {
                if (p[x] < min)
                {
                    min = p[x];
                }
            }

            return min;
        }
        

        //static void Main(string[] args)
        //{
        //    var input = Console.ReadLine().Split(' ');
        //    Execute(input);
        //}
    }
}
