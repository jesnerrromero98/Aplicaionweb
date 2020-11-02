import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Receta } from '../Model/Receta';

@Injectable({
  provideIn: 'root';
})
export class ListarRecetaService {
  constructor(private https: HttpClient) { }
  url = 'https://localhost:44379/api/Receta';
}
getReceta(){
  return this.http.get<Receta[]>(this.url);
}
