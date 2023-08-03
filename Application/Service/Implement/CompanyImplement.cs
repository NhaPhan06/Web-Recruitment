using AutoMapper;
using WebRecruitment.Application.IRepository.IUnitOfWork;
using WebRecruitment.Application.IRepository;
using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.CompanyResponse;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace Application.Service.Implement;

public class CompanyImplement : CompanyService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyImplement(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ResponseOfCompany>> GetAllCompany()
    {
        var companies = _unitOfWork.Company.GetAll();
        if (companies is null)
        {
            throw new Exception("Companies list is empty");
        }

        var responseCompanies = _mapper.Map<List<ResponseOfCompany>>(companies);

        // Populate the account-related attributes for each company
        foreach (var company in responseCompanies)
        {
            var account = _unitOfWork.Account.GetById(company.AccountId);

            if (account is not null)
            {
                company.FirstName = account.FirstName;
                company.LastName = account.LastName;
                company.Username = account.Username;
                company.Birthday = account.Birthday;
                company.Email = account.Email;
                company.Address = account.Address;
            }
        }

        return responseCompanies;
    }


    public async Task<ResponseOfCompany> UdpateCompanyInfor(Guid companyId, UpdateRequestCompany updateRequest)
    {
        var company =  _unitOfWork.Company.GetById(companyId);

        // Check if the Company object is null
        if (company is null)
        {
            throw new Exception("Company not found");
        }

        // Update the properties of the company object with values from updateRequest
        company.Description = updateRequest.Description;
        company.Size = updateRequest.Size;
        company.FoundingYear = updateRequest.FoundingYear;
        company.Logo = updateRequest.Logo;
        company.Benefits = updateRequest.Benefits;
        company.Industry = updateRequest.Industry;
        company.Website = updateRequest.Website;
        company.ContactNumber = updateRequest.ContactNumber;
        company.NameCompany = updateRequest.NameCompany;

        // Update the company in the database
        _unitOfWork.Company.Update(company);
        _unitOfWork.Save();

        // Return the updated company information
        return _mapper.Map<ResponseOfCompany>(company);
    }
}