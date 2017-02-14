namespace RongCloudNetCore.Models
{
    /// <summary>
    /// checkOnlineUser返回结果
    /// </summary>
    public class CheckOnlineReslut : BaseModel
    {
        public CheckOnlineReslut(int code, string status, string errorMessage)
        {
            Code = code;
            Status = status;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 在线状态，1为在线，0为不在线
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
