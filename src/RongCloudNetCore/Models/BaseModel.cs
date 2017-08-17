using Newtonsoft.Json;

namespace RongCloudNetCore.Models
{
    public abstract class BaseModel
    {
        public override string ToString()
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            jsetting.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(this, jsetting);
        }
    }
}
