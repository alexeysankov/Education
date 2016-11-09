using System;

namespace Algorithms
{
    //Создать связанный список из бинарного дерева
    public class Task12
    {
    }

    public class ListNode
    {
        public ListNode Next { get; set; }
        public int Value { get; set; }

        public ListNode(int newElement)
        {
            Value = newElement;
        }
    }

    public class LinkedList
    {
        private ListNode _head;

        public void AddElement(int newElement)
        {
            if (_head == null)
            {
                _head = new ListNode(newElement);
                return;
            }

            var tmp = new ListNode(newElement);
            tmp.Next = _head;
            _head = tmp;            
        }

        public void Show()
        {
            var head = _head;
            while (_head.Next != null)
            {
                Console.Write("{0}, ", _head.Value);
                _head = _head.Next;
            }
            Console.Write("{0}, ", _head.Value);
            _head = head;
        }
    }
    
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Element { get; set; }

        public Node(int element)
        {
            Element = element;
        }
    }

    public class Tree
    {
        private Node _root;

        public void AddElement(int newElement)
        {
            if (_root == null) 
            {
                _root = new Node(newElement);
                return;
            }
            AddElementRecursion(_root, newElement);
        }

        private static void AddElementRecursion(Node currentNode, int newElement)
        {
            if (currentNode.Element < newElement)
            {
                if (currentNode.Right == null)
                    currentNode.Right = new Node(newElement);
                else 
                    AddElementRecursion(currentNode.Right, newElement);
            }
            else 
            {
                if (currentNode.Left == null)                   
                    currentNode.Left = new Node(newElement);
                else 
                    AddElementRecursion(currentNode.Left, newElement);
            }

        }

        public LinkedList ConvertToLinkedList()
        {
            var linkedList = new LinkedList();
            ConvertElement(_root, linkedList);
            return linkedList;
        }

        private static void ConvertElement(Node currentNode, LinkedList linkedList)
        {
            if (currentNode.Right != null)
                ConvertElement(currentNode.Right, linkedList);

            linkedList.AddElement(currentNode.Element);

            if (currentNode.Left != null)
                ConvertElement(currentNode.Left, linkedList);
        }
    }

}