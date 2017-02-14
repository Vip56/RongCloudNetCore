namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 群组信息
    /// </summary>
    public class GroupInfo : BaseModel
    {
        public GroupInfo(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// 群组Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 群组名称
        /// </summary>
        public string Name { get; set; }
    }
}
