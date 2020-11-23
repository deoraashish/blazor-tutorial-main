using AutoMapper;
using EmployeeManagementModels;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeEditModel>()
                .ForMember(dest => dest.ConfirmEmail,
                            opt => opt.MapFrom(src => src.Email));
            CreateMap<EmployeeEditModel, Employee>();
        }
    }
}
