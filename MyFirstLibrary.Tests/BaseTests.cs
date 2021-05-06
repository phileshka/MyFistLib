using NUnit.Framework;
using System;

namespace MyFirstLibrary.Tests
{
    public abstract class BaseTests
    {
        protected IList actual;
        protected IList expected;

        public abstract void Init(int[] actualArray, int[] expectedArray);

        [TestCase(4, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(4, new int[] { }, new int[] { 4 })]
        public void Add_WhenValidValues_AddLast(int value, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 8 }, new int[] { 3, 1, 2, 8 })]
        [TestCase(3, new int[] { }, new int[] { 3 })]
        public void AddInStart_WhenValidValues_AddInStart(int value, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.AddInStart(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2, new int[] { 0, 1, 5, 8 }, new int[] { 0, 1, 3, 5, 8 })]
        [TestCase(3, 1, new int[] { 2, 3 }, new int[] { 2, 3, 3 })]
        public void AddByIndex_WhenValidValue_AddByIndex(int value, int index, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-2, -1, new int[] { 2, 3 }, new int[] { 2, 3 })]
        [TestCase(-127, -1, new int[] { 1 }, new int[] { 1 })]
        [TestCase(-127, 11, new int[] { 1 }, new int[] { 1 })]
        public void AddByIndex_WhenNotValidValue_ShouldReturnIndexOutOfRangeException(int value, int index, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value,index));
        }

        [TestCase(new int[] { 0, 1, 5, 8 }, new int[] { 0, 1, 5 })]
        [TestCase(new int[] { 0, 2 }, new int[] { 0 })]
        public void Remove_WhenValidValues_RemoveValue(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 5, 8 }, new int[] { 1, 5, 8 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        public void RemoveFromStart_WhenValidValues_RemoveFirstElement(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveFromStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 0, 1, 5, 8 }, new int[] { 0, 1, 8 })]
        [TestCase(0, new int[] { 0, 1, 5, 8 }, new int[] { 1, 5, 8 })]
        [TestCase(1, new int[] { 0, 3, 7, 8 }, new int[] { 0, 7, 8 })]
        [TestCase(0, new int[] { -10 }, new int[] { })]
        public void RemoveByIndex_WhenValidValues_RemoveElementByIndex(int index, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-3, new int[] { 0, 1, 5, 8 }, new int[] { 0, 1, 8 })]
        [TestCase(-8, new int[] { 0, 3, 7, 8 }, new int[] { 0, 3, 7 })]
        [TestCase(-11, new int[] { -10 }, new int[] { -10 })]
        public void RemoveByIndex_WhenNotValidValues_RemoveElementByIndex(int index, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));
        }

        [TestCase(5, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 0, 1, 5 })]
        [TestCase(3, new int[] { 0, 1, 5 }, new int[] { })]
        public void RemoveNElements_WhenValidValues_RemoveNElements(int NElements, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveNElements(NElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 5, 8, 7, 3, 2, 1 })]
        [TestCase(8, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { })]
        public void RemoveNElementsFromStart_WhenValidValues_RemoveFromStart(int NElements, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveNElementsFromStart(NElements);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 2, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 0, 1, 3, 2, 1 })]
        [TestCase(100, 6, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 0, 1, 5, 8, 7, 3 })]
        public void RemoveNElementsByIndex_WhenValidValues_RemoveNElementsByIndex(int nElements, int index, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveNElementsByIndex(nElements, index);

            Assert.AreEqual(expected, actual);
        }

        //[TestCase(-22, 2, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 })]
        //[TestCase(-2222, 2, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 }, new int[] { 0, 1, 5, 8, 7, 3, 2, 1 })]
        //[TestCase(6, 1, new int[] { 0, 1, 5 }, new int[] { 0, 1, 5 })]
        //[TestCase(0, 1, new int[] { }, new int[] { })]
        //public void RemoveNElementsByIndex_WhenNotValidValues_RemoveNElementsByIndex(int index, int NElements, int[] actualArr, int[] expectedArr)
        //{
        //    Assert.Throws<IndexOutOfRangeException>(() =>
        //    {

        //        Init(actualArr, expectedArr);

        //        actual.RemoveNElementsByIndex(index, NElements);
        //    });
        //}

        [TestCase(10, new int[] { 7, 8, 45, 23, 10, 34, 57 }, 4)]
        [TestCase(10, new int[] { 7, 8, 45, 23, 9, 34, 57 }, -1)]
        [TestCase(10, new int[] { 7, 8, 10, 23, 9, 10, 57 }, 2)]
        public void GetIndexByValue_WhenValidValues_ReturnIndex(int value, int[] actualArr, int expected)
        {
            Init(actualArr, null);
            int actualInt = actual.GetIndexByValue(value);

            Assert.AreEqual(expected, actualInt);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, new int[] { 57, 34, 10, 23, 45, 8, 7 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseArray_WhenValidValues_ReturnReversedArray(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, 6)]
        [TestCase(new int[] { 57, 57, 57, 57, 57, 57, 57 }, 0)]
        [TestCase(new int[] { -57 }, 0)]
        public void FindIndexOfMaxElement_WhenValidValues_ReturnIndex(int[] actualArr, int expected)
        {
            List list = new List(actualArr);
            int actual = list.FindIndexOfMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, 0)]
        [TestCase(new int[] { 57, 57, 57, 57, 57, 57, 57 }, 0)]
        [TestCase(new int[] { -57 }, 0)]
        public void FindIndexOfMinElement_WhenValidValues_ReturnIndex(int[] actualArr, int expected)
        {
            List list = new List(actualArr);
            int actual = list.FindIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, 57)]
        [TestCase(new int[] { 57, 57, 57, 57, 57, 57, 57 }, 57)]
        [TestCase(new int[] { -57 }, -57)]
        public void FindMaxElement_WhenValidValues_ReturnValue(int[] actualArr, int expected)
        {
            List list = new List(actualArr);
            int actual = list.FindMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, 7)]
        [TestCase(new int[] { 57, 57, 57, 57, 57, 57, 57 }, 57)]
        [TestCase(new int[] { -57 }, -57)]
        public void FindMinElement_WhenValidValues_ReturnValue(int[] actualArr, int expected)
        {
            List list = new List(actualArr);
            int actual = list.FindMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, new int[] { 7, 8, 10, 23, 34, 45, 57 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 3 }, new int[] { 3 })]
        public void SortInIncreasingOrder_WhenValidValues_ReturnSortedArray(int[] actualArr, int[] expectedArr)
        {
            List actual = new List(actualArr);
            List expected = new List(expectedArr);

            actual.SortInIncreasingOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 45, 23, 10, 34, 57 }, new int[] { 57, 45, 34, 23, 10, 8, 7 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortInDecreasingOrder_WhenValidValues_ReturnSortedArray(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.SortInDecreasingOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { -1, 1, 1, 3, 4, 6, 8, 12 })]
        public void SortInIncreasingOrder_WhenMethodCalled_SortbyAscending(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.SortInIncreasingOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 5, 8, 13, 1, 6, 9, 82, 65, 14 }, new int[] { 82, 65, 14, 13, 9, 8, 6, 5, 1 })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { 12, 8, 6, 4, 3, 1, 1, -1 })]
        public void SortInDecreasingOrder_WhenMethodCalled_SortbyAscending(int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.SortInDecreasingOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 5, 2, 3 }, new int[] { 1, 5, 3 })]
        [TestCase(7, new int[] { 1, 2, 3, 7 }, new int[] { 1, 2, 3 })]

        public void Remove_ElementByValue_WhenValue_RemoveValue(int value, int[] actualArr, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveByValueFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 2, 4, 2, 6, 7, 8 }, 2, new int[] { 1, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 3, 3, 3 }, 3, new int[] { })]
        public void RemoveAllByValue_WhenValue_RemoveAllValue(int[] actualArr, int value, int[] expectedArr)
        {
            Init(actualArr, expectedArr);

            actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
        }

        //[TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        //[TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        //[TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        //public void AddListToTheEnd_WhenListPassed_AddListToTheEnd(int[] actualArr, int[] arrayForList, int[] expectedArr)
        //{
        //    LinkedList actual = LinkedList.Create(actualArray);
        //    LinkedList list = LinkedList.Create(arrayForList);
        //    LinkedList expectedArrayList = LinkedList.Create(expectedArray);

        //    actual.AddListToTheEnd(list);

        //    Assert.AreEqual(expectedArrayList, actual);
        //}

        //[TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        //public void AddListToTheEnd_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int[] arrayForList)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        LinkedList actual = LinkedList.Create(actualArray);
        //        LinkedList list = LinkedList.Create(arrayForList);
        //        actual.AddListToTheEnd(list);
        //    });
        //}

        //[TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        //[TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        //[TestCase(new int[] { 1, 2, 3 }, new int[] { 10 }, new int[] { 10, 1, 2, 3 })]
        //public void AddListToStart_WhenListPassed_ThenAddLisToStart(int[] actualArray, int[] arrayForList, int[] expectedArray)
        //{
        //    LinkedList actual = LinkedList.Create(actualArray);
        //    LinkedList list = LinkedList.Create(arrayForList);
        //    LinkedList expectedArrayList = LinkedList.Create(expectedArray);

        //    actual.AddListToStart(list);

        //    Assert.AreEqual(expectedArrayList, actual);
        //}

        //[TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        //public void AddListToStart_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int[] arrayForList)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        LinkedList actual = LinkedList.Create(actualArray);
        //        LinkedList list = LinkedList.Create(arrayForList);
        //        actual.AddListToStart(list);
        //    });
        //}

        //[TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        //[TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        //[TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 5, 6, 7 }, new int[] { 1, 5, 6, 7, 2, 3, 4 })]
        //[TestCase(new int[] { }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6 })]
        //public void AddByIndex_WhenListAndIndexPassed_ThenAddListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        //{
        //    LinkedList actual = LinkedList.Create(actualArray);
        //    LinkedList list = LinkedList.Create(arrayForList);
        //    LinkedList expectedArrayList = LinkedList.Create(expectedArray);

        //    actual.AddListByIndex(list, index);

        //    Assert.AreEqual(expectedArrayList, actual);
        //}

        //[TestCase(new int[] { 1, 2, 3 }, 2, new int[] { })]
        //public void AddListByIndex_WhenMethodCalled_ReturnArgumentException(int[] actualArray, int index, int[] arrayForList)
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        LinkedList actual = LinkedList.Create(actualArray);
        //        LinkedList list = LinkedList.Create(arrayForList);
        //        actual.AddListByIndex(list, index);
        //    });
        //}

        //[TestCase(new int[] { 1, 2, 3 }, 5, new int[] { 5, 7, 9 })]
        //public void AddListByIndex_WhenMethodCalled_ReturnIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList)
        //{
        //    Assert.Throws<IndexOutOfRangeException>(() =>
        //    {
        //        LinkedList actual = LinkedList.Create(actualArray);
        //        LinkedList list = LinkedList.Create(arrayForList);
        //        actual.AddListByIndex(list, index);
        //    });
        //}

    }
}