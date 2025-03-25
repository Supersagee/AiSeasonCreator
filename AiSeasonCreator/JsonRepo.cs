using AiSeasonCreator.Interfaces;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AiSeasonCreator
{
    public class JsonRepo : IJsonRepo
    {
        public T Load<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public void Save<T>(string filePath, T data)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(data, jsonOptions);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
