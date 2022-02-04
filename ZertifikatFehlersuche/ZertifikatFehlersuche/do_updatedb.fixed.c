static int do_updatedb(CA_DB *db)
{
    ASN1_TIME *a_tm = NULL;
    int i, cnt = 0;
    char **rrow;

    a_tm = ASN1_TIME_new();
    if (a_tm == NULL)
        return -1;

    /* get actual time */
    if (X509_gmtime_adj(a_tm, 0) == NULL) {
        ASN1_TIME_free(a_tm);
        return -1;
    }

    for (i = 0; i < sk_OPENSSL_PSTRING_num(db->db->data); i++) {
        rrow = sk_OPENSSL_PSTRING_value(db->db->data, i);

        if (rrow[DB_type][0] == DB_TYPE_VAL) {
            /* ignore entries that are not valid */
            ASN1_TIME *exp_date = NULL;

            exp_date = ASN1_TIME_new();
            if (exp_date == NULL) {
                ASN1_TIME_free(a_tm);
                return -1;
            }

            if (!ASN1_TIME_set_string(exp_date, rrow[DB_exp_date])) {
                ASN1_TIME_free(a_tm);
                ASN1_TIME_free(exp_date);
                return -1;
            }

            if (ASN1_TIME_compare(exp_date, a_tm) <= 0) {
                rrow[DB_type][0] = DB_TYPE_EXP;
                rrow[DB_type][1] = '\0';
                cnt++;

                BIO_printf(bio_err, "%s=Expired\n", rrow[DB_serial]);
            }
            ASN1_TIME_free(exp_date);
        }
    }

    ASN1_TIME_free(a_tm);
    return cnt;
}