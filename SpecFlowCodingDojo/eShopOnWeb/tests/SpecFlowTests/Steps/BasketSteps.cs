using System.Threading.Tasks;
using SpecFlowTests.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class BasketSteps
    {
        private BasketDriver BasketDriver { get; }
        private UserDriver UserDriver { get; }

        public BasketSteps(BasketDriver basketDriver, UserDriver userDriver)
        {
            BasketDriver = basketDriver;
            UserDriver = userDriver;
        }

        [Given(@"the basket of '(.*)' is empty")]
        public async Task GivenTheBasketOfIsEmpty(string username)
        {
            await BasketDriver.EnsureEmptyBasket (username);
        }

        [Given(@"my basket contains '(.*)'")]
        [When(@"I add a '(.*)' to my basket")]
        public async Task GivenMyBasketContains(string itemName)
        {
            await BasketDriver.AddItemToBasket(UserDriver.CurrentUsername, itemName);
        }

        [When(@"'(.*)' adds a '(.*)' to his basket")]
        public async Task WhenAddsAToHisBasket(string username, string itemName)
        {
            await BasketDriver.AddItemToBasket(username, itemName);
        }

        [Then(@"the basket of '(.*)' contains '(.*)'")]
        public async Task ThenTheBasketOfContains(string username, string itemName)
        {
            await BasketDriver.AssertBasketContains(username, itemName);
        }

        [Then(@"my basket contains '(.*)'")]
        public async Task ThenMyBasketContains(string[] itemNames)
        {
            await BasketDriver.AssertBasketContains(UserDriver.CurrentUsername, itemNames);
        }

    }
}