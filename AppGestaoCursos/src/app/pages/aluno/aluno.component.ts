import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Aluno } from '@app/models/aluno';
import { AlunoService } from '@app/services/aluno.service';
import { CadastroAlunoComponent } from './cadastro-aluno/cadastro-aluno.component';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit {
  alunos: Aluno[] = [];
  alunosFiltrado: Aluno[] = [];
  alunoSelecionado: Aluno | null = null;
  cad: boolean = false;
  id: number = 0;
  title: string = '';
  _filtroLista: string = '';
  alunosPorPagina = 5; // Número de alunos exibidos por página
  currentPage = 1; // Página atual

  constructor(private alunoService: AlunoService, private cadastro: CadastroAlunoComponent) {}

  ngOnInit(): void {
    this.getAlunos();
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.alunosFiltrado = this.filtroLista ? this.filtrarAlunos(this.filtroLista) : this.alunos;

  }

  public filtrarAlunos(filtrarPor: string): Aluno[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.alunos.filter((aluno: any) => {
      return (
        aluno.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        aluno.email.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        aluno.curso.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    });
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  get totalPages(): number {
    return Math.ceil(this.alunosFiltrado.length / this.alunosPorPagina);
  }

  getPagesArray(): number[] {
    return Array(this.totalPages).fill(0).map((_, index) => index + 1);
  }

  get alunosPaginados(): Aluno[] {
    const startIndex = (this.currentPage - 1) * this.alunosPorPagina;
    const endIndex = startIndex + this.alunosPorPagina;
    return this.alunosFiltrado.slice(startIndex, endIndex);
  }

   onItemsPerPageChange(valor: any) {
    this.alunosPorPagina = parseInt(valor.value, 10);
  }

  getAlunos(): void {
    //debugger
    this.alunoService.getAll().subscribe({
      next: (data) => {
        this.alunos = data;
        this.alunosFiltrado = this.alunos;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  alternarAtivo(id: string, i: number) {
    // debugger;
    this.alunos[i].ativo = !this.alunos[i].ativo;
    this.alunoService.ativarAluno(id).subscribe({
      next: (data) => {
        console.log(data);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onNovo() {
    //debugger;
    this.cad = true;
    this.title = 'Cadastrar Aluno';
    this.alunoSelecionado = null;
  }

  onEditar(aluno: Aluno) {
    //debugger;
    this.cad = false;
    this.title = 'Editar Aluno';
    this.alunoSelecionado = aluno;
  }
}
