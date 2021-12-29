using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZertifikatFehlersuche;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly string[][] dbData =
        {
            new[]
            {
                "V", "990501230004Z", "1000", "unknown", "/C=AT/ST=Austria/L=OpenSSL/O=OpenSSL/OU=OpenSSL/CN=1999",
            },
            new[]
            {
                "V", "200430230003Z", "1001", "unknown", "/C=AT/ST=Austria/L=OpenSSL/O=OpenSSL/OU=OpenSSL/CN=2020",
            },            
            new[]
            {
                "V", "230430230003Z", "1002", "unknown", "/C=AT/ST=Austria/L=OpenSSL/O=OpenSSL/OU=OpenSSL/CN=2023",
            },
            new[]
            {
                "V", "730501230003Z", "1003", "unknown", "/C=AT/ST=Austria/L=OpenSSL/O=OpenSSL/OU=OpenSSL/CN=2073",
            }
        };

        [TestMethod]
        public void ExecuteDoUpdateDB()
        {
            var caDb = new CA_DB
            {
                data = dbData
            };

            CertificateUpdater.do_updatedb(ref caDb);
        }
    }
}