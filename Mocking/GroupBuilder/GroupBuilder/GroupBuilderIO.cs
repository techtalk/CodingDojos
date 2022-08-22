namespace GroupBuilder;

//TODO remove hardcoded strings to resource file
public class GroupBuilderIO
{
    private TextReader _reader;
    private TextWriter _writer;

    private GroupMode _mode;
    public GroupMode Mode => _mode;

    private int _count;
    public int Count => _count;

    public GroupBuilderIO(TextReader reader, TextWriter writer)
    {
        _reader = reader;
        _writer = writer;
    }

    public void PrintGroupBuildingQuestion()
    {
        _writer.WriteLine("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden? (g/m):");
    }

    public void PrintCountQuestion()
    {
        _writer.WriteLine(_mode == GroupMode.Group
            ? "Wie viele Gruppen sollen gebildet werden?"
            : "Wie viele Personen sollen je Gruppe sein?");
    }

    public void ReadBuilderMode()
    {
        var builderMode = _reader.ReadLine()!.ToLower();

        _mode = builderMode.StartsWith('m') 
            ? GroupMode.Person 
            : GroupMode.Group;
    }

    public void ReadCount()
    {
        var readLine = _reader.ReadLine()!;
        _count = int.Parse(readLine);
    }

    public void PrintGroups(List<Group> groups)
    {
        foreach (var (index, group) in groups.Select((g, i) => (i, g)))
        {
            _writer.WriteLine($"\nGruppe {index + 1}:");
            PrintPersons(group.Members);
        }
    }

    private void PrintPersons(List<Person> people)
    {
        foreach (var person in people)
            _writer.WriteLine(person.ToString());
    }
}