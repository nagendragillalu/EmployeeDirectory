import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EventServiceService } from './event-service.service';
import { EventDetails } from './shared/EventDetails';
import { DistinctSubscriber } from 'rxjs/internal/operators/distinct';

describe('EventServiceService', () => {
    let service: EventServiceService;
    let httpMock: HttpTestingController;
    let dummyEvents: EventDetails[];
  beforeEach(() => {
      TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [EventServiceService],
            });
    service = TestBed.get(EventServiceService);
    httpMock = TestBed.get(HttpTestingController);
    dummyEvents = [
        {
            eventId: 1,
            venu: 'testVenue',
            eventDate: new Date(),
            eventFromTime: new Date(),
            eventToTime: new Date(),
            eventTimeZone: 'Event time Zone',
            organizer: 'Organizer Name',
            eventName: 'Event Name',
            eventPhotoURL: 'Event Photo',
            eventDiscription: 'Event Discription'
        }
      ];
    });

describe('List of all the events', () => {  it('should get data from Backend', () => {
        service.getAllEvents().subscribe(data => {
            expect(data[0].eventName).toBe('Event Name');
            });
            const req = httpMock.expectOne(`api/events`, 'call to api');
            expect(req.request.method).toBe('GET');
            req.flush(dummyEvents);
            httpMock.verify();
     });

    it('should get more than 0 events', () => {
        service.getAllEvents().subscribe(data => {
            expect(data.length).toBeGreaterThan(0);
            });
            const req = httpMock.expectOne(`api/events`, 'call to api');
            expect(req.request.method).toBe('GET');
            req.flush(dummyEvents);
            httpMock.verify();
        });

        it('should get all EventDetails properties', () => {
            service.getAllEvents().subscribe(data => {
                expect(data[0].eventName).toBe('Event Name');
                expect(data[0].venu).toBe('testVenue');
                expect(data[0].eventDate).not.toBeNull();
                expect(data[0].eventFromTime).not.toBeNull();
                expect(data[0].eventToTime).not.toBeNull();
                expect(data[0].eventTimeZone).not.toBeNull();
                expect(data[0].organizer).not.toBeNull();
                expect(data[0].eventPhotoURL).not.toBeNull();
                expect(data[0].eventDiscription).not.toBeNull();
                });
                const req = httpMock.expectOne(`api/events`, 'call to api');
                expect(req.request.method).toBe('GET');
                req.flush(dummyEvents);
                httpMock.verify();
            });

    });

describe('Single event Details when Event ID is given', () => {

        it('should get Event details for given ID', () => {
            service.getEvent(1).subscribe(data => {
                expect(data[0].eventId).toBe(1);
                });
                const req = httpMock.expectOne(`/api/events/1`, 'call to api');
                expect(req.request.method).toBe('GET');
                req.flush(dummyEvents);
                httpMock.verify();
        });

        it('should get all EventDetails properties', () => {
            service.getAllEvents().subscribe(data => {
                expect(data[0].eventName).toBe('Event Name');
                expect(data[0].venu).toBe('testVenue');
                expect(data[0].eventDate).not.toBeNull();
                expect(data[0].eventFromTime).not.toBeNull();
                expect(data[0].eventToTime).not.toBeNull();
                expect(data[0].eventTimeZone).not.toBeNull();
                expect(data[0].organizer).not.toBeNull();
                expect(data[0].eventPhotoURL).not.toBeNull();
                expect(data[0].eventDiscription).not.toBeNull();
                });
                const req = httpMock.expectOne(`api/events`, 'call to api');
                expect(req.request.method).toBe('GET');
                req.flush(dummyEvents);
                httpMock.verify();
            });
    });

});
