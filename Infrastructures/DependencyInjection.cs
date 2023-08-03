using System.Text.Json.Serialization;
using Application.Helpers;
using Application.Service;
using Application.Service.Implement;
using Azure.Storage.Blobs;
using MailKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebRecruitment.Application.Authentication;
using WebRecruitment.Application.Authentication.Implement;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Infrastructure;
using WebRecruitment.Infrastructures.Mapper;
using WebRecruitment.Infrastructures.Repository;
using WebRecruitment.Infrastructures.UnitOfwork.Repository;
using IMailService = Application.Helpers.IMailService;
using MailService = Application.Helpers.Mail.MailService;

namespace WebRecruitment.Infrastructures;

public static class DependencyInjection
{
    public static IServiceCollection InfrastructuresConfiguration(this IServiceCollection services,
        string connectionString, IConfiguration configuration, string azure)
    {
        //Add Database
        services.AddDbContext<RecruitmentDbContext>(options => { options.UseSqlServer(connectionString); });

        //Add DI Container
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAuthentication, Authentication>();
        services.AddTransient<AuthenticationService, AuthenticationImplement>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<AccountService, AccountImplement>();
        services.AddTransient<IAdminRepository, AdminRepository>();
        services.AddTransient<AdminService, AdminImplement>();
        services.AddTransient<ICandidateRepository, CandidateRepository>();
        services.AddTransient<CandidateService, CandidateImplement>();
        services.AddTransient<ICompanyRepository, CompanyRepository>();
        services.AddTransient<CompanyService, CompanyImplement>();
        services.AddTransient<ICVRepository, CvRepository>();
        services.AddTransient<CVService, CVImplement>();
        services.AddTransient<IHrRepository, HrRepository>();
        services.AddTransient<HrService, HrImplement>();
        services.AddTransient<IInterviewerRepository, InterviewerRepository>();
        services.AddTransient<InterviewerService, InterviewerImplement>();
        services.AddTransient<IJobRepository, JobRepository>();
        services.AddTransient<JobService, JobImplement>();
        services.AddTransient<IMeetingRepository, MeetingRepository>();
        services.AddTransient<MeetingService, MeetingImplement>();
        services.AddTransient<IOperationRepository, OperationRepository>();
        services.AddTransient<OperationService, OperationImplement>();
        services.AddTransient<IPositionRepository, PositionRepository>();
        services.AddTransient<PositionService, PositionImplement>();
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<PostService, PostImplement>();
        services.AddTransient<IMailService, MailService>();
        services.AddTransient<ICacheManager, CacheManager>();

        services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        
        services.AddScoped(_ => {
            return new BlobServiceClient(azure);
        });
        //AUTOMAPPER
        services.AddAutoMapper(typeof(ApplicationMapper).Assembly);

        return services;
    }
}