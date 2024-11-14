namespace Hw_Week12.Configuration
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; }

        static Configuration()
        {
            ConnectionString = "Data Source=LAPTOP-CDHPQSKA\\SQLEXPRESS;Initial Catalog=TodoListDb;User ID=sa;Password=erfash3883;TrustServerCertificate=True;Encrypt=True";

        }
    }
}
