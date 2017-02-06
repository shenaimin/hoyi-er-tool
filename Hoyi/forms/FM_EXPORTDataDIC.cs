using Hoyi.conf;
using ModelCode.ModelInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoyi.forms
{
    public partial class FM_EXPORTDataDIC : Form
    {
        public FM_EXPORTDataDIC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL Document(*.html)|*.html|WORD DOocument(*.doc)|*.doc";
            saveFileDialog.FileName = AppConf.Ins.Application.AppName + ".数据字典";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = saveFileDialog.FileName;
            }
        }

        public void SaveWithHTML()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<html>");
            stringBuilder.Append("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8″><meta values=\"hoyi er tool v2.8\" /><style>html, body{margin:0px; padding:0px;}table      {      width:100%;      background: #D6E0EF;      border: 1px solid #698CC3;     word-break:break-all;       overflow:auto;      }     a {  text-decoration:none;color:black;}     a:redlink{  text-decoration:none;color:black;}     a:hover{  text-decoration:none;color:black;}     a:visited{  text-decoration:none;color:black;}     a:active{  text-decoration:none;color:black;}     a:link{  text-decoration:none;color:black;}     td {    background-color:#FFFFFF;      font-family: \"Arial\",\"宋体\", \"新宋体\";      font-size: 9pt; color: #000000;      padding-left:5px;     height:25px;     word-break:break-all;       overflow:auto;         FONT-SIZE: 12px;      }</style></head>");
            stringBuilder.Append(string.Concat(new string[]
            {
                "<body><div style=\"height:50px; line-height:50px;background-color:#7BCDFF; vertical-align:middle;\">&nbsp;&nbsp;&nbsp;&nbsp;",
                AppConf.Ins.Application.AppName,
                ",",
                AppConf.Ins.Application.NameSpace,
                "</div>"
            }));
            stringBuilder.Append("<div style=\"float:left; width:30%;\">");
            foreach (ModuleInfo current in AppConf.Ins.Application.Modules)
            {
                stringBuilder.Append("<ul>");

                stringBuilder.Append(string.Concat(new string[]
                 {
                    "<li><a href=\"#module",
                    current.Caption,
                    "\">",
                    current.ModuleName,
                    "[",
                    current.Caption,
                    ",",
                    current.Prefix,
                    "]</a></li>"
                 }));

                foreach (EntityInfo current2 in current.Entitys)
                {
                    stringBuilder.Append("<ul>");
                    stringBuilder.Append(string.Concat(new string[]
                    {
                "<li><a href=\"#",
                current.Caption,
                current2.ClassName,
                "\">",
                current2.EntityName,
                "[",
                current2.ClassName,
                "]</a></li>"
                    }));
                    stringBuilder.Append("</ul>");
                }
                stringBuilder.Append("</li>");
                stringBuilder.Append("</ul>");
            }
            stringBuilder.Append("</div>");
            stringBuilder.Append("<div style=\"float:left; width:70%; height:98%; overflow:scroll;\">");
            foreach (ModuleInfo current3 in AppConf.Ins.Application.Modules)
            {
                stringBuilder.Append("<br>");
                stringBuilder.Append("<br>");
                stringBuilder.Append(string.Concat(new string[]
                {
            "<span id=\"module",
            current3.Caption,
            "\">模块-->",
            current3.Caption,
            ", PreFix:",
            current3.Prefix,
            "</span>"
                }));
                foreach (EntityInfo current4 in current3.Entitys)
                {
                    stringBuilder.Append("<br>");
                    stringBuilder.Append("<br>");
                    stringBuilder.Append(string.Concat(new string[]
                    {
                "<span>",
                current4.EntityName,
                "[",
                current4.ClassName,
                "]",
                current4.Notes,
                "</span>"
                    }));
                    stringBuilder.Append("<br>");
                    stringBuilder.Append("<br>");
                    stringBuilder.Append("<table id=\"" + current3.Caption + current4.ClassName + "\">");
                    stringBuilder.Append("<thead></thead>");
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append("<th>序号</th>");
                    stringBuilder.Append("<th>字段</th>");
                    stringBuilder.Append("<th>说明</th>");
                    stringBuilder.Append("<th>数据类型</th>");
                    stringBuilder.Append("<th>长度</th>");
                    stringBuilder.Append("<th>主键</th>");
                    stringBuilder.Append("<th>自增</th>");
                    stringBuilder.Append("<th>允许空</th>");
                    stringBuilder.Append("<th>默认值</th>");
                    stringBuilder.Append("<th>备注</th>");
                    stringBuilder.Append("</tr>");
                    stringBuilder.Append("<tbody>");
                    int num = 1;
                    foreach (AttributeInfo current5 in current4.Attributes)
                    {
                        stringBuilder.Append("<tr>");
                        stringBuilder.Append("<td>" + num++ + "</td>");
                        stringBuilder.Append("<td>" + current5.ColumnName + "</td>");
                        stringBuilder.Append("<td>" + current5.Comment + "</td>");
                        stringBuilder.Append("<td>" + current5.TypeName + "</td>");
                        stringBuilder.Append("<td>" + current5.Length + "</td>");
                        stringBuilder.Append("<td>" + (current5.IsPK ? "√" : "×") + "</td>");
                        stringBuilder.Append("<td>" + (current5.IsIdentity ? "√" : "×") + "</td>");
                        stringBuilder.Append("<td>" + (current5.cisNull ? "√" : "×") + "</td>");
                        stringBuilder.Append("<td>" + current5.DefaultVal + "</td>");
                        stringBuilder.Append("<td>" + current5.Notes + "</td>");
                        stringBuilder.Append("</tr>");
                    }
                    stringBuilder.Append("</tbody>");
                    stringBuilder.Append("</table>");
                }
            }
            stringBuilder.Append("</div>");
            stringBuilder.Append("</body>");
            stringBuilder.Append("</html>");
            StreamWriter streamWriter = new StreamWriter(this.textBox1.Text, false, Encoding.UTF8);
            streamWriter.Write(stringBuilder.ToString());
            streamWriter.Close();
            MessageBox.Show("HTML 数据字典保存完成！路径:" + this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (text.EndsWith("html"))
            {
                this.SaveWithHTML();
                return;
            }
            if (text.EndsWith("doc"))
            {
                //this.SaveWithWord();
                MessageBox.Show("暂时不支持到处doc.");
                return;
            }
            MessageBox.Show("UnKnow Type.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
