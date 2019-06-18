using CourierKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Medium Parcel", 8);
        }
    }
}
