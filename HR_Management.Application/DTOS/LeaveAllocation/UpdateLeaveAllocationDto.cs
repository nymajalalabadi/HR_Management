﻿using HR_Management.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOS.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }

        public int Priod { get; set; }
    }
}
