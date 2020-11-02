import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private router: Router) { }

  Listar() {
    this.router.navigate(["ListarExpediente"]);
    this.router.navigate(["ListarReceta"]);
    this.router.navigate(["ListarMedico"]);
    this.router.navigate(["ListarConsulta"]);
  }
}
