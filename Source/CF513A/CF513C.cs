using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CodeForcesPractice
{
    class CF513C
    {

        private static decimal SumOf(IEnumerable<Pair> selections, int j, long M)
        {
            return (from company in selections
                       let temp = company.SelectedItems.Aggregate(1M, (current, x) => current * xxx(x, j,M))
                       let temp2 = company.Rest.Aggregate(1M, (current, y) => current * yyy(y, j, M))
                       select temp * temp2).Sum();            
        }

        private static void Execute(IList<Interval> intervals)
        {
            int Max = intervals.Max(i => i.R);

            long[] xx = new long[Max+2];

            xx[0] = intervals.Aggregate(1L, (current, i) => current*(i.R - i.L + 1));
            xx[Max+1] = 0;

            long M = 10;

            for (int j = 1; j <= Max; j++)
            {
                decimal sum = 0;

                if (intervals.Count > 2)
                {
                    sum += SumOf(AllPairs(intervals), j, M);
                }
                if (intervals.Count > 3)
                    sum += SumOf(AllThrees(intervals), j, M);

                if (intervals.Count > 4)
                    sum += SumOf(AllFours(intervals), j, M);

                sum += intervals.Aggregate(1M, (current, company) => current * xxx(company, j, M));              

                xx[j] = (long)sum;
                
                //Console.WriteLine(String.Format("xx[{0}]={1}",j,xx[j]));
            }

            long[] yy = new long[Max+1];

            for (int j = 1; j <= Max; j++)
            {
                yy[j] = (xx[j] - xx[j + 1]) * (long)Math.Pow(M, Max);
                //Console.WriteLine(j + "=" + yy[j]);
            }

            double result = 0;

            for (int j = 1; j <= Max; j++)
            {                
                result += (double)j*yy[j]/xx[0];
            }

            Console.WriteLine(result.ToString("F10", CultureInfo.CreateSpecificCulture("en-GB")));
        }

        private static decimal xxx(Interval i, int j, decimal M)
        {
            if (j < i.L)
                return (i.R - i.L + 1)/M;
            if (j > i.R)
                return 0;
            return (i.R - j + 1)/M;
        }

        private static decimal yyy(Interval i, int j, decimal M)
        {
            if (j < i.L)
                return 0;
            if (j > i.R)
                return (i.R-i.L+1)/M;
            return (j - i.L)/M;
        }

        private static IEnumerable<Pair> AllPairs(IList<Interval> intervals)
        {
            for (int i = 0; i < intervals.Count; i++)
            {
                for (int j = i + 1; j < intervals.Count; j++)
                {
                    yield return new Pair(new[]{intervals[i], intervals[j]}, intervals.Where((interval,idx) => idx != i && idx != j).ToList());        
                }
            }
        }

        private static IEnumerable<Pair> AllThrees(IList<Interval> intervals)
        {
            for (int i = 0; i < intervals.Count; i++)
            {
                for (int j = i + 1; j < intervals.Count; j++)
                {
                    for (int k = j + 1; k < intervals.Count; k++)
                    {
                        yield return
                            new Pair(new[] {intervals[i], intervals[j], intervals[k]},
                                intervals.Where((interval, idx) => idx != i && idx != j && idx != k).ToList());
                    }
                }
            }
        }

        private static IEnumerable<Pair> AllFours(IList<Interval> intervals)
        {
            for (int i = 0; i < intervals.Count; i++)
            {
                for (int j = i + 1; j < intervals.Count; j++)
                {
                    for (int k = j + 1; k < intervals.Count; k++)
                    {
                        for (int l = k + 1; l < intervals.Count; l++)
                        {
                            yield return
                                new Pair(new[] { intervals[i], intervals[j], intervals[k], intervals[l] },
                                    intervals.Where((interval, idx) => idx != i && idx != j && idx != k && idx != l).ToList());
                        }
                    }
                }
            }
        }

        //static void Main(string[] args)
        //{
        //    var n = Int32.Parse(Console.ReadLine());

        //    IList<Interval> intervals = new List<Interval>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        var input = Console.ReadLine().Split(' ');    
        //        intervals.Add(new Interval
        //        {
        //            L = Int32.Parse(input[0]),
        //            R = Int32.Parse(input[1])
        //        });
        //    }
            
        //    Execute(intervals);

        //    Console.ReadLine();
        //}

        private class Interval
        {
            public int L { get; set; }

            public int R { get; set; }
        }

        private class Pair
        {
            public Pair(IEnumerable<Interval> selectedItems, IEnumerable<Interval> rest)
            {
                Rest = rest;
                SelectedItems = selectedItems;
            }

            public IEnumerable<Interval> SelectedItems { get; set; }

            public IEnumerable<Interval> Rest { get; set; }
        }
    }
}


//private static void Execute(string[] args)
//{
//    int[] a = {2, 3, 4, 5};
//    int[] b = { 3, 4 };
//    int[] c = { 1, 2, 3, 4, 5, 6 };


//    IList<int[]> outcomes = new List<int[]>();

//    for (int i = 0; i < a.Length; i++)
//    {
//        for (int j = 0; j < b.Length; j++)
//        {
//            for (int k = 0; k < c.Length; k++)
//            {
//                outcomes.Add(new []{a[i],b[j],c[k]});
//            }
//        }
//    }

//    var result = 2.0*outcomes.Count(x => SecondMax(x[0], x[1], x[2]) == 2)/outcomes.Count +
//    3.0 * outcomes.Count(x => SecondMax(x[0], x[1], x[2]) == 3) / outcomes.Count +
//    4.0 * outcomes.Count(x => SecondMax(x[0], x[1], x[2]) == 4) / outcomes.Count +
//    5.0 * outcomes.Count(x => SecondMax(x[0], x[1], x[2]) == 5) / outcomes.Count;



//    foreach (var x in outcomes.Where(x => SecondMax(x[0], x[1], x[2]) == 5))
//    {
//        Console.Write(tostring(x) + " ");
//    }
//    Console.WriteLine();


//    foreach (var x in outcomes.Where(x => SecondMax(x[0], x[1], x[2]) == 4))
//    {
//        Console.Write(tostring(x) + " ");
//    }
//    Console.WriteLine();


//    //for (int i = 2; i <= 5; i++)
//    {

//    }

//    Console.WriteLine(result);
//    Console.ReadLine();

//}

//private static string tostring(int[] x)
//{
//    var sb = new StringBuilder();
//    sb.Append("(");
//    for (int i = 0; i < x.Length; i++)
//        sb.Append(x[i] + ",");
//    sb.Append(")");

//    return sb.ToString();
//}

//private static int SecondMax(int a, int b, int c)
//{
//    if (a >= b & a >= c)
//        return Math.Max(b, c);
//    if (b >= a & b >= c)
//        return Math.Max(a, c);
//    else
//        return Math.Max(a, b);
//}
