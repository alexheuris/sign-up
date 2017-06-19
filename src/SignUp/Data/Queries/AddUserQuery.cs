namespace SignUp.Data.Queries
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using SignUp.Models;

    public class AddUserQuery
    {
        private readonly SqlConnection _connection;
        private readonly string _query;

        public AddUserQuery(SqlConnection connection)
        {
            _connection = connection;
            _query = @"
                INSERT INTO
                    users(email, password)
                VALUES
                    (@Email, @Password);
                ";
        }

        public async Task<int> Execute(UserModel model)
        {
            using (var command = new SqlCommand(_query, _connection))
            {
                command.Parameters.Add("@Email", SqlDbType.VarChar, 256).Value = model.Email;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 128).Value = model.Password;
                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}
