﻿/*
 *          Author:Ellen
 *          Email:ellen@miloong.com   专业的App外包提供商，广州巨鲸信息技术有限公司   www.miloong.com
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Crainiate.ERM4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ModelCode.ModelInfo.View
{
    public class EntityView
    {
        public int X { get; set; }

        public int Y { get; set; }

        public EntityInfo entity { get; set; }
        [NonSerialized()]
        public Table Table;
    }
}
