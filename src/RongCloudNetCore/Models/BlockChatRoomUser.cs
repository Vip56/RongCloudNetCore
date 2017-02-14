namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 聊天室被封禁用户信息。
    /// </summary>
    public class BlockChatRoomUser : BaseModel
    {
        public BlockChatRoomUser(string id, string time)
        {
            Id = id;
            Time = time;
        }

        /// <summary>
        /// 聊天室用户Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 加入聊天室时间
        /// </summary>
        public string Time { get; set; }
    }
}
