import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ColaboradoresService } from '../../services/colaboradores.service';

@Component({
  selector: 'app-colaboradores',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './colaboradores.component.html',
  styleUrls: ['./colaboradores.component.scss'],
})
export class ColaboradoresComponent implements OnInit {
  colaboradores: any[] = [];
  editingColaborador: any = null;
  isEditing: boolean = false;
  newColaborador: any = { nome: '' }; 
  isCreating: boolean = false; 


  constructor(private colaboradoresService: ColaboradoresService) {}

  ngOnInit(): void {
    this.loadColaboradores();
  }

  loadColaboradores(): void {
    this.colaboradoresService.getColaboradores().subscribe({
      next: (data: any[]) => {
        this.colaboradores = data;
      },
      error: (err) => {
        console.error('Erro ao carregar colaboradores:', err);
      },
    });
  }

  toggleCreate(): void {
    this.isCreating = !this.isCreating;
    this.newColaborador = { nome: '' };
  }

  createColaborador(): void {
    if (this.newColaborador.nome) {
      this.colaboradoresService.createColaborador(this.newColaborador).subscribe({
        next: () => {
          this.loadColaboradores();
          this.toggleCreate();
        },
        error: (err) => {
          console.error('Erro ao criar colaborador:', err);
        },
      });
    }
  }


  startEdit(colaborador: any): void {
    this.isEditing = true;
    this.editingColaborador = { ...colaborador };
  }

  saveEdit(): void {
    if (this.editingColaborador) {
      this.colaboradoresService
        .updateColaborador(this.editingColaborador.id, this.editingColaborador)
        .subscribe({
          next: () => {
            this.isEditing = false;
            this.editingColaborador = null;
            this.loadColaboradores();
          },
          error: (err) => {
            console.error('Erro ao salvar alterações:', err);
          },
        });
    }
  }

  cancelEdit(): void {
    this.isEditing = false;
    this.editingColaborador = null;
  }

  deleteColaborador(colaboradorId: number): void {
    this.colaboradoresService.deleteColaborador(colaboradorId).subscribe({
      next: () => {
        this.loadColaboradores();
      },
      error: (err) => {
        console.error('Erro ao excluir colaborador:', err);
      },
    });
  }
}
