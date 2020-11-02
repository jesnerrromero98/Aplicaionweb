import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListarConsultaService } from 'src/app/Services/listar-consulta.services';
import { Consulta } from '../../../Model/Consulta';

@Component({
  selector: 'app-listar-consulta',
  templateUrl: './listar-consulta.component.html',
  styleUrls: ['./listar-consulta.component.css']
})

export class ListarConsultaComponent implements OnInit {
  constructor(private service: ListarConsultaService, router: Router) { }
  expedientes: Consulta[];
  ngOnInit() {
    this.service.getConsulta()
      .subscribe(Data => this.expedientes = Data);
  }
}
