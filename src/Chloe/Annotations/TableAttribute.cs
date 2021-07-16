using System;

namespace Chloe.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public TableAttribute() { }
        public TableAttribute(string name) : this(name, null)
        {
        }
        public TableAttribute(string name, string schema)
        {
            this.Name = name;
            this.Schema = schema;
        }

        public string Name { get; set; }
        public string Schema { get; set; }

        /// <summary>
        /// 李强：默认每个数据表字段前加f
        /// </summary>
        public const string DefaultColumnPrefix = "f";

        /// <summary>
        /// 李强：默认每个数据表字段可以添加的前缀，不设置则为默认值f
        /// </summary>
        public string ColumnPrefix { get; set; }
    }
}
