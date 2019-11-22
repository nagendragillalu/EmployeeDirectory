using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Authorization;
using EmployeeDirectoryAPI.Entities;
using EmployeeDirectoryAPI.Models;
using EmployeeDirectoryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectoryAPI.Controllers
{
    [Route("api/employee")]
    public class EmployeeListController : Controller
    {

        private readonly ILogger<EmployeeListController> _logger;
        private IEmployeeRepository empRepository;
        GoogleAuthorization googleAuth = new GoogleAuthorization();
        public EmployeeListController(IEmployeeRepository _empRepository, ILogger<EmployeeListController> logger)
        {
            _logger = logger;
            empRepository = _empRepository;
        }

        /*
         *Return all the Employee with all the data 
         */
        [HttpGet()]
        public IActionResult GetEmployee([FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                List<EmployeeDto> reponseEmp = (List<EmployeeDto>)empRepository.GetAllEmployees();
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    if (reponseEmp == null)
                    {
                        return Ok("No Employee Details found");
                    }
                    else
                    {
                        _logger.LogInformation("All the Employee data is returned");
                        return Ok(reponseEmp);
                     }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }


        /* 
         * Return the Complete employee details for a given employee ID
         */
        [HttpGet("{empID}")]
        public IActionResult GetEmployee(int empID,
                [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var employee = empRepository.EmployeeDetails(empID);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(employee);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("department")]
        public IActionResult GetAllDepartment([FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var allDepartments = empRepository.GetAllDepartment();
                    return Ok(allDepartments);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }
        /*
         *Get the given Department details along with all 
         * the Employees in a given Depaertment ID
         */
        [HttpGet("department/{deptId}")]
        public IActionResult GetDepartmentDetails(int deptId, [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var DepartDetails = empRepository.DepartmentDetail(deptId);
                    return Ok(DepartDetails);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }

        }

        /*
         * This method will return all the existing teams in the DB 
         */
        [HttpGet("team")]
        public IActionResult GetAllTeams([FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var allteams = empRepository.GetAllTeams();
                    return Ok(allteams);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }

        /*
         * This method will return the Team details for the given Team Id
         * also will provide the list of the emkployess belonging given team
         */
        [HttpGet("team/{teamId}")]
        public IActionResult TeamEmployeeDetails(int teamId,
                [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var TeamEmployees = empRepository.TeamEmployeeDetails(teamId);
                    return Ok(TeamEmployees);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }

        // Http Get method to get all the skills of the employee with given ID
        [HttpGet("{empId}/skills")]
        public IActionResult GetEmployeeSkills(int empId,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            if (googleAuth.ProcessRequestAtGoogle(googleToken))
            {
                var employee = "";// EmployeeDataStore.Current.Employees.FirstOrDefault(e => e.EmployeeId == empId);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpGet("{empId}/skills/{skillId}")]
        public IActionResult GetEmployeeSkill(int empId, int skillId, 
            [FromHeader(Name = "id_token")]string googleToken)
        {
            if (googleAuth.ProcessRequestAtGoogle(googleToken))
            {
                var employee = "";//EmployeeDataStore.Current.Employees.FirstOrDefault(e => e.EmployeeId == empId);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }

        /*
         * This Get Method will return list of available roles which for admin menu  while adding new employee
         */
        [HttpGet("getroles")]
        public IActionResult GetRolesList([FromHeader(Name = "id_token")]string googleToken)
        {
            try {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var roleList = empRepository.GetRoles();
                    return Ok(roleList);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }


        /*
         * This Get Method will return list of available Skills which for admin menu  while adding new employee
         */
        [HttpGet("allskills")]
        public IActionResult GetAllSkills([FromHeader(Name = "id_token")]string googleToken)
        {
            try{
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var skillList = empRepository.GetAllSkills();
                    return Ok(skillList);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }


        /*
         * This Http post method will take Employee data from Request body and call the AddEmployee method from Employee Repository
         */

        [HttpPost("add")]
        public IActionResult AddNewEmployee([FromBody] EmployeeDto newEmployee,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var employeeAddStatus = empRepository.AddEmployee(newEmployee);
                    return Ok(Json(employeeAddStatus));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception exp) {
                return NotFound(@"Can't add the given Employee");
            }
        }

        /*
         * This will add new Team to the records
         */ 
        [HttpPost("addTeam")]
        public IActionResult AddNewTeam([FromBody] TeamDetailDto newTeam,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var TeamAddStatus = empRepository.AddTeam(newTeam);
                    return Ok(Json(TeamAddStatus));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"Can't add the given Team");
            }
        }


        /*
         * This will add new Department to the records
         */
        [HttpPost("addDepartment")]
        public IActionResult AddNewDepartment([FromBody] DepartmentEmployeeDetailsDto newDepartment,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var DepartAddStatus = empRepository.AddDepartment(newDepartment);
                    return Ok(Json(DepartAddStatus));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"Can't add the given Department");
            }
        }

        /*
         * This will add new Role to the records
         */
        [HttpPost("addRole")]
        public IActionResult AddNewRole([FromBody] RolesDto newRole,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var RoleAddStatus = empRepository.AddRole(newRole);
                    return Ok(Json(RoleAddStatus));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"Can't add the given Department");
            }
        }


        /*
         * This will add new Skill to the records
         */
        [HttpPost("addSkill")]
        public IActionResult AddNewSkill([FromBody] SkillDto newSkill,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var SkillAddStatus = empRepository.AddSkill(newSkill);
                    return Ok(Json(SkillAddStatus));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"Can't add the given Department");
            }
        }



        /*
         * This method will fetch all the Employees with Given Skills
         */
        [HttpGet("skilledEmployee/{skillId}")]
        public IActionResult SkillEmployee(int skillId,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var SkilledEmployee = empRepository.GetSkilledEmployee(skillId);
                    return Ok(SkilledEmployee);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"No Employee with Given Skills");
            }
        }

        /*
         * This method will fetch all the SPOC list from DB
         */
        [HttpGet("getspoc")]
        public IActionResult GetSpoc([FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var spocList = empRepository.GetSPOC();
                    return Ok(spocList);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(@"No Employee with Given Skills");
            }
        }

    }
}
