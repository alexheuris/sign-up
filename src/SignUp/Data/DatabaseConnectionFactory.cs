namespace SignUp.Data
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class DatabaseConnectionFactory
    {
        public static SqlConnection Create()
        {
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var username = Environment.GetEnvironmentVariable("DB_USERNAME");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var name = Environment.GetEnvironmentVariable("DB_NAME");

            return new SqlConnection($"Server={host};User Id={username};Password={password};Database={name};");
        }
    }
}
