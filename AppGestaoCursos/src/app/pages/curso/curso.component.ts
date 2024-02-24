import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Curso } from '@app/models/curso';
import { CursoService } from '@app/services/curso.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent {
  idCurso = 0;
  cursos: Curso[] = [];
  title = this.idCurso === 0 ? 'Cadastrar curso' : 'Edita curso';

  constructor(private cursoService: CursoService,) {

  }

  ngOnInit(): void {
    this.getCursos();
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

}
