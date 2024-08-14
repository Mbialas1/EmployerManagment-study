using EmployerManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManagment.Domain.Services
{
    public interface IEmployeeRepository
    {
        Task<long> AddNewEmployee(Employee employee);
    }
}
