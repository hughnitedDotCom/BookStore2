export class RegisterRequest{
    constructor(firstName: string, lastName : string, emailAddress :string, password : string)
                {
                    this.firstName = firstName;
                    this.lastName = lastName;
                    this.emailAddress = emailAddress;
                    this.password = password;
                }
     firstName: string;
     lastName : string;
     emailAddress : string;
     password : string;
}