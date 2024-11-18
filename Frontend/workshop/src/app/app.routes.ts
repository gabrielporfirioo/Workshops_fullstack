import { Routes } from '@angular/router';
import { ColaboradoresComponent } from './components/colaboradores/colaboradores.component';
import { WorkshopsComponent } from './components/workshops/workshops.component';

export const routes: Routes = [
  { path: '', redirectTo: '/workshops', pathMatch: 'full' },
  { path: 'colaboradores', component: ColaboradoresComponent },
  { path: 'workshops', component: WorkshopsComponent },
];
