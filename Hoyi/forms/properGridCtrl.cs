/*
 *          Author:Sam
 *          Email:ellen@hoyi.org
 *          CreateDate:2015-01-20
 *          ModifyDate:2015-01-20
 *          hoyi entities @ hoyi.org
 *          使用请在项目关于内标注hoyi版权，
 *          hoyi版权归hoyi.org所有
 */
using Crainiate.ERM4;
using Hoyi.appConf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoyi.forms
{
   public  class properGridCtrl
    {
       private static properGridCtrl _instance;

       public static properGridCtrl Ins {
           get {
               if (_instance == null)
               {
                   _instance = new properGridCtrl();
               }
               return _instance;
           }
       }

       public static PropertyGrid propertyGrid1;

       public void table_SelectedChanged(object sender, EventArgs e)
       {
           propertyGrid1.SelectedObject = sender;
           formConf.Editedtable = sender as Table;
           //MessageBox.Show((sender as Table).ToString());
       }
    }
}
