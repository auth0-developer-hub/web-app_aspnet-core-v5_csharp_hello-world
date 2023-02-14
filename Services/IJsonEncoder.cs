namespace App.Services
{
    public interface IJsonEncoder
    {
        string Encode<T>(T model);
    }
}
