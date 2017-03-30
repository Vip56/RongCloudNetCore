using Newtonsoft.Json;

namespace RongCloudNetCore.Messages
{
    public abstract class BaseMessage
    {
        [JsonIgnore]
        public virtual string TYPE { get; }

        public override string ToString()
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            jsetting.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(this, jsetting);
        }
    }
}
