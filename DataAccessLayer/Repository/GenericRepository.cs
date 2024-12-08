using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        // This method deletes the given entity from the database.
        public void Delete(T entity)
        {
            using var context = new Context();
            context.Remove(entity);
            context.SaveChanges();
        }

        // This method retrieves all entities from the database.
        public List<T> GetList()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        // This method inserts the given entity into the database.
        public void Insert(T entity)
        {
            using var context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        // This method updates the given entity in the database.
        public void Update(T entity)
        {
            using var context = new Context();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}