import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Expediente } from '../Model/Expediente';

@Injectable({
  provideIn: 'root';
})
export class ListarExpedienteService {
  constructor(private https: HttpClient) { }
  url = 'https://localhost:44379/api/Expediente';
}
getExpediente(){
  return this.http.get<Expediente[]>(this.url);
}
