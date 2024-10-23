using Dapper;
using SecondTry.Models;
using System.Data;
using System.Text.Json;

namespace SecondTry.Repsitories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> AddUser(List<User> users)
        {
            string JsonData = JsonSerializer.Serialize(users);

            var parameters = new DynamicParameters();

            parameters.Add("@JsonData", JsonData, DbType.String);

            return await _connection.QueryAsync<User>("UploadUserData", parameters, commandType: CommandType.StoredProcedure);
        }

        
    }
}
