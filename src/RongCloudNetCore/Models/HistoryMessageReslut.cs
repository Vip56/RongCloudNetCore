namespace RongCloudNetCore.Models
{
    /// <summary>
    /// historyMessage返回结果
    /// </summary>
    public class HistoryMessageReslut : BaseModel
    {
        public HistoryMessageReslut(int code, string url, string date, string errorMessage)
        {
            Code = code;
            Url = url;
            Date = date;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 历史消息下载地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 历史记录时间（yyyymmddhh）
        /// </summary>
        public string Date { get; set; }
        
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
