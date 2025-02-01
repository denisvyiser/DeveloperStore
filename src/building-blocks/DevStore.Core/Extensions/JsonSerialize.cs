using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DevStore.Core.Extensions
{
    public static class JsonSerialize
    {
        public static string ToJson<T>(this T model) where T : class
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
