namespace MyFirstLibrary.Tests
{
    public class ListTest : BaseTests
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            if (actualArray != null)
            {
                actual = new List(actualArray);
            }
            if (expectedArray != null)
            {
                expected = new List(expectedArray);
            }
        }
    }
}

