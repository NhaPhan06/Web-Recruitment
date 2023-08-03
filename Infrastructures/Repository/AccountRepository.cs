using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(RecruitmentDbContext context) : base(context)
    {
    }

    public async Task<Account> GetAccount(string userAccount)
    {
        return _context.Accounts.FirstOrDefault(ac => ac.Username.Equals(userAccount));
    }
    
    public async Task<Account> GetAccountByEmail(string email)
    {
        return _context.Accounts.FirstOrDefault(ac => ac.Email.Equals(email));
    }

}