using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Common.Web
{
    //
    // 摘要:
    //     /// 响应契约实体 ///
    public class Response<T>
    {
        //
        // 摘要:
        //     /// 是否执行成功 ///
        public bool IsSucess
        {
            get;
            set;
        } = true;


        //
        // 摘要:
        //     /// 状态码 ///
        public int StateCode
        {
            get;
            set;
        } = 200;


        //
        // 摘要:
        //     /// 结果信息 ///
        public string ResultMsg
        {
            get;
            set;
        } = "success";


        //
        // 摘要:
        //     /// 自定义消息 ///
        public string SubMsg
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 接口调用时长 ///
        public string ServiceTime
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 响应数据 ///
        public T Body
        {
            get;
            set;
        }

        //
        // 摘要:
        //     /// 响应契约实体 ///
        //
        // 参数:
        //   status:
        //     状态
        //
        //   msg:
        //     消息
        //
        //   body:
        //     泛型数据
        public Response(int status, string msg, T body)
        {
            StateCode = status;
            ResultMsg = msg;
            Body = body;
        }

        //
        // 摘要:
        //     /// 无参构造函数 ///
        public Response()
        {
        }
    }
}
