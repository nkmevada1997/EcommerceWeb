using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class SupplierService(ISupplierRepository repository) : ISupplierService
    {
        private readonly ISupplierRepository _repository = repository;

        public async Task<AddSupplierResponse> AddSupplier(AddSupplierRequest request)
        {
            return await _repository.AddSupplierAsync(request);
        }

        public async Task<GetSuppliersResponse> GetSuppliers()
        {
            return await _repository.GetSuppliersAsync();
        }

        public async Task<GetSupplierDetailResponse> GetSupplierDetail(Guid Id)
        {
            return await _repository.GetSupplierDetailAsync(Id);
        }

        public async Task<EditSupplierResponse> EditSupplier(Guid Id, EditSupplierRequest request)
        {
            return await _repository.EditSupplierAsync(Id, request);
        }

        public async Task<DeleteSupplierResponse> DeleteSupplier(Guid Id)
        {
            return await _repository.DeleteSupplierAsync(Id);
        }
    }
}
