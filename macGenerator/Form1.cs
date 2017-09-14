using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace macGenerator
{
    public partial class Form1 : Form
    {

        static string startMac;
        static int number;
        static long jump;
        static string filePath = Application.StartupPath + "\\result.txt";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string pattern = @"^[0-9A-F]{12}$";
            //Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            //if(!rgx.IsMatch(this.textBox1.Text) && this.textBox1.TextLength >= 14)
            //{
            //    MessageBox.Show("请输入正确的MAC地址，不要加‘-’或者‘_’,不要超过12位！");
            //    this.textBox1.Text = "";
            //}
            if(this.textBox1.TextLength >= 13)
            {
                MessageBox.Show("请输入正确的MAC地址，不要加‘-’或者‘_’,不要超过12位！");
                this.textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startMac = this.textBox1.Text;
            number = (int)numericUpDown1.Value;
            jump = long.Parse(this.textBox3.Text);

            
            if(File.Exists(filePath))
            {
                if(MessageBox.Show("文件已存在，是否删除？", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    File.Delete(filePath);
                }
            }
            long leftAddress = Converter.Str2Long(startMac);
            long rightAddress;

            long macAddress = Converter.Str2Long(startMac);
            //MessageBox.Show(number.ToString());

            FileStream filestream = File.OpenWrite(filePath);
            StreamWriter writer = new StreamWriter(filestream);

            for (int i = 0; i< number; i++)
            {
                rightAddress = leftAddress + 28;
                writer.WriteLine(Converter.Long2Str(leftAddress) + ",,," + Converter.Long2Str(rightAddress));
                leftAddress = rightAddress + 1;
            }

            writer.Close();

            MessageBox.Show("生成完毕！文件位于" + filePath);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
