namespace App.Repository.Desctop
{
    class StringConexaoDB
    {
        private string PathDatabaseSQLServer()
        {
            return @"Data Source = (localdb)\MSSQLLocalDB; Database = DBWattsAppApiDesKtop; User ID = sa; Password = senha; TrustServerCertificate = True; Trusted_Connection = False; Connection Timeout = 300; Integrated Security = False; Persist Security Info = False; Encrypt = false; MultipleActiveResultSets = True;";
        }

        public string PathConexaoDB()
        {
            return PathDatabaseSQLServer();
        }
    }
}
