namespace Trackmatic.Planning.Framework
{
    public interface IStorage<T> where T : IStorable
    {
        void Store(T item);

        T Get(string id);
    }
}
