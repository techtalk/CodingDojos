using System;
using System.Globalization;

namespace ZertifikatFehlersuche
{
    public class CertificateUpdater_TeamA
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
            DateTime time = DateTime.Now;
            int countExpired = 0;
            string timeString;
            timeString = time.ToString(CultureInfo.InvariantCulture);
            //if (strncmp(a_tm_s, "49", 2) <= 0)
            foreach (string[] rrow in db.data)
            {
                if (rrow[DB_type] == DB_TYPE_VAL)
                {
                    /* ignore entries that are not valid */
                    var dbIsBefore2K = !strncmp(rrow[DB_exp_date], 49, 2); /* flags = 1 if y >= 2000 */
                    //remove in 2050
                    if (rrow[DB_exp_date].Length == 13)
                    {
                        var prefix = dbIsBefore2K ? "19" : "20";
                        rrow[DB_exp_date] = prefix + rrow[DB_exp_date];
                    }
                    //make actual datetime conversion/comparison
                    var isInvalid = long.Parse(rrow[DB_exp_date].Substring(0, 14)) < long.Parse(time.ToString("yyyyMMddhhmmss"));
                    if (dbIsBefore2K || isInvalid)
                    {
                        /* all on the same y2k side */
                        //if (strcmp(rrow[DB_exp_date], a_tm_s) <= 0)
                        rrow[DB_type] = DB_TYPE_EXP;
                        countExpired++;
                        Console.WriteLine($"{rrow[DB_serial]} is expired");
                    }
                }
            }
            return countExpired;
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