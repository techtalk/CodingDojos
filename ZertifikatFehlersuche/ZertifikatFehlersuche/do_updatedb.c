static int do_updatedb(CA_DB *db)
{
    ASN1_UTCTIME *a_tm = NULL;
    int i, cnt = 0;
    int db_y2k, a_y2k;          /* flags = 1 if y >= 2000 */
    char **rrow, *a_tm_s;

    a_tm = ASN1_UTCTIME_new();
    if (a_tm == NULL)
        return -1;

    /* get actual time and make a string */
    if (X509_gmtime_adj(a_tm, 0) == NULL) {
        ASN1_UTCTIME_free(a_tm);
        return -1;
    }
    a_tm_s = app_malloc(a_tm->length + 1, "time string");

    memcpy(a_tm_s, a_tm->data, a_tm->length);
    a_tm_s[a_tm->length] = '\0';

    if (strncmp(a_tm_s, "49", 2) <= 0)
        a_y2k = 1;
    else
        a_y2k = 0;

    for (i = 0; i < sk_OPENSSL_PSTRING_num(db->db->data); i++) {
        rrow = sk_OPENSSL_PSTRING_value(db->db->data, i);

        if (rrow[DB_type][0] == DB_TYPE_VAL) {
            /* ignore entries that are not valid */
            if (strncmp(rrow[DB_exp_date], "49", 2) <= 0)
                db_y2k = 1;
            else
                db_y2k = 0;

            if (db_y2k == a_y2k) {
                /* all on the same y2k side */
                if (strcmp(rrow[DB_exp_date], a_tm_s) <= 0) {
                    rrow[DB_type][0] = DB_TYPE_EXP;
                    rrow[DB_type][1] = '\0';
                    cnt++;

                    BIO_printf(bio_err, "%s=Expired\n", rrow[DB_serial]);
                }
            } else if (db_y2k < a_y2k) {
                rrow[DB_type][0] = DB_TYPE_EXP;
                rrow[DB_type][1] = '\0';
                cnt++;

                BIO_printf(bio_err, "%s=Expired\n", rrow[DB_serial]);
            }

        }
    }

    ASN1_UTCTIME_free(a_tm);
    OPENSSL_free(a_tm_s);
    return cnt;
}
