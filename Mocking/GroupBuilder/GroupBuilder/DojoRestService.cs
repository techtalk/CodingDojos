using System.Net;

namespace GroupBuilder
{
    internal class DojoRestService
    {
        public HttpStatusCode SendToDojo(List<Person> group)
        {
            return HttpStatusCode.Created;
        }
    }
}
