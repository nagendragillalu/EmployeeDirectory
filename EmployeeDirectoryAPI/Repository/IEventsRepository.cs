using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Repository
{
    public interface IEventsRepository
    {
        IEnumerable<EventsDto> GetAllEvents();

        EventsDto GetEventDetails(int EventId);

        void AddEvents(EventsDto eventData);
    }
}
