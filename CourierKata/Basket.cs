using System.Collections.Generic;

namespace CourierKata
{
    public class Basket
    {
        private List<Parcel> parcels;

        public Basket()
        {
            parcels = new List<Parcel>();
        }

        public string AddToBasket(int id, string name, decimal price)
        {
            Parcel parcel = new Parcel(id, name, price);
            parcels.Add(parcel);

            return parcel.Name + " " + parcel.Price.ToString();
        }

        public IEnumerable<string> GetBasketParcelNames()
        {
            foreach (var parcel in parcels)
                yield return parcel.Name;
        }

        public void Clear()
        {
            parcels.Clear();
        }
    }
}
