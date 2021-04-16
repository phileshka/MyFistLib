//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MyFirstLibrary
//{
//    public class DoubleLinkedList : IList
//    {
//        private DoubleNode _root;
//        private DoubleNode _tail;

//        public int Length { get; private set; }

//        public int this[int index]
//        {
//            get
//            {
//                DoubleNode current = _root;

//                for (int i = 1; i <= index; i++)
//                {
//                    current = current.Next;
//                }
//                return current.Value;
//            }

//            set
//            {
//                DoubleNode current = _root;

//                for (int i = 1; i <= index; i++)
//                {
//                    current = current.Next;
//                }

//                current.Value = value;
//            }
//        }

//        public DoubleLinkedList()
//        {
//            Length = 0;
//            _root = null;
//            _tail = null;
//        }

//        public DoubleLinkedList(int value)
//        {
//            {
//                Length = 0;
//                _root = null;
//                _tail = null;
//            }
//        }

//        public DoubleLinkedList(int[] values)
//        {
//            Length = values.Length;

//            if (values.Length != 0)
//            {
//                _root = new DoubleNode(values[0]);
//                _root.Previous = null;
//                _tail = _root;

//                for (int i = 1; i < values.Length; ++i)
//                {
//                    _tail.Next = new DoubleNode(values[i]);
//                    _tail = _tail.Next;
//                }
//            }

//            else
//            {
//                _root = null;
//                _tail = null;
//            }

//        }

//        public void Add(int value)
//        {
//            ++Length;
//            _tail.Next = new DoubleNode(value);
//            _tail = _tail.Next;

//        }

//        public void AddInStart(int value)
//        {
//            ++Length;
//            DoubleNode _start = new DoubleNode(value);
//            _start.Next = _root;
//            _root = _start;
//        }

//        public void AddByIndex(int value, int index)
//        {
//            DoubleNode current = _root;

//            if (index >= 0 && index < Length)
//            {
//                for (int i = 1; i < index; i++)
//                {
//                    current = current.Next;
//                    current.Next.Next.Value = value;
//                    ++Length;
//                }
//            }
//        }

//        public void Remove()
//        {
//            DoubleNode current = _tail;
//            _tail = _tail.Previous;
//            _tail.Next = null;
//            --Length;
//        }

//        public void RemoveFromStart()
//        {
//            _root = _root.Next;
//            --Length;
//        }

//        public void RemoveByIndex(int index)
//        {
//            if (Length / 2 > index)
//            {
//                DoubleNode current = _root;

//                for (int i = 1; i < index; ++i)
//                {
//                    current = current.Next;
//                }

//                current.Next = current.Next.Next;
//                --Length;
//            }

//            else
//            {
//                DoubleNode current = _tail;

//                for (int i = Length; i > index; --i)
//                {
//                    current = current.Previous;
//                }

//                current.Previous = current.Previous.Previous;
//                --Length;
//            }
//        }

//        public void RemoveNElements(int nElements)
//        {
//            if (Length >= nElements)
//            {
//                if (nElements >= 0)
//                {
//                    int res = Length - nElements;
//                    DoubleNode current = _tail;

//                    for (int i = Length; i > res - 1; --i)
//                    {
//                        current = current.Previous;
//                    }

//                    current.Previous = _tail;
//                    Length -= nElements;
//                }
//            }

//            else
//            {
//                throw new IndexOutOfRangeException();
//            }
//        }

//        public void RemoveNElementsFromStart(int nElements)
//        {
//            if (Length >= nElements)
//            {
//                if (nElements >= 0)
//                {
//                    DoubleNode current = _root;

//                    for (int i = 1; i < nElements; ++i)
//                    {
//                        current = current.Next;
//                    }

//                    current.Next = _root;
//                }
//            }

//            else
//            {
//                throw new IndexOutOfRangeException();
//            }
//        }

//        public int GetIndexByValue(int value)
//        {
//            DoubleNode current = _root;
//            for (int i = 1; i < Length; ++i)
//            {
//                if (current.Value == value)
//                {
//                    return i;
//                }
//            }

//            return -1;
//        }

//        public int FindIndexOfMaxElement()
//        {
//            DoubleNode current = _root;
//            int maxIndex = 0;
//            int temp = current.Value;

//            for (int i = 1; i < Length; ++i)
//            {
//                if (temp < current.Value)
//                {
//                    maxIndex = i;
//                    temp = current.Value;
//                }

//                current = current.Next;
//            }

//            return maxIndex;
//        }

//        public int FindIndexOfMinElement()
//        {
//            DoubleNode current = _root;
//            int minIndex = 0;
//            int temp = current.Value;

//            for (int i = 1; i < Length; ++i)
//            {
//                if (temp > current.Value)
//                {
//                    minIndex = i;
//                    temp = current.Value;
//                }

//                current = current.Next;
//            }

//            return minIndex;
//        }

//        public int FindMaxElement()
//        {
//            DoubleNode current = _root;
//            int max = current.Value;

//            for (int i = 1; i < Length; ++i)
//            {
//                if (max < current.Value)
//                {
//                    max = current.Value;
//                }

//                current = current.Next;
//            }

//            return max;
//        }

//        public int FindMinElement()
//        {
//            DoubleNode current = _root;
//            int min = current.Value;

//            for (int i = 1; i < Length; ++i)
//            {
//                if (min > current.Value)
//                {
//                    min = current.Value;
//                }

//                current = current.Next;
//            }

//            return min;
//        }

//        //public DoubleNode GetNodeByIndex(int index)
//        //{
//        //    DoubleNode current = _root;

//        //    if (Length / 2 > index)
//        //    {
//        //        for (int i = 1; i < index; ++i)
//        //        {
//        //            current = current.Next;
//        //        }
//        //    }

//        //    else
//        //    {
//        //        current = _tail;

//        //        for (int i = Length; i > index; --i)
//        //        {
//        //            current = current.Previous;
//        //        }
//        //    }

//        //    return current;
//        //}

//        public override string ToString()
//        {
//            if (Length != 0)
//            {
//                DoubleNode current = _root;
//                StringBuilder result = new StringBuilder(string.Empty);
//                result.Append(current.Value + " ");

//                while (!(current.Next is null))
//                {
//                    current = current.Next;
//                    result.Append(current.Value + " ");
//                }

//                return result.ToString().Trim();
//            }
//            else
//            {
//                return String.Empty;
//            }
//        }

//        public override bool Equals(object obj)
//        {
//            if (!(obj is null) || obj is DoubleLinkedList)
//            {
//                DoubleLinkedList list = (DoubleLinkedList)obj;
//                bool isEqual = false;
//                if (this.Length == list.Length)
//                {
//                    isEqual = true;
//                    DoubleNode currentThis = this._root;
//                    DoubleNode currentList = list._root;
//                    DoubleNode currentPrevThis = this._tail;
//                    DoubleNode currentPrevList = list._tail;
//                    while (!(currentThis is null))
//                    {
//                        if (currentThis.Value != currentList.Value || currentPrevThis.Value != currentPrevList.Value)
//                        { isEqual = false; break; }
//                        currentThis = currentThis.Next;
//                        currentList = currentList.Next;
//                        currentPrevThis = currentPrevThis.Previous;
//                        currentPrevList = currentPrevList.Previous;
//                    }
//                }

//                return isEqual;
//            }

//            throw new ArgumentException("obj is not LinkedList");
//        }

//        public void RemoveNElementsByIndex(int nElements, int index)
//        {
//            throw new NotImplementedException();
//        }

//        public void Reverse()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
