using System.Transactions;
using XPBanking.API.Services.Dto;

namespace XPBanking.API.Data.Interface
{
    public interface IConsultInvestimentRepository
    {
        Task<List<UserTransaction>> GetUserInvestment(int id);
        int GetMinValue(int assetId);
        User GetBalance(int id);
        Task InsertNewBalance(int id, User userValue);
        Task InsertUserTransaction(TransactionDto transaction);
        Task<List<UserStatement>> GetStatementByUser(int id);
        List<UserTransaction> GetEmailList();
    }
}
