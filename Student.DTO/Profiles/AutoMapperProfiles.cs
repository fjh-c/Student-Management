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
            CreateMap<StudentInfo, StudentInfoQuery>()
                .ForMember(d => d.DepartName, opt => opt.MapFrom(i => i.Depart.DepartName));
            CreateMap<StudentInfoQuery, StudentInfo>();
        }
    }
}
