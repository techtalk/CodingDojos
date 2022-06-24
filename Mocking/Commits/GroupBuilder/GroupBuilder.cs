namespace GroupBuilder
{
    public class GroupBuilder
    {
        public string BuilderMode { get; private set; } = string.Empty;

        internal void PrintGroupBuildingQuestion()
        {
            Console.WriteLine("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden?");
        }

        internal void ReadBuilderMode()
        {
           BuilderMode = Console.ReadLine()!;
        }
    }
}