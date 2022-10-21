namespace CakeDecorator
{
    public class Bundle : ICake
    {
        private readonly ICake[] _cakes;

        public Bundle(params ICake[] cakes)
        {
            _cakes = cakes;
        }

        public string GetName()
        {
            string name = "Bundle with:\n";
            foreach (var bundle in _cakes)
            {
                name = $"{name}{bundle.GetName()}\n";
            }
            return name;
        }

        public double GetPrice()
        {
            double price = 0;
            foreach (var bundle in _cakes)
            {
                price += bundle.GetPrice();
            }

            return price;
        }
    }
}
