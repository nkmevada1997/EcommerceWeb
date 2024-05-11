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
        }
    }

    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }

    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }

    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>().ReverseMap();
        }
    }

    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>().ReverseMap();
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
