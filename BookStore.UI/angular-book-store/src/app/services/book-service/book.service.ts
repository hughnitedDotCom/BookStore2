import { Injectable } from '@angular/core';
import { Book } from 'src/app/models/book-model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]>{


    var result = this.http.get<Book[]>(`${environment.apiURL}api/Book/GetAllBooks`);

    // let books = [new Book(1, "Advantures of", "Hello World!", 23.80), 
    //              new Book(1, "Advantures of 2", "Hello World 2!", 28.30), 
    //              new Book(1, "Advantures of 3", "Hello World 3!", 12.38)]
    return result;
  }

  getBook(bookId: number): Observable<Book>{
    var result = this.http.get<Book>(`${environment.apiURL}api/Book/GetBook/${bookId}`);
    return result;
  }


  getColumns() {
    return [
      {
        prop: 'name',
        name: 'name'
      }, {
        prop: 'text',
        name: 'text'
      }, {
        prop: 'purchasePrice',
        name: 'purchasePrice'
      }
    ];
  }
}
