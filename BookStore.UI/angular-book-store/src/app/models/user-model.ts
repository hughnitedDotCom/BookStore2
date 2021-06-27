import { Book } from "./book-model";

export class User{
    constructor( userId: number, 
        firstName: string, 
        lastName: string,
        emailAddress: string,
        password: string,
        bookSubscriptions: Book[] = []){
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.password = password;
            this.bookSubscriptions = bookSubscriptions;
    }
    userId: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    password: string
    bookSubscriptions: Book[] = [];
}