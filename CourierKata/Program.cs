using System;

namespace CourierKata
{
    class Program
    {
        public static void Main()
        {
            Basket basket = new Basket();

            bool stillAddingParcels = true;
            decimal totalPrice = 0;
            int sParcelCount = 0;
            int mParcelCount = 0;
            int lParcelCount = 0;
            int xlParcelCount = 0;
            decimal sParcelPrice = 0;
            decimal mParcelPrice = 0;
            decimal lParcelPrice = 0;
            decimal xlParcelPrice = 0;

            while (stillAddingParcels)
            {
                Console.Clear();
                Console.WriteLine("Welcome to our new CourierKata system. What would you like to do?");
                Console.WriteLine("Type 'add' to add a new parcel in yoru basket.");
                Console.WriteLine("Type 'view' to view parcels in your basket and the total price.");
                Console.WriteLine("Type 'clear' to clear your basket.");
                Console.WriteLine("Type 'exit' to quit the system.");

                string menuInput = Console.ReadLine();
                Console.Clear();

                switch (menuInput)
                {
                    case "add":
                        {
                            Console.WriteLine("Please enter the number of the parcel you wish to add to the basket.");
                            Console.WriteLine("1 - Small Parcel (< 10cm), $3");
                            Console.WriteLine("2 - Medium Parcel (< 50cm), $8");
                            Console.WriteLine("3 - Large Parcel (< 100cm), $15");
                            Console.WriteLine("4 - XL Parcel (> 100cm), $25");

                            string parcelInput = Console.ReadLine();

                            switch (parcelInput)
                            {
                                case "1":
                                    Console.WriteLine("Parcel Added");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                    basket.AddToBasket(1, "Small Parcel", 3);
                                    sParcelCount++;
                                    break;
                                case "2":
                                    Console.WriteLine("Parcel Added");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                    basket.AddToBasket(2, "Medium Parcel", 8);
                                    sParcelCount++;
                                    break;
                                case "3":
                                    Console.WriteLine("Parcel Added");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                    basket.AddToBasket(3, "Large Parcel", 15);
                                    sParcelCount++;
                                    break;
                                case "4":
                                    Console.WriteLine("Parcel Added");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                    basket.AddToBasket(4, "XL Parcel", 25);
                                    sParcelCount++;
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

                            totalPrice = sParcelPrice + mParcelPrice + lParcelPrice + xlParcelPrice;

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
    }
}
