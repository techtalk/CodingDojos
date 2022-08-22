using System.Diagnostics;

namespace GroupBuilder;

public class Person
{

    public string Name { get; set; }
    public Roles Role { get; set; }

    public Person(string name, Roles role)
    {
        Name=name;
        Role=role;
    }

    public override string ToString()
    {
        return $"\t{Name}\t({Role})";
    }
}