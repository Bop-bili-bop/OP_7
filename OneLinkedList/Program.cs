using System;
using SinglyLinkedListLibrary;
class Program
{
    static void Main()
    {
        var list = new SinglyLinkedList();
        list.AddAfterSecond(2.5f);
        list.AddAfterSecond(-3.1f);
        list.AddAfterSecond(1.2f);
        list.AddAfterSecond(4.8f);
        list.AddAfterSecond(-0.5f);

        Console.WriteLine("Original list:");
        list.Print();

        Console.WriteLine("First negative: " + list.FindFirstNegative());
        Console.WriteLine("Sum > average: " + list.SumGreaterThanAverage());

        Console.WriteLine("Positive elements list:");
        var positives = list.GetPositiveElements();
        positives.Print();

        list.RemoveNegatives();
        Console.WriteLine("List after removing negatives:");
        list.Print();
    }
}