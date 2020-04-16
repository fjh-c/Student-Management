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
            CreateMap<StudentInfo, StudentInfoDTO>().ForMember(d => d.Sex, opt => opt.MapFrom(i => i.Sex == 1 ? "男" : "女"));
            CreateMap<StudentInfoDTO, StudentInfo>();
        }
    }
}
