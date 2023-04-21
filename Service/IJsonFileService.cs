using System.Text.Json;

namespace dotnet.Service
{
    public interface IJsonFileService
    {
        public T ReadFromJsonFile<T>(string jsonFilePath);

        public bool WriteToJsonFile(string jsonFilePath, object data);
        
    }
}
