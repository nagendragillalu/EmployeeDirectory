import {EmployeeFilterPipe} from './employee-filter.pipe';

describe ('Employe Filter Pipe', () => {
    let EMPLOYEEDATA;
    const pipe = new EmployeeFilterPipe();
    beforeEach(() => {
        EMPLOYEEDATA = [
            {
                employeeId: 1,
                firstName: 'Nagendra',
                lastName: 'Gillalu',
            },
            {
                employeeId: 2,
                firstName: 'OMKAR',
                lastName: 'Kumtekar',
            }
        ];
    });

    it ('should return Employee with given search name', () =>    {
        let result = pipe.transform(EMPLOYEEDATA, 'Nagendra' );
        expect(result.length).toEqual(1);
    });

    it('should display all employees when search string is nothing', () => {
        let result = pipe.transform(EMPLOYEEDATA, '');
        expect(result.length).toEqual(2);
    });

    it('should display searched employee only', () => {
        let result = pipe.transform(EMPLOYEEDATA, 'OMKAR');
        expect(result[0].firstName).toEqual('OMKAR');
    });

    it('should return result irrespective of search string case', () => {
        let result = pipe.transform(EMPLOYEEDATA, 'omkar');
        expect(result[0].lastName).toEqual('Kumtekar');
    });
});
