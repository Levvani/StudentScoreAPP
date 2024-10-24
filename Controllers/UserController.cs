using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SecondTry.Repsitories;
using SecondTry.Models;
using Microsoft.Data.SqlClient;

namespace SecondTry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserScoreRepository _userScoreRepository;

        public UserController(IUserRepository userRepository, IUserScoreRepository userScoreRepository)
        {
            _userRepository = userRepository;
            _userScoreRepository = userScoreRepository;
        }
        
        [HttpPost]

        public async Task<IActionResult> CreateUser([FromBody] List<User> users)
        {
            try
            {
                var result = await _userRepository.AddUser(users);
                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("This User Already Exists!");
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpPost("UploadScore")]
        public async Task<IActionResult> UploadScore([FromBody] List<UserScore> scores)
        {
            try
            {
                var result = await _userScoreRepository.AddScore(scores);
                if (result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("This User Does Not Exist!");
                }
            }
            catch (SqlException ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ScoresByDay")]
        public async Task<IEnumerable<ScoreByDay>> ByDay( DateTime Date)
        {
           return await _userScoreRepository.GetScoresByDay(Date);
             
        }

        [HttpGet("ScoresByMonth")]

        public async Task <IEnumerable<ScoresByMonth>> ByMonth(int month)
        {
            return await _userScoreRepository.GetScoresByMonth(month);
        }

        [HttpGet("GetAllData")]

        public async Task <IEnumerable<AllData>> GetAllData()
        {
            return await _userScoreRepository.GetAllData();
        }

        [HttpGet("GetStats")]
        public async Task<IEnumerable<Stats>> GetStats()
        {
            return await _userScoreRepository.GetStats();
        }

        [HttpGet("GetUserInfo")]
        public async Task<UserInfo> GetUserInfo(int UserID)
        {
            return await _userScoreRepository.GetUserInfo(UserID);
        }

        [HttpGet("GetUserInfoByDates")]
        public async Task<UserInfoByDates> GetUserInfoByDates(DateTime from, DateTime to, int UserID)
        {
            return await _userScoreRepository.GetUserInfoByDates(from, to, UserID);
        }
    }
}
