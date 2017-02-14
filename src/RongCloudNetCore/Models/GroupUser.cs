namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 群组用户信息
    /// </summary>
    public class GroupUser : BaseModel
    {
        public GroupUser(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string Id { get; set; }
    }
}
