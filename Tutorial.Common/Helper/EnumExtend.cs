using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Tutorial.Common.Helper
{
    //
    // 摘要:
    //     /// 枚举扩展类 ///
    public static class EnumExtend
    {
        //
        // 摘要:
        //     /// 返回枚举描述 ///
        //
        // 参数:
        //   en:
        //     枚举
        //
        // 返回结果:
        //     枚举描述
        public static string GetDesc(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] member = type.GetMember(en.ToString());
            if (member != null && member.Length != 0)
            {
                DescriptionAttribute[] array = member[0].GetCustomAttributes(typeof(DescriptionAttribute), inherit: false) as DescriptionAttribute[];
                if (array != null && array.Length != 0)
                {
                    return array[0].Description;
                }
            }
            return en.ToString();
        }
    }
}
