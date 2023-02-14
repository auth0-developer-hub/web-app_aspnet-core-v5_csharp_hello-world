using System.Text.Json;

namespace App.Services
{
    public class JsonEncoder : IJsonEncoder
    {
        public string Encode<T>(T model)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(model, options);
        }
    }
}
