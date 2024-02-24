import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoComponent } from './pages/aluno/aluno.component';
import { CursoComponent } from './pages/curso/curso.component';

const routes: Routes = [
  { path: '', component: AlunoComponent },
  { path: 'cursos', component: CursoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
