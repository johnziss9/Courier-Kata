using CourierKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourierKataTests
{
    [TestClass]
    public class BasketTotalUnitTest
    {
        [TestMethod]
        public void Test_SmallMediumParcels()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Medium Parcel", 8);
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 11);
        }

        [TestMethod]
        public void Test_SmallParcelDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetSmallBasketDiscounts();
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 23);
        }

        [TestMethod]
        public void Test_MediumParcelDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 8);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 8);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 6);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetMediumBasketDiscounts();
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 62);
        }

        [TestMethod]
        public void Test_ClearingBasket()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Medium Parcel", 8);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.AddToBasket("XL Parcel", 25);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 25);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.Clear(); // Clear basket
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 0);
        }

        [TestMethod]
        public void Test_ClearingDiscount()
        {
            Basket basket = new Basket();
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 6);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 3);
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 4);
            basket.AddToBasket("Speedy Shipping", 0);
            basket.GetSmallBasketDiscounts(); // Add discount to parcels
            basket.Clear(); // Clear basket
            basket.AddToBasket("Small Parcel", 3);
            basket.AddToBasket("Additional Weight Cost", 0);
            basket.AddToBasket("Speedy Shipping", 3);
            decimal totalPrice = basket.GetBasketTotalPrice();
            Assert.AreEqual(totalPrice, 6);
        }
    }
}
