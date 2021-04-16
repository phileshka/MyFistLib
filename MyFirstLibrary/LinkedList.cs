using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstLibrary
{
    public class LinkedList : IList
    {
        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }

            set
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public LinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length > 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; ++i)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }

            else
            {
                _root = null;
                _tail = null;
            }

        }

        public void Add(int value)
        {
            if (Length > 0)
            {
                ++Length;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
                ++Length;
            }
        }

        public void AddInStart(int value)
        {
            ++Length;
            Node _start = new Node(value);
            _start.Next = _root;
            _root = _start;
        }

        public void AddByIndex(int value, int index)
        {
            Node current = _root;

            if (index > 0 && index<Length-1)
            {
                if (index == 0)
                {
                    AddInStart(value);
                    return;
                }
                else if (index == Length - 1)
                {
                    Add(value);
                    return;
                }

                Node insert = new Node(value);

                for (int i = 1; i < index; ++i)
                {
                    current = current.Next;
                }

                insert.Next = current.Next;
                current.Next = insert;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            Node current = _root;
            for (int i = 1; i < Length - 1; ++i)
            {
                current.Next = null;
                _tail = current;
            }
            --Length;
        }

        public void RemoveFromStart()
        {
            _root = _root.Next;
            --Length;
        }

        public void RemoveByIndex(int index)
        {
            if (index == 0)
            {
                RemoveFromStart();
                return;
            }
            else if (index == Length - 1)
            {
                Remove();
                return;
            }
            
            Node current = _root;

            if (index >= 0 && index < Length - 1)
            {
                for (int i = 1; i < index; ++i)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                --Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveNElements(int nElements)
        {
            if (Length >= nElements)
            {
                if (nElements >= 0)
                {
                    int res = Length - nElements;
                    Node current = _root;

                    for (int i = 1; i < res ; ++i)
                    {
                        current = current.Next;
                    }

                    current.Next = _tail;
                    Length -= nElements;
                }
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveNElementsFromStart(int nElements)
        {
            if (Length >= nElements)
            {
                if (nElements >= 0)
                {
                    Node current = _root;

                    for (int i = 1; i < nElements; ++i)
                    {
                        current = current.Next;
                    }

                    current.Next = _root;
                    --Length;
                }
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //public void RemoveNElementsByIndex(int nElements, int index)
        //{
        //    if (Length >= nElements)
        //    {
        //        if (nElements >= 0)
        //        {
        //            Node current = index;//get node by index
        //            Node range = nElements + index;

        //            RemoveNElements(index);
        //            Length -= nElements;
        //        }
        //    }
        //}//ff

        public int GetIndexByValue(int value)
        {
            Node current = _root;
            for (int i = 1; i < Length; ++i)
            {
                if (current.Value == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse()
        {
            Node current = _root;
            Node next = null;

            while (current != null)
            {
                Node tmp = current.Next;
                current.Next = next;
                next = current;
                current = tmp;
            }

            _root = next;
        }

        public int FindIndexOfMaxElement()
        {
            Node current = _root;
            int maxIndex = 0;
            int temp = current.Value;

            for (int i = 1; i < Length; ++i)
            {
                if (temp < current.Value)
                {
                    maxIndex = i;
                    temp = current.Value;
                }

                current = current.Next;
            }

            return maxIndex;
        }

        public int FindIndexOfMinElement()
        {
            Node current = _root;
            int minIndex = 0;
            int temp = current.Value;

            for (int i = 1; i < Length; ++i)
            {
                if (temp > current.Value)
                {
                    minIndex = i;
                    temp = current.Value;
                }

                current = current.Next;
            }

            return minIndex;
        }

        public int FindMaxElement()
        {
            Node current = _root;
            int max = current.Value;

            for (int i = 1; i < Length; ++i)
            {
                if (max < current.Value)
                {
                    max = current.Value;
                }

                current = current.Next;
            }

            return max;
        }

        public int FindMinElement()
        {
            Node current = _root;
            int min = current.Value;

            for (int i = 1; i < Length; ++i)
            {
                if (min > current.Value)
                {
                    min = current.Value;
                }

                current = current.Next;
            }

            return min;
        }

        public void SortInIncreasingOrder()
        {
            Node current = _root;

            if (Length >= 0)
            {
                for (int i = 1; i < Length - 1; ++i)
                {
                    int min = current.Value;

                    for (int j = i + 1; j < Length; ++j)
                    {
                        if (current.Next.Value < min)
                        {
                            min = current.Next.Value;
                        }
                    }

                    Swap();
                }

                return;
            }
        }

        public void SortInDecreasingOrder()
        {
        }

        public void RemoveByFirstValue(int value)
        {
            Node current = _root;

            if (Length > 0)
            {
                for (int i = 1; i < Length; ++i)
                {
                    current = current.Next;
                    if (current.Value == value)
                    {
                        --Length;
                        break;
                    }
                }
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void RemoveByAllValues(int value)
        {
            Node current = _root;

            if (Length > 0)
            {
                for (int i = 1; i < Length; ++i)
                {
                    current = current.Next;
                    if (current.Value == value)
                    {
                        RemoveByIndex(i);
                        --i;
                    }
                }
            }

            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void Swap()
        {
            Node current = _root;
            int tmp = current.Value;
            current.Next.Value = current.Next.Next.Value;
            current.Next.Next.Value = tmp;
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                StringBuilder result = new StringBuilder(string.Empty);
                result.Append(current.Value + " ");

                while (!(current.Next is null))
                {
                    current = current.Next;
                    result.Append(current.Value + " ");
                }

                return result.ToString().Trim();
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            bool result = true;
            Node current = _root;
            Node comparable = list._root;

            while (current != null && comparable != null)
            {
                if (current.Value != comparable.Value)
                {
                    result = false;
                    break;
                }

                current = current.Next;
                comparable = comparable.Next;
            }

            return result;
        }

        public void RemoveNElementsByIndex(int nElements, int index)
        {
            throw new NotImplementedException();
        }
    }
}
