namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 通用命令通知消息，此类型消息没有Push通知。
    /// </summary>
    public class CmdNtfMessage : BaseMessage
    {
        public CmdNtfMessage(string name, string data)
        {
            Data = data;
            Name = name;
        }

        public override string TYPE
        {
            get
            {
                return "RC:CmdNtf";
            }
        }

        public string Name { get; set; }

        public string Data { get; set; |}
    }
}
