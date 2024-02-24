import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Curso } from '@app/models/curso';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { API_CONFIG } from 'src/config/api-config';
import { HeaderConfig } from 'src/config/header';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  headers = HeaderConfig.header();
  apiUrl = API_CONFIG.getBaseUrl();

  constructor(private http: HttpClient) { }

  cadastro(curso: Curso): Observable<Curso> {
    return this.http.post<Curso>(this.apiUrl + 'api/curso', curso).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'api/Curso', { headers: this.headers }).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }
}
