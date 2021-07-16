using System;

namespace Chloe.Annotations
{
    /// <summary>
    /// 插入时忽略（李强新增专用，只在MsSql中适用，未改其他数据库引擎）
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class InsertIgnoreAttribute : Attribute
    {
    }
}
