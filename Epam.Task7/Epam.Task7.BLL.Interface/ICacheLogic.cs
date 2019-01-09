namespace Epam.Task7.BLL.Interface
{
    public interface ICacheLogic
    {
        bool Add<T>(string key, T value);

        T Get<T>(string key);

        bool Delete(string key);
    }
}
