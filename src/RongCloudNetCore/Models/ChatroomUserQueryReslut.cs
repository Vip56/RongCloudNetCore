using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// chatroomUserQuery 返回结果
    /// </summary>
    public class ChatroomUserQueryReslut : BaseModel
    {
        public ChatroomUserQueryReslut(int code, int total, List<ChatRoomUser> users, string errorMessage)
        {
            Code = code;
            Total = total;
            Users = users;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 聊天室中用户数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 聊天室成员列表
        /// </summary>
        public List<ChatRoomUser> Users { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
