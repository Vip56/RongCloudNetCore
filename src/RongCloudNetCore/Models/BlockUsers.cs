namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 封禁用户信息
    /// </summary>
    public class BlockUsers : BaseModel
    {
        public BlockUsers(string userId, string blockEndTime)
        {
            UserId = userId;
            BlockEndTime = blockEndTime;
        }

        /// <summary>
        /// 被封禁用户 ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 封禁结束时间
        /// </summary>
        public string BlockEndTime { get; set; }
    }
}
