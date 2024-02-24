using ApiGestaoCursos.Application.Models;

namespace ApiGestaoCursos.Application.interfaces.Services
{
    public interface IAlunoAppService
    {
        AlunoGetModel Cadastrar(AlunoPostModel model);
        AlunoGetModel Atualizar(AlunoPutModel model);
        List<AlunoGetModel> GetAll();
        List<AlunoGetModel> GetAlunos();
        AlunoGetModel GetById(Guid id);
        AlunoGetModel Excluir(AlunoGetModel model);
        AlunoGetModel AtivarAluno(Guid id);
    }
}
