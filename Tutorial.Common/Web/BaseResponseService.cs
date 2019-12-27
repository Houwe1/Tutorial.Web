using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Common.Web
{
    //
    // 摘要:
    //     /// 公共响应服务类 ///
    public class BaseResponseService
    {
        //
        // 摘要:
        //     /// 成功返回参数 ///
        //
        // 参数:
        //   body:
        //
        //   msg:
        //     成功描述
        //
        // 类型参数:
        //   T:
        //     返回类型
        public Response<T> OkResult<T>(T body, string msg = "执行成功")
        {
            return new Response<T>
            {
                IsSucess = true,
                StateCode = 200,
                ResultMsg = msg,
                Body = body
            };
        }

        //
        // 摘要:
        //     /// 执行成功，无预期结果 ///
        //
        // 参数:
        //   body:
        //
        //   msg:
        //     成功描述
        //
        // 类型参数:
        //   T:
        //     返回类型
        public Response<T> WarnResult<T>(T body, string msg = "")
        {
            return new Response<T>
            {
                IsSucess = true,
                StateCode = 201,
                ResultMsg = (string.IsNullOrEmpty(msg) ? "执行成功，无预期结果" : msg),
                Body = body
            };
        }

        //
        // 摘要:
        //     /// 失败返回参数 ///
        public Response<T> FailResult<T>(T body)
        {
            return new Response<T>
            {
                IsSucess = false,
                StateCode = 500,
                ResultMsg = "程序异常",
                Body = body
            };
        }

        //
        // 摘要:
        //     /// 自定义响应结果 ///
        //
        // 参数:
        //   body:
        //     结果
        //
        //   code:
        //     响应代码
        //
        //   msg:
        //     响应文案
        //
        // 类型参数:
        //   T:
        public Response<T> CustomResult<T>(T body, int code, string msg)
        {
            return new Response<T>
            {
                IsSucess = true,
                StateCode = code,
                ResultMsg = msg,
                Body = body
            };
        }
        //
        // 摘要:
        //     /// 参数验证不通过（统一错误编码401） ///
        //
        // 参数:
        //   body:
        //     结果
        //
        //   msg:
        //     响应文案
        //
        // 类型参数:
        //   T:
        public Response<T> InvalidArgsResult<T>(string msg, T body = default(T))
        {
            return new Response<T>
            {
                IsSucess = true,
                StateCode = 401,
                ResultMsg = msg,
                Body = body
            };
        }
    }
}
