using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Repository.Models;
using System.Linq;

namespace EcommerceWeb.API.Mapper
{

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, AddCityRequest>().ReverseMap();
            CreateMap<City, EditCityRequest>().ReverseMap();
        }
    }

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, AddCountryRequest>().ReverseMap();
            CreateMap<Country, EditCountryRequest>().ReverseMap();
        }
    }

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, AddCustomerRequest>().ReverseMap();
            CreateMap<Customer, EditCustomerRequest>().ReverseMap();
        }
    }

    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<State, AddStateRequest>().ReverseMap();
            CreateMap<State, EditStateRequest>().ReverseMap();
        }
    }

    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<Supplier, AddSupplierRequest>().ReverseMap();
            CreateMap<Supplier, EditSupplierRequest>().ReverseMap();
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
