import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListarRecetaService } from 'src/app/Services/listar-receta.services';
import { Medico } from '../../../Model/Medico';

@Component({
  selector: 'app-listar-medico',
  templateUrl: './listar-medico.component.html',
  styleUrls: ['./listar-medico.component.css']
})

export class ListarMedicoComponent implements OnInit {
  constructor(private service: ListarRecetaService, router: Router) { }
  expedientes: Medico[];
  ngOnInit() {
    this.service.getMedico()
      .subscribe(Data => this.expedientes = Data);
  }
}
