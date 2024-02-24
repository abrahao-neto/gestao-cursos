using ApiGestaoCursos.Application.Models;

namespace ApiGestaoCursos.Application.interfaces.Services
{
    public interface ICursoAppService
    {
        CursoGetModel Cadastrar(CursoPostModel model);
        CursoGetModel Atualizar(CursoPutModel model);
        List<CursoGetModel> GetAll();
        CursoGetModel GetById(Guid? id);
        CursoGetModel Excluir(CursoGetModel model);
    }
}
