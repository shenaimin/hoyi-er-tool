/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
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

namespace ModelCode.ModelInfo.ROS
{
    /// <summary>
    /// 角色.
    /// </summary>
    public class RolesInfo
    {
        public RolesInfo()
        { 

        }
        public RolesInfo(string _rolename, string _roletype, string _notes)
        {
            this.roleName = _rolename;
            this.roleType = _roletype;
            this.notes = _notes;
        }
        public string roleName { get; set; }

        public string roleType { get; set; }

        public string notes { get; set; }

        public RolesInfo ParentRole { get; set; }
    }
}
