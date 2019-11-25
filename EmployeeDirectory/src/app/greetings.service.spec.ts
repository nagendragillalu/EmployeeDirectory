import { TestBed, tick  } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { GreetingsService } from './greetings.service';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { Greetings } from './shared/GreetingsData';

describe('GreetingsService', () => {
    let service: GreetingsService;
    let httpMock: HttpTestingController;

  beforeEach(() => {
      TestBed.configureTestingModule({
          imports: [HttpClientTestingModule],
          providers: [GreetingsService],
          schemas: [NO_ERRORS_SCHEMA],
      });
      service = TestBed.get(GreetingsService);
      httpMock = TestBed.get(HttpTestingController);
    });

    afterEach(() => {
        httpMock.verify();
      });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('Employee Birthday details for the month', () => {  
            it('should return all Birthday cards for given month' , () => {
            const mockResponse: Greetings[] = [{
                employeeId: 1,
                fName: 'Nagendra',
                lName: 'Gillalu',
                greetDate: new Date(),
                eMail: '',
                twitter: '',
                facebook: '',
                yearCount: 0,
                photoUrl: '',
            }];
            service.getAllBday(1).subscribe((res) => {
                expect(res[0].fName).toBe(mockResponse[0].fName);
                expect(res[0].lName).toBe(mockResponse[0].lName);
                expect(res[0].greetDate).not.toBeNull();
            });

            const req = httpMock.expectOne(`/api/greetings/bday/1`, 'Get All birthDays cards') ;
            expect(req.request.method).toBe('GET');
            req.flush(mockResponse);
        });

    });

    describe('Employee Anniversary list for the given month', () => {
        it('should return all Anniversary cards for given month' , () => {
        const mockResponse: Greetings[] = [{
            employeeId: 1,
            fName: 'Nagendra',
            lName: 'Gillalu',
            greetDate: new Date(),
            eMail: '',
            twitter: '',
            facebook: '',
            yearCount: 0,
            photoUrl: '',
        }];
        service.getAllAnniver(1).subscribe((res) => {
            expect(res[0].fName).toBe(mockResponse[0].fName);
            expect(res[0].lName).toBe(mockResponse[0].lName);
            expect(res[0].greetDate).not.toBeNull();
        });

        const req = httpMock.expectOne(`/api/greetings/anniversary/1`, 'Get All Anniversary cards') ;
        expect(req.request.method).toBe('GET');
        req.flush(mockResponse);
    });

});

});
