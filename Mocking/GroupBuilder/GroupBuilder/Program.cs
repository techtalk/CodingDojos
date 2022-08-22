using System.Configuration;
using GroupBuilder;

var IO = new GroupBuilderIO(Console.In, Console.Out);
IO.PrintGroupBuildingQuestion();
IO.ReadBuilderMode();
IO.PrintCountQuestion();
IO.ReadCount();

string pathToFile = ConfigurationManager.AppSettings["PeopleFilePath"] ?? throw new ArgumentNullException();
var personRecords = File.ReadAllText(pathToFile);

var participants = CsvPersonParser.Parse(personRecords);
var groupBuilder = new Builder();
var groups = groupBuilder.BuildGroups(participants, IO.Mode, IO.Count);

IO.PrintGroups(groups);

var restService = new DojoRestService();
var externalService = new ExternalService(restService);
externalService.SendGroupsToDojoService(groups);