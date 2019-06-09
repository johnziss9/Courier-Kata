﻿using System.Collections.Generic;

namespace CourierKata
{
    public class Basket
    {
        private List<Parcel> parcels;

        public Basket()
        {
            parcels = new List<Parcel>();
        }

        public string AddToBasket(string name, decimal price)
        {
            Parcel parcel = new Parcel(name, price);
            parcels.Add(parcel);

            return parcel.Name + " " + parcel.Price.ToString();
        }

        public IEnumerable<string> GetBasketParcels()
        {
            foreach (var parcel in parcels)
                yield return parcel.Name + " $" + parcel.Price;
        }

        public IEnumerable<decimal> GetBasketTotalPrice()
        {
            foreach (var parcelPrice in parcels)
                yield return parcelPrice.Price;
        }

        // TODO Fix This
        public List<decimal> GetBasketDiscounts()
        {
            decimal smallParcelDiscount = 0;
            List<decimal> smallParcels = new List<decimal>();

            for (int i = 0; i <= parcels.Count - 1; i++)
            {
                if (parcels[i].Name == "Small Parcel")
                {
                    smallParcelDiscount += parcels[i].Price + parcels[i + 1].Price + parcels[i + 2].Price;
                    smallParcels.Add(smallParcelDiscount);
                    smallParcelDiscount = 0;
                    i += 2;
                }
            }

            return smallParcels;
        }








        //public decimal SmallParcelDiscount(decimal price)
        //{
        //    foreach (var smallParcel in parcels)
        //    {
        //        if (smallParcel == "Small Parcel")
        //        {
        //            smallParcelTotalPrice += smallParcel.Price;
        //            smallParcelTotalPrice += 
        //        }
        //    }
        //}

        public void Clear()
        {
            parcels.Clear();
        }
    }
}
