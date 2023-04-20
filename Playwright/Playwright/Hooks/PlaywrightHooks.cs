using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Playwright.Hooks
{
    [Binding]
    public class PlaywrightHooks
    {
        private bool UsePlaywrightBrowser => true;
        public IPage CurrentPage { get; private set; } = null!; // -> Die BrowserPage welche in allen Tests verwendet wird

        [BeforeScenario]
        public async Task RegisterSingleInstancePractitioner()
        {
            //Playwright initialisieren
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            //Browser initialisieren - 'Chromium' kann auch auf 'Firefox' oder 'Webkit' geändert werden
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,   // -> Setzt den Browser auf sichtbar oder nicht
                SlowMo = 1000,      // -> Setzt die Geschwidigkeit von den Playwright Klicks
                Timeout = 10000,    // -> Setzen den Timeout, wie lange Playwright versucht Objekte zu finden/klicken
                Channel = "msedge", // -> "msedge", "chrome" "chrome-beta", "msedge-beta", "msedge-dev", etc.
                ExecutablePath = TryGetPathToInstalledChrome(), // -> Es ist auch möglich den eigenen Browser zu verwenden
                //DownloadsPath = ""
            });

            //Setup des Browser Kontexts
            var context = await browser.NewContextAsync();

            //Initialisiere eine neue Seite in dem aktuellen Browser Kontext
            CurrentPage = await context.NewPageAsync();
        }

        protected virtual string? TryGetPathToInstalledChrome()
        {
            if (UsePlaywrightBrowser)
                return null;

            var regeditBrwoserPath = @"HKEY_CLASSES_ROOT\ChromeHTML\shell\open\command";
            var path = Microsoft.Win32.Registry.GetValue(regeditBrwoserPath, null, null) as string;
            if (path == null) 
                return path;
            
            var split = path.Split('\"');
            return split.Length >= 2 ? split[1] : null;
        }
    }
}