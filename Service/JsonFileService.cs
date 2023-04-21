using System.IO;
using System.Text.Json;

namespace dotnet.Service
{
    public class JsonFileService :IJsonFileService
    {
        public T ReadFromJsonFile<T>(string jsonFilePath)
        {
            var fileText = File.ReadAllText(jsonFilePath);
            var objectData = JsonSerializer.Deserialize<T>(fileText);
            return objectData;
        }

        public bool WriteToJsonFile(string jsonFilePath, object data)
        {
            if (File.Exists(jsonFilePath))
            {
                var searilizedData = JsonSerializer.Serialize(data, options: new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(jsonFilePath, searilizedData);
            }
            return true;
        }

    }
}
