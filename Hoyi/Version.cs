using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hoyi
{
    public class Version
    {
        private static String VersionContent = "";

        private static bool inited = false;

        private static void Init() {
            VersionContent = "";

            StringBuilder builder = new StringBuilder();

            builder.AppendLine("");
            builder.AppendLine("-version: v3.50");
            builder.AppendLine("");
            builder.AppendLine("修改增删改后，整棵树刷新的问题.");
            builder.AppendLine("");
            builder.AppendLine("-version: v3.44");

            builder.AppendLine("");
            builder.AppendLine("修复改ID复制的Bug.");
            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("-version: v3.43");

            builder.AppendLine("");
            builder.AppendLine("修复存在空字段时，CopyField的Bug.");
            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("-version: v3.42");

            builder.AppendLine("");
            builder.AppendLine("添加CopyField,和RelaField方法.");
            builder.AppendLine("RelaField方法,可以加外键.");
            builder.AppendLine("");

            builder.AppendLine("");
            builder.AppendLine("-version: v3.41");

            builder.AppendLine("");
            builder.AppendLine("修复打开关闭后加载窗口还出现的问题.");
            builder.AppendLine("");
            builder.AppendLine("-version: v3.4");

            builder.AppendLine("");
            builder.AppendLine("工具栏快捷键: V 选择, L直线。+ 放大, - 缩小， 0 原始大小.");
            builder.AppendLine("关于窗口的版本内容。");
            builder.AppendLine("打开异常关闭文件的提示问题。");
            builder.AppendLine("未保存的提示问题。");
            builder.AppendLine("");

            builder.AppendLine("-version: v3.3");

            builder.AppendLine("");
            builder.AppendLine("Enter，创建或者编辑实体。");
            builder.AppendLine("CTRL + ENTER创建实体,");
            builder.AppendLine("CTRL + M创建模块，");
            builder.AppendLine("CTRL + L修改项目信息");
            builder.AppendLine("CTRL + W关闭系统");

            builder.AppendLine("");

            builder.AppendLine("-version: v3.2");

            builder.AppendLine("");
            builder.AppendLine("修复拖动文件打开");

            builder.AppendLine("");
            builder.AppendLine("-version: v2.11");
            builder.AppendLine("");
            builder.AppendLine("所有窗体加ESC返回。");
            builder.AppendLine("表编辑添加全选删除。");
            builder.AppendLine("项目树双击错误问题。");
            builder.AppendLine("所有窗体Tab顺序。");
            builder.AppendLine("新建表自动打开表编辑界面。");
            builder.AppendLine("项目树右击不能选中问题。");
            builder.AppendLine("添加数据字典导出。");

            builder.AppendLine("");

            builder.AppendLine("-version: v2.10");

            builder.AppendLine("");
            builder.AppendLine("完善实体编辑，上移下移，多个上移下移。");
            builder.AppendLine("输入选择模版，输入选择现有的字段，Enter添加。");
            builder.AppendLine("添加欢迎页面，");
            builder.AppendLine("CTRL + L修改项目信息");
            builder.AppendLine("CTRL + W关闭系统");

            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("");

            builder.AppendLine("");

            VersionContent = builder.ToString();


        }

        public static String GetVersion() {
            if(!inited)
                Init();
            return VersionContent;
        }
    }
}
