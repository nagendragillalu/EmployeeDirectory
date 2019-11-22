using EmployeeDirectoryAPI.Entities;
using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private EmployeeDbContext Context;
        public EventsRepository(EmployeeDbContext context)
        {
            this.Context = context;
        }

        public EventsDto GetEventDetails(int EventId)
        {
            EventsDto eventsDto = new EventsDto();
            try
            {
                var allEvents = Context.EventsDetails
                    .FirstOrDefault(evt => evt.EventId == EventId);

                eventsDto.EventId = allEvents.EventId;
                eventsDto.Venu = allEvents.Venu;
                eventsDto.EventDate = allEvents.EventDate;
                eventsDto.EventFromTime = allEvents.EventFromTime;
                eventsDto.EventToTime = allEvents.EventToTime;
                eventsDto.EventTimeZone = allEvents.EventTimeZone;
                eventsDto.Organizer = allEvents.Organizer;
                eventsDto.EventName = allEvents.EventName;
                eventsDto.EventPhotoURL = allEvents.EvenPhotoURL;
                eventsDto.EventDiscription = allEvents.EvenDiscription;
            }
            catch (SqlException expSql)
            {
                throw expSql;
            }
            catch (NullReferenceException expNull)
            {
                throw expNull;
            }
            return eventsDto;
        }

        public IEnumerable<EventsDto> GetAllEvents()
        {
            List<EventsDto> EventList = new List<EventsDto>();
            try
            {
                var allEvents = Context.EventsDetails
                    .ToList();
                foreach (EventsDetails evt in allEvents)
                {
                    EventsDto eventsDto = new EventsDto();
                    eventsDto.EventId = evt.EventId;
                    eventsDto.Venu = evt.Venu;
                    eventsDto.EventDate = evt.EventDate;
                    eventsDto.EventFromTime = evt.EventFromTime;
                    eventsDto.EventToTime = evt.EventToTime;
                    eventsDto.EventTimeZone = evt.EventTimeZone;
                    eventsDto.Organizer = evt.Organizer;
                    eventsDto.EventName = evt.EventName;
                    eventsDto.EventPhotoURL = evt.EvenPhotoURL;
                    eventsDto.EventDiscription = evt.EvenDiscription;
                    EventList.Add(eventsDto);
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
            return EventList;
        }

        public void AddEvents(EventsDto eventData)
        {
            try
            {
                EventsDetails eventsEntity = new EventsDetails();

                eventsEntity.Venu = eventData.Venu;
                eventsEntity.EventName = eventData.EventName;
                eventsEntity.EventName = eventData.EventName;
                eventsEntity.EventTimeZone = eventData.EventTimeZone;
                eventsEntity.EventToTime = eventData.EventToTime;
                eventsEntity.EventFromTime = eventData.EventFromTime;
                eventsEntity.EvenDiscription = eventData.EventDiscription;
                eventsEntity.Organizer = eventData.Organizer;
                eventsEntity.EvenPhotoURL = "https://picsum.photos/600/250/?image=27";//eventData.EventPhotoURL;
                eventsEntity.EventDate = eventData.EventDate;
                Context.EventsDetails.Add(eventsEntity);
                Context.SaveChanges();
                //return "";
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
    }
}
