using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierKata
{
    class Program
    {
        public static void Main()
        {
            Basket basket = new Basket();
            List<decimal> smallParcelDiscount = new List<decimal>();
            List<decimal> mediumParcelDiscount = new List<decimal>();

            bool stillAddingParcels = true;
            bool sDiscountApplied = false;
            bool mDiscountApplied = false;
            decimal totalPrice = 0;
            decimal totalShippingPrice = 0;
            decimal weightPrice = 0;
            decimal parcelWeight = 0;
            int sParcelCount = 0;
            int mParcelCount = 0;
            int lParcelCount = 0;
            int xlParcelCount = 0;
            int hParcelCount = 0;
            int sParcelDiscountCount = 0;
            int mParcelDiscountCount = 0;

            while (stillAddingParcels)
            {
                Console.Clear();
                Console.WriteLine("Welcome to our new CourierKata system. What would you like to do?");
                Console.WriteLine("Type 'add' to add a new parcel in yoru basket.");
                Console.WriteLine("Type 'view' to view parcels in your basket and the total price.");
                Console.WriteLine("Type 'clear' to clear your basket.");
                Console.WriteLine("Type 'exit' to quit the system.");

                string menuInput = Console.ReadLine().ToLower();
                Console.Clear();

                switch (menuInput)
                {
                    case "add":
                        {
                            Console.WriteLine("Please enter the number of the parcel you wish to add to the basket.");
                            Console.WriteLine("1 - Small Parcel (< 10cm, < 1KG), $3");
                            Console.WriteLine("2 - Medium Parcel (< 50cm, < 3KG), $8");
                            Console.WriteLine("3 - Large Parcel (< 100cm, < 6KG), $15");
                            Console.WriteLine("4 - XL Parcel (> 100cm, < 10KG), $25");
                            Console.WriteLine("5 - Heavy Parcel (< 50KG), $50");
                            Console.WriteLine("An additional $2 will be added for each Kg is the parcel is over the corresponded weight.");

                            string parcelInput = Console.ReadLine();

                            switch (parcelInput)
                            {
                                case "1":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 1 ? 0 : (parcelWeight - 1) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Small Parcel", 3);
                                    sParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    weightPrice = 0; // clear weight price
                                    basket.ClearSmallParcelDiscounts();
                                    sDiscountApplied = false;
                                    totalShippingPrice += SpeedyShipping(parcelInput, 3, totalShippingPrice, basket);
                                    break;
                                case "2":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 3 ? 0 : (parcelWeight - 3) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Medium Parcel", 8);
                                    mParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    weightPrice = 0; // clear weight price
                                    basket.ClearMediumParcelDiscounts();
                                    mDiscountApplied = false;
                                    totalShippingPrice += SpeedyShipping(parcelInput, 8, totalShippingPrice, basket);
                                    break;
                                case "3":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 6 ? 0 : (parcelWeight - 6) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Large Parcel", 15);
                                    lParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    weightPrice = 0; // clear weight price
                                    totalShippingPrice += SpeedyShipping(parcelInput, 15, totalShippingPrice, basket);
                                    break;
                                case "4":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 10 ? 0 : (parcelWeight - 10) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("XL Parcel", 25);
                                    xlParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    weightPrice = 0; // clear weight price
                                    totalShippingPrice += SpeedyShipping(parcelInput, 25, totalShippingPrice, basket);
                                    break;
                                case "5":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 50 ? 0 : (parcelWeight - 50) * 1;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Heavy Parcel", 50);
                                    hParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    weightPrice = 0; // clear weight price
                                    totalShippingPrice += SpeedyShipping(parcelInput, 50, totalShippingPrice, basket);
                                    break;
                                default:
                                    Console.WriteLine("Wrong input. Please press enter and try again.");
                                    Console.Read();
                                    break;
                            }
                        }
                        break;
                    case "view":
                        {
                            // Applying Small Parcel Mania Discount
                            while (sParcelCount >= 4 && sDiscountApplied == false)
                            {
                                smallParcelDiscount = basket.GetSmallBasketDiscounts();
                                sDiscountApplied = true;

                                foreach (var s in smallParcelDiscount)
                                {
                                    sParcelDiscountCount++;
                                    if (sParcelDiscountCount % 4 == 0)
                                        basket.AddToBasket("4th Small Parcel Discount", -Math.Abs(s));
                                }
                            }

                            // Applying Medium Parcel Mania Discount
                            while (mParcelCount >= 3 && mDiscountApplied == false)
                            {
                                mediumParcelDiscount = basket.GetMediumBasketDiscounts();
                                mDiscountApplied = true;

                                foreach (var s in mediumParcelDiscount)
                                {
                                    mParcelDiscountCount++;
                                    if (mParcelDiscountCount % 3 == 0)
                                        basket.AddToBasket("3rd Medium Parcel Discount", -Math.Abs(s));
                                }
                            }

                            foreach (string parcel in basket.GetBasketParcels())
                                Console.WriteLine(parcel);

                            totalPrice = 0; // Reset Price

                            // Basket Calculation
                            foreach (decimal parcelPrice in basket.GetBasketTotalPrice())
                                totalPrice += parcelPrice;

                            if (totalPrice != 0)
                            {
                                Console.WriteLine("----------");
                                Console.WriteLine("Total Price For Parcels: $" + totalPrice);
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No items added in basket.");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }

                            break;
                        }
                    case "clear":
                        basket.Clear();
                        sParcelCount = 0;
                        mParcelCount = 0;
                        lParcelCount = 0;
                        xlParcelCount = 0;
                        hParcelCount = 0;
                        weightPrice = 0;
                        totalShippingPrice = 0;
                        Console.WriteLine("Basket Cleared.");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case "exit":
                        stillAddingParcels = false;
                        break;
                    default:
                        Console.WriteLine("Please select one of the above options.");
                        break;

                }
            }
        }

        public static decimal SpeedyShipping(string parcelInput, decimal shippingPrice, decimal totalShippingPrice, Basket basket)
        {
            Console.WriteLine("Would you like to add speedy shipping? (Reply with a yes or no)");
            Console.WriteLine("This will cost double the price of the parcel.");
            string speedyShippingInput = Console.ReadLine().ToLower();

            if (speedyShippingInput == "yes")
            {
                basket.AddToBasket("Speedy Shipping", shippingPrice);
                totalShippingPrice += shippingPrice;
                Console.WriteLine("Speedy Shipping Added.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else if (speedyShippingInput == "no")
            {
                shippingPrice = 0;
                basket.AddToBasket("Speedy Shipping", shippingPrice);
                totalShippingPrice += 0;
                Console.WriteLine("Parcel Added with no Speedy Shipping.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Wrong input. Please press enter and try again.");
                Console.Read();
            }

            return totalShippingPrice;
        }
    }
}
