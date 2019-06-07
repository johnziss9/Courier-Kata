using System;

namespace CourierKata
{
    class Program
    {

        public static void Main()
        {
            Basket basket = new Basket();

            bool stillAddingParcels = true;
            decimal sParcelPrice = 0;
            decimal mParcelPrice = 0;
            decimal lParcelPrice = 0;
            decimal xlParcelPrice = 0;
            decimal totalPrice = 0;
            decimal totalShippingPrice = 0;
            decimal weightPrice = 0;
            decimal sParcelWeight = 1;
            decimal mParcelWeight = 3;
            decimal lParcelWeight = 6;
            decimal xlParcelWeight = 19;
            decimal parcelWeight = 0;
            int sParcelCount = 0;
            int mParcelCount = 0;
            int lParcelCount = 0;
            int xlParcelCount = 0;

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
                            Console.WriteLine("An additional $2 will be added for each Kg is the parcel is over the corresponded weight.");

                            string parcelInput = Console.ReadLine();

                            switch (parcelInput)
                            {
                                case "1":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 1 ? weightPrice = 0 : weightPrice = (parcelWeight - 1) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Small Parcel", 3);
                                    sParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    totalShippingPrice += SpeedyShipping(parcelInput, 3, totalShippingPrice, basket);
                                    break;
                                case "2":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 3 ? weightPrice = 0 : weightPrice = (parcelWeight - 1) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Medium Parcel", 8);
                                    sParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    totalShippingPrice += SpeedyShipping(parcelInput, 8, totalShippingPrice, basket);
                                    break;
                                case "3":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 6 ? weightPrice = 0 : weightPrice = (parcelWeight - 1) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("Large Parcel", 15);
                                    sParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    totalShippingPrice += SpeedyShipping(parcelInput, 15, totalShippingPrice, basket);
                                    break;
                                case "4":
                                    Console.WriteLine("What is the weight of the parcel?");
                                    parcelWeight = Convert.ToDecimal(Console.ReadLine());
                                    weightPrice += parcelWeight <= 10 ? weightPrice = 0 : weightPrice = (parcelWeight - 1) * 2;
                                    Console.WriteLine("Parcel Added");
                                    basket.AddToBasket("XL Parcel", 25);
                                    sParcelCount++;
                                    basket.AddToBasket("Additional Weight Cost", weightPrice);
                                    totalShippingPrice += SpeedyShipping(parcelInput, 25, totalShippingPrice, basket);
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
                            foreach (string parcel in basket.GetBasketParcelNames())
                                Console.WriteLine(parcel);

                            sParcelPrice = sParcelCount * 3;
                            mParcelPrice = mParcelCount * 8;
                            lParcelPrice = lParcelCount * 15;
                            xlParcelPrice = xlParcelCount * 25;

                            totalPrice = sParcelPrice + mParcelPrice + lParcelPrice + xlParcelPrice + totalShippingPrice + weightPrice;

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
            Console.WriteLine("Would you like to add speedy shipping?");
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

        public static int ParcelWeight(string parcelInput)
        {
            Console.WriteLine("What is the weight of the parcel?");
            int parcelWeight = Convert.ToInt32(Console.ReadLine());



            return parcelWeight;
        }
    }
}
