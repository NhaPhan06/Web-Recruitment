namespace WebRecruitment.Application.IRepository.IUnitOfWork;

public interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IAdminRepository Admin { get; }
    ICandidateRepository Candidate { get; }
    ICompanyRepository Company { get; }
    ICVRepository Cv { get; }
    IEventRepository Event { get; }
    IHrRepository Hr { get; }
    IInterviewerRepository Interviewer { get; }
    IJobRepository Job { get; }
    IMeetingRepository Meeting { get; }
    IOperationRepository Operation { get; }
    IPositionRepository Position { get; }
    IPostRepository Post { get; }

    void Save();
}