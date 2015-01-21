/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Hoyi.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoyi.ctrl
{
    public class ImportCTRL
    {
        private static ImportCTRL _instance;

        public static ImportCTRL Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportCTRL();
                }
                return _instance;
            }
        }

        public FMClass mainclassform { get; set; }



    }
}
