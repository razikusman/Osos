import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from './book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  
  api : string = "https://localhost:7173/api/Books"
  constructor(private http: HttpClient) { }

  getBook(id :string) : Observable<Book>{
    return this.http.get<Book>("/" +this.api + "id?id="+id);
  }

  getBookList() : Observable<Book[]> {
    return this.http.get<Book[]>(this.api);
  }
  
}
