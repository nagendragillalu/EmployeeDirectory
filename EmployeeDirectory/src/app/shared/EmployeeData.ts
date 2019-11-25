export class EmployeeData {
    employeeId: number;
    firstName: String;
    lastName: String;
    dob: Date;
    joiningDate: Date;
    emailId: String;
    photoUrl: String;
    role: Roles;
    departmnent: Department;
    team: Team;
    contactDetail: ContactDetail;
    bio: Biography;
    employeeSkills: Skills[];
}

export class Skills {
    skillId: number;
    employeeId: number;
    skillName: String;
    skillLevel: String;
}

export class Roles {
    roleId: number;
    roleName: String;
}

export class Department {
    departmentId: number;
    departmentName: String;
    departmentDiscription: String;
    departmentHeadName: String;
}

export class Team {
    teamId: number;
    teamName: String;
    leadName: String;
    teamDicription: String;
}

export class ContactDetail {
    mobileOffice: number;
    mobilePersonal: number;
    skypeId: String;
    slackId: String;
    address: String;
    fbLink: String;
    twitterLink: String;
    gitHubLink: String;
    linkdinLink: String;
}

export class  Biography {
    about: String;
    hobbies: String;
    interests: String;
}


