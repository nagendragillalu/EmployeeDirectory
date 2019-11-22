using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Repository
{
    public interface IGreetingsRepository
    {
        IEnumerable<GreetListDto> getAllBirthdayEmployee(int birthMonth);
        IEnumerable<GreetListDto> getAllAniversaryEmployee(int anvMonth, int anvYear);
    }
}
