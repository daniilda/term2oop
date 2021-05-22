using System;
using System.Collections;
using System.Collections.Generic;

namespace homework.Models
{
    //As mush as I know использовать стандартную структуру в .NET LinkedList не получиться ТК она несовсем линейный (односвязный список)
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
            }

            tail = node;

            count++;
        }
        

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }

                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }
        
        public int Count
        {
            get { return count; }
        }
        

        public bool IsEmpty
        {
            get { return count == 0; }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public List<T> ToList() //Требуется для DataGrid 
        {
            var list = new List<T>();
            Node<T> current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list;
        }

        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        public LinkedList<T> FindAll(Predicate<T> pred )
        {
            var list = new LinkedList<T>();
            Node<T> current = head;
            while (current != null)
            {
                if (pred(current.Data)) //Боже надеюсь это работает
                {
                    list.Add(current.Data);
                }
                
                
                current = current.Next;
            }


            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        
    }
}