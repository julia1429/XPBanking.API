namespace XPBanking.API.Services.Dto
{
    public class UserTransaction
    {
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string UserName { get; set; } 
        public string email { get; set; }
        public string Desc { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CurrentInvestedBalance { get; set; }
    }
}
