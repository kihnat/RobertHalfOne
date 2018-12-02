using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobertHalfProblemOne
{
    class Program
    {
        /*
   I typically use nUnit for my test cases, but I know that I shouldn't need you to download anything for the program to run. 
   I didn't want to just hard code in some test cases that it then just prints to the screen so I made it accept input from me and that spits out the result.
   I have included below the test cases that I used for debugging
   12~23 + 1234% = Please enter numbers only
   1234 + 204 = 4732
   1 + 54321 = 12346
   00 + 01234 = 43210
   123 + 1230 = 642
   1 + 00000 = 1
*/
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number list");
            var first = GetNumber();
            Console.WriteLine("Enter the second number list");
            var second = GetNumber();
            var result = ComputeAddition(first, second);
            Console.WriteLine("The result is: ");
            result.ToList().ForEach(Console.Write);
            Console.ReadLine();
        }

        private static LinkedList<int> GetNumber()
        {
            string input = Console.ReadLine();

            //I want to double check that I've been given only integers.
            Regex regex = new Regex("^[0-9]+$");
            bool isNumberOnly = regex.IsMatch(input);
            while (!isNumberOnly)
            {
                Console.WriteLine("Please enter numbers only!");
                input = Console.ReadLine();
                isNumberOnly = regex.IsMatch(input);
            }

            //Generating a linked list from the input
            var intArray = input.ToCharArray();
            var numberList = new LinkedList<int> { };
            foreach (var letter in intArray)
            {
                numberList.AddLast(Int32.Parse(letter.ToString()));
            }
            return numberList;
        }

        private static LinkedList<int> ComputeAddition(LinkedList<int> first, LinkedList<int> second)
        {
            //I want to make sure the first array is the longer of the two
            if (first.Count() < second.Count())
            {
                var intermediate = first;
                first = second;
                second = intermediate;
            }

            LinkedList<int> ret = new LinkedList<int> { };
            while (first.Count() >0)
            {
                if (second.Count() >0)
                {
                    ret.AddFirst(first.First.Value + second.First.Value);
                    first.RemoveFirst();
                    second.RemoveFirst();
                }
                else
                {
                    ret.AddFirst(first.First.Value);
                    first.RemoveFirst();
                }
               
            }
            while(ret.First.Value == 0)
            {
                if (ret.Count >1)
                {
                    ret.RemoveFirst();
                }
                else
                {
                    break;
                }
            }
            return ret;
        }

    }
}
