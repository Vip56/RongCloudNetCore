using System.Collections.Generic;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 设备中的推送内容。（非必传）
    /// </summary>
    public class PlatformNotification : BaseModel
    {
        public PlatformNotification(string alert, Dictionary<string,string> extras)
        {
            Alert = alert;
            Extras = extras;
        }

        /// <summary>
        /// 默认推送消息内容，如填写了 ios 或 android 下的 alert 时，则推送内容以对应平台系统的 alert 为准。（必传）
        /// </summary>
        public string Alert { get; set; }

        /// <summary>
        /// ios 或 android 不同平台下的附加信息，如果开发者自己需要，可以自己在 App 端进行解析。（非必传）
        /// </summary>
        public Dictionary<string, string> Extras { get; set; }
    }
}
