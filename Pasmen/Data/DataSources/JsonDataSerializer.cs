using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pasmen.Data.DataSources
{
    public class JsonDataSerializer : IDataSerializer
    {
        public Dictionary<string, string> DeserializeData(string stringData)
        {
            var deserializedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringData);
            return deserializedData;
        }

        public string SerializeData(IDictionary<string, string> dictionary)
        {
            var serializedData = JsonConvert.SerializeObject(dictionary);
            return serializedData;
        }
    }
}
