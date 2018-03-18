using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformLinkage {
    public partial class FormDialogValue : MetroForm { 
        public FormDialogValue() {
            InitializeComponent();
        } 
        public string ReturnValue {
            get { return _returnValue; }
            set { _returnValue = value; }
        }
        private string _returnValue;
        private void btnOK_Click(object sender, EventArgs e) {
            ReturnValue = this.metroTextBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) { 
            this.Close();
        }

        private void FormDialogValue_Load(object sender, EventArgs e) {
            this.metroTextBox1.Text = _returnValue;

        }
         
    }
}
