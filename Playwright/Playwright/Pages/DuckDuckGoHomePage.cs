using FluentAssertions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright.Hooks;

namespace Playwright.Pages;

public class DuckDuckGoHomePage : PageTest
{
    #region Constructors

    private readonly IPage _currentPage;

    public DuckDuckGoHomePage(PlaywrightHooks hooks)
    {
        _currentPage = hooks.CurrentPage;
    }

    #endregion

    #region Selectors

    private ILocator SearchInput => _currentPage.Locator("input[id='search_form_input_homepage']");
    private ILocator SearchButton => _currentPage.Locator("input[id='search_button_homepage']");

    #endregion

    #region Actions/Assertions

    public async Task RunRecord()
    {
        await _currentPage.GotoAsync("https://duckduckgo.com/");

        await _currentPage.GetByPlaceholder("Search the web without being tracked").ClickAsync();

        await _currentPage.GetByPlaceholder("Search the web without being tracked").FillAsync("Playwright");

        await _currentPage.GetByPlaceholder("Search the web without being tracked").PressAsync("Enter");

        await _currentPage.GetByRole(AriaRole.Link, new() { Name = "Fast and reliable end-to-end testing for modern web apps | Playwright" }).ClickAsync();
    }

    public async Task AssertPageContent()
    {
        _currentPage.Url.Should().Be("https://duckduckgo.com/");

        var searchInputVisibility = await SearchInput.IsVisibleAsync();
        searchInputVisibility.Should().BeTrue();

        var searchBtnVisibility = await SearchButton.IsVisibleAsync();
        searchBtnVisibility.Should().BeTrue();
    }

    public async Task SearchAndEnter(string searchTerm)
    {
        await SearchInput.TypeAsync(searchTerm);

        var searchInputInnerText = await SearchInput.InputValueAsync();
        searchInputInnerText.Should().Be(searchTerm);

        await SearchButton.ClickAsync();
    }

    #endregion
}