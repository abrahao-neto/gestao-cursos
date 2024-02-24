import { Injectable } from '@angular/core';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { API_CONFIG } from 'src/config/api-config';
import { HeaderConfig } from 'src/config/header';
import { Aluno } from '@app/models/aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  headers = HeaderConfig.header();
  apiUrl = API_CONFIG.getBaseUrl();

  constructor(private http: HttpClient) { }

  cadastro(aluno: Aluno): Observable<Aluno> {
    return this.http.post<Aluno>(this.apiUrl + 'api/aluno', aluno, { headers: this.headers }).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }

  editar(aluno: Aluno): Observable<Aluno> {
    return this.http.put<Aluno>(this.apiUrl + 'api/aluno', aluno, { headers: this.headers }).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }

  getById(id: string): Observable<Aluno> {
    return this.http.get<Aluno>(this.apiUrl + `api/aluno/${id}`, { headers: this.headers }).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }

  getAll(): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.apiUrl + 'api/aluno', { headers: this.headers }).pipe(
      tap((response: any) => {
        console.log('Resposta bem-sucedida:', response);
      }),
      catchError((error) => {
        console.error('Erro na requisição:', error);
        return throwError(error);
      })
    );
  }

  ativarAluno(id: string): Observable<Aluno[]> {
    // debugger;
    return this.http.put<Aluno[]>(this.apiUrl + `api/Aluno/AtivarAluno/${id}`, { headers: this.headers }).pipe(
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
