using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Repositories;
using ApiGestaoCursos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoCursos.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public List<Aluno> GetAlunos()
        {
            using (var context = new DataContext())
            {
                return context.Set<Aluno>().OrderBy(a => a.Nome).Include(c => c.Curso).ToList();
            }
        }

        public string GetEmail(string email)
        {
            using (var context = new DataContext())
            {
                var aluno = context.Set<Aluno>().Where(a => a.Email == email).FirstOrDefault();

                return aluno?.Email;
            }
        }

        public Aluno AtivaAluno(Guid id)
        {
            using (var context = new DataContext())
            {
                var aluno = context.Set<Aluno>().Where(a => a.Id == id).FirstOrDefault();

                aluno.Ativo = !aluno.Ativo;

                context.Update(aluno);
                context.SaveChanges();

                return context.Set<Aluno>().Where(a => a.Id == id).Include(c => c.Curso).FirstOrDefault();
            }
        }
    }
}
