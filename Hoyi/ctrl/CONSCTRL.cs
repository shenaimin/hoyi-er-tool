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

namespace Hoyi.ctrl
{
   public  class CONSCTRL
    {
       public static CONSCTRL CR()
       {
           return new CONSCTRL();
       }
       public List<ConstraintInfo> cons = new List<ConstraintInfo>();

       public List<ConstraintInfo> Copyfrom(EntityInfo info)
       {
           cons.Clear();
           ConstraintInfo con = null;
           for (int i = 0; i < info.constraints.Count; i++)
           {
               con = new ConstraintInfo();
               con = info.constraints[i];
               cons.Add(con);
           }

           //foreach (ConstraintInfo co in info.constraints)
           //{
           //    cons.Add(co.Copy());
           //}

           return cons;
       }
    }
}
