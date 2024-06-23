namespace XPBanking.API.Services.Dto
{
    public class UserStatement
    {
        public int userId { get; set; }
        public string AssetDescription { get; set; }
        public int type { get; set; }
        public int value { get; set; }
        public int DailyBalance { get; set; }
        public DateTime updatedDateTime { get; set; }
    }
}
