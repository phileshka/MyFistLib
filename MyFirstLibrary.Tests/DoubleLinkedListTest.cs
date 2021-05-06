namespace MyFirstLibrary.Tests
{
    public class DoubleLinkedListTest : BaseTests
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            if (actualArray != null)
            {
                actual = new DoubleLinkedList(actualArray);
            }
            if (expectedArray != null)
            {
                expected = new DoubleLinkedList(expectedArray);
            }
        }
    }
}
