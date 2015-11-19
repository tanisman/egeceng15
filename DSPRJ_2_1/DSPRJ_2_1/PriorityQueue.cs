using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPRJ_2_1
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> items;

        public PriorityQueue()
        {
            items = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            lock (items)
            {
                if (IsEmpty)
                    items.AddFirst(item);
                else
                {
                    LinkedListNode<T> n = items.First;
                    while (n != null)
                    {
                        if (n.Value.CompareTo(item) >= 0)
                            break;
                        n = n.Next;
                    }

                    if (n != null)
                        items.AddBefore(n, item);
                    else
                        items.AddLast(item);
                }
            }
        }

        public T Dequeue()
        {
            lock (items)
            {
                T it = items.First.Value;
                items.RemoveFirst();
                return it;
            }
        }

        public T Peek()
        {
            lock (items)
            {
                return items.First.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }
    }
}
