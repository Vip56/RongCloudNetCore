using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// listGagChatroomUser返回结果
    /// </summary>
    public class ListGagChatroomUserReslut : BaseModel
    {
        public ListGagChatroomUserReslut(int code, List<GagChatRoomUser> users,string errorMesage)
        {
            Code = code;
            Users = users;
            ErrorMessage = errorMesage;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 聊天室被禁言用户列表
        /// </summary>
        public List<GagChatRoomUser> Users { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
