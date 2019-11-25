import { PipeTransform, Pipe } from '@angular/core';
import { EmployeeData } from '../shared/EmployeeData';

@Pipe({
    name: 'employeeFilterPipe',
    pure: true,
})
export class EmployeeFilterPipe implements PipeTransform {
    transform(employees: EmployeeData[], searchTerm: string): EmployeeData[] {
        if (!employees || !searchTerm) {
            return employees;
        }

        return employees.filter(empl =>
            empl.firstName.toLowerCase()
            .indexOf(searchTerm.toLowerCase()) !== -1 );
    }
}
