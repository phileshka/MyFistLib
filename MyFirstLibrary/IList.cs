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
    }
}
