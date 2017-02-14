using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// listWordfilter返回结果
    /// </summary>
    public class ListWordfilterReslut : BaseModel
    {
        public ListWordfilterReslut(int code, string word, string errorMessage)
        {
            Code = code;
            Word = word;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 敏感词内容
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
