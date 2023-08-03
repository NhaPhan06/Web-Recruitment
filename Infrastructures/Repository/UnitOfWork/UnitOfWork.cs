using AutoMapper;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Repository;

namespace WebRecruitment.Infrastructures.UnitOfwork.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RecruitmentDbContext _context;
    private IUnitOfWork _unitOfWorkImplementation;

    public UnitOfWork(RecruitmentDbContext context)
    {
        // ReSharper disable once RedundantAssignment
        _context = context;
        Account = new AccountRepository(_context);
        Admin = new AdminRepository(_context);
        Candidate = new CandidateRepository(_context);
        Company = new CompanyRepository(_context);
        Cv = new CvRepository(_context);
        Event = new EventRepository(_context);
        Hr = new HrRepository(_context);
        Interviewer = new InterviewerRepository(_context);
        Job = new JobRepository(_context);
        Meeting = new MeetingRepository(_context);
        Operation = new OperationRepository(_context);
        Position = new PositionRepository(_context);
        Post = new PostRepository(_context);
    }

    public IAccountRepository Account { get; }
    public IAdminRepository Admin { get; }
    public ICandidateRepository Candidate { get; }
    public ICompanyRepository Company { get; }
    public ICVRepository Cv { get; }
    public IEventRepository Event { get; }
    public IHrRepository Hr { get; }
    public IInterviewerRepository Interviewer { get; }
    public IJobRepository Job { get; }
    public IMeetingRepository Meeting { get; }
    public IOperationRepository Operation { get; }
    public IPositionRepository Position { get; }
    public IPostRepository Post { get; }

    public void Save()
    {
        _context.SaveChanges();
    }
}