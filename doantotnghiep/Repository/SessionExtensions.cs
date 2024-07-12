using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication2.Repository
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sesionData = session.GetString(key);
            return sesionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sesionData);
        }
    }
}
