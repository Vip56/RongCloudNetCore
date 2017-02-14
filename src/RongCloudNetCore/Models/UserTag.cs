namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 用于打标签的对象
    /// </summary>
    public class UserTag : BaseModel
    {
        public UserTag(string[] tags, string userId)
        {
            Tags = tags;
            UserId = userId;
        }

        /// <summary>
        /// 用户标签，一个用户最多添加 20 个标签，每个 tags 最大不能超过 40 个字节，标签中不能包含特殊字符。（必传）
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// 用户 Id
        /// </summary>
        public string UserId { get; set; }
    }
}
