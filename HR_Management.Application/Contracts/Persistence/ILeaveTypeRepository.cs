using HR_Management_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
    {
    }
}
