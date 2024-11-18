import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ColaboradoresService {
  private apiUrl = 'http://localhost:5212/api/colaborador'; 

  constructor(private http: HttpClient) {}

  getColaboradores(): Observable<any[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map((response) => {
        // Extrai $values da resposta, se existir
        if (response?.$values) {
          return response.$values;
        }
        return []; // Retorna array vazio se $values não existir
      })
    );
  }

  createColaborador(colaborador: any): Observable<any> {
    return this.http.post(this.apiUrl, colaborador);
  }

  updateColaborador(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }
  

  deleteColaborador(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
