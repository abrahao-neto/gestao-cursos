namespace ApiGestaoCursos.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        void Post(TEntity entity);
        void Put(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(Guid? id);
        List<TEntity> GetAll();
    }
}
