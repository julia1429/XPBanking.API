using System.ComponentModel.DataAnnotations.Schema;

namespace XPBanking.API.Services.Dto
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ExpireDate { get; set; }
        public int UnitPrice { get; set; }
        public int MinValue  { get; set; }
    }
}
