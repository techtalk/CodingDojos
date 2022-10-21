namespace CakeDecorator
{
    public class ChocolateCake : CakeDecorator
    {
        public override string GetName() => $"{Cake.GetName()} with 🍫";

        public override double GetPrice() => Cake.GetPrice() + 0.1;

        public ChocolateCake(ICake cake) : base(cake)
        {
        }
    }
}
