using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(RecruitmentDbContext context) : base(context)
    {
    }
}