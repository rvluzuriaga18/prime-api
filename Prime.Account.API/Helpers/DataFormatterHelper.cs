using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Prime.Account.API.Helpers
{
    public static class DataFormatterHelper
    {
        public static string ConvertPascalToCamelCase<T>(T model)
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            };

            return JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
        }
    }
}