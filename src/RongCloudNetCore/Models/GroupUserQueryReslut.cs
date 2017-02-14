using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// groupUserQuery返回结果
    /// </summary>
    public class GroupUserQueryReslut : BaseModel
    {
        public GroupUserQueryReslut(int code, string id, List<GroupUser> users)
        {
            Code = code;
            Id = id;
            Users = users;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 群成员用户Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 群成员列表
        /// </summary>
        public List<GroupUser> Users { get; set; }
    }
}
