using System.Net;
using WebRecruitment.Application.Model.Response.AccountResponse;

namespace WebRecruitment.Application.Model.Response;

public class MessageResponse
{
    public MessageResponse()
    {
    }

    public MessageResponse(HttpStatusCode httpStatusCode, string? message, string data)
    {
        this.httpStatusCode = httpStatusCode;
        this.message = message;
        this.data = data;
    }

    public MessageResponse(HttpStatusCode httpStatusCode, string message, List<object> list)
    {
        this.httpStatusCode = httpStatusCode;
        this.message = message;
        this.list = list;
    }

    public HttpStatusCode httpStatusCode { get; set; }
    public string? message { get; set; }
    public string data { get; set; }
    public List<object> list { get; set; }
    public ResponseAllAccount responseAllAccount { get; set; }
    public List<ResponseAllAccount> listResponseAllAccount { get; set; }
}