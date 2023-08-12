using AutoMapper;
using HR_Management.Application.DTOS.LeaveAllocation;
using HR_Management.Application.DTOS.LeaveRequest;
using HR_Management.Application.DTOS.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
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
            #region leave trpe

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();

            #endregion

            #region leave request

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestsDto>().ReverseMap();

            #endregion

            #region leave allocation

            CreateMap<LeaveAllocation, UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

            #endregion
        }
    }
}
