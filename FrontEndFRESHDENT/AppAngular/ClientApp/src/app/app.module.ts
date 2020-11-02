import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ButtonAdd } from './Components/Button/ButtonComponents';
import { ListarExpedienteService } from 'src/app/Services/listar-expediente.services';
import { ListarRecetaService } from 'src/app/Services/listar-receta.services';
import { ListarMedicoService } from 'src/app/Services/listar-medico.services';
import { ListarConsultaService } from 'src/app/Services/listar-consulta.services';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ButtonAdd
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'ListarExpediente', component: ListarExpedienteComponent },
      { path: 'ListarReceta', component: ListarRecetaComponent },
      { path: 'ListarMedico', component: ListarMedicoComponent },
      { path: 'ListarConsulta', component: ListarConsultaComponent },
    ])
  ],
  providers: [ListarExpedienteService, ListarRecetaService, ListarMedicoService, ListarConsultaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
