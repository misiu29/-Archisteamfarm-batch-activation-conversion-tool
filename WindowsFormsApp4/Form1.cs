using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private List<string> ExtractKeysFromString(string source)
        {
            MatchCollection m = Regex.Matches(source, "([0-9A-Z]{5})(?:\\-[0-9A-Z]{5}){2,3}",
                  RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> result = new List<string>();
            if (m.Count > 0)
            {
                foreach (Match v in m)
                {
                    result.Add(v.Value);
                }
            }
            return result;
        }
        private void ExtractKeysFromClipBoardAndCopyToClipboard()
        {


            List<string> listStrKeys = ExtractKeysFromString(richTextBox1.Text);
            if (listStrKeys.Count > 0)
            {
                string strKeys;
                strKeys = string.Join(",", listStrKeys.ToArray());
                richTextBox2.Text = "!redeem "+ strKeys;
                toolStripStatusLabel1.Text = "转换完成";
                button2.Enabled = true;
            }
            else
            {
                toolStripStatusLabel1.Text = "没有找到Key";
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ExtractKeysFromClipBoardAndCopyToClipboard();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
            toolStripStatusLabel1.Text = "已复制到剪贴板";
        }
    }
}
