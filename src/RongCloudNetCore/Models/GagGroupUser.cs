namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 群组用户信息
    /// </summary>
    public class GagGroupUser : BaseModel
    {
        public GagGroupUser(string time, string userId)
        {
            Time = time;
            UserId = userId;
        }

        /// <summary>
        /// 解禁时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 群成员ID
        /// </summary>
        public string UserId { get; set; }
    }
}
