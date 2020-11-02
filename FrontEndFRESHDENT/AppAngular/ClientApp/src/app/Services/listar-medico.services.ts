import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Medico } from '../Model/Medico';

@Injectable({
  provideIn: 'root';
})
export class ListarMedicoService {
  constructor(private https: HttpClient) { }
  url = 'https://localhost:44379/api/Medico';
}
getMedico(){
  return this.http.get<Medico[]>(this.url);
}
