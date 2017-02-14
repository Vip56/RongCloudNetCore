namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 聊天室用户信息
    /// </summary>
    public class ChatRoomUser : BaseModel
    {
        public ChatRoomUser(string id, string time)
        {
            Id = id;
            Time = time;
        }

        /// <summary>
        /// 聊天室用户ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 加入聊天室时间
        /// </summary>
        public string Time { get; set; }
    }
}
