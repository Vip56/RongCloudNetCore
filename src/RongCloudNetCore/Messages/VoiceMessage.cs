namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceMessage : BaseMessage
    {
        public VoiceMessage() { }

        public VoiceMessage(string content, string extra, long duration)
        {
            Content = content;
            Extra = extra;
            Duration = duration;
        }

        public override string TYPE
        {
            get
            {
                return "RC:VcMsg";
            }
        }

        /// <summary>
        /// 表示语音内容，格式为 AMR，以 Base64 进行 Encode 后需要将所有 \r\n 和 \r 和 \n 替换成空，大小不超过 60k，duration 表示语音长度，最长为 60 秒。
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附加信息(如果开发者自己需要，可以自己在 App 端进行解析)。
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public long Duration { get; set; }
    }
}
