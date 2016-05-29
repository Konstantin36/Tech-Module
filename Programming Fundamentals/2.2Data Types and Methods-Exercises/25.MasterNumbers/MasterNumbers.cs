using System;

namespace _25.MasterNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class MasterNumbers
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i < number; i++)
            {
                if (IsPalindrome(i) && 
                    (SumOfDigits(i) % 7 == 0) && 
                    ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool ContainsEvenDigit(int i)
        {
            bool isEven = false;

            while (i != 0)
            {
                int currNum = i % 10;
                if (currNum % 2 == 0)
                {
                    isEven = true;
                }
                i /= 10;
            }
            return isEven;
        }

        private static int SumOfDigits(int i)
        {
            int sum = 0;
            while (i != 0)
            {
                sum += i % 10;
                i /= 10;
            }
            return sum;
        }

        private static bool IsPalindrome(int i)
        {
            IEnumerable<char> forwards = i.ToString().ToCharArray();
            return forwards.SequenceEqual(forwards.Reverse());
        }
    }
}