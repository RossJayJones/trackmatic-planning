namespace Trackmatic.Planning.Framework
{
    public interface IVersion<out T>
    {
        T Edit(UserReference user);
    }
}
