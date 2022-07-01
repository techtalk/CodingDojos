using System.Configuration;
namespace GroupBuilder;

public static class CsvParser
{
    public static string[][] ConvertCsvToStrings()
    {
        string pathToFile = ConfigurationManager.AppSettings["PeopleFilePath"] ?? throw new ArgumentNullException();
        var lines = File.ReadAllLines(Path.GetFullPath(pathToFile));
        var result = new string[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
            result[i] = lines[i].Split(@",", StringSplitOptions.TrimEntries);

        return result;
    }
}