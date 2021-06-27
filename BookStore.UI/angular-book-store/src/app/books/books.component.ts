import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book-model';
import { BookService } from '../services/book-service/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  constructor(private bookService: BookService) { }

  books: Book[] = [];
  displayedColumns: string[] = [];

  ngOnInit(): void {
    this.getBooks();

    this.displayedColumns = this.bookService.getColumns().map((c) => c.prop);
  }

  getBooks(): void{
    this.books = this.bookService.getBooks();

  }

}
