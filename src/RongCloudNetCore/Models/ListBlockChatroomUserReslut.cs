using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// listBlockChatroomUser返回结果
    /// </summary>
    public class ListBlockChatroomUserReslut : BaseModel
    {
        public ListBlockChatroomUserReslut(int code, List<BlockChatRoomUser> users, string errorMessage)
        {
            Code = code;
            Users = users;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 被封禁用户列表
        /// </summary>
        public List<BlockChatRoomUser> Users { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
