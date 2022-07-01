namespace GroupBuilder;

public class GroupBuilder
{
    enum GroupMode
    {
        Group,
        Person
    }

    public string BuilderMode { get; private set; } = string.Empty;
    private GroupMode _mode;
    private int _count;

    public void SetupGroupBuilderViaConsole()
    {
        PrintGroupBuildingQuestion();
        ReadBuilderMode();
        PrintCountQuestion();
        ReadCount();
    }

    internal void PrintGroupBuildingQuestion()
    {
        Console.WriteLine("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden? (G/m):");
    }

    internal void PrintCountQuestion()
    {
        Console.WriteLine(_mode == GroupMode.Group
            ? "Wie viele Gruppen sollen gebildet werden?"
            : "Wie viele Personen sollen je Gruppe sein?");
    }

    internal void ReadBuilderMode()
    {
        BuilderMode = Console.ReadLine()!.ToLower();

        _mode = BuilderMode.StartsWith('m') ? GroupMode.Person : GroupMode.Group;
    }

    internal void ReadCount()
    {
        var readLine = Console.ReadLine()!;
        _count = Int32.Parse(readLine);
    }

    public List<Person>[] BuildGroups(List<Person> participants)
    {
        participants = participants.OrderByDescending(p => p.Role).ToList();

        int groupCount = -1;
        if (_mode == GroupMode.Group)
            groupCount = participants.Count < _count ? participants.Count : _count;
        else
            groupCount = (int)Math.Ceiling(((double)participants.Count) / _count);

        return makeGroupsList(participants, groupCount);
    }

    private List<Person>[] makeGroupsList(List<Person> participants, int groupCount)
    {
        var groups = new List<Person>[groupCount];
        for (int i = 0; i < groupCount; i++)
            groups[i] = new List<Person>();

        for (int i = 0; i < participants.Count; i++)
            groups[i % groups.Length].Add(participants[i]);

        return groups;
    }

    public void PrintGroups(List<Person>[] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            Console.WriteLine($"\nGruppe {i + 1}:");
            foreach (var person in groups[i])
                Console.WriteLine(person.ToString());
        }
    }
}