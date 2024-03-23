using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface ICustomerService
    {
        Task<AddCustomerResponse> AddCustomer(AddCustomerRequest request);
        Task<GetCustomersResponse> GetCustomers();
        Task<GetCustomerDetailResponse> GetCustomerDetail(Guid Id);
        Task<EditCustomerResponse> EditCustomer(Guid Id, EditCustomerRequest request);
        Task<DeleteCustomerResponse> DeleteCustomer(Guid Id);
    }

    public interface ICustomerRepository
    {
        Task<AddCustomerResponse> AddCustomerAsync(AddCustomerRequest request);
        Task<GetCustomersResponse> GetCustomersAsync();
        Task<GetCustomerDetailResponse> GetCustomerDetailAsync(Guid Id);
        Task<EditCustomerResponse> EditCustomerAsync(Guid Id, EditCustomerRequest request);
        Task<DeleteCustomerResponse> DeleteCustomerAsync(Guid Id);
    }
}
