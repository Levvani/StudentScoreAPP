using SecondTry.Models;

namespace SecondTry.Repsitories
{
    public interface IUserScoreRepository
    {
        Task<IEnumerable<UserScore>> AddScore(List<UserScore> score);
        Task <IEnumerable<ScoreByDay>> GetScoresByDay(DateTime Date);
        Task <IEnumerable<ScoresByMonth>> GetScoresByMonth(int Month);
        Task <IEnumerable<AllData>> GetAllData();
        Task<IEnumerable<Stats>> GetStats();
        Task<UserInfo> GetUserInfo(int UserId);
        Task<UserInfoByDates> GetUserInfoByDates(DateTime from, DateTime to, int UserID);

    }
}
