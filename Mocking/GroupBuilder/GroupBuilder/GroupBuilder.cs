using System.Net;

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

    public void PrintGroupBuildingQuestion()
    {
        Console.WriteLine("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden? (g/m):");
    }

    public void PrintCountQuestion()
    {
        Console.WriteLine(_mode == GroupMode.Group
            ? "Wie viele Gruppen sollen gebildet werden?"
            : "Wie viele Personen sollen je Gruppe sein?");
    }

    public void ReadBuilderMode()
    {
        BuilderMode = Console.ReadLine()!.ToLower();

        _mode = BuilderMode.StartsWith('m') ? GroupMode.Person : GroupMode.Group;
    }

    public void ReadCount()
    {
        var readLine = Console.ReadLine()!;
        _count = int.Parse(readLine);
    }

    public List<Person>[] BuildGroups(List<Person> participants)
    {
        participants = participants.OrderByDescending(p => p.Role).ToList();

        int groupCount;
        if (_mode == GroupMode.Group)
            groupCount = participants.Count < _count ? participants.Count : _count;
        else
            groupCount = (int)Math.Ceiling((double)participants.Count / _count);

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

    public void SendGroupsToDojoService(List<Person>[] groups)
    {
        var service = new DojoRestService();
        foreach (var group in groups)
        {
            if (service.SendToDojo(group) != HttpStatusCode.Created)
                throw new Exception($"group could not be created, members: {string.Join(", ", group.Select(p => p.Name))}");
        }
    }
}