namespace GroupBuilder;

public static class CsvPersonParser
{
    public static List<Person> Parse(string fileContent)
    {
        var rows = fileContent.Split(Environment.NewLine);
        return rows
            .Select(ParsePerson)
            .ToList();
    }

    internal static Person ParsePerson(string personCsv)
    {
        //assumes person to be name, role
        var parts = personCsv.Split(@",", StringSplitOptions.TrimEntries);

        if (parts.Length != 2)
            throw new ArgumentException("you fail in life");

        var role = ParseRole(parts[1]);
        return new Person(parts[0], role);
    }

    private static Roles ParseRole(string role)
    {
        return role switch
        {
            "Junior" => Roles.Junior,
            "Dev" => Roles.Dev,
            "Senior" => Roles.Senior,
            "Architekt" => Roles.Architekt,
            _ => 0
        };
    }

}