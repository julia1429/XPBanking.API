using XPBanking.API.Services.Dto;

namespace XPBanking.API.Services.Interface
{
    public interface ISendEmailService
    {
        Task EnviarEmailParaId(UserTransaction user);
    }
}
