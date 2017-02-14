namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TxtMessage : BaseMessage
    {
        public TxtMessage() { }

        public TxtMessage(string content, string extra)
        {
            Content = content;
            Extra = extra;
        }

        public override string TYPE
        {
            get
            {
                return "RC:TxtMsg";
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附加信息(如果开发者自己需要，可以自己在 App 端进行解析)
        /// </summary>
        public string Extra { get; set; }
    }
}
