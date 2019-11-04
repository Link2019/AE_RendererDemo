using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_RendererDemo
{
    public partial class TextInput : Form
    {
        decimal fontsize;
        string Text;

        public decimal Fontsize
        {
            get
            {
                return fontsize;
            }
        }

        public string ThimaticMapName
        {
            get
            {
                return Text;
            }
        }

        public TextInput()
        {
            InitializeComponent();
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            if(txtInput.Text=="")
            {
                MessageBox.Show("专题图名不能为空！");
                return;
            }
            Text = txtInput.Text;
            if (txtTypeface.Text == "")
            {
                fontsize = 20;
            }
            else
            {
                fontsize = Convert.ToDecimal(txtTypeface.Text);
            }
            this.Dispose();

        }

        private void btnOverwrite_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
