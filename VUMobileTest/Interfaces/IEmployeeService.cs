using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.ViewModels;

namespace VUMobileTest.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetEmployees();
    }
}
