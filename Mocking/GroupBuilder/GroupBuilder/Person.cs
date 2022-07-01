namespace GroupBuilder;

public class Person
{
    public enum Roles
    {
        Junior,
        Dev,
        Senior,
        Architekt
    }
    public string Name { get; set; }
    public Roles Role { get; set; }

    public Person(string name, Roles role)
    {
        Name=name;
        Role=role;
    }

    public static List<Person> PersonConverter(string[][] input)
    {
        var persons = new List<Person>();
        foreach (var personStrings in input)
        {
            Roles role = personStrings[1] switch
            {
                "Junior" => Roles.Junior,
                "Dev" => Roles.Dev,
                "Senior" => Roles.Senior,
                "Architekt" => Roles.Architekt,
                _ => 0
            };

            persons.Add(new Person(personStrings[0], role));
        }

        return persons;
    }

    public override string ToString()
    {
        return $"\t{Name}\t({Role})";
    }
}