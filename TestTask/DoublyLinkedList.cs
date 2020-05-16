using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Свойство для получения количества элементов в списке.
        /// </summary>
        public int Count { get; private set; }
        Node<T> Head { get; set; }
        Node<T> Tail { get; set; }

        public DoublyLinkedList() { }

        public DoublyLinkedList(T data)
        {
            Node<T> node = new Node<T>(data);
            Head = node;
            Tail = node;
            Count = 1;
        }

        /// <summary>
        /// Метод для вставки новых элементов в конец списка.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }

            Count++;
        }

        /// <summary>
        /// Метод для вставки новых элементов в произвольную позицию, по индексу.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public void Insert(T data, int index)
        {
            Node<T> node = new Node<T>(data);

            if (index == 0)
            {
                if (Count == 0)
                {
                    Add(data);
                    return;
                }
                else
                {
                    Head.Prev = node;
                    node.Next = Head;
                    Head = node;
                }
            }
            else if (index == Count)
            {
                Add(data);
                return;
            }
            else if ((Count - index) > index)
            {
                Node<T> prev = Head;

                for (int i = 0; i < index - 1; i++)
                {
                    prev = prev.Next;
                }

                node.Next = prev.Next;
                node.Prev = prev;
                prev.Next.Prev = node;
                prev.Next = node;
            }
            else
            {
                Node<T> next = Tail;

                for (int i = Count - 1; i > index; i--)
                {
                    next = next.Prev;
                }

                node.Next = next;
                node.Prev = next.Prev;
                next.Prev.Next = node;
                next.Prev = node;
            }

            Count++;
        }

        /// <summary>
        /// Метод для удаления элементов списка по индексу.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            else if (index == Count - 1)
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            else if ((Count - index) > index)
            {
                Node<T> prev = Head;

                for (int i = 0; i < index - 1; i++)
                {
                    prev = prev.Next;
                }

                prev.Next = prev.Next.Next;
                prev.Next.Prev = prev;
            }
            else
            {
                Node<T> next = Tail;

                for (int i = Count - 1; i > index + 1; i--)
                {
                    next = next.Prev;
                }

                next.Prev = next.Prev.Prev;
                next.Prev.Next = next;
            }

            Count--;
            GC.Collect();
        }

        /// <summary>
        /// Метод для получения элемента списка по индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetElement(int index)
        {
            if ((Count - index) > index)
            {
                Node<T> current = Head;

                for (int i = 0; current != null; i++)
                {
                    if (i == index)
                    {
                        return current.Data;
                    }
                    current = current.Next;
                }
            }
            else
            {
                Node<T> current = Tail;

                for (int i = Count -1; current != null; i--)
                {
                    if (i == index)
                    {
                        return current.Data;
                    }
                    current = current.Prev;
                }
            }         

            return default(T);
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
