using ApiGestaoCursos.Domain.Interfaces.Repositories;
using ApiGestaoCursos.Infra.Data.Contexts;

namespace ApiGestaoCursos.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public void Post(T entity)
        {
            using (var context = new DataContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Put(T entity)
        {
            using (var context = new DataContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new DataContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(Guid? id)
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().Find(id);
            }
        }
    }
}
