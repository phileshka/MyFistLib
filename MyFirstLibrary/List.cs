using System;

namespace MyFirstLibrary
{
    public class List : IList
    {
        public int Length { get; private set; }
        private int[] _array;

        public List()
        {
            Length = 0;
            _array = new int[10];
        }

        public List(int value)
        {
            Length = 1;
            _array = new int[11];
            _array[0] = value;
        }

        public List(int[] value)
        {
            if (!(value == null))
            {
                Length = value.Length;
                _array = new int[value.Length];

                for (int i = 0; i < value.Length; ++i)
                {
                    _array[i] = value[i];
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public int this[int index]
        {
            get { return _array[index]; }

            set
            {
                if (!(index >= Length || index <= 0))
                {
                    _array[index] = value;
                }

                else
                {
                    throw new IndexOutOfRangeException(" Index out of range");
                }
            }
        }

        public void Add(int value)
        {
            int lastIndex = Length;
            AddByIndex(value, lastIndex);
        }

        public void AddInStart(int value)
        {
            int startIndex = 0;
            AddByIndex(value, startIndex);
        }

        public void AddByIndex(int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length >= _array.Length)
                {
                    Resize();
                }

                for (int i = Length; i >= index; --i)
                {
                    if (i + 1 < _array.Length)
                    {
                        _array[i + 1] = _array[i];
                    }
                }

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            --Length;
        }

        public void RemoveFromStart()
        {
            int startIndex = 0;
            RemoveByIndex(startIndex);
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length > 0)
                {
                    for (int i = index; i < Length; ++i)
                    {
                        if (i + 1 < _array.Length)
                        {
                            _array[i] = _array[i + 1];
                        }
                    }

                    Resize();
                    --Length;
                }
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

                    Length -= nElements;
                }
            }
            else
            {
                Length = 0;
            }

            Resize();
        }

        public void RemoveNElementsFromStart(int nElements)
        {
            int startIndex = 0;
            RemoveNElementsByIndex(startIndex, nElements);
        }

        public void RemoveNElementsByIndex(int index, int nElements)
        {
            if (index > 0 && index <= Length)
            {
                if (Length >= nElements)
                {
                    if (nElements >= 0)
                    {
                        Length -= nElements;
                        ShiftLeft(index, nElements);
                    }
                }

                else
                {
                    Length = index;
                }

                Resize();
            }

            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (value == _array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Reverse()
        {

            for (int i = 0; i < Length / 2; i++)
            {
                Swap(ref _array[i], ref _array[Length - i - 1]);
            }
        }

        public int FindIndexOfMaxElement()
        {
            int indexOfMaxElement = 0;

            if (_array.Length != 0)
            {
                for (int i = 1; i < Length; ++i)
                {
                    if (_array[indexOfMaxElement] < _array[i])
                    {
                        indexOfMaxElement = i;
                    }
                }

                return indexOfMaxElement;
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public int FindIndexOfMinElement()
        {
            int indexOfMinElement = 0;

            if (_array.Length != 0)
            {
                for (int i = 1; i < Length; ++i)
                {
                    if (_array[indexOfMinElement] > _array[i])
                    {
                        indexOfMinElement = i;
                    }
                }

                return indexOfMinElement;
            }

            else
            {
                throw new ArgumentException();
            }
        }

        public int FindMinElement()
        {
            return _array[FindIndexOfMinElement()];
        }

        public int FindMaxElement()
        {
            return _array[FindIndexOfMaxElement()];
        }

        public int[] SortInIncreasingOrder()
        {

            for (int i = 0; i < Length - 1; ++i)
            {
                int min = i;

                for (int j = i + 1; j < Length; ++j)
                {
                    if (_array[j] < _array[min])
                    {
                        min = j;
                    }
                }

                Swap(ref _array[i], ref _array[min]);
            }

            return _array;
        }

        public int[] SortInDecreasingOrder()
        {

            for (int i = 0; i < Length - 1; ++i)
            {
                int max = i;

                for (int j = i + 1; j < Length; ++j)
                {
                    if (_array[max] < _array[j])
                    {
                        max = j;
                    }
                }

                Swap(ref _array[i], ref _array[max]);
            }

            return _array;
        }

        public void RemoveByFirstValue(int value)
        {
            int numberOfElements = 1;
            if (Length > 0)
            {
                for (int i = 0; i < Length; ++i)
                {
                    if (_array[i] == value)
                    {
                        ShiftLeft(i, numberOfElements);
                        --Length;
                        Resize();
                        break;
                    }
                }
            }
        }

        public void RemoveByAllValues(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (value == _array[i])
                {
                    RemoveByIndex(i);
                    --i;
                }
            }
        }

        public void AddList(List list)
        {
            if (list != null && list.Length != 0)
            {
                int lastIndex = Length;
                AddArrayListByIndex(list, lastIndex);
            }
        }

        public void AddListInStart(List list)
        {
            if (list != null && list.Length != 0)
            {
                int firstIndex = 0;
                AddArrayListByIndex(list, firstIndex);
            }
        }

        public void AddArrayListByIndex(List list, int index)
        {
            if (list != null && list.Length != 0)
            {
                if (index >= 0 && index <= Length)
                {
                    Length += list.Length;
                    if (Length >= _array.Length)
                    {
                        Resize();
                    }

                    int tempLength = list.Length;
                    for (int i = Length - 1; i >= index; i--)
                    {
                        if (i + tempLength < _array.Length)
                        {
                            _array[i + tempLength] = _array[i];
                        }
                    }

                    int count = 0;
                    for (int i = index; i < Length; i++)
                    {
                        if (count < list.Length)
                        {
                            _array[i] = list[count++];
                        }
                    }
                }

                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            else
            {
                throw new ArgumentException("List no contains elements");
            }
        }

        private void Resize()
        {
            int tempLength = Length;

            if (Length >= _array.Length || (Length < _array.Length / 2))
            {
                tempLength = (int)(Length * 1.33d + 1);
            }

            int[] temparray = new int[tempLength];

            for (int i = 0; i < temparray.Length; i++)
            {
                if (i < _array.Length)
                {
                    temparray[i] = _array[i];
                }
                else
                {
                    break;
                }
            }

            _array = temparray;
        }

        private void ShiftLeft(int index, int nElements)
        {
            for (int i = index; i < Length; i++)
            {
                if (i + nElements < _array.Length)
                {
                    _array[i] = _array[i + nElements];
                }
            }
        }

        private void ShiftRight(int index, int nElements)
        {
            for (int i = Length - 1; i > index; i--)
            {
                _array[i] = _array[i - nElements];
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public override string ToString()
        {
            string s = string.Empty;

            for (int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }
            return s;
        }

        public override bool Equals(object obj)
        {
            List list = (List)obj;
            if (this.Length != list.Length)
            {

                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (this._array[i] != list._array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
