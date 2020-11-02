import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Consulta } from '../Model/Consulta';

@Injectable({
  provideIn: 'root';
})
export class ListarConsultaService {
  constructor(private https: HttpClient) { }
  url = 'https://localhost:44379/api/Consulta';
}
getConsulta(){
  return this.http.get<Consulta[]>(this.url);
}
