using Newtonsoft.Json;

namespace RongCloudNetCore.Models
{
    public abstract class BaseModel
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
