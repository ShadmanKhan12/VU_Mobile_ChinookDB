using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VUMobileTest.Interfaces;

namespace VUMobileTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }

        [HttpGet]
        [Route("api/employees")]
        public IActionResult GetEmployess()
        {
            try
            {
                var messages = EmployeeService.GetEmployees();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
