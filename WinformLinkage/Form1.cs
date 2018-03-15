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
    public partial class Form1 : MetroForm {
        public Form1() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
            this.axFramerControl1.Open(System.AppDomain.CurrentDomain.BaseDirectory+"测试PPT.pptx", true, "PowerPoint.Show", "", "");
        }

        //显示tooltip
        private void listBox1_MouseMove(object sender, MouseEventArgs e) { 
            int index = listBoxCircuit.IndexFromPoint(e.Location); 
            if (index != -1 && index < listBoxCircuit.Items.Count) { 
                if (toolTip1.GetToolTip(listBoxCircuit) != listBoxCircuit.Items[index].ToString()) { 
                    toolTip1.SetToolTip(listBoxCircuit, listBoxCircuit.Items[index].ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            //回路数据绑定
            listBoxCircuitBingding();
        }

        /// <summary>
        /// 获取回路数据并绑定到listBox上
        /// </summary>
        private void listBoxCircuitBingding() {
            var circuits = Models.GetCircuits();
            this.listBoxCircuit.DataSource = circuits;
        }
         


    }


}
