using System;
using System.Linq;

namespace VeyorCode
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionOne testOne = new QuestionOne();
            QuestionTwo testTwo = new QuestionTwo();
        }
    }

    class QuestionOne
    {
        public QuestionOne()
        {
            long arrLen = Convert.ToInt64(Console.ReadLine());
            int[] numbers = new int[arrLen];
            for (int index=0; index < arrLen; index++)
            {
                numbers[index] = int.Parse(Console.ReadLine());
            }
            customSort(numbers);
        }

        public static void customSort(int[] arr)
        {
            var result =  arr.GroupBy( n => n )
                .OrderBy(n => n.Count())
                .ThenBy(n => n.Key)
                .SelectMany(n => n);

            foreach(var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
    }

    class QuestionTwo
    {
        static int staticMod = 1000000007;

        public QuestionTwo()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            long k = Convert.ToInt64(Console.ReadLine());
            solver(n,k);
        }

        public static void solver(long n,long k)
        {
            /*
                Explanation:
                Greedy problem involving skipping the first number if it lands on K during with the largest triangular number <= k
                sum of triangular number T = n(n+1) / 2
                equate to zero              n^2 + n - 2T = 0
                solve for n                 n = (-1 +- sqrt(1 - 8T)) / 2
                n is strictly positive      n = (1 + sqrt(1 - 8T)) / 2
                we then find the the largest n that is less than or equal to k
                if this is equal to k we skip the first number, else we take the sum of that trianglular number.
                https://en.wikipedia.org/wiki/Triangular_number
            */
            if (n <= 0)
            {
                System.Console.WriteLine(0);
                return;
            }

            // Find largest triangle number <= k
            long tNumber = (long) Math.Floor(( Math.Sqrt(8*k + 1) - 1 ) / 2 );
            if ( tNumber*(tNumber+1)/2 == k )
            {
                // For this case skip 1
                System.Console.WriteLine( ((n*(n+1)/2 - 1 ) % staticMod));
                return;
            }
            else
            {
                // We do not need to skip any
                System.Console.WriteLine( ((n*(n+1)/2) % staticMod));
                return;
            }
        }
    }
}
