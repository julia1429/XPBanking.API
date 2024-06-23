using XPBanking.API.Services.Dto;

namespace XPBanking.API.Services.Interface
{
    public interface IConsultInvestmentService
    {
        Task<List<UserTransaction>> GetUserInvestment(int id);
        User GetTotalBalanceUser(int id);
        bool checkMinValue(int assetId, int value);
        Task<string> AssetBalance(int id, int assetId, int value, int type);
        Task<List<UserStatement>> GetStatement(int id);
        public List<UserTransaction> GetAssetsExpired();
        void EnviarEmailsParaUsuarios(List<UserTransaction> usuarios);
    }
}
