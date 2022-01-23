using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeDevelopmentPlatform.Common
{
    public class ReturnResult<T>
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public State State { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }

    }

    public enum State
    {
        Success=200,
        Fail=500
    }
}
