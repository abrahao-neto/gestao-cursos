import { Curso } from "./curso";

export class Aluno {
  id: string;
  nome: string;
  data_Nascimento: string;
  email: string;
  curso: Curso;
  ativo: boolean;
  data_Criacao: string;
  data_Atualizacao: string;
}
