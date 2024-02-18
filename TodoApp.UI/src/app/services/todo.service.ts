import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo.model';
import { FormsModule } from '@angular/forms';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseApiUrl: string ="https://localhost:7083";

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<Todo[]> {
    return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodos')
               .pipe(map((response: { listTodo: any; }) => response.listTodo));
  }

  // getAllTodos(): Observable<Todo[]> {
  //   return this.http.get<any>(this.baseApiUrl + '/api/Todo/GetAllTodos').pipe(
  //     map(response => response.listtodo)
  //   );
  // }

  // addTodo(newTodo: Todo): Observable<Todo>{
  //   // newTodo.id ='00000000-0000-0000-0000-000000000000';
  //   return this.http.post<Todo>(this.baseApiUrl + '/api/todo', newTodo);
  // }
}
