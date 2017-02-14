using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// chatroomQuery 返回结果
    /// </summary>
    public class ChatroomQueryReslut : BaseModel
    {
        public ChatroomQueryReslut(int code, List<ChatRoom> chatRooms, string errorMessage)
        {
            Code = code;
            ChatRooms = chatRooms;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码：200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 聊天室信息数组
        /// </summary>
        public List<ChatRoom> ChatRooms { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
