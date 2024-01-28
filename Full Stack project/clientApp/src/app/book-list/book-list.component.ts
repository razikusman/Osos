import { Component, signal } from '@angular/core';
import { BookService } from '../book.service';
import { Book } from '../book';

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
    name: undefined,
    author: undefined,
    description: undefined,
    isActive: undefined
  });
  /**
   *
   */
  constructor(private bookService : BookService) {
    bookService.getBookList().subscribe((data : any) => {
      console.log(data.data)
      this.books = [...data.data]
    });

  }

  clicked(book : Book){
    this.selectedBook.set(book);
  }
}
