using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Generic.Repository;

namespace WebRecruitment.Infrastructures.Repository;

public class EventRepository : GenericRepository<Event>, IEventRepository
{

    public EventRepository(RecruitmentDbContext context) : base(context)
    {
    }
}