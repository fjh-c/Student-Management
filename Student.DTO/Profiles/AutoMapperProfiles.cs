using AutoMapper;
using Student.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DTO.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StudentInfo, StudentInfoDTO>()
                .ForMember(d => d.DepartName, opt => opt.MapFrom(i => i.Depart.DepartName))
                .ForMember(d => d.EnrollmentDT, opt => opt.MapFrom(i => i.EnrollmentDT.ToDate()))
                //使用ProjectTo转DTO,enum不能隐式转int类型，需要映射
                .ForMember(d => d.Gender, opt => opt.MapFrom(i => (int)i.Gender))
                .ForMember(d => d.Nation, opt => opt.MapFrom(i => (int)i.Nation))
                .ForMember(d => d.Status, opt => opt.MapFrom(i => (int)i.Status));
            CreateMap<StudentInfoDTO, StudentInfo>();
        }
    }
}
