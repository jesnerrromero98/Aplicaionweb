import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListarExpedienteService } from 'src/app/Services/listar-expediente.services';
import { Expediente } from '../../../Model/Expediente';

@Component({
  selector: 'app-listar-expediente',
  templateUrl: './listar-expediente.component.html',
  styleUrls: ['./listar-receta.component.css']
})

export class ListarExpedienteComponent implements OnInit {
  constructor(private service: ListarExpedienteService, router: Router) { }
  expedientes: Expediente[];
  ngOnInit() {
    this.service.getExpediente()
      .subscribe(Data => this.expedientes = Data);
  }
}
