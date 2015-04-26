using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeForcesPractice
{
    class CF527B
    {

        private static void Main(string[] args)
        {
            var n = 200000; //Int32.Parse(Console.ReadLine());
            var s = new string(Enumerable.Repeat('x', 200000).ToArray()); //Console.ReadLine();
            var t = new string(Enumerable.Repeat('y', 200000).ToArray()); //Console.ReadLine();


            var distance = Distance(s, t);


            var bestMatch = BestMatch(s, t, n);
            Console.WriteLine(distance - bestMatch.Score);
            //Console.WriteLine(String.Format("{0} {1}", Math.Min(bestMatch.I+1, bestMatch.J+1), Math.Max(bestMatch.I+1, bestMatch.J+1)));
            Console.WriteLine(String.Format("{0} {1}", bestMatch.I + 1, bestMatch.J + 1));

            //Console.ReadLine();
        }

        static Match BestMatch(string s, string t, int n)
        {
            var match = new Match
            {
                I = -2,
                J = -2,
                Score = 0
            };            

            for (int i = 0; i < n; i++)
            {
                if (s[i] != t[i])
                {   
                    for (int j = 0; j < n; j++)
                    {
                        if (t[j] == s[i] && t[j] != s[j])
                        {
                            if (s[j] == t[i])
                            {
                                return new Match
                                {
                                    I = i,
                                    J = j,
                                    Score = 2
                                };
                            }

                            match = new Match
                            {
                                I = i,
                                J = j,
                                Score = 1
                            };
                        }
                    }
                }
            }

            return match;
        }

        static int Distance(string s1, string s2)
        {
            int result = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    result++;
                }
            }
            return result;
        }

        class Match
        {
            public int I { get; set; }

            public int J { get; set; }

            public int Score { get; set; }
        }
    }
}
