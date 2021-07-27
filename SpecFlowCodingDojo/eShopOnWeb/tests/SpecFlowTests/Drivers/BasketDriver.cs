using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.eShopWeb.Web.Pages.Basket;
using SpecFlowTests.Setup;

namespace SpecFlowTests.Drivers
{
    public class BasketDriver
    {
        private readonly UserCommandsHandler _userCommandsHandler;

        public BasketDriver(UserCommandsHandler userCommandsHandler)
        {
            _userCommandsHandler = userCommandsHandler;
        }

        public async Task EnsureEmptyBasket(string username)
        {
            var basket = await _userCommandsHandler.GetBasketOfUser(username);
            await _userCommandsHandler.CleanBasket(basket.Id);
        }

        public async Task AddItemToBasket(string username, string itemName)
        {
            var item = await _userCommandsHandler.GetItemByName(itemName);
            await _userCommandsHandler.AddToBasket(username, item.Id, item.Price, 1);
        }

        public async Task AssertBasketContains(string username, string itemName)
        {
            var basket = await _userCommandsHandler.GetBasketOfUser(username);

            basket.Items.Should().Contain(i => i.ProductName == itemName);
        }

        public async Task AssertBasketContains(string username, string[] itemNames)
        {
            var basket = await _userCommandsHandler.GetBasketOfUser(username);
            foreach (var itemName in itemNames)
            {
                basket.Items.Should().Contain(i => i.ProductName == itemName);
            }
        }
    }
}