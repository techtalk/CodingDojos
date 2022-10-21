namespace CakeDecorator
{
    public interface ICake
    {
        string GetName();
        double GetPrice();
    }

    public abstract class CakeDecorator : ICake
    {
        protected ICake Cake { get; }

        protected CakeDecorator(ICake cake)
        {
            Cake = cake;
        }

        public virtual string GetName() => Cake.GetName();

        public virtual double GetPrice() => Cake.GetPrice();
    }

    public class BaseCake : ICake
    {
        public string GetName() => string.Empty;

        public double GetPrice() => 0;
    }
}
