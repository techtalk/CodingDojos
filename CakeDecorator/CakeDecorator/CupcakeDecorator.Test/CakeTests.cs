using Xunit;

namespace CakeDecorator.Test;

public class CakeTests
{
    [Fact]
    //The name function should return “🧁”
    public void Cake_Name_ReturnsCupcake()
    {
        //arrange
        var cake = new Cupcake(new BaseCake());

        //assert
        Assert.Equal("🧁", cake.GetName());
        Assert.Equal(1.0d, cake.GetPrice());
    }    
    
    [Fact]
    //The name function should return “🧁 with 🍫”
    public void Cake_Name_ReturnsCupcakeWithChocolate()
    {
        //arrange
        var cake = new Cupcake(new ChocolateCake(new BaseCake()));

        //assert
        Assert.Equal("🧁 with 🍫", cake.GetName());
        Assert.Equal(1.1d, cake.GetPrice());
    }

    [Fact]
    //The price function should return 1$ for “🧁”
    public void Cake_Price_ReturnsCupcake()
    {
        //arrange


        //act


        //assert

    }

    [Fact]
    //The name function should return “Bundle with\n🧁 with 🍫”
    public void CakeBundle_Name_ReturnsBundleName()
    {
        //arrange
        var cake = new Bundle(new Cupcake(new ChocolateCake(new BaseCake())));

        //assert
        Assert.Equal("Bundle with:\n🧁 with 🍫\n", cake.GetName());
        Assert.Equal(1.1d, cake.GetPrice());
    }
}