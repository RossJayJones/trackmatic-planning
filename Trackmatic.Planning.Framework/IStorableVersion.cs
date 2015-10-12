namespace Trackmatic.Planning.Framework
{
    public interface IStorableVersion<out T> where T : IVersionSnapshot
    {
        T CreateSnapshot();
    }
}
