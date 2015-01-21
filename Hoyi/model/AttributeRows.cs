/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.model
{
    public class AttributeRows
    {
        public List<AttributeInfo> rows = new List<AttributeInfo>();

        public void CopyFromAttrs(List<AttributeInfo> attrs)
        {
            rows.Clear();
            AttributeInfo row = null;
            for (int i = 0; i < attrs.Count; i++)
            {
                row = new AttributeInfo();
                row = attrs[i];
                rows.Add(row);
            }
        }
    }
}
