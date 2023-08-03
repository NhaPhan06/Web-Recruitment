using WebRecruitment.Application.IRepository.IGeneric;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.IRepository;

public interface IInterviewerRepository : IGenericRepository<Interviewer>
{
    Task<List<Interviewer>> GetAllInterviewers();
    Task<Interviewer> GetInterviewerById(Guid id);
    Task<List<Interviewer>> GetInterviewerByName(string name);
    Task<Interviewer> GetByAccountId(Guid id);
    Task<Interviewer> SetStatusInterviewer(Guid id);
}