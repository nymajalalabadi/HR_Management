using HR_Management.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOS
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Priod { get; set; }
    }
}
