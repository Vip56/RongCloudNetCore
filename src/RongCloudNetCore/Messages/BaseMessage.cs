using Newtonsoft.Json;

namespace RongCloudNetCore.Messages
{
    public abstract class BaseMessage
    {
        public virtual string TYPE { get; }

        public override string ToString()
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
