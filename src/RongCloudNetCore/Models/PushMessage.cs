namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 不落地 push 消息体
    /// </summary>
    public class PushMessage : BaseModel
    {
        public PushMessage(string[] platform, string fromuserid, TagObj audience, MsgObj message, Notification notification)
        {
            Platform = platform;
            Fromuserid = fromuserid;
            Audience = audience;
            Message = message;
            Notification = notification;
        }

        /// <summary>
        /// 目标操作系统。（iOS、Android）。（必传）
        /// </summary>
        public string[] Platform { get; set; }

        /// <summary>
        /// 发送用户Id（必传）
        /// </summary>
        public string Fromuserid { get; set; }

        /// <summary>
        /// 推送条件，包括： tag 、 userid 、 is_to_all。（必传）
        /// </summary>
        public TagObj Audience { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public MsgObj Message { get; set; }

        /// <summary>
        /// 按操作系统类型推送消息内容，如 platform 中设置了给 ios 和 android 系统推送消息，而在 notification 中只设置了 ios 的推送内容，则 android 的推送内容为最初 alert 设置的内容。
        /// </summary>
        public Notification Notification { get; set; }
    }
}
