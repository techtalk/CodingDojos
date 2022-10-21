namespace CakeDecorator
{
    public class Cupcake : CakeDecorator
    {
        public override string GetName() => $"🧁{Cake.GetName()}" ;

        public override double GetPrice() =>  Cake.GetPrice() + 1;

        public Cupcake(ICake cake) : base(cake)
        {
        }
    }
}
