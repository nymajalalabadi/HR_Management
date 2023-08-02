using AutoMapper;
using HR_Management.Application.DTOS;
using HR_Management.Application.DTOS.LeaveRequest;
using HR_Management_Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<LeaveType , LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        }
    }
}
