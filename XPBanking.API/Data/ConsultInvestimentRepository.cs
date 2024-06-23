using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using XPBanking.API.Data.Interface;
using XPBanking.API.Services.Dto;

namespace XPBanking.API.Data
{
    public class ConsultInvestimentRepository : IConsultInvestimentRepository
    {
        private readonly XPBankingContext _context;
        private readonly int _limiteDias = 30;
        public ConsultInvestimentRepository(XPBankingContext context)
        {
            _context = context;
        }
        public async Task<List<UserTransaction>> GetUserInvestment(int id)
        {
            return await _context.UserTransaction
                                 .Where(u => u.UserId == id)
                                 .ToListAsync();


        }

        public async Task InsertNewBalance(int id, User userValue)
        {
            try
            {
                var existingUser = _context.User.Find(id);

                existingUser.currentBalance = userValue.currentBalance;
                existingUser.currentInvestedBalance = userValue.currentInvestedBalance; 

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public User GetBalance(int id)
        {
            var userBalance = _context.User
                                .Where(u => u.id == id)
                                .FirstOrDefault();

            return userBalance;
        }

        public int GetMinValue(int assetId)
        {
            var minValue =  _context.investmentDto
                            .Where(u => u.Id == assetId)
                            .Select(u => u.MinValue)
                            .FirstOrDefault();
           
            return minValue;
        }

        public async Task InsertUserTransaction(TransactionDto transaction)
        {
             _context.transactionDto.Add(transaction);

            await _context.SaveChangesAsync();

        }

        public async Task<List<UserStatement>> GetStatementByUser(int id)
        {
            return await _context.userStatements
                                 .Where(u => u.userId == id)
                                 .ToListAsync();
        }

        public List<UserTransaction> GetEmailList()
        {
            var currentDate = DateTime.Today;
            var limitedDate = currentDate.AddDays(_limiteDias);
            
            var userTransactions = _context.UserTransaction
             .Where(p => p.ExpireDate <= limitedDate && p.ExpireDate >= currentDate)
             .Select(p => new UserTransaction
             {
                 UserName = p.UserName,
                 email = p.email, 
                 AssetId = p.AssetId,
                 AssetName = p.AssetName,

             })
             .ToList();

            return userTransactions;
        }
    }
}
