namespace Playwright.Utilits
{
    public static class SearchEngineDictionary
    {
        private static Dictionary<string, string> _searchEngineMapping = new ()
        {
            {"google", "https://www.google.at/search?q=" },
            {"duckduckgo", "https://duckduckgo.com/?q=" },
        };

        public static string GetSearchEngineUrl(string searchEngine)
        {
            return _searchEngineMapping.TryGetValue(searchEngine.ToLower(), out var url) ? url : string.Empty;
        }
    }
}