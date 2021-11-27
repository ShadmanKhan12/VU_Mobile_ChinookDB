using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.Interfaces;
using VUMobileTest.Models;
using VUMobileTest.ViewModels;

namespace VUMobileTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private chinookContext db;

        public EmployeeService(chinookContext db)
        {
            this.db = db;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            if (db != null)
            {
                List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

                var result = from o in db.Employees
                             orderby o.FirstName ascending, o.LastName ascending
                             select o;

                foreach (var r in result)
                {
                    EmployeeViewModel employee = new EmployeeViewModel();
                    employee.EmployeeId = r.EmployeeId;
                    employee.FirstName = r.FirstName;
                    employee.LastName = r.LastName;
                    employee.Phone = r.Phone;
                    employee.Email = r.Email;

                    employees.Add(employee);
                }

                return employees;
            }

            return null;
        }
    }
}
