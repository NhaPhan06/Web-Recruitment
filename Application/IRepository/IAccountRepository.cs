using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<Account> GetAccount(string userAccount);
    Task<Account> GetAccountByEmail(string email);
}