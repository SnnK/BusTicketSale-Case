using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OBiletCase.Web.Extentions
{
    public static class SessionExtention
    {
        public static void SetObject(this ISession Session, string key, object Object)
        {
            
            var json = JsonConvert.SerializeObject(Object);
            Session.SetString(key, json);
        }

        public static T GetObject<T>(this ISession Session, string key) where T : class, new()
        {
            var data = Session.GetString(key);

            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            var deserializedData = JsonConvert.DeserializeObject<T>(data);

            return deserializedData;
        }
    }
}
