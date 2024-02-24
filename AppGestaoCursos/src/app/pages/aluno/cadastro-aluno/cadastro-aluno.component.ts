import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Aluno } from '@app/models/aluno';
import { Curso } from '@app/models/curso';
import { AlunoService } from '@app/services/aluno.service';
import { CursoService } from '@app/services/curso.service';

@Component({
  selector: 'app-cadastro-aluno',
  templateUrl: './cadastro-aluno.component.html',
  styleUrls: ['./cadastro-aluno.component.css']
})
export class CadastroAlunoComponent implements OnInit, OnChanges  {
  @Input() cadastrar = 'Cadastrar Aluno';
  @Input() alunoSel: Aluno | null = null;
  cursos: Curso[] = [];
  form: FormGroup;
  aluno = new Aluno();
  alunoEdicao = new Aluno();

  constructor(private cursoService: CursoService, private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.initialForm();
    this.getCursos();
  }

  get f(): any {
    return this.form.controls;
  }

  getCursos() {
    this.cursoService.getAll().subscribe({
      next: (data) => {
        this.cursos = data as Curso[];
      },
      error: (e) => {
        console.log(e)
      }
    });
  }

  initialForm() {
    //debugger;
    this.form = new FormGroup({
      nome: new FormControl('', Validators.required),
      data_nascimento: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      cursoId: new FormControl('', Validators.required),
    });
  }

  onSubmit(): void {
    debugger;

    if (this.aluno.id === undefined) {
      this.aluno = this.form.value;
      this.alunoService.cadastro(this.aluno).subscribe({
        next: (data) => {
          console.log(data);
          alert('Aluno cadastrado com sucesso!');
          this.form.reset();
          location.reload();
        },
        error: (err) => {
          console.log(err);
          if (err.status === 500) {
            alert('O email já esta cadastrado no sistema, tente outro.')
          }
        }
      });
    } else {
      this.aluno = this.form.value;
      this.aluno.id = this.alunoEdicao.id;
      this.aluno.data_Criacao = this.alunoEdicao.data_Criacao;
      this.aluno.data_Atualizacao = this.alunoEdicao.data_Atualizacao;
      this.aluno.ativo = this.alunoEdicao.ativo;

      this.alunoService.editar(this.aluno).subscribe({
        next: (data) => {
          console.log(data);
          alert('Aluno atualizado com sucesso!');
          this.form.reset();
          location.reload();
        },
        error: (err) => {
          console.log(err);
          if (err.status === 500) {
            alert('O email já esta cadastrado no sistema, tente outro.')
          }
        }
      });
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    //debugger;
    if (changes['alunoSel'] && changes['alunoSel'].currentValue) {
      this.aluno = changes['alunoSel'].currentValue as Aluno;
      this.alunoEdicao = this.aluno;
      this.form.patchValue({
        nome: this.aluno.nome,
        data_nascimento: this.aluno.data_Nascimento,
        email: this.aluno.email,
        cursoId: this.aluno.curso.id
      });
    } else {
      this.initialForm();
    }
  }
}
