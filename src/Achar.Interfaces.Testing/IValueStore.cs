namespace Achar.Interfaces.Testing
{
    public interface IValueStore
    {
        void SetValue(
            string key,
            string value
        );

        string GetValue(
            string key
        );
    }
}