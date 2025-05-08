using System;
using System.Collections.Generic;

namespace LinkedListOOP
{
    // Node class represents a single element in the singly linked list
    public class Node
    {
        public float Data { get; set; }
        public Node Next { get; set; }

        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    // SinglyLinkedList class encapsulates list operations
    public class SinglyLinkedList
    {
        private Node head;

        public SinglyLinkedList()
        {
            head = null;
        }

        // Add new node after the second element
        public void AddAfterSecond(float value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }

            if (head.Next == null)
            {
                head.Next = new Node(value);
                return;
            }

            Node second = head.Next;
            Node newNode = new Node(value)
            {
                Next = second.Next
            };
            second.Next = newNode;
        }

        // Find first negative element
        public Node FindFirstNegative()
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data < 0)
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Calculate sum of elements greater than average
        public float SumGreaterThanAverage()
        {
            if (head == null)
                return 0;

            // compute average
            int count = 0;
            float sum = 0;
            Node current = head;
            while (current != null)
            {
                sum += current.Data;
                count++;
                current = current.Next;
            }
            float avg = sum / count;

            // sum elements > average
            float result = 0;
            current = head;
            while (current != null)
            {
                if (current.Data > avg)
                    result += current.Data;
                current = current.Next;
            }
            return result;
        }

        // Get new list of positive elements
        public SinglyLinkedList GetPositiveElementsList()
        {
            SinglyLinkedList positiveList = new SinglyLinkedList();
            Node current = head;

            // we will add at end to preserve order
            Node tail = null;
            while (current != null)
            {
                if (current.Data > 0)
                {
                    Node newNode = new Node(current.Data);
                    if (positiveList.head == null)
                    {
                        positiveList.head = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        tail.Next = newNode;
                        tail = newNode;
                    }
                }
                current = current.Next;
            }
            return positiveList;
        }

        // Remove all negative elements from current list
        public void RemoveNegativeElements()
        {
            // remove from head
            while (head != null && head.Data < 0)
            {
                head = head.Next;
            }

            Node current = head;
            while (current != null && current.Next != null)
            {
                if (current.Next.Data < 0)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        // Utility: Print list contents
        public void PrintList()
        {
            Node current = head;
            Console.Write("List: ");
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new SinglyLinkedList();

            // Example: populate list
            float[] values = { 3.5f, -2.2f, 7.1f, 0f, -5.4f, 8.8f };
            foreach (var v in values)
            {
                list.AddAfterSecond(v);
            }

            Console.WriteLine("Initial list:");
            list.PrintList();

            // 1. Find first negative
            var negNode = list.FindFirstNegative();
            Console.WriteLine(negNode != null
                ? $"First negative element: {negNode.Data}" 
                : "No negative elements found.");

            // 2. Sum greater than average
            float sumGtAvg = list.SumGreaterThanAverage();
            Console.WriteLine($"Sum of elements > average: {sumGtAvg}");

            // 3. New list of positive elements
            var posList = list.GetPositiveElementsList();
            Console.WriteLine("List of positive elements:");
            posList.PrintList();

            // 4. Remove all negative elements
            list.RemoveNegativeElements();
            Console.WriteLine("List after removing negative elements:");
            list.PrintList();
        }
    }
}
