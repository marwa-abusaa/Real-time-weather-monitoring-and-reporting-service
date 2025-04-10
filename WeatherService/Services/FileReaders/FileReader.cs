using WeatherService.Models;

namespace WeatherService.Services.FileReaders
{
    public class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
