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
        private Models _model = new Models();
        private string _currentSchema = "";
        public Form1() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
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
            ChangeSchematic("回路1");
        }

        /// <summary>
        /// 获取回路数据并绑定到listBox上
        /// </summary>
        private void listBoxCircuitBingding() {
            var circuits = _model.GetCircuits();
            this.listBoxCircuit.DataSource = circuits;
        }

        protected override void OnClosed(EventArgs e) {
            try {
                CloseOffice();
            } catch (Exception ex) {
                throw ex;
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// 关闭office文档
        /// </summary>
        private void CloseOffice() {
            if (this.axFramerControl1 != null) {
                this.axFramerControl1.Close();
            }
        } 

        /// <summary>
        /// 切换第二个页签（故障分析）中的内容
        /// </summary>
        /// <param name="circuit"></param>
        private void ChangeFaluireAnalysis(string circuit) {
            ChangeFaliurePhenomenon(circuit);
        }

        /// <summary>
        /// 切换对应的故障现象
        /// </summary>
        /// <param name="circuit"></param>
        private void ChangeFaliurePhenomenon(string circuit) {
            this.listBoxPhenomenon.Items.Clear();
            if (string.IsNullOrEmpty(circuit)) {
                return;
            }
            this.listBoxPhenomenon.Items.AddRange(_model.GetPhenomenons(circuit).ToArray());
            if (this.listBoxPhenomenon.Items.Count>0) {
                this.listBoxPhenomenon.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 切换到对应的原理图
        /// </summary>
        /// <param name="circuit"></param>
        private void ChangeSchematic(string circuit) { 
            var fileName = AppDomain.CurrentDomain.BaseDirectory + _model.GetSchematicPath(circuit);
            CloseOffice();
            this.axFramerControl1.Open(fileName);
            this._currentSchema = circuit;
        }

        /// <summary>
        /// 切换对应的故障原因
        /// </summary>
        /// <param name="p"></param>
        private void ChangeReasons(string p) {
            this.listBoxReason.Items.Clear();
            if (string.IsNullOrEmpty(p)) {
                return;
            }
            this.listBoxReason.Items.AddRange(_model.GetReasons(p).ToArray());
            if (this.listBoxReason.Items.Count > 0) {
                this.listBoxReason.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 切换对应的定位内容
        /// </summary>
        /// <param name="p"></param>
        private void ChangePositions(string p) {
            this.listBoxPosition.Items.Clear();
            if (string.IsNullOrEmpty(p)) {
                return;
            }
            this.listBoxPosition.Items.AddRange(_model.GetPositions(p).ToArray());
            if (this.listBoxPosition.Items.Count > 0) {
                this.listBoxPosition.SelectedIndex = 0;
            }
        }

        #region 事件

        
        /// <summary>
        /// 选择回路改变事件，选择回路后切换到对应的原理图、故障分析、故障原因、原因定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCircuit_SelectedIndexChanged(object sender, EventArgs e) {
            var circuit =this.listBoxCircuit.SelectedValue.ToString();
            if (string.IsNullOrEmpty(circuit)) {
                return;
            }
            if (this.tbCtrl.SelectedTab == this.tbPgSchematic&&this._currentSchema!=circuit) {
                ChangeSchematic(circuit);
            }
            ChangeFaluireAnalysis(circuit);
        }

        /// <summary>
        /// 切换故障原因事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxReason_SelectedIndexChanged(object sender, EventArgs e) {
            ChangePositions(this.listBoxReason.Text);
        }


        /// <summary>
        /// 故障现象选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPhenomenon_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeReasons(this.listBoxPhenomenon.Text);

        }
        #endregion

        private void tbCtrl_SelectedIndexChanged(object sender, EventArgs e) {
            var circuit = this.listBoxCircuit.Text;
            if (string.IsNullOrEmpty(circuit) || this.tbCtrl.SelectedTab == this.tbPgFailureAnalysis || this._currentSchema == circuit) {
                return;
            }
            ChangeSchematic(circuit);
        }

    }


}
