import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule], 
  template: `
    <h1>Bem-vindo ao Gerenciador de Workshops</h1>
    <nav>
      <a routerLink="/colaboradores" routerLinkActive="active">Colaboradores</a>
      <a routerLink="/workshops" routerLinkActive="active">Workshops</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styleUrls: ['./app.component.css'],
})
export class AppComponent {}
