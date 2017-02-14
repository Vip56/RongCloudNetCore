namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 聊天室信息
    /// </summary>
    public class ChatRoom : BaseModel
    {
        public ChatRoom(string chrmId, string name, string time)
        {
            ChrmId = chrmId;
            Name = name;
            Time = time;
        }

        /// <summary>
        /// 聊天室ID
        /// </summary>
        public string ChrmId { get; set; }

        /// <summary>
        /// 聊天室名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 聊天室创建时间
        /// </summary>
        public string Time { get; set; }
    }
}
