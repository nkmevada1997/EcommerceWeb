using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface ISupplierService
    {
        Task<AddSupplierResponse> AddSupplier(AddSupplierRequest request);
        Task<GetSuppliersResponse> GetSuppliers();
        Task<GetSupplierDetailResponse> GetSupplierDetail(Guid Id);
        Task<EditSupplierResponse> EditSupplier(Guid Id, EditSupplierRequest request);
        Task<DeleteSupplierResponse> DeleteSupplier(Guid Id);
    }

    public interface ISupplierRepository
    {
        Task<AddSupplierResponse> AddSupplierAsync(AddSupplierRequest request);
        Task<GetSuppliersResponse> GetSuppliersAsync();
        Task<GetSupplierDetailResponse> GetSupplierDetailAsync(Guid Id);
        Task<EditSupplierResponse> EditSupplierAsync(Guid Id, EditSupplierRequest request);
        Task<DeleteSupplierResponse> DeleteSupplierAsync(Guid Id);
    }
}
