import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi } from '../interfaces/response-api';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoVentaService {
  apiBase: string = '/api/departamentoventa/'
  constructor(private http: HttpClient) { }

  getDepartamentoVentas(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.apiBase}Lista`)
  }
}
