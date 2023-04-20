using Microsoft.Playwright;
using Playwright.Hooks;
using Playwright.Pages;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class PlenumSteps
    {
        private readonly IPage _currentPage;
        private readonly PlenumPage _plenumHomePage;

        public PlenumSteps(PlaywrightHooks hooks, PlenumPage plenumHomePage)
        {
            _currentPage = hooks.CurrentPage;
            _plenumHomePage = plenumHomePage;
        }

        [Given(@"der Benutzer ist auf der Plenum Homepage")]
        public async Task GivenDerBenutzerIstAufDerPlenumHomepage()
        {
            await _plenumHomePage.OpenHomepage();
            await _plenumHomePage.AssertPageContent();
        }

        [Given(@"dieser Benutzer loggt sich ein")]
        public async Task GivenDieserBenutzerLoggtSichEin()
        {
            await _plenumHomePage.Login();
        }

        [When(@"der Benutzer die Sitzung '(.*)' mit der Sitzungsart '(.*)' erstellt")]
        public async Task WhenDieserBenutzerDieSitzungMitDerSitzungsartErstellt(string sitzungsName, string sitzungsArt)
        {
            await _plenumHomePage.CreateSitzung(sitzungsName, sitzungsArt);
        }

        [Given(@"der Benutzer sich auf der Startseite befindet")]
        public async Task GivenDerBenutzerSichAufDerStartseiteBefindet()
        {
            await _plenumHomePage.GoToStartpage();
        }

        [When(@"der Benutzer die Sitzung mit der Sitzungsart '([^']*)' öffnet")]
        [Given(@"der Benutzer die Sitzung mit der Sitzungsart '([^']*)' öffnet")]
        public async Task GivenDerBenutzerDieSitzungMitDerSitzungsartOffnet(string sitzungsArt)
        {
            await _plenumHomePage.OpenSitzung(sitzungsArt);
        }

        [When(@"der Benutzer den vorhandenen Teilnehmer '([^']*)' hinzufügt")]
        public async Task WhenDerBenutzerDenVorhandenenTeilnehmerHinzufugt(string teilnehmer)
        {
            await _plenumHomePage.AddExistingTeilnehmendeToSitzung(teilnehmer);
        }

        [When(@"der Benutzer '([^']*)' anklickt")]
        public async Task WhenDerBenutzerAnklickt(string p0)
        {
            await _plenumHomePage.ShowAllCompletedSitzungen();
        }

        [When(@"der Benutzer einen neuen Tagesordnungspunkt '([^']*)' erstellt")]
        public async Task WhenDerBenutzerEinenNeuenTagesordnungspunktErstellt(string topName)
        {
            await _plenumHomePage.CreateTagesordnungspunkt(topName);
        }

        [When(@"diesen Tagesordnungspunkt '([^']*)' zuordnet")]
        public async Task WhenDiesenTagesordnungspunkteZuordnet(string topName)
        {
            await _plenumHomePage.AddTagesordnungspunktToSitzung(topName);
        }

        [When(@"der Benutzer einen neuen Tagesordnungspunkt '([^']*)' anlegt")]
        public async Task WhenDerBenutzerEinenNeuenTagesordnungspunktAnlegt(string topName)
        {
            await _plenumHomePage.CreateTagesordnungspunktWithinSitzung(topName);
        }

        [Given(@"der Benutzer den Tagesordnungspunkt '([^']*)' öffnet")]
        public async Task GivenDerBenutzerDenTagesordnungspunktOffnet(string topName)
        {
            await _plenumHomePage.OpenTagesordnungspunkt(topName);
        }

        [When(@"der Benutzer einen Kommentar '([^']*)' anlegt")]
        public async Task WhenDerBenutzerEinenKommentarAnlegt(string comment)
        {
            await _plenumHomePage.AddCommentToTagesordnungspunkt(comment);
        }

        [When(@"der Benutzer den Status auf '([^']*)' ändert")]
        public async Task WhenDerBenutzerDenStatusAufAndert(string state)
        {
            await _plenumHomePage.ChangeStateOfTagesordnungspunkt(state);
        }

        [Then(@"sollte eine Sitzung '([^']*)' mit der Sitzungsart '([^']*)' existieren")]
        public async Task ThenSollteEineSitzungMitDerSitzungsartExistieren(string sitzungsName, string sitzungsArt)
        {
            await _plenumHomePage.AssertSitzungWithTitle(sitzungsName, sitzungsArt);
        }

        [Then(@"sollte die Sitzung mit der Sitzungsart '([^']*)' den Teilnehmer '([^']*)' hinterlegt haben")]
        public async Task ThenSollteDieSitzungMitDerSitzungsartDenTeilnehmerHinterlegtHaben(string sitzungsArt, string teilnehmerName)
        {
            await _plenumHomePage.AssertTeilnehmerInSitzung(sitzungsArt, teilnehmerName);
        }

        [Then(@"sollte dieser Tagesordnungspunkt '([^']*)' in der Sitzung mit der Sitzungsart '([^']*)' existieren")]
        public async Task ThenSollteDieserTagesordnungspunktInDerSitzungMitDerSitzungsartExistieren(string topName, string sitzungsArt)
        {
            await _plenumHomePage.AssertTagesordnungspunktInSitzung(sitzungsArt, topName);
        }

        [Then(@"sollte dieser Kommentar '([^']*)' auf dem Tagesordnungspunkt '([^']*)' in der Sitzung mit der Sitzungsart '([^']*)' existieren")]
        public async Task ThenSollteDieserKommentarAufDemTagesordnungspunktInDerSitzungMitDerSitzungsartExistieren(string comment, string topName, string sitzungsArt)
        {
            await _plenumHomePage.AssertCommentInTagesordnungspunktInSitzung(sitzungsArt, topName, comment);
        }

        [Then(@"sollte der Tagesordnungspunkt '([^']*)' in der Sitzung mit der Sitzungsart '([^']*)' den Status '([^']*)' haben")]
        public async Task ThenSollteDerTagesordnungspunktInDerSitzungMitDerSitzungsartDenStatusHaben(string topName, string sitzungsArt, string state)
        {
            await _plenumHomePage.AssertStateOfTagesordnungspunktInSitzung(sitzungsArt, topName, state);
        }
    }
}