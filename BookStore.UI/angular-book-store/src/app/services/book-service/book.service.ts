import { Injectable } from '@angular/core';
import { Book } from 'src/app/models/book-model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor() { }

  getBooks(): Book[]{

    let books = [new Book(1, "Advantures of", "Hello World!", 23.80), 
                 new Book(1, "Advantures of 2", "Hello World 2!", 28.30), 
                 new Book(1, "Advantures of 3", "Hello World 3!", 12.38)]
    return books;
  }

  getColumns() {
    return [
      {
        prop: 'name',
        name: 'name'
      }, {
        prop: 'text',
        name: 'text'
      }
      , {
        prop: 'purchasePrice',
        name: 'purchasePrice'
      }
    ];
  }
}
