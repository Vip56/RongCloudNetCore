using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// 用于Push中的message
    /// </summary>
    public class MsgObj : BaseModel
    {
        public MsgObj(string content, string objectName)
        {
            Content = content;
            ObjectName = objectName;
        }

        /// <summary>
        /// Push消息中的消息体
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 聊天室名称
        /// </summary>
        public string ObjectName { get; set; }
    }
}
