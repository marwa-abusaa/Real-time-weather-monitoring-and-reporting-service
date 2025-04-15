
namespace WeatherService.Models
{
    public interface IFileReader
    {
        string ReadAllText(string path);
    }
}
