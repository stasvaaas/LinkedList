using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }



    internal class LinkedList<T>
    {
        public Node<T>? Head { get; private set; }

        private List<Node<T>> _nodes = new List<Node<T>>();

        public void Add(T value)
        {
            //if list is empty - sets valuse as a Head
            Node<T> newNode = new Node<T>(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                //if there is a next node - current variable sets to the next Node
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                //if next node is null - next node sets to the newNode
                current.Next = newNode;
            }
            _nodes.Add(newNode);
        }

        public Node<T> searchNodeAt(int index)
        {
            if(index < 0 || index >= _nodes.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node<T> current = Head;
            int currentIndex = 0;
            while(currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            return current;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= _nodes.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(index == 0)
            {
                Head = Head.Next;
            }
            else 
            //we found the node that is before the node we want to delete
            //and set this previous node's Next  to skip(delete) our needed node
            //and point Next to the node after the one we want to delete
            {
                Node<T> previous = searchNodeAt(index - 1);
                previous.Next = previous.Next.Next;
            }
        }

        public bool IsEmpty()
        {
            return _nodes.Count == 0;
        }

    }
}
