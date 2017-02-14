namespace RongCloudNetCore.Models
{
    /// <summary>
    /// SMSSendCodeReslut 成功返回结果
    /// </summary>
    public class SMSSendCodeReslut : BaseModel
    {
        public SMSSendCodeReslut(int code, string sessionId, string errorMessage)
        {
            Code = code;
            SessionId = sessionId;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200 为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 短信验证码唯一标识
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
