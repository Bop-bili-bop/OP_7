using System.Collections;

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
        public void AddAfterSecond(float value)
        {
            Node newNode = new Node(value);
            if (head == null || head.Next == null)
            {
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    head.Next = newNode;
                }
            }
            else
            {
                Node second = head.Next;
                newNode.Next = second.Next;
                second.Next = newNode;
            }
        }

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
            var current = head;
            while (current != null)
            {
                if (current.Data > 0)
                {
                    result.AddAfterSecond(current.Data); 
                }
                current = current.Next;
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
