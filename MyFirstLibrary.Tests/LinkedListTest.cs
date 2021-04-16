namespace MyFirstLibrary.Tests
{
    public class LinkedListTestt : BaseTests
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            if (actualArray != null)
            {
                actual = new LinkedList(actualArray);
            }
            if (expectedArray != null)
            {
                expected = new LinkedList(expectedArray);
            }
        }
    }
}

