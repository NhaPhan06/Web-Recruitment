using WebRecruitment.Application.Model.Request.CompanyRequest;
using WebRecruitment.Application.Model.Response.CompanyResponse;

namespace Application.Service;

public interface CompanyService
{
    Task<List<ResponseOfCompany>> GetAllCompany();
    Task<ResponseOfCompany> UdpateCompanyInfor(Guid companyId, UpdateRequestCompany updateRequest);
}