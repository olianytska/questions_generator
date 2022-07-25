namespace PL.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Delete(T item);
        void Update(T item);
        IEnumerable<T> GetAllItems();
        void Dispose();
    }
}
