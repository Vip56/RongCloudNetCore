namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 位置消息
    /// </summary>
    public class LBSMessage : BaseMessage
    {
        public LBSMessage() { }

        public LBSMessage(string content, string extra, double latitude, double longitude, string poi)
        {
            Content = content;
            Extra = extra;
            Latitude = latitude;
            Longitude = longitude;
            Poi = poi;
        }

        public override string TYPE
        {
            get
            {
                return "RC:LBSMsg";
            }
        }

        /// <summary>
        /// 获取位置图片缩略图，格式为 JPG，以 Base64 进行 Encode 后需要将所有 \r\n 和 \r 和 \n 替换成空。
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附加信息(如果开发者自己需要，可以自己在 App 端进行解析)。
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 位置信息
        /// </summary>
        public string Poi { get; set; }
    }
}
