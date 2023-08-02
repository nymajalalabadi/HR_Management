using HR_Management.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOS.LeaveType
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }

        public int DefaultDay { get; set; }
    }
}
