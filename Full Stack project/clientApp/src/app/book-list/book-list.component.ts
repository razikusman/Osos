import { Component, signal } from '@angular/core';
import { BookService } from '../book.service';
import { Book } from '../book';
import {FormsModule} from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent {

  Active : boolean = false;
  books : Book[] = []
  ColumnsName: string[] = [];

  selectedBook = signal<Book>({
    bookId: undefined,
    name: '',
    author: undefined,
    description: '',
    isActive: undefined
  });
  loaded: boolean = false;
  /**
   *
   */
  constructor(private bookService : BookService) {
    this.loaded = false
    bookService.getBookList().subscribe((data : any) => {
      console.log(data.data)
      this.books = [...data.data]
      this.loaded = true
    });

  }

  clicked(book : Book){
    this.selectedBook.set(book);
    console.log(book)
  }

  // dataSource = [
  //   { position: 1, name: 'John Doe', age: 25 },
  //   { position: 2, name: 'Jane Doe', age: 30 },
  //   // add more data as needed
  // ];

  columns: string[] = ['Name','Description', 'Author', 'Status'];
}
