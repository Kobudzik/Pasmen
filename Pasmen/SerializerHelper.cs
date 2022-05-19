using Newtonsoft.Json;

namespace Pasman
{
    public static class SerializerHelper
    {
        public static T DeserializeJson<T>(string data)
        {
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }

        public static string SerializeJson<T>(T data)
        {
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        //serialize XML
        //deserialize XML
    }
}