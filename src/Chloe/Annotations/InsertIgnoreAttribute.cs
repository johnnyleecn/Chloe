using System;

namespace Chloe.Annotations
{
    /// <summary>
    /// 插入时忽略（李强新增专用）
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class InsertIgnoreAttribute : Attribute
    {
    }
}
