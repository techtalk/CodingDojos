using System.Net;

namespace GroupBuilder
{
    //TODO add interface
    internal class DojoRestService
    {
        public HttpStatusCode SendToDojo(List<Person> group)
        {
            return HttpStatusCode.Created;
        }
    }
}
