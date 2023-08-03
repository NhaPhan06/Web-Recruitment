using System.Security.Cryptography;
using Application.Helpers;
using Application.Model.Request;
using AutoMapper;
using Domain.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using WebRecruitment.Application.Authentication;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.Model.Request.AccountRequest;
using WebRecruitment.Application.Model.Request.HrRequest;
using WebRecruitment.Application.Model.Request.InterviewerRequest;
using WebRecruitment.Application.Model.Response.AccountResponse;
using WebRecruitment.Domain.Entity;
using WebRecruitment.Domain.Enums.Role;
using WebRecruitment.Domain.Enums.Status;

namespace Application.Service.Implement;

public class AuthenticationImplement : AuthenticationService
{
    private readonly IAccountRepository _accountRepository;
    private readonly AppConfiguration _appConfiguration;
    private readonly IAuthentication _authentication;
    private readonly IMailService _mailService;
    private readonly ICacheManager _cacheManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHrRepository _hrRepository;
    private readonly IInterviewerRepository _interviewerRepository;

    public AuthenticationImplement(IAccountRepository accountRepository, IAuthentication authentication,
        IUnitOfWork unitOfWork, IMapper mapper, AppConfiguration appConfiguration, ICacheManager cacheManager,
        IMailService mailService, IInterviewerRepository interviewerRepository, IHrRepository hrRepository)
    {
        _hrRepository = hrRepository;
        _interviewerRepository = interviewerRepository;
        _accountRepository = accountRepository;
        _authentication = authentication;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _appConfiguration = appConfiguration;
        _cacheManager = cacheManager;
        _mailService = mailService;
    }

    public async Task<LoginRespone> Validate(RequestLogin accountLogin)
    {
        
        //check account has Exist or not
        var Account = await _accountRepository.GetAccount(accountLogin.UserName);
        var response = new LoginRespone();
        if (Account == null)
        {
            response.Success = false;
            response.Messenger = "Username Not Exist";
            return response;
        }

        var result = _authentication.Verify(Account.HashPassword, accountLogin.Password);
        if (!result)
        {
            response.Success = false;
            response.Messenger = "Invalid Password";
            return response;
        }

        var check = await _cacheManager.Get<bool>(Account.Accountid.ToString());
        if (check)
        {
            response.Success = false;
            response.Messenger = "This Account has Login";
            return response;
        }

        string role = Account.Role;
        if (role.Equals(ROLEACCOUNT.COMPANY.ToString()))
        {
            if (_hrRepository.GetByAccountId(Account.Accountid) != null)
            {
                role = RolePosition.HR.ToString();
            }
            else if (_interviewerRepository.GetByAccountId(Account.Accountid) != null)
            {
                role = RolePosition.INTERVIEWER.ToString();
            }
        }

        _cacheManager.Set(Account.Accountid.ToString(), true, 60);
        response.Data = _authentication.GenerateToken(Account, _appConfiguration.JWTSecretKey, role);
        response.Success = true;
        response.Messenger = "Login Success";
        return response;
    }
    
    public async Task<Boolean> Logout(Guid AccountId)
    {
        try
        {
            _cacheManager.Remove(AccountId.ToString());
        }
        catch (Exception e)
        {
            throw e;
        }
        return true;
    }

    public async Task<ResponseAccountAdmin> CreateAccountAdmin(RequestAccountToAdmin requestAccountToAdmin)
    {
        var isExist = await _accountRepository.GetAccount(requestAccountToAdmin.Username);
        if (isExist != null) new Exception("Username already use ! ");
        
        var admin = _mapper.Map<Admin>(requestAccountToAdmin);
        //set
        var passwordHash = _authentication.Hash(requestAccountToAdmin.HashPassword);
        admin.Account.HashPassword = passwordHash;
        string phone = "84" + requestAccountToAdmin.Phone;
        admin.Account.Phone = phone;
        if (requestAccountToAdmin.Equals("female"))
        {
            admin.Account.Gender = Gender.Female.ToString();
        }
        else if(requestAccountToAdmin.Equals("male"))
        {
            admin.Account.Gender = Gender.Male.ToString();
        }

        //
        _unitOfWork.Admin.Add(admin);
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountAdmin>(admin);
    }

    public async Task<ResponseAccountCandidate> CreateAccountCandidate(
        RequestAccountToCadidate requestAccountToCandidate)
    {
        var isExist = await _accountRepository.GetAccount(requestAccountToCandidate.Username);
        if (isExist != null) new Exception("Username already use ! ");

        var candidate = _mapper.Map<Candidate>(requestAccountToCandidate);
        //set
        var passwordHash = _authentication.Hash(requestAccountToCandidate.HashPassword);
        candidate.Account.HashPassword = passwordHash;
        string phone = "84" + requestAccountToCandidate.Phone;
        candidate.Account.Phone = phone;
        
        if (requestAccountToCandidate.Equals("female"))
        {
            candidate.Account.Gender = Gender.Female.ToString();
        }
        else if(requestAccountToCandidate.Equals("male"))
        {
            candidate.Account.Gender = Gender.Male.ToString();
        }
        
        //
        _unitOfWork.Candidate.Add(candidate);
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountCandidate>(candidate);
    }

    public async Task<ResponseAccountCompany> CreateAccountCompany(RequestAccountToCompany requestAccountToCompany)
    {
        var isExist = await _accountRepository.GetAccount(requestAccountToCompany.Username);
        if (isExist != null) new Exception("Username already use ! ");

        string Contacnumber = "84" + requestAccountToCompany.Phone;
        requestAccountToCompany.ContactNumber = Contacnumber;
        
        var company = _mapper.Map<Company>(requestAccountToCompany);
        //set
        var passwordHash = _authentication.Hash(requestAccountToCompany.HashPassword);
        company.Account.HashPassword = passwordHash;
        company.Status = CompanyEnum.ACTIVE.ToString();
        string phone = "84" + requestAccountToCompany.Phone;
        company.Account.Gender = Gender.Company.ToString();
        company.Account.Phone = phone;
        //
        _unitOfWork.Company.Add(company);
        _unitOfWork.Save();
        return _mapper.Map<ResponseAccountCompany>(company);
    }

    public async Task<ResponseAccountHr> CreateAccountHr(RequestAccountToHr requestAccountToHr)
    {
        var isExist = await _accountRepository.GetAccount(requestAccountToHr.Username);
        if (isExist != null) new Exception("Username already use ! ");

        var hr = _mapper.Map<Hr>(requestAccountToHr);

        //set
        var passwordHash = _authentication.Hash(requestAccountToHr.HashPassword);
        hr.Account.HashPassword = passwordHash;
        hr.Status = HrEnum.ACTIVE.ToString();
        string phone = "84" + requestAccountToHr.Phone;
        hr.Account.Phone = phone;
        if (requestAccountToHr.Equals("female"))
        {
            hr.Account.Gender = Gender.Female.ToString();
        }
        else if(requestAccountToHr.Equals("male"))
        {
            hr.Account.Gender = Gender.Male.ToString();
        }
        _unitOfWork.Hr.Add(hr);
        _unitOfWork.Save();

        return _mapper.Map<ResponseAccountHr>(hr);
    }

    public async Task<ResponseAccountInterviewer> CreateAccountInterviewer(
        RequestAccountToInterviewer requestAccountToInterviewer)
    {
        var isExist = await _accountRepository.GetAccount(requestAccountToInterviewer.Username);
        if (isExist != null) new Exception("Username already use ! ");

        var interviewer = _mapper.Map<Interviewer>(requestAccountToInterviewer);

        //set
        var passwordHash = _authentication.Hash(requestAccountToInterviewer.HashPassword);
        interviewer.Account.HashPassword = passwordHash;
        interviewer.Status = InterviewerEnum.ACTIVE.ToString();
        string phone = "84" + requestAccountToInterviewer.Phone;
        interviewer.Account.Phone = phone;
        if (requestAccountToInterviewer.Equals("female"))
        {
            interviewer.Account.Gender = Gender.Female.ToString();
        }
        else if(requestAccountToInterviewer.Equals("male"))
        {
            interviewer.Account.Gender = Gender.Male.ToString();
        }
        
        _unitOfWork.Interviewer.Add(interviewer);
        _unitOfWork.Save();

        return _mapper.Map<ResponseAccountInterviewer>(interviewer);
    }

    public async Task<bool> ForgetPassword(string email)
    {
        var account = await _accountRepository.GetAccountByEmail(email);
        if (account != null)
        {
            Random random = new Random();
            var resetToken = random.Next(11111, 999999).ToString();
            _cacheManager.Set(email, resetToken, 5);
            Mail sendMail = new Mail()
            {
                To = email,
                Subject = "Reset Token Form WebRecruitment",
                Body = "Your Reset Token is '" + resetToken + " '. This Token has exiset in 5 minute"
            };
            _mailService.SendEmail(sendMail);
            return true;
        }

        return false;
    }

    public async Task<bool> ResetPassword(string email, string password, string resetToken)
    {
        var tokenCache = await _cacheManager.Get<string>(email);
        var account = await _accountRepository.GetAccountByEmail(email);
        if (tokenCache == null)
        {
            throw new NotFoundException("Your Reset Token has expired");
        }
        if (tokenCache.Equals(resetToken))
        {
            account.HashPassword = _authentication.Hash(password);
            _unitOfWork.Save();
            return true;
        }
        return false;
    }
}