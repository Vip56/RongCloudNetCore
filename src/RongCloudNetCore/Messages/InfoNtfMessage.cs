namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 提示条（小灰条）通知消息，此类型消息没有Push通知。
    /// </summary>
    public class InfoNtfMessage : BaseMessage
    {
        public InfoNtfMessage() { }

        public InfoNtfMessage(string message, string extra)
        {
            Message = message;
            Extra = extra;
        }

        public override string TYPE
        {
            get
            {
                return "RC:InfoNtf";
            }
        }

        /// <summary>
        /// 提示条消息内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        public string Extra { get; set; }
    }
}
