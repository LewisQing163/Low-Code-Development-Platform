using System;
namespace LowCodeDevelopmentPlatform.Common
{
    /// <summary>
    /// 服务层响应实体
    /// </summary>
    public class ServiceResult<T>
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success => Code == ServiceResultCode.Succeed;

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void IsFailed(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exexception></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void IsFailed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = ServiceResultCode.Failed;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void IsSuccess(T result, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }

    }

    /// <summary>
    /// 服务层响应码枚举
    /// </summary>
    public enum ServiceResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 200,

        /// <summary>
        /// 失败
        /// </summary>
        Failed = 500,

    }
}
