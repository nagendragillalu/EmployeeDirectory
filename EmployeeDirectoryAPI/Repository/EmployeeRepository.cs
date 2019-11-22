using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Entities;
using EmployeeDirectoryAPI.Models;
using Microsoft.EntityFrameworkCore;

// This is to Implement IEmployeeRepository Interface, which acts as an agreement between DBContext and Controller
// This Implementation is Registerd in service container, wherein it can be Injected as per our requirement

namespace EmployeeDirectoryAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private EmployeeDbContext Context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            this.Context = context;
        }

        /*
         * This Method will return all Employees in a given department
         * with depId 
         */
        public DepartmentEmployeeDetailsDto DepartmentDetail(int depId)
        {
            DepartmentEmployeeDetailsDto departDetails = new DepartmentEmployeeDetailsDto();

            try
            {
                var deptDetail = Context.DepartmentDetails
                    .FirstOrDefault(d => d.DepartmentId == depId);

                var empDeptDetail = Context.Employees
                    .Include(e => e.DepartmentDetails)
                    .Where(e => e.DepartmentDetails.DepartmentId == deptDetail.DepartmentId);

                departDetails.DepartmentName = deptDetail.DepartmentName;
                departDetails.DepartmentDisc = deptDetail.DepartmentDiscription;
                departDetails.DepartHeadName = deptDetail.DepartmentHeadName;
                ICollection<EmployeeDto> emplList = new List<EmployeeDto>();
                foreach (Employee emp in empDeptDetail)
                {
                    EmployeeDto deptEmployee = new EmployeeDto();
                    deptEmployee.EmployeeId = emp.EmployeeId;
                    deptEmployee.FirstName = emp.FirstName;
                    deptEmployee.LastName = emp.LastName;
                    deptEmployee.EmailId = emp.EmailID;

                    emplList.Add(deptEmployee);
                }
                departDetails.EmployeeList = emplList;
            }
            catch (SqlException expSql)
            {
                throw expSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }

            return departDetails;
        }

        /*
         * This method returns only the Employee Details of given employeeID
         */
        public EmployeeDto EmployeeDetails(int emplId)
        {
            try
            {
                var Employee = Context.Employees
                    .Include(emp => emp.ContactDetails)
                    .Include(emp => emp.DepartmentDetails)
                    .Include(emp => emp.EmployeeBiography)
                    .Include(emp => emp.employeeRoles)
                    .Include(emp => emp.TeamDetails)
                    .Include(emp => emp.EmployeeBiography)
                    .FirstOrDefault(emp => emp.EmployeeId == emplId);
                var skills = Context.EmployeeSkills
                    .Include(s => s.skills)
                    .Where(s => s.EmployeeId == Employee.EmployeeId)
                    .Select(s => new EmployeeSkillsDto
                    {
                        SkillName = s.skills.SkillName,
                        SkillLevel = s.SkillLevel,
                        EmployeeId = s.EmployeeId,
                        SkillId = s.SkillId
                    }).ToList();

                EmployeeDto empl = new EmployeeDto();
                RolesDto role = new RolesDto();
                DepartmentDetailsDto depart = new DepartmentDetailsDto();
                TeamDetailDto team = new TeamDetailDto();
                ContactDto contact = new ContactDto();
                BioGraphyDto bio = new BioGraphyDto();

                empl.FirstName = Employee.FirstName;
                empl.LastName = Employee.LastName;
                empl.EmployeeId = Employee.EmployeeId;
                empl.Dob = Employee.Dob;
                empl.JoiningDate = Employee.JoiningDate;
                empl.EmailId = Employee.EmailID;
                empl.PhotoUrl = Employee.EmployeePhotoURL;
                empl.SPOC = Employee.SPOC;
                role.RoleName = Employee.employeeRoles.RoleName;
                empl.Role = role;

                depart.DepartmentName = Employee.DepartmentDetails.DepartmentName;
                empl.Departmnent = depart;


                team.TeamName = Employee.TeamDetails.TeamName;
                team.LeadName = Employee.TeamDetails.TeamLeadName;
                empl.Team = team;

                contact.Address = Employee.ContactDetails.Address;
                contact.MobileOffice = Employee.ContactDetails.MobNumberOff;
                contact.MobilePersonal = Employee.ContactDetails.MobNumberPersonal;
                contact.SkypeId = Employee.ContactDetails.SkypeID;
                contact.SlackId = Employee.ContactDetails.SlackID;
                contact.FBLink = Employee.ContactDetails.FBLink;
                contact.TwitterLink = Employee.ContactDetails.TwitterLink;
                contact.GitHubLink = Employee.ContactDetails.GitHubLink;
                contact.LinkdinLink = Employee.ContactDetails.linkdinLink;
                empl.ContactDetail = contact;

                bio.About = Employee.EmployeeBiography.About;
                bio.Hobbies = Employee.EmployeeBiography.Hobbies;
                bio.Interests = Employee.EmployeeBiography.Interests;
                empl.Bio = bio;

                foreach (EmployeeSkillsDto empSkill in skills)
                {
                    empl.EmployeeSkills.Add(empSkill);
                }

                return empl;
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }

        }

        /*
         * This Method return list of all the Departments in DB.
         */
        public IEnumerable<DepartmentDetailsDto> GetAllDepartment()
        {
            List<DepartmentDetailsDto> DeptList = new List<DepartmentDetailsDto>();
            try
            {
                var allDept = Context.DepartmentDetails.ToList();
                foreach (DepartmentDetails dept in allDept)
                {
                    DepartmentDetailsDto deptDto = new DepartmentDetailsDto();
                    deptDto.DepartmentId = dept.DepartmentId;
                    deptDto.DepartmentName = dept.DepartmentName;
                    deptDto.DepartmentHeadName = dept.DepartmentHeadName;
                    deptDto.DepartmentDiscription = dept.DepartmentDiscription;

                    DeptList.Add(deptDto);
                }
                return DeptList;
            }
            catch (SqlException expSql)
            {
                throw expSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
        }


        /*
         * This method retrieves all the Employess with details from the DB.
         * Also we map the EMployee Entity to our DTO's
         * it Returns List of EmployeeDto
         */
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            List<EmployeeDto> EmployeeList = new List<EmployeeDto>();
            try
            {
                var allEmployees = Context.Employees.Include(emp => emp.ContactDetails)
                .Include(emp => emp.DepartmentDetails)
                .Include(emp => emp.EmployeeBiography)
                .Include(emp => emp.employeeRoles)
                .Include(emp => emp.TeamDetails)
                .Include(emp => emp.EmployeeBiography).ToList();

                foreach (Employee Employee in allEmployees)
                {
                    var skills = Context.EmployeeSkills
                                    .Include(s => s.skills)
                                    .Where(s => s.EmployeeId == Employee.EmployeeId)
                                    .Select(s => new EmployeeSkillsDto
                                    {
                                        SkillName = s.skills.SkillName,
                                        SkillLevel = s.SkillLevel,
                                        EmployeeId = s.EmployeeId,
                                        SkillId = s.SkillId
                                    }).ToList();

                    EmployeeDto empl = new EmployeeDto();
                    RolesDto role = new RolesDto();
                    DepartmentDetailsDto depart = new DepartmentDetailsDto();
                    TeamDetailDto team = new TeamDetailDto();
                    ContactDto contact = new ContactDto();
                    BioGraphyDto bio = new BioGraphyDto();

                    empl.FirstName = Employee.FirstName;
                    empl.LastName = Employee.LastName;
                    empl.EmployeeId = Employee.EmployeeId;
                    empl.Dob = Employee.Dob;
                    empl.JoiningDate = Employee.JoiningDate;
                    empl.EmailId = Employee.EmailID;
                    empl.PhotoUrl = Employee.EmployeePhotoURL;
                    empl.SPOC = Employee.SPOC;

                    role.RoleName = Employee.employeeRoles.RoleName;
                    empl.Role = role;

                    depart.DepartmentName = Employee.DepartmentDetails.DepartmentName;
                    empl.Departmnent = depart;

                    team.TeamName = Employee.TeamDetails.TeamName;
                    team.TeamName = Employee.TeamDetails.TeamName;
                    team.LeadName = Employee.TeamDetails.TeamName;
                    empl.Team = team;

                    contact.Address = Employee.ContactDetails.Address;
                    contact.MobileOffice = Employee.ContactDetails.MobNumberOff;
                    contact.MobilePersonal = Employee.ContactDetails.MobNumberPersonal;
                    contact.SkypeId = Employee.ContactDetails.SkypeID;
                    contact.SlackId = Employee.ContactDetails.SlackID;
                    contact.FBLink = Employee.ContactDetails.FBLink;
                    contact.TwitterLink = Employee.ContactDetails.TwitterLink;
                    contact.GitHubLink = Employee.ContactDetails.GitHubLink;
                    contact.LinkdinLink = Employee.ContactDetails.linkdinLink;
                    empl.ContactDetail = contact;

                    bio.About = Employee.EmployeeBiography.About;
                    bio.Hobbies = Employee.EmployeeBiography.Hobbies;
                    bio.Interests = Employee.EmployeeBiography.Interests;
                    empl.Bio = bio;
                    foreach (EmployeeSkillsDto empSkill in skills)
                    {
                        empl.EmployeeSkills.Add(empSkill);
                    }

                    EmployeeList.Add(empl);
                }

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return EmployeeList;
        }

        public IEnumerable<TeamDetailDto> GetAllTeams()
        {
            List<TeamDetailDto> TeamList = new List<TeamDetailDto>();


            try
            {
                var allTeam = Context.TeamDetails.ToList();

                foreach (TeamDetails teamDetail in allTeam)
                {
                    TeamDetailDto team = new TeamDetailDto();
                    team.TeamId = teamDetail.TeamID;
                    team.TeamName = teamDetail.TeamName;
                    team.TeamDicription = teamDetail.TeamDiscription;
                    team.LeadName = teamDetail.TeamLeadName;

                    TeamList.Add(team);
                }
            }
            catch (SqlException expSql)
            {
                throw expSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return TeamList;
        }

        public TeamEmployeeDto TeamEmployeeDetails(int teamID)
        {
            TeamEmployeeDto teamEmpDetail = new TeamEmployeeDto();
            List<EmployeeDto> teamEmp = new List<EmployeeDto>();
            try
            {
                var Team = Context.TeamDetails
                    .FirstOrDefault(td => td.TeamID == teamID);

                var TeamEmployee = Context.Employees
                    .Include(emp => emp.employeeRoles)
                    .Where(emp => emp.TeamDetails.TeamID == Team.TeamID)
                    .ToList();
                teamEmpDetail.TeamId = Team.TeamID;
                teamEmpDetail.TeamName = Team.TeamName;
                teamEmpDetail.LeadName = Team.TeamLeadName;
                teamEmpDetail.TeamDiscription = Team.TeamDiscription;

                foreach (Employee emp in TeamEmployee)
                {
                    EmployeeDto empDto = new EmployeeDto();
                    RolesDto roleDto = new RolesDto();
                    empDto.EmployeeId = emp.EmployeeId;
                    empDto.FirstName = emp.FirstName;
                    empDto.LastName = emp.LastName;
                    empDto.PhotoUrl = emp.EmployeePhotoURL;
                    empDto.Dob = emp.Dob;
                    empDto.JoiningDate = emp.JoiningDate;
                    empDto.EmailId = emp.EmailID;

                    roleDto.RoleName = emp.employeeRoles.RoleName;
                    empDto.Role = roleDto;

                    teamEmp.Add(empDto);
                }
                teamEmpDetail.TeamEmployees = teamEmp;
            }
            catch (SqlException expSql)
            {
                throw expSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return teamEmpDetail;
        }

        public IEnumerable<RolesDto> GetRoles()
        {
            
            List<RolesDto> rolesList = new List<RolesDto>();

            try {
                var getRoles = Context.EmployeeRoles.ToList();
                foreach (EmployeeRoles role in getRoles)
                {
                    RolesDto singleRole = new RolesDto();
                    singleRole.RoleName = role.RoleName;
                    singleRole.RoleId = role.RoleId;
                    rolesList.Add(singleRole);
                }
            }
            catch(SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return rolesList;
        }


        public IEnumerable<SkillDto> GetAllSkills()
        {
            List<SkillDto> skillList = new List<SkillDto>();
            try {
                var getSkills = Context.Skills.ToList();
                foreach (Skills skill in getSkills)
                {
                    SkillDto singleSkill = new SkillDto();
                    singleSkill.SkillId = skill.SkillID;
                    singleSkill.SkillName = skill.SkillName;

                    skillList.Add(singleSkill);
                }
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return skillList;
        }

        /*
         * This method will add the given Employee Details to DB along with other related details
         * It takes EmployeeDto object and returns the string message
         */
        public int AddEmployee(EmployeeDto toAddEmployee)
        {
            ContactDetails contactEntity = new ContactDetails();
            EmployeeBiography biographyEntity = new EmployeeBiography();
            Employee employeeEntity = new Employee();
            try {

                //Adding Employee Contact Details to DB Entity

                contactEntity.MobNumberOff = toAddEmployee.ContactDetail.MobileOffice;
                contactEntity.MobNumberPersonal = toAddEmployee.ContactDetail.MobilePersonal;
                contactEntity.SkypeID = toAddEmployee.ContactDetail.SkypeId;
                contactEntity.SlackID = toAddEmployee.ContactDetail.SlackId;
                contactEntity.Address = toAddEmployee.ContactDetail.Address;
                contactEntity.FBLink = toAddEmployee.ContactDetail.FBLink;
                contactEntity.TwitterLink = toAddEmployee.ContactDetail.TwitterLink;
                contactEntity.GitHubLink = toAddEmployee.ContactDetail.GitHubLink;
                contactEntity.linkdinLink = toAddEmployee.ContactDetail.LinkdinLink;

                Context.ContactDetails.Add(contactEntity);

                //Adding Employee Biography to DB Entity

                biographyEntity.About = toAddEmployee.Bio.About;
                biographyEntity.Hobbies = toAddEmployee.Bio.Hobbies;
                biographyEntity.Interests = toAddEmployee.Bio.Interests;

                Context.ContactDetails.Add(contactEntity);
                Context.EmployeeBiographies.Add(biographyEntity);
                Context.SaveChanges();

                var departDetails = Context.DepartmentDetails
                    .FirstOrDefault(depart => depart.DepartmentId == toAddEmployee.Departmnent.DepartmentId);
                var roledetails = Context.EmployeeRoles
                    .FirstOrDefault(role => role.RoleId == toAddEmployee.Role.RoleId);
                var teamDetails = Context.TeamDetails
                    .FirstOrDefault(team => team.TeamID == toAddEmployee.Team.TeamId);

                // Adding Employee Details to Employee Entity

                employeeEntity.FirstName = toAddEmployee.FirstName;
                employeeEntity.LastName = toAddEmployee.LastName;
                employeeEntity.Dob = toAddEmployee.Dob;
                employeeEntity.EmployeePhotoURL = "https://picsum.photos/300/200/?image="; //toAddEmployee.PhotoUrl;
                employeeEntity.JoiningDate = toAddEmployee.JoiningDate;
                employeeEntity.EmailID = toAddEmployee.EmailId;
                employeeEntity.SPOC = toAddEmployee.SPOC;
                employeeEntity.RoleId = toAddEmployee.Role.RoleId;
                employeeEntity.employeeRoles = roledetails;
                employeeEntity.DepartmentDetails = departDetails;
                employeeEntity.TeamDetails = teamDetails;
                employeeEntity.ContactId = contactEntity.ContactId;
                employeeEntity.BioId = biographyEntity.BioId;

                Context.Employees.Add(employeeEntity);
                Context.SaveChanges();

                // Mapping and Adding Employee Skills to DB Entity

                List<EmployeeSkills> skillList = new List<EmployeeSkills>();
                foreach(EmployeeSkillsDto empSkill in toAddEmployee.EmployeeSkills)
                {
                    EmployeeSkills skillEntity = new EmployeeSkills();

                    skillEntity.employee = employeeEntity;
                    skillEntity.SkillId = empSkill.SkillId;
                    skillEntity.EmployeeId = employeeEntity.EmployeeId;
                    skillEntity.SkillLevel = empSkill.SkillLevel;


                    skillList.Add(skillEntity);
                }

                // Adding Employee Skills
                Context.EmployeeSkills.AddRange(skillList);
                Context.SaveChanges();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return employeeEntity.EmployeeId;
        }



        /*
         * This method to add new team to the Db with given Details
         */ 
        public int AddTeam(TeamDetailDto toAddTeam)
        {
            TeamDetails teamData = new TeamDetails();
            try
            {
                teamData.TeamDiscription = toAddTeam.TeamDicription;
                teamData.TeamLeadName = toAddTeam.LeadName;
                teamData.TeamName = toAddTeam.TeamName;
                Context.TeamDetails.Add(teamData);
                Context.SaveChanges();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return teamData.TeamID;
        }

        /*
         * This method to add new team to the Db with given Details
         */
        public int AddDepartment(DepartmentEmployeeDetailsDto toAddDepartment)
        {
            DepartmentDetails departmentData = new DepartmentDetails();
            try
            {
                departmentData.DepartmentHeadName = toAddDepartment.DepartHeadName;
                departmentData.DepartmentDiscription = toAddDepartment.DepartmentDisc;
                departmentData.DepartmentName = toAddDepartment.DepartmentName;

                Context.DepartmentDetails.Add(departmentData);
                Context.SaveChanges();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return departmentData.DepartmentId;
        }


        /*
         * This method to add new Role to the Db with given Details
         */
        public int AddRole(RolesDto toAddRole)
        {
            EmployeeRoles roleData = new EmployeeRoles();
            try
            {
                roleData.RoleName = toAddRole.RoleName;

                Context.EmployeeRoles.Add(roleData);
                Context.SaveChanges();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return roleData.RoleId;
        }

        /*
         * This method to add new Skill to the Db with given Details
         */
        public int AddSkill(SkillDto toAddSkill)
        {
            Skills skillData = new Skills();
            try
            {
                skillData.SkillName = toAddSkill.SkillName;

                Context.Skills.Add(skillData);
                Context.SaveChanges();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return skillData.SkillID;
        }

        /*
         * This method returns employees with given skills
         */
        public Object GetSkilledEmployee(int skillId)
        {
   
            try
            {
                //var skillLookUp = Context.Skills.FirstOrDefault(s => s.SkillName.Contains(skillId));

                var skilledEmoloyee = from e in Context.Employees
                            join es in Context.EmployeeSkills
                            on e.EmployeeId equals es.EmployeeId
                            where es.SkillId == skillId
                            select new
                            {
                                e.EmployeeId,
                                e.FirstName,
                                e.LastName,
                                e.EmployeePhotoURL,
                                es.SkillId,
                                es.SkillLevel
                            };

                return skilledEmoloyee;
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            
        }


        /*
         * This method returns employees with given skills
         */
         public Object GetSPOC()
        {
            try
            {
                var spocList = Context.Employees
                    .Where(emp => emp.SPOC != null).
                    Select(emp => new {
                        emp.EmailID,
                        emp.EmployeePhotoURL,
                        emp.EmployeeId,
                        emp.FirstName,
                        emp.LastName,
                        emp.employeeRoles.RoleName,
                        emp.SPOC,
                        emp.DepartmentDetails.DepartmentName
                    }).ToList();

                return spocList;
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
        } 
    }

}
