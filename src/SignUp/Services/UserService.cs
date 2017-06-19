namespace SignUp.Services
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using SignUp.Models;

    public class UserService : IUserService
    {
        public async Task AddUser(UserModel model)
        {
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var username = Environment.GetEnvironmentVariable("DB_USERNAME");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var name = Environment.GetEnvironmentVariable("DB_NAME");

            using (var connection = new SqlConnection($"Server={host};User Id={username};Password={password};Database={name};"))
            {
                await connection.OpenAsync();

                var query = @"
                    INSERT INTO
                        users(email, password)
                    VALUES
                        (@Email, @Password);
                    ";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Email", SqlDbType.VarChar, 256).Value = model.Email;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 32).Value = model.Password;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
