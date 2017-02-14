using Newtonsoft.Json;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 用于Push中的 标签
    /// </summary>
    public class TagObj : BaseModel
    {
        public TagObj(string[] tag, string[] userid, bool istoall)
        {
            Tag = tag;
            UserId = userid;
            IsToAll = istoall;
        }

        /// <summary>
        /// 标签。（最多20个）
        /// </summary>
        public string[] Tag { get; set; }

        /// <summary>
        /// 如果填 userId 给 userId 发如果没有给 tag 发。（最多1000个）
        /// </summary>
        public string[] UserId { get; set; }

        [JsonProperty("is_to_all")]
        public bool IsToAll { get; set; }
    }
}
