using Newtonsoft.Json;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 按操作系统类型推送消息内容，如 platform 中设置了给 ios 和 android 系统推送消息，而在 notification 中只设置了 ios 的推送内容，则 android 的推送内容为最初 alert 设置的内容。（非必传）
    /// </summary>
    public class Notification : BaseModel
    {
        public Notification(string alert, PlatformNotification ios, PlatformNotification android)
        {
            Alert = alert;
            IOS = ios;
            Android = android;
        }

        /// <summary>
        ///  默认推送消息内容，如填写了 ios 或 android 下的 alert 时，则推送内容以对应平台系统的 alert 为准。（必传）
        /// </summary>
        public string Alert { get; set; }

        /// <summary>
        /// 设置 iOS 平台下的推送及附加信息
        /// </summary>
        [JsonProperty("ios")]
        public PlatformNotification IOS { get; set; }

        /// <summary>
        /// 设置 Android 平台下的推送及附加信息
        /// </summary>
        public PlatformNotification Android { get; set; }
    }
}
