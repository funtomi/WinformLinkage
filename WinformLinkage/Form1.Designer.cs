namespace WinformLinkage {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.lbl5 = new MetroFramework.Controls.MetroLabel();
            this.lbl4 = new MetroFramework.Controls.MetroLabel();
            this.listBoxPosition = new System.Windows.Forms.ListBox();
            this.listBoxReason = new System.Windows.Forms.ListBox();
            this.lbl3 = new MetroFramework.Controls.MetroLabel();
            this.lbl2 = new MetroFramework.Controls.MetroLabel();
            this.lbl1 = new MetroFramework.Controls.MetroLabel();
            this.listBoxPhenomenon = new System.Windows.Forms.ListBox();
            this.listBoxCircuit = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl6 = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl7 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(307, 124);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(686, 467);
            this.axFramerControl1.TabIndex = 2;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbl5.Location = new System.Drawing.Point(452, 201);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(28, 25);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "→";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(134, 432);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(79, 19);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "故障定位：";
            // 
            // listBoxPosition
            // 
            this.listBoxPosition.FormattingEnabled = true;
            this.listBoxPosition.ItemHeight = 15;
            this.listBoxPosition.Location = new System.Drawing.Point(134, 454);
            this.listBoxPosition.Name = "listBoxPosition";
            this.listBoxPosition.Size = new System.Drawing.Size(167, 154);
            this.listBoxPosition.TabIndex = 7;
            this.listBoxPosition.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPosition_MouseDoubleClick);
            this.listBoxPosition.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // listBoxReason
            // 
            this.listBoxReason.FormattingEnabled = true;
            this.listBoxReason.ItemHeight = 15;
            this.listBoxReason.Location = new System.Drawing.Point(134, 290);
            this.listBoxReason.Name = "listBoxReason";
            this.listBoxReason.Size = new System.Drawing.Size(167, 139);
            this.listBoxReason.TabIndex = 6;
            this.listBoxReason.SelectedIndexChanged += new System.EventHandler(this.listBoxReason_SelectedIndexChanged);
            this.listBoxReason.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxReason_MouseDoubleClick);
            this.listBoxReason.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(134, 268);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(79, 19);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "原因分析：";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbl2.Location = new System.Drawing.Point(698, 164);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(21, 25);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "↓";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(134, 93);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(79, 19);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "故障现象：";
            // 
            // listBoxPhenomenon
            // 
            this.listBoxPhenomenon.FormattingEnabled = true;
            this.listBoxPhenomenon.ItemHeight = 15;
            this.listBoxPhenomenon.Location = new System.Drawing.Point(134, 124);
            this.listBoxPhenomenon.Name = "listBoxPhenomenon";
            this.listBoxPhenomenon.Size = new System.Drawing.Size(167, 139);
            this.listBoxPhenomenon.TabIndex = 2;
            this.listBoxPhenomenon.SelectedIndexChanged += new System.EventHandler(this.listBoxPhenomenon_SelectedIndexChanged);
            this.listBoxPhenomenon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPhenomenon_MouseDoubleClick);
            this.listBoxPhenomenon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // listBoxCircuit
            // 
            this.listBoxCircuit.FormattingEnabled = true;
            this.listBoxCircuit.ItemHeight = 15;
            this.listBoxCircuit.Location = new System.Drawing.Point(23, 124);
            this.listBoxCircuit.Name = "listBoxCircuit";
            this.listBoxCircuit.Size = new System.Drawing.Size(105, 484);
            this.listBoxCircuit.TabIndex = 2;
            this.listBoxCircuit.SelectedIndexChanged += new System.EventHandler(this.listBoxCircuit_SelectedIndexChanged);
            this.listBoxCircuit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxCircuit_MouseDoubleClick);
            this.listBoxCircuit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(23, 93);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(93, 19);
            this.lbl6.TabIndex = 3;
            this.lbl6.Text = "请选择回路：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOpen,
            this.MenuItemSave,
            this.MenuItemSaveAs,
            this.MenuItemExit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.Size = new System.Drawing.Size(129, 26);
            this.MenuItemOpen.Text = "打开";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.Size = new System.Drawing.Size(129, 26);
            this.MenuItemSave.Text = "保存";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.Size = new System.Drawing.Size(129, 26);
            this.MenuItemSaveAs.Text = "另存为";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "";
            this.MenuItemExit.Size = new System.Drawing.Size(129, 26);
            this.MenuItemExit.Text = "退出";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(307, 102);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(65, 19);
            this.lbl7.TabIndex = 10;
            this.lbl7.Text = "原理图：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 614);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.listBoxCircuit);
            this.Controls.Add(this.axFramerControl1);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBoxPosition);
            this.Controls.Add(this.listBoxPhenomenon);
            this.Controls.Add(this.listBoxReason);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "故障分析系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.ListBox listBoxCircuit;
        private System.Windows.Forms.ToolTip toolTip1;
        private MetroFramework.Controls.MetroLabel lbl1;
        private System.Windows.Forms.ListBox listBoxPhenomenon;
        private MetroFramework.Controls.MetroLabel lbl2;
        private System.Windows.Forms.ListBox listBoxReason;
        private MetroFramework.Controls.MetroLabel lbl3;
        private System.Windows.Forms.ListBox listBoxPosition;
        private MetroFramework.Controls.MetroLabel lbl4;
        private MetroFramework.Controls.MetroLabel lbl5;
        private AxDSOFramer.AxFramerControl axFramerControl1;
        private MetroFramework.Controls.MetroLabel lbl6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private MetroFramework.Controls.MetroLabel lbl7;
    }
}

