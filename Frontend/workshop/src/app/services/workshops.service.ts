import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WorkshopsService {
  private apiUrl = 'http://localhost:5212/api/workshop'; 

  constructor(private http: HttpClient) {}

  getWorkshops(): Observable<any[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map((response) => {
        console.log('Resposta da API:', response); // Verifica os dados brutos recebidos
        if (response?.$values) {
          return response.$values.map((workshop: any) => ({
            ...workshop,
            colaboradores: workshop.colaboradores?.$values || [],
          }));
        }
        return [];
      })
    );
  }
  

  getWorkshopById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createWorkshop(workshop: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, {
      id: 0, // A API geralmente ignora o ID para novos registros
      nome: workshop.nome,
      data: workshop.data,
      descricao: workshop.descricao,
      colaboradoresIds: workshop.colaboradoresIds,
    });
  }
  

  updateWorkshop(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }
  

  deleteWorkshop(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
