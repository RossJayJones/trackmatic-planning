namespace Trackmatic.Planning.Framework
{
    public interface IStorable
    {
        
    }

    public interface IStorable<T, TS> : IStorable where TS : IVersionSnapshot where T : ISnapshot<TS>
    {
        T CreateSnapshot();
    }
}
