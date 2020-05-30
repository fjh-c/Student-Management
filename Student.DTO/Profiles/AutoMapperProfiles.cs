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
                .ForMember(d => d.DepartName, opt => opt.MapFrom(i => i.Depart.DepartName));
            CreateMap<StudentInfoDTO, StudentInfo>();

            CreateMap<Depart, DepartDTO>();
            CreateMap<DepartDTO, Depart>();

            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();
        }
    }
}
