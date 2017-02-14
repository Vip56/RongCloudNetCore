using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// lisitGagGroupUser 返回结果
    /// </summary>
    public class ListGagGroupUserReslut : BaseModel
    {
        public ListGagGroupUserReslut(int code, List<GagGroupUser> users, string errorMessage)
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
        /// 群组被禁言用户列表
        /// </summary>
        public List<GagGroupUser> Users { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
