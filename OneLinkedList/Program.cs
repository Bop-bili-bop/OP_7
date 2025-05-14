using System;
using SinglyLinkedListLibrary;

namespace SinglyLinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList();
            list.Add(3.4f);
            list.Add(-2.1f);
            list.AddAfterIndex(1, 5.7f);
            list.AddAfterSecond(-8.3f);
            list.AddAfterSecond(-1.1f);
            list.AddAfterSecond(9.3f);

            Console.WriteLine("Orinial list");
            list.Print();

            Console.WriteLine("First negative:");
            Console.WriteLine(list.FindFirstNegative());

            Console.WriteLine("Sum greater than average:");
            Console.WriteLine(list.SumGreaterThanAverage());

            Console.WriteLine("Positive elements:");
            var positives = list.GetPositiveElements();
            positives.Print();

            Console.WriteLine("Delete all the negative elements:");
            list.RemoveNegatives();
            list.Print();

            Console.WriteLine("Element with index 1:");
            Console.WriteLine(list[1]);

            Console.WriteLine("Remove element with index 1:");
            list.RemoveAt(1);
            list.Print();

            Console.WriteLine("Iteration using foreach:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}