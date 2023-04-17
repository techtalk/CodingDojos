using FluentAssertions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright.Hooks;

namespace Playwright.Pages;

public class DuckDuckGoHomePage : PageTest
{
    #region Constructors

    private readonly IPage _user;

    public DuckDuckGoHomePage(PlaywrightHooks hooks)
    {
        _user = hooks.User;
    }

    #endregion

    #region Selectors

    private ILocator SearchInput => _user.Locator("input[id='search_form_input_homepage']");
    private ILocator SearchButton => _user.Locator("input[id='search_button_homepage']");

    #endregion

    #region Actions/Assertions

    public async Task RunRecord()
    {
        await _user.GotoAsync("https://duckduckgo.com/");

        await _user.GetByRole(AriaRole.Button, new() { Name = "Alle akzeptieren" }).ClickAsync();

        await _user.GetByRole(AriaRole.Combobox, new() { Name = "Suche" }).ClickAsync();

        await _user.GetByRole(AriaRole.Combobox, new() { Name = "Suche" }).FillAsync("Playwright");

        await _user.GetByRole(AriaRole.Combobox, new() { Name = "Suche" }).PressAsync("Enter");

        await _user.GetByRole(AriaRole.Link, new() { Name = "Playwright: Fast and reliable end-to-end testing for modern ... Playwright https://playwright.dev" }).ClickAsync();
    }

    public async Task AssertPageContent()
    {
        //Assert that the correct URL has been reached
        _user.Url.Should().Be("https://duckduckgo.com/");

        //Assert that the search input is visible
        var searchInputVisibility = await SearchInput.IsVisibleAsync();
        searchInputVisibility.Should().BeTrue();

        //Assert that the search button is visible
        var searchBtnVisibility = await SearchButton.IsVisibleAsync();
        searchBtnVisibility.Should().BeTrue();
    }

    public async Task SearchAndEnter(string searchTerm)
    {
        //Type the search term into the search input
        await SearchInput.TypeAsync(searchTerm);

        //Assert that the search input has the text entered
        var searchInputInnerText = await SearchInput.InputValueAsync();
        searchInputInnerText.Should().Be(searchTerm);

        //Click the search button to submit the search
        await SearchButton.ClickAsync();
    }

    #endregion
}