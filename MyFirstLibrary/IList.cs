using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstLibrary
{
    public interface IList
    {
        void Add(int value);
        
        void AddInStart(int value);
        
        void AddByIndex(int value, int index);
        
        void Remove();
        
        void RemoveFromStart();
        
        void RemoveByIndex(int index);

        void RemoveNElements(int nElements);

        void RemoveNElementsFromStart(int nElements);

        void RemoveNElementsByIndex(int nElements, int index);

        int GetIndexByValue(int value);

        void Reverse();

        int FindIndexOfMaxElement();

        int FindIndexOfMinElement();

        int FindMaxElement();

        int FindMinElement();

        void SortInIncreasingOrder();

        void SortInDecreasingOrder();

        void RemoveByValueFirst(int value);

        void RemoveByValueAll(int value);

        //void AddListToTheEnd(LinkedList secondList);

        //void AddListToStart(LinkedList secondList);

        //void AddListByIndex(LinkedList secondList, int index);

        //void AddListToTheEnd(DoubleLinkedList secondList);

        //void AddListToStart(DoubleLinkedList secondList);

        //void AddListByIndex(DoubleLinkedList secondList, int index);
    }
}
