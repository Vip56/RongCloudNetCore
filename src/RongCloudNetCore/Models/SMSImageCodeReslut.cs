namespace RongCloudNetCore.Models
{
    /// <summary>
    /// getImageCode 成功返回结果
    /// </summary>
    public class SMSImageCodeReslut : BaseModel
    {
        public SMSImageCodeReslut(int code, string url, string verifyId, string errorMessage)
        {
            Code = code;
            Url = url;
            VerifyId = verifyId;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200 为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回的图片验证码 URL 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 返回图片验证标识 Id
        /// </summary>
        public string VerifyId { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
