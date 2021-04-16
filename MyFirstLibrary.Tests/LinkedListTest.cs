namespace MyFirstLibrary.Tests
{
    public class LinkedListTestt : BaseTests
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            actual = new LinkedList(actualArray);
            expected = new LinkedList(expectedArray);
        }
    }
}

