import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { WorkshopsService } from '../../services/workshops.service';
import { ColaboradoresService } from '../../services/colaboradores.service';

@Component({
  selector: 'app-workshops',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './workshops.component.html',
  styleUrls: ['./workshops.component.scss'],
})
export class WorkshopsComponent implements OnInit {
  workshops: any[] = [];
  colaboradores: any[] = [];
  editingWorkshop: any = null;
  isEditing: boolean = false;
  selectedColaboradorIds: number[] = []; 
  selectedWorkshop: any = null;
  isCreating: boolean = false; 
  newWorkshop: any = { nome: '', data: '', descricao: '', colaboradoresIds: [] };

  selectedColaboradores: any[] = [];


  constructor(
    private workshopsService: WorkshopsService,
    private colaboradoresService: ColaboradoresService
  ) {}

  //Carregar dados

  ngOnInit(): void {
    this.loadWorkshops();
    this.loadColaboradores();
  }
  //Carrega os workshops
  loadWorkshops(): void {
    this.workshopsService.getWorkshops().subscribe({
      next: (data: any[]) => {
        this.workshops = data.map((workshop) => ({
          ...workshop,
          colaboradores: workshop.colaboradores || [],
        }));
      },
      error: (err) => {
        console.error('Erro ao carregar workshops:', err);
      },
    });
  }
  
  
  toggleColaborador(colaboradorId: number, event: Event): void {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      // Adicionar o ID se estiver marcado
      this.selectedColaboradores.push(colaboradorId);
    } else {
      // Remover o ID se estiver desmarcado
      this.selectedColaboradores = this.selectedColaboradores.filter(
        (id) => id !== colaboradorId
      );
    }
  }
  
  
  
  // Carrega os colaboradores
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


  //Deleta os colaboradores
  deleteWorkshop(workshopId: number): void {
    this.workshopsService.deleteWorkshop(workshopId).subscribe({
      next: () => {
        this.loadWorkshops(); 
      },
      error: (err) => {
        console.error('Erro ao excluir workshop:', err);
      },
    });
  }
  

  selectWorkshop(workshopId: number): void {
    const selected = this.workshops.find((workshop) => workshop.id === workshopId);
    if (selected) {
      console.log('Workshop selecionado:', selected); 
      this.selectedWorkshop = selected;
    }
  }
  

  // Método para fechar os detalhes
  closeDetails(): void {
    this.selectedWorkshop = null;
  }


  startCreate(): void {
    this.isCreating = true;
    this.newWorkshop = { nome: '', data: '', descricao: '' };
  }

  cancelCreate(): void {
    this.isCreating = false;
    this.newWorkshop = {
      nome: '',
      data: '',
      descricao: '',
      colaboradoresIds: []
    };
    this.selectedColaboradores = []; // Resetar seleção de colaboradores
  }
  
  //Salva o novo workshop criado
  saveNewWorkshop(): void {
    if (!this.newWorkshop.nome || !this.newWorkshop.data || !this.newWorkshop.descricao) {
      alert('Preencha todos os campos!');
      return;
    }
  
    this.newWorkshop.colaboradoresIds = this.selectedColaboradores;
  
    this.workshopsService.createWorkshop(this.newWorkshop).subscribe({
      next: () => {
        this.loadWorkshops(); // Atualizar a lista de workshops
        this.cancelCreate(); // Resetar o formulário
      },
      error: (err) => {
        console.error('Erro ao criar workshop:', err);
      }
    });
  }
  
  
  


}
