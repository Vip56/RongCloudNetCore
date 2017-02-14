namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 资料通知消息，此类型消息没有 Push 通知
    /// </summary>
    public class ProfileNtfMessage : BaseMessage
    {
        public ProfileNtfMessage() { }

        public ProfileNtfMessage(string operation, string data, string extra)
        {
            Operation = operation;
            Data = data;
            Extra = extra;
        }

        public override string TYPE
        {
            get
            {
                return "RC:ProfileNtf";
            }
        }

        /// <summary>
        /// 资料通知操作，可以自行定义
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// 操作的数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 附加内容（如果开发者自己需要，可以自己在 App 端进行解析）
        /// </summary>
        public string Extra { get; set; }
    }
}
