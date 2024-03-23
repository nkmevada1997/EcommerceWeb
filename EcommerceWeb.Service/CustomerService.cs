using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
    {
        readonly ICustomerRepository _repository = repository;

        public async Task<AddCustomerResponse> AddCustomer(AddCustomerRequest request)
        {
            return await _repository.AddCustomerAsync(request);
        }

        public async Task<GetCustomersResponse> GetCustomers()
        {
            return await _repository.GetCustomersAsync();
        }

        public async Task<GetCustomerDetailResponse> GetCustomerDetail(Guid Id)
        {
            return await _repository.GetCustomerDetailAsync(Id);
        }

        public async Task<EditCustomerResponse> EditCustomer(Guid Id, EditCustomerRequest request)
        {
            return await _repository.EditCustomerAsync(Id, request);
        }

        public async Task<DeleteCustomerResponse> DeleteCustomer(Guid Id)
        {
            return await _repository.DeleteCustomerAsync(Id);
        }
    }
}
