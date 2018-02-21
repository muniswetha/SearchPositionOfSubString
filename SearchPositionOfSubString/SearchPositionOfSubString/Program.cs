using System;

namespace SearchPositionOfSubString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------Program to search the first position of a substring within a string--------");
            Console.WriteLine("\n");

            Console.WriteLine("Input a String:");
            var inputString = Console.ReadLine();

            Console.WriteLine("Input a substring to be found in the string:");
            var substring = Console.ReadLine();

            var position = GetPositionOfSubSctring(inputString, substring);

            Console.WriteLine(position < 0
                    ? "Substring '{0}' is not found in given input string '{1}'"
                    : "Found '{0}' in '{1}' at position {2}", substring, inputString, position);

            Console.ReadLine();
        }

        private static int GetPositionOfSubSctring(string inputString, string subString)
        {
            int position = -1, inputStringIndex = 0, subStringIndex = 0;

            if (subString.Length > inputString.Length)
            {
                return position;
            }

            if (subString.Length == inputString.Length &&
                (subString[0] != inputString[0] || subString[subString.Length - 1] != inputString[inputString.Length - 1]))
            {
                return position;
            }

            while (inputStringIndex < inputString.Length)
            {
                if (subStringIndex < subString.Length)
                {
                    if (inputString[inputStringIndex] == subString[subStringIndex])
                    {
                        position = inputStringIndex;
                        subStringIndex++;
                    }
                    else if(position >= 0)
                    {
                        inputStringIndex = position - subStringIndex + 1;
                        position = -1;
                        subStringIndex = 0;
                    }
                }
                else
                {
                    return position - subString.Length + 1;
                }

                inputStringIndex++;
            }

            return position - subString.Length + 1;
        }
    }
}
