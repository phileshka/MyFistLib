using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstLibrary
{
    public class DoubleLinkedList : IList
    {
        private DoubleNode _root;
        private DoubleNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                DoubleNode current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }

            set
            {
                DoubleNode current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        public DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleNode(values[0]);
                _root.Previous = null;
                _tail = _root;

                for (int i = 1; i < values.Length; ++i)
                {
                    _tail.Next = new DoubleNode(values[i]);
                    _tail = _tail.Next;
                }
            }

            else
            {
                _root = null;
                _tail = null;
            }
        }
        public static DoubleLinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new DoubleLinkedList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            ++Length;
            if (_tail != null)
            {
                _tail.Next = new DoubleNode(value);
                _tail = _tail.Next;
            }
            else
            {
                _tail = new DoubleNode(value);
            }

        }

        public void AddInStart(int value)
        {
            ++Length;
            DoubleNode _start = new DoubleNode(value);
            _start.Next = _root;
            _root = _start;
        }

        public void AddByIndex(int value, int index)
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
            if (index > 0 && index < Length - 1)
            {

                DoubleNode current = _root;
                DoubleNode insert = new DoubleNode(value);

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
            DoubleNode current = _root;
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

            DoubleNode current = _root;

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
                    DoubleNode current = _root;

                    for (int i = 1; i < res; ++i)
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
                    DoubleNode current = _root;

                    for (int i = 1; i < nElements; ++i)
                    {
                        current = current.Next;
                    }

                    _root = current.Next;
                    Length -= nElements;
                }
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void RemoveNElementsByIndex(int nElements, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveNElementsFromStart(nElements);
                }
                else if (nElements == Length - 1)
                {
                    RemoveNElements(nElements);
                }
                else if (nElements > 0)
                {
                    DoubleNode current = _root;
                    DoubleNode tmp = _root;

                    for (int i = 1; i < index; ++i)
                    {
                        current = current.Next;
                        tmp = tmp.Next;
                    }
                    if (nElements + index >= Length)
                    {
                        Length = index;
                        current.Next = null;
                    }
                    else
                    {
                        for (int i = index; i <= index + nElements; ++i)
                        {
                            tmp = tmp.Next;
                        }

                        Length -= nElements;
                        current.Next = tmp;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid count");
                }
            }
            else if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetIndexByValue(int value)
        {
            DoubleNode current = _root;

            for (int i = 0; i < Length; ++i)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        public void Reverse()
        {
            DoubleNode current = _root;
            DoubleNode next = null;

            while (current != null)
            {
                DoubleNode tmp = current.Next;
                current.Next = next;
                next = current;
                current = tmp;
            }

            _root = next;
        }

        public int FindIndexOfMaxElement()
        {
            DoubleNode current = _root;
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
            DoubleNode current = _root;
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
            DoubleNode current = _root;
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
            DoubleNode current = _root;
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
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(max).Value < GetNodeByIndex(j).Value)
                    {
                        max = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(max).Value;
                GetNodeByIndex(max).Value = temp;
            }
        }

        public void SortInDecreasingOrder()
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(max).Value < GetNodeByIndex(j).Value)
                    {
                        max = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(max).Value;
                GetNodeByIndex(max).Value = temp;
            }
        }

        public void RemoveByValueFirst(int value)
        {
            int index = GetIndexByValue(value);

            if (!(value == -1))
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveByValueAll(int value)
        {
            int indexOfElements = GetIndexByValue(value);

            while (indexOfElements != -1)
            {
                RemoveByIndex(indexOfElements);
                indexOfElements = GetIndexByValue(value);
            }
        }

        public void AddListToTheEnd(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    _tail.Next = secondList._root;
                    secondList._root.Previous = _tail;
                    _tail = secondList._tail;

                    Length += secondList.Length;

                }

                else
                {
                    throw new ArgumentException("No elements in list!");
                }
            }

            else
            {
                _root = secondList._root;
                _tail = secondList._tail;

                Length = secondList.Length;
            }
        }

        public void AddListToStart(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    secondList._tail.Next = _root;
                    _root.Previous = secondList._tail;
                    _root = secondList._root;

                    Length += secondList.Length;
                }

                else
                {
                    throw new ArgumentException("No elements in list!");
                }
            }

            else
            {
                _root = secondList._root;
                _tail = secondList._tail;

                Length = secondList.Length;
            }
        }

        public void AddListByIndex(DoubleLinkedList secondList, int index)
        {
            if (secondList.Length != 0)
            {
                if (index >= 0 && index <= Length)
                {
                    if (Length != 0)
                    {
                        if (index == 0)
                        {
                            AddListToStart(secondList);
                        }

                        else
                        {
                            DoubleNode current = GetNodeByIndex(index - 1);

                            secondList._tail.Next = current.Next;
                            current.Next.Previous = secondList._tail;
                            current.Next = secondList._root;
                            secondList._root.Previous = current;

                            Length += secondList.Length;
                        }
                    }

                    else
                    {
                        _root = secondList._root;
                        _tail = secondList._tail;

                        Length = secondList.Length;
                    }
                }

                else
                {
                    throw new IndexOutOfRangeException("Out of range!");
                }
            }

            else
            {
                throw new ArgumentException("No elements in list!");
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                DoubleNode current = _root;
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
            DoubleLinkedList list = (DoubleLinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            bool result = true;
            DoubleNode current = _root;
            DoubleNode comparable = list._root;

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

        private DoubleNode GetNodeByIndex(int index)
        {
            DoubleNode current;

            if (index > Length / 2 + 1) //+1
            {
                current = _tail;
                for (int i = Length - 1; i > index; i--) //>=
                {
                    current = current.Previous;
                }
                return current;
            }

            else
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }

        }
    }
}
