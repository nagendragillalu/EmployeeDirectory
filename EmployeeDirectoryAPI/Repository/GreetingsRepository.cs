using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Entities;
using EmployeeDirectoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryAPI.Repository
{
    public class GreetingsRepository : IGreetingsRepository
    {
        private EmployeeDbContext Context;
        public GreetingsRepository(EmployeeDbContext context)
        {
            this.Context = context;
        }


        IEnumerable<GreetListDto> IGreetingsRepository.getAllAniversaryEmployee(int anvMonth, int anvYear)
        {

            ICollection<GreetListDto> AniverList = new List<GreetListDto>();
            try
            {
                var getAllAniverEmployee = Context.Employees
                    .Include(emp => emp.ContactDetails)
                    .Where(emp => emp.JoiningDate.Month == anvMonth);

                //var test = Context.EmployeeSkills
                //    .Join(Context.Employees,
                //    e => e.EmployeeId,
                //    es => es.EmployeeId,
                //    () => new {
                //    });



                foreach (Employee emp in getAllAniverEmployee)
                {
                    GreetListDto AnniverEmployee = new GreetListDto();

                    AnniverEmployee.fName = emp.FirstName;
                    AnniverEmployee.employeeId = emp.EmployeeId;
                    AnniverEmployee.lName = emp.LastName;
                    AnniverEmployee.greetDate = emp.JoiningDate;
                    AnniverEmployee.eMail = emp.EmailID;
                    AnniverEmployee.twitter = emp.ContactDetails.TwitterLink;
                    AnniverEmployee.facebook = emp.ContactDetails.FBLink;
                    AnniverEmployee.yearCount = (anvYear - emp.JoiningDate.Year);
                    AnniverEmployee.photoUrl = emp.EmployeePhotoURL;

                    AniverList.Add(AnniverEmployee);
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

            return AniverList;
        }

        IEnumerable<GreetListDto> IGreetingsRepository.getAllBirthdayEmployee(int birthMonth)
        {
            ICollection<GreetListDto> bdayList = new List<GreetListDto>();
            try
            {
                var getAllBdayEmployee = Context.Employees
                    .Include(emp => emp.ContactDetails)
                    .Where(emp => emp.Dob.Month == birthMonth);

                foreach (Employee emp in getAllBdayEmployee)
                {
                    GreetListDto BdayEmployee = new GreetListDto();

                    BdayEmployee.fName = emp.FirstName;
                    BdayEmployee.employeeId = emp.EmployeeId;
                    BdayEmployee.lName = emp.LastName;
                    BdayEmployee.greetDate = emp.Dob;
                    BdayEmployee.eMail = emp.EmailID;
                    BdayEmployee.twitter = emp.ContactDetails.TwitterLink;
                    BdayEmployee.facebook = emp.ContactDetails.FBLink;
                    BdayEmployee.photoUrl = emp.EmployeePhotoURL;
                    bdayList.Add(BdayEmployee);
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

            return bdayList;
        }
    }
}
