using HR_Management.Application.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOS.LeaveRequest
{
    public class ChangeLeaveRequestApprovealDto : BaseDto
    {
        public bool? Aoorived { get; set; }

    }
}
