namespace Trackmatic.Planning.Framework
{
    public interface IStorableVersion<T> where T : IVersionSnapshot
    {
        T CreateSnapshot();
    }
}
