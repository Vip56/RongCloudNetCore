namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 聊天室信息
    /// </summary>
    public class ChatRoomInfo : BaseModel
    {
        public ChatRoomInfo(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// 聊天室Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 聊天室名称
        /// </summary>
        public string Name { get; set; }
    }
}
