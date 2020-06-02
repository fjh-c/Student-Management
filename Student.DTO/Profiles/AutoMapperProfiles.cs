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

            CreateMap<Account, AccountDTO>()
                .ForMember(d => d.PassWord, opt => opt.MapFrom(i => "密码保密"));
            CreateMap<AccountDTO, Account>()
                .ForMember(d => d.PassWord, opt => opt.MapFrom(i => $"{i.UserName}_{i.PassWord}".ToMd5Hash()));
        }
    }
}
