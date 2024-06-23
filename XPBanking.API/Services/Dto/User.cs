using System.ComponentModel.DataAnnotations;

namespace XPBanking.API.Services.Dto
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string birthDate { get; set; }
        public int currentBalance {  get; set; } 
        public int currentInvestedBalance { get; set; }    
        public string email { get; set; }   
    }
}
