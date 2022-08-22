using System.Net;

namespace GroupBuilder;

internal class ExternalService
{
    private readonly DojoRestService _service;

    //TODO interface DojoRestServic
    public ExternalService(DojoRestService service)
    {
        _service = service;
    }

    public void SendGroupsToDojoService(List<Group> groups)
    {
        foreach (var group in groups)
        {
            if (_service.SendToDojo(group.Members) != HttpStatusCode.Created)
                throw new Exception($"group could not be created, members: {string.Join(", ", group.Members.Select(p => p.Name))}");
        }
    }
}