namespace SecondTry.Models
{
    public class UserInfoByDates
    {
        public int UserID { get; set; }
        public int Score_Sum { get; set; }
        public int Rating{ get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
