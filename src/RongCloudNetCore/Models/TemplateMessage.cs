using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 模版消息对象
    /// </summary>
    public class TemplateMessage : BaseModel
    {
        public TemplateMessage(string fromUserId, string[] toUserId, string content, List<Dictionary<string, string>> values, string objectName, string[] pushContent, string[] pushData, int verifyBlacklist)
        {
            FromUserId = fromUserId;
            ToUserId = toUserId;
            Content = content;
            Values = values;
            ObjectName = objectName;
            PushContent = pushContent;
            PushData = pushData;
            VerifyBlacklist = verifyBlacklist;
        }

        /// <summary>
        /// 发送人用户 Id（必传）
        /// </summary>
        public string FromUserId { get; set; }

        /// <summary>
        /// 接收用户 Id，提供多个本参数可以实现向多人发送消息，上限为 1000 人。（必传）
        /// </summary>
        public string[] ToUserId { get; set; }

        /// <summary>
        /// 发送消息内容，内容中定义标识通过 values 中设置的标识位内容进行替换，参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。（必传）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 消息内容中，标识位对应内容。（必传）
        /// </summary>
        public List<Dictionary<string, string>> Values { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// 定义显示的 Push 内容，如果 objectName 为融云内置消息类型时，则发送后用户一定会收到 Push 信息。如果为自定义消息，定义显示的 Push 内容，内容中定义标识通过 values 中设置的标识位内容进行替换。如消息类型为自定义不需要 Push 通知，则对应数组传空值即可。（必传）
        /// </summary>
        public string[] PushContent { get; set; }

        /// <summary>
        /// 针对 iOS 平台为 Push 通知时附加到 payload 中，Android 客户端收到推送消息时对应字段名为 pushData。如不需要 Push 功能对应数组传空值即可。（可选）
        /// </summary>
        public string[] PushData { get; set; }

        /// <summary>
        /// 是否过滤发送人黑名单列表，0 为不过滤、 1 为过滤，默认为 0 不过滤。（可选）
        /// </summary>
        public int VerifyBlacklist { get; set; }
    }
}
