using FluentAssertions;
using Microsoft.Playwright;
using Playwright.Hooks;

namespace Playwright.Pages
{
    public class PlenumPage
    {
        #region Constructors

        private readonly IPage _currentPage;
        private string UserName => "verena.muster@plenum.loc";
        private string Password => "Test1Test!";
        private string PlenumUrl => "https://thankful-river-04943d203-preview.westeurope.1.azurestaticapps.net/";

        public PlenumPage(PlaywrightHooks hooks)
        {
            _currentPage = hooks.CurrentPage;
        }

        #endregion

        #region Selectors

        private ILocator EmailInput => _currentPage.GetByPlaceholder("Email Address");
        private ILocator PasswordInput => _currentPage.GetByPlaceholder("Password");
        private ILocator SaveButton => _currentPage.GetByRole(AriaRole.Button, new() { Name = "Speichern" });
        private ILocator YesButton => _currentPage.GetByRole(AriaRole.Button, new() { Name = "Ja" });

        #endregion

        #region Actions

        public async Task Login()
        {
            await EmailInput.FillAsync(UserName);
            await PasswordInput.FillAsync(Password);
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
        }

        public async Task OpenHomepage()
        {
            await _currentPage.GotoAsync(PlenumUrl);
        }

        public async Task GoToStartpage()
        {
            var navigation = _currentPage.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button);
            navigation.Should().NotBeNull();
            await navigation.ClickAsync();

            var startButton = _currentPage.GetByRole(AriaRole.Button, new() { Name = " Startseite" });
            startButton.Should().NotBeNull();
            await startButton.ClickAsync();

            await ClickElementWithTextIfExists("Weitere Sitzungen anzeigen");
        }

        public async Task<bool> ExistsTextInPage(IPage page, string element)
        {
            return await page.IsVisibleAsync($"text='{element}'");
        }

        public async Task<bool> ExistsElementInPage(IPage page, string element)
        {
            return await page.Locator(element).CountAsync() > 0;
        }

        public async Task ClickElementWithTextIfExists(string element)
        {
            if (await ExistsTextInPage(_currentPage, element))
                await _currentPage.GetByText(element).ClickAsync();
        }

        public async Task SetDateToNow()
        {
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Toggle popup" }).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Link, new() { Name = "Heute" }).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Jetzt" }).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

        public async Task CreateSitzung(string sitzungName, string sitzungsArt)
        {
            await _currentPage.GetByRole(AriaRole.Link, new() { Name = "Neue Sitzung" }).ClickAsync();
            await _currentPage.GetByPlaceholder("Titel").ClickAsync();
            await _currentPage.GetByPlaceholder("Titel").FillAsync(sitzungName);

            await SetDateToNow();

            await _currentPage.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" }).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" })
                .FillAsync(sitzungsArt);
            await _currentPage.GetByRole(AriaRole.Combobox, new() { Name = "Ort" }).ClickAsync();
            await _currentPage.GetByText("Gemeinderatssaal").ClickAsync();

            await SaveButton.ClickAsync();
            await GoToStartpage();
        }

        public async Task RemoveTeilnehmendeFromSitzung(string teilnehmende)
        {
            if (await ExistsElementInPage(_currentPage, "kendo-treelist") &&
                await _currentPage.GetByRole(AriaRole.Gridcell, new() { Name = teilnehmende }).CountAsync() == 1)
            {
                await _currentPage.GetByRole(AriaRole.Row, new() { Name = teilnehmende })
                    .GetByTitle("aus Sitzung entfernen").ClickAsync();
                await YesButton.ClickAsync();
            }
        }

        public async Task AddExistingTeilnehmendeToSitzung(string teilnehmer)
        {
            await RemoveTeilnehmendeFromSitzung(teilnehmer);
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Teilnehmende hinzufügen" }).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Treeitem, new() { Name = teilnehmer }).Locator("kendo-checkbox")
                .ClickAsync();
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Zur Sitzung hinzufügen" }).ClickAsync();
        }

        public async Task OpenSitzung(string sitzungsArt)
        {
            var sitzung = _currentPage.GetByText(sitzungsArt);
            sitzung.Should().NotBeNull();
            await sitzung.ClickAsync();
        }

        public async Task OpenTagesordnungspunkt(string topName)
        {
            //TODO: Check if works
            var topExists = await ExistsElementInPage(_currentPage, topName);
            var top = _currentPage.GetByText(topName, new() { Exact = true });
            top.Should().NotBeNull();
            await top.ClickAsync();
        }

        public async Task AddCommentToTagesordnungspunkt(string comment)
        {
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = " Neuen Kommentar hinzufügen" }).ClickAsync();
            //await _currentPage.Locator("newCommentBtn").GetByRole(AriaRole.Button).ClickAsync();
            await _currentPage.GetByPlaceholder("Schreibe einen Kommentar ...").FillAsync(comment);
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Posten" }).ClickAsync();
            await GoToStartpage();
        }

        public async Task CreateTagesordnungspunktWithinSitzung(string topName)
        {
            await _currentPage.Locator("pl-button").Filter(new() { HasText = "Neuen Tagesordnungspunkt erstellen" })
                .GetByRole(AriaRole.Button, new() { Name = "Neuen Tagesordnungspunkt erstellen" }).ClickAsync();

            await _currentPage.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();
            await _currentPage.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync(topName);

            await SaveButton.ClickAsync();
            await GoToStartpage();
        }

        public async Task AddTagesordnungspunktToSitzung(string topName)
        {
            await _currentPage.Locator("app-admin-add-pending-traktandum")
                .GetByRole(AriaRole.Button, new() { Name = "Select" }).ClickAsync();

            await _currentPage.GetByText(topName).ClickAsync();
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Tagesordnungspunkt zuordnen" }).ClickAsync();

            await GoToStartpage();
        }

        public async Task CreateTagesordnungspunkt(string topName)
        {
            await _currentPage.GetByRole(AriaRole.Link, new() { Name = "Neuer Tagesordnungspunkt" }).ClickAsync();

            await _currentPage.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();
            await _currentPage.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync(topName);

            await SaveButton.ClickAsync();
            await GoToStartpage();
        }

        public async Task ShowAllCompletedSitzungen()
        {
            await _currentPage.GetByRole(AriaRole.Checkbox).CheckAsync();
        }

        public async Task ClickStatusDropDown()
        {
            await _currentPage.Locator("formly-field")
                .Filter(new() { HasText = "Status *" })
                .Nth(2).ClickAsync();
        }

        public async Task ChangeStateOfTagesordnungspunkt(string newState)
        {
            await ClickStatusDropDown();
            await _currentPage.GetByText(newState, new() { Exact = true }).ClickAsync();
            await SaveButton.ClickAsync();
        }

        #endregion

        #region Assertions

        public async Task AssertPageContent()
        {
            var emailInputVisibility = await EmailInput.IsVisibleAsync();
            emailInputVisibility.Should().BeTrue();

            var passwordInputVisibility = await PasswordInput.IsVisibleAsync();
            passwordInputVisibility.Should().BeTrue();
        }

        public async Task AssertSitzung(string sitzungsArt)
        {
            await GoToStartpage();
            var sitzungsArtExists = await ExistsTextInPage(_currentPage, sitzungsArt);
            sitzungsArtExists.Should().BeTrue();
            await OpenSitzung(sitzungsArt);
        }

        public async Task AssertSitzungWithTitle(string sitzungsName, string sitzungsArt)
        {
            await AssertSitzung(sitzungsArt);
            var sitzungInputField = await _currentPage.GetByPlaceholder("Titel").InputValueAsync();
            sitzungInputField.Should().Be(sitzungsName);
        }

        public async Task AssertTeilnehmerInSitzung(string sitzungsArt, string teilnehmerName)
        {
            await AssertSitzung(sitzungsArt);
            var teilnehmerListExists = await ExistsElementInPage(_currentPage, "kendo-treelist");
            teilnehmerListExists.Should().BeTrue();
            var teilnehmerCount = await _currentPage.GetByRole(AriaRole.Gridcell, new() { Name = teilnehmerName }).CountAsync();
            teilnehmerCount.Should().Be(1);
        }

        public async Task AssertTagesordnungspunktInSitzung(string sitzungsArt, string topName)
        {
            await AssertSitzung(sitzungsArt);
            var topCount = await _currentPage.GetByText(topName, new() { Exact = true }).CountAsync();
            topCount.Should().Be(1);
        }

        public async Task AssertCommentInTagesordnungspunktInSitzung(string sitzungsArt, string topName, string comment)
        {
            await AssertSitzung(sitzungsArt);
            await OpenTagesordnungspunkt(topName);
            var count = await _currentPage.Locator("app-annotation-textarea").CountAsync();
            count.Should().Be(1);
            //var text = await _currentPage.Locator("app-annotation-textarea").Locator("textarea").TextContentAsync();
            //text = await _currentPage.Locator("app-annotation-textarea").Locator("textarea").InnerTextAsync();
            //var text2 = await _currentPage.Locator("app-annotation-textarea").AllTextContentsAsync();
            //text2 = await _currentPage.Locator("app-annotation-textarea").AllInnerTextsAsync();
            //text.Should().Be(comment);
        }

        public async Task AssertStateOfTagesordnungspunktInSitzung(string sitzungsArt, string topName, string expectedState)
        {
            await AssertSitzung(sitzungsArt);
            await OpenTagesordnungspunkt(topName);
            var state = await _currentPage.Locator("kendo-dropdownlist").Locator("span").AllTextContentsAsync();
            state.Contains(expectedState).Should().BeTrue();
        }

        #endregion
    }
}