using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalizeTextTool
{
    public partial class ModalForm : Form
    {
        private MainForm parentForm = null;
        private string sTextString = "";
        private string sTextString2 = "";
        private bool bCheckFontType = false;

        public ModalForm(MainForm form)
        {
            parentForm = form;
            InitializeComponent();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            sTextString = findTextBox.Text;
            bCheckFontType = fontTypeCheckBox.Checked;

            parentForm.FindText(sTextString, bCheckFontType);
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            sTextString = findTextBox.Text;
            sTextString2 = changeTextBox.Text;
            bCheckFontType = fontTypeCheckBox.Checked;
        }

        private void allChangeBtn_Click(object sender, EventArgs e)
        {
            sTextString = findTextBox.Text;
            sTextString2 = changeTextBox.Text;
            bCheckFontType = fontTypeCheckBox.Checked;

            parentForm.AllChangeText(sTextString, sTextString2, bCheckFontType);
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
