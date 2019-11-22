using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDto EmployeeDetails(int emplId);

        int AddEmployee(EmployeeDto newEmployee);

        IEnumerable<TeamDetailDto> GetAllTeams();

        TeamEmployeeDto TeamEmployeeDetails(int teamID);

        int AddTeam (TeamDetailDto newTeam);

        IEnumerable<DepartmentDetailsDto> GetAllDepartment();

        DepartmentEmployeeDetailsDto DepartmentDetail(int depId);

        int AddDepartment(DepartmentEmployeeDetailsDto toAddDepartment);

        IEnumerable<RolesDto> GetRoles();

        int AddRole(RolesDto toAddRole);

        IEnumerable<SkillDto> GetAllSkills();

        int AddSkill(SkillDto toAddSkill);

        Object GetSkilledEmployee(int skillId);

        Object GetSPOC();
    }
}
