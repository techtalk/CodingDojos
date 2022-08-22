namespace GroupBuilder;

public class Builder
{
    public List<Group> BuildGroups(List<Person> participants, GroupMode mode, int count)
    {
        participants = participants.OrderByDescending(p => p.Role).ToList();

        int groupCount;
        if (mode == GroupMode.Group)
            groupCount = participants.Count < count ? participants.Count : count;
        else
            groupCount = (int)Math.Ceiling((double)participants.Count / count);

        return MakeGroupsList(participants, groupCount)
            .Select(x => new Group() {Members = x})
            .ToList();
    }

    private List<Person>[] MakeGroupsList(List<Person> participants, int groupCount)
    {
        var groups = new List<Person>[groupCount];
        for (int i = 0; i < groupCount; i++)
            groups[i] = new List<Person>();

        for (int i = 0; i < participants.Count; i++)
            groups[i % groups.Length].Add(participants[i]);

        return groups;
    }
}