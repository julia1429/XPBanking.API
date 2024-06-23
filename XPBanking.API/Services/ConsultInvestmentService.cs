using Microsoft.AspNetCore.Http.HttpResults;
using System.Transactions;
using XPBanking.API.Data.Interface;
using XPBanking.API.Services.Dto;
using XPBanking.API.Services.Interface;

namespace XPBanking.API.Services
{
    public class ConsultInvestmentService : IConsultInvestmentService
    {
        private readonly IConsultInvestimentRepository _consultInvestimentRepository;
        private readonly ISendEmailService _emailService;
        public ConsultInvestmentService(IConsultInvestimentRepository consultInvestimentRepository, ISendEmailService emailService)
        {
            _consultInvestimentRepository = consultInvestimentRepository;
            _emailService = emailService;
        }
        public async Task<List<UserTransaction>> GetUserInvestment(int id)
        {

            return await _consultInvestimentRepository.GetUserInvestment(id);

        }

        public async Task<string> AssetBalance(int id, int assetId, int value, int type)
        {
            var userValue = new User();
            var newTotalBalance = default(int);
            var investmentsBalance = default(int);

            userValue = GetTotalBalanceUser(id);


            if (type == 1) //compra
            {
                if (!checkMinValue(assetId, value))
                {
                    return ("Valor Minimo de investimento não atingido");
                }
                if (userValue.currentBalance < value)
                {
                    return ("Saldo indisponível");
                }
                else
                {
                    newTotalBalance = userValue.currentBalance - value;
                    investmentsBalance = userValue.currentInvestedBalance + value;

                    userValue = new User
                    {
                        id = id,
                        currentBalance = newTotalBalance,
                        currentInvestedBalance = investmentsBalance
                    };

                    try
                    {
                        var result = _consultInvestimentRepository.InsertNewBalance(id, userValue);
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            if (type == 2)
            {
                newTotalBalance = userValue.currentBalance + value;
                investmentsBalance = userValue.currentInvestedBalance -= value;

                userValue = new User
                {
                    id = id,
                    currentBalance = newTotalBalance,
                    currentInvestedBalance = investmentsBalance

                };

                try
                {
                    var result = _consultInvestimentRepository.InsertNewBalance(id, userValue);
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }

            var transaction = new TransactionDto
            {
                Id = Guid.NewGuid(),
                AssetId = assetId,
                UserId = id,
                UpdatedDateTime = DateTime.Now,
                Type = type,
                Value = value,
                Amount = newTotalBalance

            };

            await InsertTransaction(transaction); 

            return ("");
        }

        public async Task InsertTransaction(TransactionDto transaction)
        {
            await _consultInvestimentRepository.InsertUserTransaction(transaction);
        }

        public bool checkMinValue(int assetId, int value)
        {
            var minValue = _consultInvestimentRepository.GetMinValue(assetId);

            bool result = value > minValue ? true : false;

            return result;

        }
        public User GetTotalBalanceUser(int id)
        {
            var totalBalance = _consultInvestimentRepository.GetBalance(id);

            return totalBalance;

        }

        public async Task<List<UserStatement>> GetStatement(int id)
        {
            return await _consultInvestimentRepository.GetStatementByUser(id); 

            
        }

        public List<UserTransaction> GetAssetsExpired()
        {
            return _consultInvestimentRepository.GetEmailList();

        }
        public void EnviarEmailsParaUsuarios(List<UserTransaction> usuarios)
        {
            foreach (var usuario in usuarios)
            {
                _emailService.EnviarEmailParaId(usuario);
            }
        }

    }
}
