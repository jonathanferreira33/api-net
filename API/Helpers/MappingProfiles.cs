using API.Models.DTOs;
using API.Models.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.Id));

            CreateMap<EmployeeRequestDTO, Employee>();


            CreateMap<Movement, MovementDTO>()
                .ForMember(dest => dest.MovimentNumber, opt => opt.MapFrom(src => src.Id));
            CreateMap<Movement, MovementDTO>().ReverseMap();


            CreateMap<ProductRequestDTO, Product>();

            CreateMap<EmployeePutDTO, Employee>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RegistrationNumber));

        }
    }
}
