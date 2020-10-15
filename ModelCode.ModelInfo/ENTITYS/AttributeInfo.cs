/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelCode.ModelInfo
{
    /// <summary>
    /// 属性Info,之前LTP的没有外键，这里把外键也加上.
    /// 一列的属性.
    /// </summary>
    public class AttributeInfo
    {
        public AttributeInfo() { }
        /// <summary>
        /// 列名,注释.Comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        ///  字段名称.
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 是否为主键.
        /// </summary>
        public bool IsPK { get; set; }
        /// <summary>
        /// 是否自增,SQL中为identity,MySQL中为:auto_increment.
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 是否为空.
        /// </summary>
        public bool cisNull { get; set; }
        public bool IsUnique { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 字段的Option,用JSON格式存储，[{"0":"开始"}, {"1", "结束"}]
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// 应该说是 key 属性
        /// 1. 如果Key是空的, 那么该列值的可以重复, 表示该列没有索引, 或者是一个非唯一的复合索引的非前导列
        /// 2. 如果Key是PRI, 那么该列是主键的组成部分
        /// 3. 如果Key是UNI, 那么该列是一个唯一值索引的第一列(前导列),并别不能含有空值(NULL)
        /// 4. 如果Key是MUL, 那么该列的值可以重复, 该列是一个非唯一索引的前导列(第一列)或者是一个唯一性索引的组成部分但是可以含有空值NULL
        /// 如果对于一个列的定义，同时满足上述4种情况的多种，比如一个列既是PRI,又是UNI
        /// 那么"desc 表名"的时候，显示的Key值按照优先级来显示 PRI->UNI->MUL
        /// 那么此时，显示PRI
        /// 一个唯一性索引列可以显示为PRI,并且该列不能含有空值，同时该表没有主键
        /// 一个唯一性索引列可以显示为MUL, 如果多列构成了一个唯一性复合索引
        /// 因为虽然索引的多列组合是唯一的，比如ID+NAME是唯一的，但是没一个单独的列依然可以有重复的值
        /// 只要ID+NAME是唯一的即可 
        /// 
        /// 
        /// PRI主键约束；
        /// UNI唯一约束；
        /// MUL可以重复。
        /// 
        /// 数据库内存的KEY的值.
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// MySQL中的Extra值.
        /// </summary>
        public string Extra { get; set; }
        /// <summary>
        /// 默认值.
        /// </summary>
        public string DefaultVal { get; set; }
        /// <summary>
        /// 系统默认值，例如生成当前时间等.
        /// </summary>
        public string SysDefaultVal { get; set; }
        /// <summary>
        /// Float,Double,Decimal的小数点前面的值.
        /// </summary>
        public string Preci { get; set; }
        /// <summary>
        /// Float,Double,Decimal的小数后前面的值.
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 字符集
        /// </summary>
        public string Collation { get; set; }

        public AttributeInfo Clone()
        {
            AttributeInfo attr = new AttributeInfo();
            attr.Comment = this.Comment;
            attr.ColumnName = this.ColumnName;
            attr.TypeName = this.TypeName;
            attr.Length = this.Length;

            attr.IsPK = this.IsPK;
            attr.IsIdentity = this.IsIdentity;

            attr.cisNull = this.cisNull;
            attr.IsUnique = this.IsUnique;
            attr.Key = this.Key;

            attr.Extra = this.Extra;
            attr.DefaultVal = this.DefaultVal;
            attr.Preci = this.Preci;
            attr.Scale = this.Scale;

            attr.Collation = this.Collation;
            attr.Notes = this.Notes;
            attr.SysDefaultVal = this.SysDefaultVal;
            attr.Options = this.Options;

            return attr;
        }

        public override string ToString()
        {
            return "[AttributeInfo:{Comment:" + Comment + ", ColumnName:" + ColumnName + ", TypeName:" + TypeName + ", Length:" + Length + ", Collation:" + Collation + ", cisNull:" + cisNull + ", IsPK:" + IsPK + ", IsUnique:" + IsUnique + ", Key:" + Key + ", Extra:" + Extra + ", IsIdentity:" + IsIdentity + ", DefaultVal:" + DefaultVal + ", SysDefaultVal:" + SysDefaultVal + ", Preci:" + Preci + ", Scale:" + Scale + ",Notes:" + Notes + "}]";
        }
    }
}
