namespace RongCloudNetCore.Models
{
    /// <summary>
    /// queryBlacklistUser返回结果
    /// </summary>
    public class QueryBlacklistUserReslut : BaseModel
    {
        public QueryBlacklistUserReslut(int code, string[] users, string errorMessage)
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
        /// 黑名单用户列表
        /// </summary>
        public string[] Users { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
