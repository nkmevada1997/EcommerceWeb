using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using EcommerceWeb.Utility.Encode;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class CustomerRepository(ApplicationDbContext dbContext, IMapper mapper) : ICustomerRepository
    {
        readonly ApplicationDbContext _dbContext = dbContext;
        readonly IMapper _mapper = mapper;

        public async Task<AddCustomerResponse> AddCustomerAsync(AddCustomerRequest request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request);
                customer.Password = EncodeBase.EncodeBase64(request.Password);
                customer.Id = Guid.NewGuid();
                customer.CreatedBy = Guid.NewGuid();

                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();

                return new AddCustomerResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "Customer Added",
                };
            }
            catch (Exception ex)
            {
                return new AddCustomerResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable To Add Customer",
                    ExceptionMessage = ex.ToString()
                };
            }
        }

        public async Task<GetCustomersResponse> GetCustomersAsync()
        {
            try
            {
                var customers = await _dbContext.Customers.Where(x => x.IsActive).ToListAsync();

                if (customers != null && customers.Count != 0)
                {
                    var result = new List<CustomerDTO>();

                    foreach (var customer in customers)
                    {
                        result.Add(_mapper.Map<CustomerDTO>(customer));
                    }

                    return new GetCustomersResponse
                    {
                        IsError = false,
                        Result = result,
                        Message = "Customers Data Retreive Successfully",
                    };
                }

                return new GetCustomersResponse
                {
                    IsError = false,
                    Result = [],
                    Message = "Records Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCustomersResponse
                {
                    IsError = true,
                    Result = [],
                    Message = "Unable To Retreive Customers",
                    ExceptionMessage = ex.Message
                };
            }

        }

        public async Task<GetCustomerDetailResponse> GetCustomerDetailAsync(Guid Id)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (customer != null)
                {
                    return new GetCustomerDetailResponse
                    {
                        IsError = false,
                        Result = _mapper.Map<CustomerDTO>(customer),
                        Message = "Customer Data is Retrieved",
                    };
                }

                return new GetCustomerDetailResponse
                {
                    IsError = false,
                    Message = "Record is Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCustomerDetailResponse
                {
                    IsError = false,
                    Message = "Unable To Retreive Customers",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<EditCustomerResponse> EditCustomerAsync(Guid Id, EditCustomerRequest request)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);
                if (customer != null)
                {
                    customer = _mapper.Map<Customer>(request);
                    customer.UpdatedDate = DateTime.UtcNow;

                    await _dbContext.SaveChangesAsync();

                    return new EditCustomerResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Customer Updated",
                    };
                }
                return new EditCustomerResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Customer Not Found",
                };
            }
            catch (Exception ex)
            {
                return new EditCustomerResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Unable to Update Customer",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<DeleteCustomerResponse> DeleteCustomerAsync(Guid Id)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);
                if (customer != null)
                {
                    customer.IsActive = false;
                    customer.UpdatedDate = DateTime.UtcNow;

                    await _dbContext.SaveChangesAsync();

                    return new DeleteCustomerResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Customer Deleted",
                    };
                }
                return new DeleteCustomerResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Customer Not Found",
                };
            }
            catch (Exception ex)
            {
                return new DeleteCustomerResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Delete Record",
                    ExceptionMessage = ex.Message
                };
            }

        }
    }
}
