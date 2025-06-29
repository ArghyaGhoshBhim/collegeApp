using AutoMapper;
using collegeApp.Model;

namespace collegeApp.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            /*CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();*/

            //CreateMap<StudentDTO, Student>().ReverseMap();

            /*CreateMap<StudentDTO, Student>().ReverseMap()
                .ForMember(n=>n.Name, opt=>opt.MapFrom(x=>x.StudentName));*/

            /*CreateMap<StudentDTO, Student>().ReverseMap()
                .ForMember(n => n.StudentName, opt => opt.Ignore());*/


            /*CreateMap<StudentDTO, Student>().ReverseMap()
                .AddTransform<string>(n => string.IsNullOrEmpty(n) ? "No data Found" : n);*/

            CreateMap<StudentDTO, Student>().ReverseMap()
                .ForMember(n => n.Address, opt => opt.MapFrom(n => string.IsNullOrEmpty(n.Address) ? "No Address Found" : n.Address));


        }
    }
}
