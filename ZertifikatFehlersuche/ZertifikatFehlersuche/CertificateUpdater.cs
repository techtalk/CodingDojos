using System;
using System.Formats.Asn1;
using System.Globalization;

namespace ZertifikatFehlersuche
{
    public class CA_DB
    {
        public string[][] data { get; set; }
    }

    public class CertificateUpdater
    {
        private const string DB_TYPE_REV = "R"; /* Revoked  */
        private const string DB_TYPE_EXP = "E" /* Expired  */;
        private const string DB_TYPE_VAL = "V"; /* Valid ; inserted with: ca ... -valid */
        private const string DB_TYPE_SUSP = "S"; /* Suspended  */
        private const int DB_type = 0;
        private const int DB_exp_date = 1;
        private const int DB_rev_date = 2;
        private const int DB_serial = 3; /* index - unique */
        private const int DB_file = 4;
        private const int DB_name = 5; /* index - unique when active and not disabled */

        public static int do_updatedb(ref CA_DB db)
        {
            DateTime a_tm = DateTime.Now;
            int cnt = 0;
            int db_y2k, a_y2k; /* flags = 1 if y >= 2000 */
            string a_tm_s;

            a_tm_s = a_tm.ToString(CultureInfo.InvariantCulture);

            //if (strncmp(a_tm_s, "49", 2) <= 0)
            if (strncmp(a_tm_s, 49, 2))
                a_y2k = 1;
            else
                a_y2k = 0;

            foreach (string[] rrow in db.data)
            {
                if (rrow[DB_type] == DB_TYPE_VAL)
                {
                    /* ignore entries that are not valid */
                    if (strncmp(rrow[DB_exp_date], 49, 2))
                        db_y2k = 1;
                    else
                        db_y2k = 0;

                    if (db_y2k == a_y2k)
                    {
                        /* all on the same y2k side */
                        //if (strcmp(rrow[DB_exp_date], a_tm_s) <= 0)
                        if (long.Parse(rrow[DB_exp_date].Substring(0, 12)) < long.Parse(a_tm.ToString("yyMMddhhmmss")))
                        {
                            rrow[DB_type] = DB_TYPE_EXP;
                            cnt++;

                            Console.WriteLine($"{rrow[DB_serial]} is expired");
                        }
                    } else if (db_y2k < a_y2k)
                    {
                        rrow[DB_type] = DB_TYPE_EXP;
                        cnt++;

                        Console.WriteLine($"{rrow[DB_serial]} is expired");
                    }
                }
            }

            return cnt;
        }

        private static bool strncmp(string a_tm_s, int toCompare, int length)
        {
            var number = a_tm_s.Substring(0, length);
            if (int.TryParse(number, NumberStyles.Any, null, out int result))
            {
                if (result < toCompare)
                    return true;
            }

            return false;
        }
    }
}