using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformLinkage {
    public partial class Form1 : MetroForm {
        private static string PATH = ConfigurationManager.AppSettings["path"].ToString();
        private Models _model = new Models();
        private string _currentSchema = "";
        public Form1() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
        }

        //显示tooltip
        private void listBox1_MouseMove(object sender, MouseEventArgs e) {
            var listBox = sender as ListBox;
            if (listBox == null) {
                return;
            }
            int index = listBox.IndexFromPoint(e.Location);
            if (index != -1 && index < listBox.Items.Count) {
                if (toolTip1.GetToolTip(listBox) != listBox.Items[index].ToString()) {
                    toolTip1.SetToolTip(listBox, listBox.Items[index].ToString());
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e) {
            RefreshWindow(false);
        }

        /// <summary>
        /// 获取回路数据并绑定到listBox上
        /// </summary>
        private void listBoxCircuitBingding() {
            var circuits = _model.GetCircuits();
            this.listBoxCircuit.Items.AddRange(circuits.ToArray());
            this.listBoxCircuit.SelectedIndex = 0;
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
            var list = _model.GetPhenomenons(circuit);
            if (list == null || list.Count == 0) {
                return;
            }
            this.listBoxPhenomenon.Items.AddRange(list.ToArray());
            if (this.listBoxPhenomenon.Items.Count > 0) {
                this.listBoxPhenomenon.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 切换到对应的原理图
        /// </summary>
        /// <param name="circuit">回路</param>
        private void ChangeSchematic(string circuit) {
            var circuits = this.listBoxCircuit.Items;
            if (circuits == null || circuits.Count == 0) {
                return;
            }
            if (string.IsNullOrEmpty(circuit)) {
                circuit = circuits[0].ToString();
            }
            if (string.IsNullOrEmpty(circuit)) {
                return;
            }
            var fileName = _model.GetSchematicPath(circuit);
            var path = Path.GetFullPath(fileName);
            CloseOffice();
            this.axFramerControl1.Open(path);
            this._currentSchema = circuit;
        }


        /// <summary>
        /// 切换对应的故障原因
        /// </summary>
        /// <param name="p">故障现象名称</param>
        private void ChangeReasons(string p) {
            this.listBoxReason.Items.Clear();
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(this.listBoxCircuit.Text)) {
                return;
            }
            var circuit = this.listBoxCircuit.Text;
            var list = _model.GetReasons(circuit, p);
            if (list == null || list.Count == 0) {
                return;
            }
            this.listBoxReason.Items.AddRange(list.ToArray());
            if (this.listBoxReason.Items.Count > 0) {
                this.listBoxReason.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 切换对应的定位内容
        /// </summary>
        /// <param name="r">故障原因</param>
        private void ChangePositions(string r) {
            this.listBoxPosition.Items.Clear();
            var c = this.listBoxCircuit.Text;
            var ph = this.listBoxPhenomenon.Text;
            if (string.IsNullOrEmpty(r) || string.IsNullOrEmpty(c) || string.IsNullOrEmpty(ph)) {
                return;
            }
            var list = _model.GetPositions(c, ph, r);
            if (list == null || list.Count == 0) {
                return;
            }
            this.listBoxPosition.Items.AddRange(list.ToArray());
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
            var circuit = this.listBoxCircuit.Text;
            if (string.IsNullOrEmpty(circuit)) {
                return;
            }
            if (this.tbCtrl.SelectedTab == this.tbPgSchematic && this._currentSchema != circuit) {
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

        private void MenuItemExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void MenuItemOpen_Click(object sender, EventArgs e) {
            try {
                var fileName = OpenFile();
                this._model = new Models(fileName);
                RefreshWindow(_model.HasData);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void MenuItemSave_Click(object sender, EventArgs e) {

        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// 选择文件
        /// </summary>
        private string OpenFile() {
            using (OpenFileDialog fileDialog = new OpenFileDialog()) {
                fileDialog.DefaultExt = " ";
                fileDialog.FileName = "openFileDialog1";
                fileDialog.Filter = "数据文件|*.json";
                fileDialog.InitialDirectory = Path.GetFullPath(PATH);
                fileDialog.Multiselect = false;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK) {
                    return fileDialog.FileName;
                }
                return null;
            }
        }

        private void RefreshWindow(bool hasData) {
            if (hasData) {
                //回路数据绑定
                listBoxCircuitBingding();
                if (this.tbCtrl.SelectedTab == this.tbPgSchematic) {
                    ChangeSchematic(""); 
                }
                return;
            }
            this.listBoxCircuit.Items.Clear();
            this.listBoxPhenomenon.Items.Clear();
            this.listBoxReason.Items.Clear();
            this.listBoxPosition.Items.Clear();
            this.CloseOffice();

        }

        private string GetChangeText(object sender, MouseEventArgs e) {
            var listBox = sender as ListBox;
            if (listBox == null) {
                return null;
            }
            //获取当前鼠标双击选择的项;  
            int index = listBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches) {
               var text = OpenDialog(listBox.Items[index].ToString());
                if (string.IsNullOrEmpty(text)) {
                    return null;
                }
                listBox.Items.RemoveAt(index);//先移除当前项的值  
                listBox.Items.Insert(index, text);//在当前指定项插入新的值
                return text;
            }
            return null;
        }

        /// <summary>
        /// 打开模态窗口修改值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string OpenDialog(string text) {
            using (FormDialogValue form = new FormDialogValue()) {
                form.StyleManager = this.StyleManager;
                form.ReturnValue = text;
                form.ShowDialog(this);
                form.BringToFront();
                if (form.DialogResult == DialogResult.OK) {
                    return form.ReturnValue;
                }
                return null;
            }
        }

        private void listBoxCircuit_MouseDoubleClick(object sender, MouseEventArgs e) {
            var origin = this.listBoxCircuit.Text;
            var value = GetChangeText(sender, e);
            if (string.IsNullOrEmpty(value) || origin == value) {
                return;
            }
            _model.ChangeCircuit(origin, value);
            
        }

        private void listBoxPhenomenon_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        private void listBoxReason_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

        private void listBoxPosition_MouseDoubleClick(object sender, MouseEventArgs e) {

        }

    }

}
