using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using EcommerceWeb.Utility.Encode;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class SupplierRepository(IMapper mapper, ApplicationDbContext context) : ISupplierRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly ApplicationDbContext _context = context;

        public async Task<AddSupplierResponse> AddSupplierAsync(AddSupplierRequest request)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(request);
                supplier.Id = Guid.NewGuid();
                supplier.CreatedDate = DateTime.UtcNow;
                supplier.Password = EncodeBase.EncodeBase64(request.Password);

                await _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();

                return new AddSupplierResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "Supplier Added",
                    ExceptionMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new AddSupplierResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Add Supplier",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<GetSuppliersResponse> GetSuppliersAsync()
        {
            try
            {
                var suppliers = await _context.Suppliers.Where(x => x.IsActive).ToListAsync();

                if (suppliers != null && suppliers.Count != 0)
                {
                    var result = new List<SupplierDTO>();

                    foreach (var supplier in suppliers)
                    {
                        result.Add(_mapper.Map<SupplierDTO>(supplier));
                    }

                    return new GetSuppliersResponse
                    {
                        IsError = false,
                        Result = result,
                        Message = "Record Retrieve",
                    };
                }

                return new GetSuppliersResponse
                {
                    IsError = false,
                    Result = [],
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetSuppliersResponse
                {
                    IsError = true,
                    Message = "Unable to Get Data",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<GetSupplierDetailResponse> GetSupplierDetailAsync(Guid Id)
        {
            try
            {
                var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (supplier != null)
                {
                    return new GetSupplierDetailResponse
                    {
                        IsError = false,
                        Result = _mapper.Map<SupplierDTO>(supplier),
                        Message = "Record Retrieve",
                    };
                }

                return new GetSupplierDetailResponse
                {
                    IsError = false,
                    Result = null,
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetSupplierDetailResponse
                {
                    IsError = true,
                    Result = null,
                    Message = "Unable to Fetch Data",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<EditSupplierResponse> EditSupplierAsync(Guid Id, EditSupplierRequest request)
        {
            try
            {
                var suppliers = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (suppliers != null)
                {
                    suppliers = _mapper.Map<Supplier>(request);
                    suppliers.UpdatedBy = Guid.Empty;
                    suppliers.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new EditSupplierResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Supplier Updated",
                        ExceptionMessage = string.Empty
                    };
                }

                return new EditSupplierResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ExceptionMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new EditSupplierResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<DeleteSupplierResponse> DeleteSupplierAsync(Guid Id)
        {
            try
            {
                var supplier = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (supplier != null)
                {
                    supplier.IsActive = false;
                    await _context.SaveChangesAsync();

                    return new DeleteSupplierResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Supplier Deleted",
                        ExceptionMessage = string.Empty
                    };
                }

                return new DeleteSupplierResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ExceptionMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DeleteSupplierResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}
