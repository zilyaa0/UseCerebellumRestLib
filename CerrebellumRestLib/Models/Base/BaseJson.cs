using Newtonsoft.Json;

namespace CerebellumRestLib.Models.Base
{
    public class JsonBase
    {
        public string ToJson(bool ignoreNulls = false)
        {
            return JsonConvert.SerializeObject(this, 
                new JsonSerializerSettings
                {
                    NullValueHandling = ignoreNulls 
                        ? NullValueHandling.Ignore 
                        : NullValueHandling.Include,
                });
        }
    }
}
