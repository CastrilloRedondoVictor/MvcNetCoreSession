using System.Text.Json;
using MvcNetCoreSession.Helpers;

namespace MvcNetCoreSession.Extensions
{
    public static class SessionExtension
    {

        public static T GetObject<T>(this ISession session, string key)
        {
            string data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return HelperJsonSession.ByteToObject<T>(data);
        }

        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, HelperJsonSession.ObjectToByte(value));
        }
    }
}
