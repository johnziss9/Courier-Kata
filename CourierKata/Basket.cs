using System.Collections.Generic;
using System.Linq;

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

        public decimal GetBasketTotalPrice()
        {
            // Original Code
            //foreach (var parcelPrice in parcels)
            //    yield return parcelPrice.Price;

            // Try add basket total in this class
            decimal totalPrice = 0;

            foreach (var parcelPrice in parcels)
                totalPrice += parcelPrice.Price;

            return totalPrice;

        }

        public List<decimal> GetSmallBasketDiscounts()
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

        public void ClearSmallParcelDiscounts()
        {
            foreach (var p in parcels.ToList())
            {
                if (p.Name == "4th Small Parcel Discount")
                    parcels.Remove(p);
            }
        }

        public List<decimal> GetMediumBasketDiscounts()
        {
            decimal mediumParcelDiscount = 0;
            List<decimal> mediumParcels = new List<decimal>();

            for (int i = 0; i <= parcels.Count - 1; i++)
            {
                if (parcels[i].Name == "Medium Parcel")
                {
                    mediumParcelDiscount += parcels[i].Price + parcels[i + 1].Price + parcels[i + 2].Price;
                    mediumParcels.Add(mediumParcelDiscount);
                    mediumParcelDiscount = 0;
                    i += 2;
                }
            }

            return mediumParcels;
        }

        public void ClearMediumParcelDiscounts()
        {
            foreach (var p in parcels.ToList())
            {
                if (p.Name == "3rd Medium Parcel Discount")
                    parcels.Remove(p);
            }
        }

        public void Clear()
        {
            parcels.Clear();
        }
    }
}
