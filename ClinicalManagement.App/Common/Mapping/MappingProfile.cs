using AutoMapper;
using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using ClinicalManagement.Application.Dtos.UserDtos.Queries;
using ClinicalManagement.Application.User.Commands;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>();

            CreateMap<CreatePatient, Patient>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.NationalId));


            CreateMap<CreateAdmin, Admin>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.NationalId));


            CreateMap<CreateDoctor, Doctor>()
               /*.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
               .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization))
               .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization))
               .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.NationalId))*/;

        }
    }
}
