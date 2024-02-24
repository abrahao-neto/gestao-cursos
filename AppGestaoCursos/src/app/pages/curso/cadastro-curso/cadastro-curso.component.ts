import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Curso } from '@app/models/curso';
import { CursoService } from '@app/services/curso.service';

@Component({
  selector: 'app-cadastro-curso',
  templateUrl: './cadastro-curso.component.html',
  styleUrls: ['./cadastro-curso.component.css']
})
export class CadastroCursoComponent {

  form: FormGroup;
  curso = new Curso();

  constructor(private cursoService: CursoService) { }

  ngOnInit(): void {
    this.initialForm();
  }

  get f(): any {
    return this.form.controls;
  }



  initialForm() {
    this.form = new FormGroup({
      nome: new FormControl('', Validators.required),
      descricao: new FormControl('', Validators.required),
      data_inicio: new FormControl('', Validators.required),
      data_fim: new FormControl('', Validators.required),
    });
  }

  onSubmit(): void {
    debugger;
    this.curso = this.form.value;

    this.cursoService.cadastro(this.curso).subscribe({
      next: (data) => {
        console.log(data);
        alert('Curso cadastrado com sucesso!');
        this.form.reset();
        location.reload();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

}
