namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 聊天室被禁言用户信息
    /// </summary>
    public class GagChatRoomUser : BaseModel
    {
        public GagChatRoomUser(string time, string userId)
        {
            Time = time;
            UserId = userId;
        }

        /// <summary>
        /// 解禁时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 被封禁用户Id
        /// </summary>
        public string UserId { get; set; }
    }
}
