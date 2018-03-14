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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tbCtrl = new MetroFramework.Controls.MetroTabControl();
            this.tbPgSchematic = new MetroFramework.Controls.MetroTabPage();
            this.tbPgFailureAnalysis = new MetroFramework.Controls.MetroTabPage();
            this.lbl2 = new MetroFramework.Controls.MetroLabel();
            this.lbl1 = new MetroFramework.Controls.MetroLabel();
            this.listBoxPhenomenon = new System.Windows.Forms.ListBox();
            this.listBoxCircuit = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl3 = new MetroFramework.Controls.MetroLabel();
            this.listBoxReason = new System.Windows.Forms.ListBox();
            this.listBoxPosition = new System.Windows.Forms.ListBox();
            this.lbl4 = new MetroFramework.Controls.MetroLabel();
            this.lbl5 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tbCtrl.SuspendLayout();
            this.tbPgFailureAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tbCtrl
            // 
            this.tbCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtrl.Controls.Add(this.tbPgSchematic);
            this.tbCtrl.Controls.Add(this.tbPgFailureAnalysis);
            this.tbCtrl.ItemSize = new System.Drawing.Size(105, 36);
            this.tbCtrl.Location = new System.Drawing.Point(241, 81);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 1;
            this.tbCtrl.ShowToolTips = true;
            this.tbCtrl.Size = new System.Drawing.Size(749, 519);
            this.tbCtrl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbCtrl.TabIndex = 1;
            this.tbCtrl.UseSelectable = true;
            // 
            // tbPgSchematic
            // 
            this.tbPgSchematic.HorizontalScrollbarBarColor = true;
            this.tbPgSchematic.HorizontalScrollbarHighlightOnWheel = false;
            this.tbPgSchematic.HorizontalScrollbarSize = 10;
            this.tbPgSchematic.Location = new System.Drawing.Point(4, 40);
            this.tbPgSchematic.Name = "tbPgSchematic";
            this.tbPgSchematic.Size = new System.Drawing.Size(741, 475);
            this.tbPgSchematic.TabIndex = 0;
            this.tbPgSchematic.Text = "原理图";
            this.tbPgSchematic.VerticalScrollbarBarColor = true;
            this.tbPgSchematic.VerticalScrollbarHighlightOnWheel = false;
            this.tbPgSchematic.VerticalScrollbarSize = 10;
            // 
            // tbPgFailureAnalysis
            // 
            this.tbPgFailureAnalysis.Controls.Add(this.lbl5);
            this.tbPgFailureAnalysis.Controls.Add(this.lbl4);
            this.tbPgFailureAnalysis.Controls.Add(this.listBoxPosition);
            this.tbPgFailureAnalysis.Controls.Add(this.listBoxReason);
            this.tbPgFailureAnalysis.Controls.Add(this.lbl3);
            this.tbPgFailureAnalysis.Controls.Add(this.lbl2);
            this.tbPgFailureAnalysis.Controls.Add(this.lbl1);
            this.tbPgFailureAnalysis.Controls.Add(this.listBoxPhenomenon);
            this.tbPgFailureAnalysis.HorizontalScrollbarBarColor = true;
            this.tbPgFailureAnalysis.HorizontalScrollbarHighlightOnWheel = false;
            this.tbPgFailureAnalysis.HorizontalScrollbarSize = 10;
            this.tbPgFailureAnalysis.Location = new System.Drawing.Point(4, 40);
            this.tbPgFailureAnalysis.Name = "tbPgFailureAnalysis";
            this.tbPgFailureAnalysis.Size = new System.Drawing.Size(741, 475);
            this.tbPgFailureAnalysis.TabIndex = 1;
            this.tbPgFailureAnalysis.Text = "故障分析";
            this.tbPgFailureAnalysis.VerticalScrollbarBarColor = true;
            this.tbPgFailureAnalysis.VerticalScrollbarHighlightOnWheel = false;
            this.tbPgFailureAnalysis.VerticalScrollbarSize = 10;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbl2.Location = new System.Drawing.Point(169, 220);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(21, 25);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "↓";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(3, 10);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(79, 19);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "故障现象：";
            // 
            // listBoxPhenomenon
            // 
            this.listBoxPhenomenon.FormattingEnabled = true;
            this.listBoxPhenomenon.ItemHeight = 15;
            this.listBoxPhenomenon.Location = new System.Drawing.Point(3, 35);
            this.listBoxPhenomenon.Name = "listBoxPhenomenon";
            this.listBoxPhenomenon.Size = new System.Drawing.Size(341, 184);
            this.listBoxPhenomenon.TabIndex = 2;
            // 
            // listBoxCircuit
            // 
            this.listBoxCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCircuit.FormattingEnabled = true;
            this.listBoxCircuit.ItemHeight = 15;
            this.listBoxCircuit.Location = new System.Drawing.Point(23, 79);
            this.listBoxCircuit.Name = "listBoxCircuit";
            this.listBoxCircuit.Size = new System.Drawing.Size(199, 514);
            this.listBoxCircuit.TabIndex = 2;
            this.listBoxCircuit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(3, 235);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(79, 19);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "原因分析：";
            // 
            // listBoxReason
            // 
            this.listBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxReason.FormattingEnabled = true;
            this.listBoxReason.ItemHeight = 15;
            this.listBoxReason.Location = new System.Drawing.Point(3, 260);
            this.listBoxReason.Name = "listBoxReason";
            this.listBoxReason.Size = new System.Drawing.Size(341, 214);
            this.listBoxReason.TabIndex = 6;
            // 
            // listBoxPosition
            // 
            this.listBoxPosition.FormattingEnabled = true;
            this.listBoxPosition.ItemHeight = 15;
            this.listBoxPosition.Location = new System.Drawing.Point(378, 35);
            this.listBoxPosition.Name = "listBoxPosition";
            this.listBoxPosition.Size = new System.Drawing.Size(350, 439);
            this.listBoxPosition.TabIndex = 7;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(378, 10);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(79, 19);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "故障定位：";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbl5.Location = new System.Drawing.Point(348, 359);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(28, 25);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "→";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 614);
            this.Controls.Add(this.listBoxCircuit);
            this.Controls.Add(this.tbCtrl);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "故障分析系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tbCtrl.ResumeLayout(false);
            this.tbPgFailureAnalysis.ResumeLayout(false);
            this.tbPgFailureAnalysis.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tbCtrl;
        private MetroFramework.Controls.MetroTabPage tbPgSchematic;
        private MetroFramework.Controls.MetroTabPage tbPgFailureAnalysis;
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
    }
}

