namespace CourierKata
{
    public class Parcel
    {
        private int Id;
        public string Name;
        public decimal Price;

        public Parcel(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
