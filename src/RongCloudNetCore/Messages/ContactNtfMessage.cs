namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 添加联系人消息
    /// </summary>
    public class ContactNtfMessage : BaseMessage
    {
        public ContactNtfMessage(string operation, string extra, string sourceUserId, string targetUserId, string message)
        {
            Operation = operation;
            Extra = extra;
            SourceUserId = sourceUserId;
            TargetUserId = targetUserId;
            Message = message;
        }

        public override string TYPE
        {
            get
            {
                return "RC:ContactNtf";
            }
        }

        /// <summary>
        /// 操作名
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// 附加信息（如果开发者自己需要，可以自己在App端进行解析）
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// 请求者的UserId
        /// </summary>
        public string SourceUserId { get; set; }

        /// <summary>
        /// 响应者的UserId
        /// </summary>
        public string TargetUserId { get; set; }

        /// <summary>
        /// 请求或者响应消息
        /// </summary>
        public string Message { get; set; }
    }
}
