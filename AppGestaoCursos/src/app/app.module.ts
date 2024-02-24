import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunoComponent } from './pages/aluno/aluno.component';
import { CursoComponent } from './pages/curso/curso.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { NavigateComponent } from './components/navigate/navigate.component';
import { CadastroAlunoComponent } from './pages/aluno/cadastro-aluno/cadastro-aluno.component';
import { CadastroCursoComponent } from './pages/curso/cadastro-curso/cadastro-curso.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent,
    CursoComponent,
    NavigateComponent,
    CadastroAlunoComponent,
    CadastroCursoComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
  ],
  exports: [],
  providers: [CadastroAlunoComponent, AlunoComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
