using GroupBuilder;

GroupBuilder.GroupBuilder groupBuilder = new GroupBuilder.GroupBuilder();
groupBuilder.SetupGroupBuilderViaConsole();

var participants = Person.PersonConverter(CsvParser.ConvertCsvToStrings());
var groups = groupBuilder.BuildGroups(participants);

groupBuilder.PrintGroups(groups);