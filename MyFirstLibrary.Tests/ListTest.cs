namespace MyFirstLibrary.Tests
{
    public class ListTest : BaseTests
    {
        public override void Init(int[] actualArray, int[] expectedArray)
        {
            actual = new List(actualArray);
            expected = new List(expectedArray);
        }
    }
}

