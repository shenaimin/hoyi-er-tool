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
    /// 外键.
    /// select * from KEY_COLUMN_USAGE where TABLE_SCHEMA='changtu_erp'
    /// </summary>
    public class ConstraintInfo
    {
        /// <summary>
        /// 外键名or PRIMARY
        /// </summary>
        public string Constraint_name { get; set; }
        /// <summary>
        /// 主表名.
        /// </summary>
        public string Table_Name { get; set; }
        /// <summary>
        /// 主表字段
        /// </summary>
        public string Column_Name { get; set; }
        /// <summary>
        /// 引用表名.
        /// </summary>
        public string REFERENCED_TABLE_NAME { get; set; }
        /// <summary>
        /// 引用列名.
        /// </summary>
        public string REFERENCED_COLUMN_NAME { get; set; }
        /// <summary>
        /// 是否启用.
        /// </summary>
        public bool Using { get; set; }
        /// <summary>
        /// 备注.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 引用表位置.
        /// </summary>
        public string POSITION_IN_UNIQUE_CONSTRAINT { get; set; }
        /// <summary>
        /// 引用数据库.
        /// </summary>
        public string REFERENCED_TABLE_SCHEMA { get; set; }
        /// <summary>
        /// 原表索引位置.
        /// </summary>
        public string ORDINAL_POSITION { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Table_Schema { get; set; }
        /// <summary>
        /// 数据库名称.
        /// </summary>
        public string Constraint_schema { get; set; }
        /// <summary>
        /// 默认def
        /// </summary>
        public string Table_Catalog { get; set; }
        /// <summary>
        /// 默认def
        /// </summary>
        public string Constraint_catalog { get; set; }

        public ConstraintInfo Copy()
        {
            ConstraintInfo cos = new ConstraintInfo();
            cos.Constraint_catalog = Constraint_catalog;
            cos.Constraint_schema = Constraint_schema;
            cos.Constraint_name = Constraint_name;
            cos.Table_Catalog = Table_Catalog;
            cos.Table_Schema = Table_Schema;
            cos.Table_Name = Table_Name;
            cos.Column_Name = Column_Name;
            cos.ORDINAL_POSITION = ORDINAL_POSITION;
            cos.POSITION_IN_UNIQUE_CONSTRAINT = POSITION_IN_UNIQUE_CONSTRAINT;
            cos.REFERENCED_TABLE_SCHEMA = REFERENCED_TABLE_SCHEMA;
            cos.REFERENCED_TABLE_NAME = REFERENCED_TABLE_NAME;
            cos.REFERENCED_COLUMN_NAME = REFERENCED_COLUMN_NAME;
            cos.Using = this.Using;
            cos.Notes = this.Notes;
            return cos;
        }
    }
}
