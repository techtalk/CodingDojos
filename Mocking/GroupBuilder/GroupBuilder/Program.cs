using GroupBuilder;

var groupBuilder = new GroupBuilder.GroupBuilder();
groupBuilder.PrintGroupBuildingQuestion();
groupBuilder.ReadBuilderMode();
groupBuilder.PrintCountQuestion();
groupBuilder.ReadCount();

var participants = Person.PersonConverter(CsvParser.ConvertCsvToStrings());
var groups = groupBuilder.BuildGroups(participants);

groupBuilder.PrintGroups(groups);
groupBuilder.SendGroupsToDojoService(groups);