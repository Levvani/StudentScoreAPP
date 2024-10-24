using System.Data;
using System.Data.Common;
using SecondTry.Models;
using Dapper;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SecondTry.Repsitories
{
    public class UserScoreRepository: IUserScoreRepository
    {
        private readonly IDbConnection connection;

        public UserScoreRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<UserScore>> AddScore(List<UserScore> scores)
        {
            string JsonData = JsonSerializer.Serialize(scores);

            var parameters = new DynamicParameters();

            parameters.Add("@JsonData", JsonData, DbType.String);

            return await connection.QueryAsync<UserScore>("UploadUserScore", parameters, commandType:CommandType.StoredProcedure);
        }
        
        public async Task <IEnumerable <ScoreByDay>>  GetScoresByDay(DateTime Date)
        {

            return await connection.QueryAsync<ScoreByDay>("GetScoresByDay", new {Date = Date}, commandType:CommandType.StoredProcedure);
            
        }
        public async Task <IEnumerable <ScoresByMonth>> GetScoresByMonth(int month)
        {

            return await connection.QueryAsync<ScoresByMonth>("GetScoresByMonth", new {Month = month}, commandType:CommandType.StoredProcedure);

        }
        public async Task <IEnumerable<AllData>> GetAllData()
        {
            return await connection.QueryAsync<AllData>("GetAllData", commandType:CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Stats>> GetStats()
        {
            return await connection.QueryAsync<Stats>("GetStats",commandType:CommandType.StoredProcedure);
        }

        public async Task <UserInfo> GetUserInfo(int UserID)
        {
            return await connection.QuerySingleAsync<UserInfo>("GetUserInfo", new {ID = UserID}, commandType:CommandType.StoredProcedure);
        }

        public async Task <UserInfoByDates> GetUserInfoByDates(DateTime from, DateTime to, int UserID)
        {
        
            var parameters = new DynamicParameters();

            parameters.Add("@From", from, DbType.String);

            parameters.Add("@To", to, DbType.String);

            parameters.Add("@UserID", UserID);

            return await connection.QuerySingleAsync<UserInfoByDates>("GetUserInfoByDates",parameters, commandType:CommandType.StoredProcedure);
        }
    }
}

