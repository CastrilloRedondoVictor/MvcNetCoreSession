using System.Text.Json;

namespace MvcNetCoreSession.Helpers
{
    public class HelperJsonSession
    {
        public static string ObjectToByte<T>(T objeto)
        {
            return JsonSerializer.Serialize(objeto);
        }

        public static T ByteToObject<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
