namespace Trackmatic.Planning.Framework
{
    public interface IStorable
    {
        
    }

    public interface IStorable<T> : IStorable where T : IVersionableSnapshot
    {
        T CreateSnapshot();
    }
}
