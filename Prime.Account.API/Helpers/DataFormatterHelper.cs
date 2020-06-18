using Newtonsoft.Json;

namespace Prime.Account.API.Helpers
{
    public static class DataFormatterHelper
    {
        public static T RemoveReferenceLooping<T>(T model)
        {
            var rawJson = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return JsonConvert.DeserializeObject<T>(rawJson);
        }
    }
}