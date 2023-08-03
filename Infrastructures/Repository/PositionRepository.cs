using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class PositionRepository : GenericRepository<Position>, IPositionRepository
{

    public PositionRepository(RecruitmentDbContext context) : base(context)
    {
    }
}