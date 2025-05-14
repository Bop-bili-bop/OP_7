using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedListLibrary
{
    public class Node
    {
        public float Data;
        public Node? Next;

        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    
    public class SinglyLinkedList : IEnumerable<float>
    {
        private Node? head;
        public bool IsEmpty()
        {
            Node? current = head;
    
            while (current != null)
            {
                return false; 
            }

            return true; 
        }
        public void Add(float value)
        {
            Node newNode = new Node(value);

            if (IsEmpty())
            {
                head = newNode;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
        
        public void AddAfterIndex(int index, float value)
        {
            Node newNode = new Node(value);

            if (index < 0)
                throw new IndexOutOfRangeException();

            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("List empty");
            }

            int currentIndex = 0;
            Node? current = head;

            while (current != null && currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null)
                throw new IndexOutOfRangeException();

            newNode.Next = current.Next;
            current.Next = newNode;
        }
        
        public void AddAfterSecond(float value) => AddAfterIndex(1, value);
        public float? FindFirstNegative()
        {
            var current = head;
            while (current != null)
            {
                if (current.Data < 0)
                    return current.Data;
                current = current.Next;
            }
            return null;
        }

        private float FindAverage()
        {
            float sum = 0;
            int count = 0;
            var current = head;
            while (current != null)
            {
                sum += current.Data;
                count++;
                current = current.Next;
            }
            return count == 0 ? 0 : sum / count;
        }
        
        public float SumGreaterThanAverage()
        {
            float average = FindAverage();
            float sum = 0;
            var current = head;
            while (current != null)
            {
                if (current.Data > average)
                    sum += current.Data;
                current = current.Next;
            }
            return sum;
        }
        
        public SinglyLinkedList GetPositiveElements()
        {
            var result = new SinglyLinkedList();
            foreach (var value in this)
            {
                if (value > 0)
                {
                    result.Add(value); 
                }
            }
            return result;
        }
        
        public void RemoveNegatives()
        {
            while (head != null && head.Data < 0)
            {
                head = head.Next;
            }

            var current = head;
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
        
        public float this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();

                int count = 0;
                var current = head;
                while (current != null)
                {
                    if (count == index)
                        return current.Data;
                    count++;
                    current = current.Next;
                }

                throw new IndexOutOfRangeException();
            }
        }
        
        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            if (head == null)
                throw new InvalidOperationException("List is empty");

            if (index == 0)
            {
                head = head.Next;
                return;
            }

            Node? current = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null || current.Next == null)
                    throw new IndexOutOfRangeException();
                current = current.Next;
            }

            if (current.Next == null)
                throw new IndexOutOfRangeException();

            current.Next = current.Next.Next;
        }
        
        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        
        public IEnumerator<float> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
