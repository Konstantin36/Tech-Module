using System.Diagnostics.Eventing.Reader;

namespace Arrays
{
    using System;
    using System.Linq;

    public class ArraysMain
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                int[] args = new int[2];
                string[] stringParams = command.Split(ArgumentsDelimiter);

                if (stringParams[0].Equals("add") ||
                    stringParams[0].Equals("subtract") ||
                    stringParams[0].Equals("multiply"))
                {                   
                    args[0] = int.Parse(stringParams[1]);
                    args[1] = int.Parse(stringParams[2]);
                }

               array = PerformAction(array, stringParams[0], args);

               
                //Console.WriteLine('\n');

                command = Console.ReadLine();
            }
        }

        static long[] PerformAction(long[] array, string action, int[] args)
        {
            //long[] array = arr.Clone() as long[];
            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    PrintArray(array);
                    break;
                case "add":
                    array[pos] += value;
                    PrintArray(array);
                    break;
                case "subtract":
                    array[pos] -= value;
                    PrintArray(array);
                    break;
                case "lshift":
                    array = ArrayShiftLeft(array);
                    PrintArray(array);
                    break;
                case "rshift":
                    array = ArrayShiftRight(array);
                    PrintArray(array);
                    break;
            }

            return  array;
        }

        private static long[] ArrayShiftRight(long[] array)
        {
            long[] prevArr = array;
            long[] newArr = new long[prevArr.Length];

            newArr[0] = prevArr[prevArr.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                newArr[i] = array[i - 1];
            }
            array = newArr;
            return array;
        }

        private static long[] ArrayShiftLeft(long[] array)
        {
            long[] prevArr = array;
            long[] newArr = new long[prevArr.Length];

            newArr[newArr.Length - 1] = prevArr[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                newArr[i] = array[i + 1];
            }

            array = newArr;
            return array;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}