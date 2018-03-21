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
        private static string FILE_FORMAT = "PowerPoint.Show";
        private Models _model = new Models();
        private string _currentCircuit = "";  
        public Form1() {
            InitializeComponent();
            this.StyleManager = this.metroStyleManager1;
        }

        #region 事件
        //窗口加载事件
        private void Form1_Load(object sender, EventArgs e) {
            RefreshWindow(false);
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

        /// <summary>
        /// 窗口关闭事件，需要关闭打开的office
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e) {
            try {
                CloseOffice();
            } catch (Exception ex) {
                throw ex;
            }
            base.OnClosed(e);
        }

        /// <summary>
        /// 选择回路事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void childMenu_Click(object sender, EventArgs e) {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) {
                return;
            }
            var circuit = menuItem.Text;
            if (string.IsNullOrEmpty(circuit) || this._currentCircuit == circuit) {
                return;
            }
            _currentCircuit = circuit;
            ChangeSchematic(circuit);
            ChangeFaliurePhenomenon(circuit);
        }

        /// <summary>
        /// 故障现象选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPhenomenon_SelectedIndexChanged(object sender, EventArgs e) { 
            ChangeReasons(this.listBoxPhenomenon.Text);
        }

        /// <summary>
        /// 修改故障现象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPhenomenon_MouseDoubleClick(object sender, MouseEventArgs e) {
            var origin = this.listBoxPhenomenon.Text;
            this.listBoxPhenomenon.SelectedIndexChanged -= listBoxPhenomenon_SelectedIndexChanged;
            var value = GetChangeText(sender, e);
            if (string.IsNullOrEmpty(value) || origin == value) {
                return;
            }
            _model.ChangePhenomenon(_currentCircuit, origin, value);
            this.listBoxPhenomenon.SelectedIndexChanged += listBoxPhenomenon_SelectedIndexChanged;

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
        /// 修改故障原因
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxReason_MouseDoubleClick(object sender, MouseEventArgs e) {
            var origin = this.listBoxReason.Text;
            this.listBoxReason.SelectedIndexChanged -= listBoxReason_SelectedIndexChanged;
            var value = GetChangeText(sender, e);
            if (string.IsNullOrEmpty(value) || origin == value) {
                return;
            }
            _model.ChangeReason(_currentCircuit, this.listBoxPhenomenon.Text, origin, value);
            this.listBoxReason.SelectedIndexChanged += listBoxReason_SelectedIndexChanged;

        }

        /// <summary>
        /// 修改故障定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPosition_MouseDoubleClick(object sender, MouseEventArgs e) {
            var origin = this.listBoxPosition.Text;
            var value = GetChangeText(sender, e);
            if (string.IsNullOrEmpty(value) || origin == value) {
                return;
            }
            _model.ChangePosition(_currentCircuit, this.listBoxPhenomenon.Text, this.listBoxReason.Text, origin, value);
        }

        /// <summary>
        /// 选择退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
        #endregion

        /// <summary>
        /// 关闭office文档
        /// </summary>
        private void CloseOffice() {
            if (this.axFramerControl1 != null) {
                this.axFramerControl1.Close();
            }
        }

        /// <summary>
        /// 动态添加菜单项
        /// </summary>
        private void AddMenuItems() {
            ClearMenuItems();
            var dic = _model.GetCircuitStruct();
            if (dic == null || dic.Count == 0) {
                return;
            }
            foreach (var item in dic) {
                if (item.Key == "nullName") {
                    foreach (var childItem in item.Value) {
                        ToolStripMenuItem childMenu = new ToolStripMenuItem(childItem);
                        childMenu.Name = childItem;
                        childMenu.Click += childMenu_Click;
                        this.menuStrip1.Items.Add(childMenu);
                    }
                    continue;
                }
                ToolStripMenuItem parentMenu = new ToolStripMenuItem(item.Key);
                foreach (var childItem in item.Value) {
                    ToolStripMenuItem childMenu = new ToolStripMenuItem(childItem);
                    childMenu.Name = childItem;
                    childMenu.Click += childMenu_Click;
                    parentMenu.DropDownItems.Add(childMenu);
                }
                this.menuStrip1.Items.Add(parentMenu);
            }
        }

        /// <summary>
        /// 清除动态加载的回路菜单
        /// </summary>
        private void ClearMenuItems() {
            for (int i = 1; i < this.menuStrip1.Items.Count; i++) {
                this.menuStrip1.Items.RemoveAt(i);
            }
        }

        /// <summary>
        /// 刷新窗口
        /// </summary>
        /// <param name="hasData"></param>
        private void RefreshWindow(bool hasData) {
            ClearWindow();
            if (!hasData) {
                return;
            }
            //回路数据绑定 
            AddMenuItems();
        }

        /// <summary>
        /// 清除窗口内容
        /// </summary>
        private void ClearWindow() {
            _currentCircuit = "";
            this.listBoxPhenomenon.Items.Clear();
            this.listBoxReason.Items.Clear();
            this.listBoxPosition.Items.Clear();
            ClearMenuItems();
            this.CloseOffice();
        }

        /// <summary>
        /// 切换到对应的原理图
        /// </summary>
        /// <param name="circuit">回路</param>
        private void ChangeSchematic(string circuit) {
            if (string.IsNullOrEmpty(circuit)) {
                return;
            }
            var fileName = _model.GetSchematicPath(circuit);
            var path = Path.GetFullPath(fileName);
            CloseOffice();
            this.axFramerControl1.Open(path); 
            SendKeys.SendWait("{F5}");
            SendKeys.Flush();
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
        /// 切换对应的故障原因
        /// </summary>
        /// <param name="p">故障现象名称</param>
        private void ChangeReasons(string p) {
            this.listBoxReason.Items.Clear();
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(_currentCircuit)) {
                return;
            }
            var list = _model.GetReasons(_currentCircuit, p);
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
            var ph = this.listBoxPhenomenon.Text;
            if (string.IsNullOrEmpty(r) || string.IsNullOrEmpty(_currentCircuit) || string.IsNullOrEmpty(ph)) {
                return;
            }
            var list = _model.GetPositions(_currentCircuit, ph, r);
            if (list == null || list.Count == 0) {
                return;
            }
            this.listBoxPosition.Items.AddRange(list.ToArray());
            if (this.listBoxPosition.Items.Count > 0) {
                this.listBoxPosition.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 打开修改窗口获取修改的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
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
                listBox.Items[index] = text; 
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


        /// <summary>
        /// 选择打开菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpen_Click(object sender, EventArgs e) {
            try {
                var fileName = OpenFile();
                this._model = new Models(fileName);
                RefreshWindow(_model.HasData);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选择保存菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSave_Click(object sender, EventArgs e) {
            if (!_model.HasData) {
                return;
            }
            this.axFramerControl1.Save();
            this._model.Save();
        }

        /// <summary>
        /// 选择另存为菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSaveAs_Click(object sender, EventArgs e) {
            if (!_model.HasData) {
                return;
            }
            bool changeSchematic = false;
            try {
                if (MessageBox.Show("是否更改原理图保存路径？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    //另存原理图
                    using (SaveFileDialog sfd = new SaveFileDialog()) {
                        var path = this._model.GetSchematicPath(_currentCircuit);
                        string sExt = System.IO.Path.GetExtension(path);
                        sfd.Filter = "PPT文件(*.ppt)|*.ppt";
                        if (sfd.ShowDialog() == DialogResult.OK) {
                            string sSavePath = sfd.FileName;
                            if (System.IO.File.Exists(sSavePath)) {
                                System.IO.File.Delete(sSavePath);
                            }
                            this.axFramerControl1.SaveAs(sSavePath, FILE_FORMAT);
                            this._model.ChangeSchematicPath(_currentCircuit, sSavePath);
                        }
                    }
                    changeSchematic = true;
                }
                using (SaveFileDialog sfd = new SaveFileDialog()) {
                    sfd.Filter = "数据文件(*.json)|*.json";
                    if (sfd.ShowDialog() == DialogResult.OK) {
                        string sSavePath = sfd.FileName;
                        if (System.IO.File.Exists(sSavePath)) {
                            System.IO.File.Delete(sSavePath);
                        }
                        if (!changeSchematic) {
                            this.axFramerControl1.Save();
                        }
                        this._model.Save(sSavePath);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
 
    }

}
