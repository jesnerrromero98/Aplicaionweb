import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListarRecetaService } from 'src/app/Services/listar-receta.services';
import { Receta } from '../../../Model/Receta';

@Component({
  selector: 'app-listar-receta',
  templateUrl: './listar-receta.component.html',
  styleUrls: ['./listar-receta.component.css']
})

export class ListarRecetaComponent implements OnInit {
  constructor(private service: ListarRecetaService, router: Router) { }
  expedientes: Receta[];
  ngOnInit() {
    this.service.getReceta()
      .subscribe(Data => this.expedientes = Data);
  }
}
