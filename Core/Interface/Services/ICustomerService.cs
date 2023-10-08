using Core.WebModel.Response;

namespace Core.Interface.Services
{
    public interface ICustomerService
    {
        Task<CustomerResponse> GetCustomerAppUserInfoByAppUserId(string appUserId);
    }
}
