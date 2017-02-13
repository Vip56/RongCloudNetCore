namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 自定义消息
    /// </summary>
    public class CustomTxtMessage : BaseMessage
    {
        public CustomTxtMessage() { }

        public CustomTxtMessage(string content)
        {
            Content = content;
        }

        public override string TYPE
        {
            get
            {
                return "RC:TxtMsg";
            }
        }

        public string Content { get; set; }
    }
}
