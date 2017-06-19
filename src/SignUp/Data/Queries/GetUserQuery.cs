namespace SignUp.Data.Queries
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using SignUp.Models;

    public sealed class GetUserQuery
    {
        private readonly SqlConnection _connection;
        private readonly string _query;

        public GetUserQuery(SqlConnection connection)
        {
            _connection = connection;
            _query = @"
                SELECT
                    email, password
                FROM
                    users
                WHERE
                    email = @Email;
                ";
        }

        public async Task<UserModel> Execute(string email)
        {
            using (var command = CreateCommand(email))
            using (var reader = await command.ExecuteReaderAsync())
            {
                return await GetModelFromReader(reader);
            }
        }

        private SqlCommand CreateCommand(string email)
        {
            var command = new SqlCommand(_query, _connection);
            command.Parameters.AddWithValue("@Email", email);
            return command;
        }

        private async Task<UserModel> GetModelFromReader(SqlDataReader reader)
        {
            if (!(await reader.ReadAsync()))
                return null;

            return new UserModel
            {
                Email = reader["email"] as string
            };
        }
    }
}
