namespace XPBanking.API.Services.Dto
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int AssetId { get; set; }  
        public int Type {  get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int Value { get; set; }
        public int Amount { get; set; }
    }
}
