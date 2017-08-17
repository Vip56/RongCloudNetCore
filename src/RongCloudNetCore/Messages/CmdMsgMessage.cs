namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 通用命令通知消息，此类型消息没有Push通知，与通用命令通知消息的区别是不存储、不计数。
    /// </summary>
    public class CmdMsgMessage : BaseMessage
    {
        public CmdMsgMessage(string name,string data)
        {
            Name = name;
            Data = data;
        }

        public override string TYPE
        {
            get
            {
                return "RC:CmdMsg";
            }
        }

        public string Name { get; set; }

        public string Data { get; set; }
    }
}
