﻿namespace AE_RendererDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加地图元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指北针ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比例尺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分等级法渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简单符号法渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唯一值法渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比例符号法渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点状密度法渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.添加地图元素ToolStripMenuItem,
            this.分等级法渲染ToolStripMenuItem,
            this.简单符号法渲染ToolStripMenuItem,
            this.唯一值法渲染ToolStripMenuItem,
            this.比例符号法渲染ToolStripMenuItem,
            this.点状密度法渲染ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 添加地图元素ToolStripMenuItem
            // 
            this.添加地图元素ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图例ToolStripMenuItem,
            this.指北针ToolStripMenuItem,
            this.比例尺ToolStripMenuItem,
            this.文本ToolStripMenuItem});
            this.添加地图元素ToolStripMenuItem.Name = "添加地图元素ToolStripMenuItem";
            this.添加地图元素ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.添加地图元素ToolStripMenuItem.Text = "添加地图元素";
            this.添加地图元素ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.添加地图元素ToolStripMenuItem_DropDownItemClicked);
            // 
            // 图例ToolStripMenuItem
            // 
            this.图例ToolStripMenuItem.Name = "图例ToolStripMenuItem";
            this.图例ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.图例ToolStripMenuItem.Text = "图例";
            // 
            // 指北针ToolStripMenuItem
            // 
            this.指北针ToolStripMenuItem.Name = "指北针ToolStripMenuItem";
            this.指北针ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.指北针ToolStripMenuItem.Text = "指北针";
            // 
            // 比例尺ToolStripMenuItem
            // 
            this.比例尺ToolStripMenuItem.Name = "比例尺ToolStripMenuItem";
            this.比例尺ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.比例尺ToolStripMenuItem.Text = "比例尺";
            // 
            // 文本ToolStripMenuItem
            // 
            this.文本ToolStripMenuItem.Name = "文本ToolStripMenuItem";
            this.文本ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.文本ToolStripMenuItem.Text = "文本";
            // 
            // 分等级法渲染ToolStripMenuItem
            // 
            this.分等级法渲染ToolStripMenuItem.Name = "分等级法渲染ToolStripMenuItem";
            this.分等级法渲染ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.分等级法渲染ToolStripMenuItem.Text = "分等级法渲染";
            this.分等级法渲染ToolStripMenuItem.Click += new System.EventHandler(this.分等级法渲染ToolStripMenuItem_Click);
            // 
            // 简单符号法渲染ToolStripMenuItem
            // 
            this.简单符号法渲染ToolStripMenuItem.Name = "简单符号法渲染ToolStripMenuItem";
            this.简单符号法渲染ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.简单符号法渲染ToolStripMenuItem.Text = "简单符号法渲染";
            this.简单符号法渲染ToolStripMenuItem.Click += new System.EventHandler(this.简单符号法渲染ToolStripMenuItem_Click);
            // 
            // 唯一值法渲染ToolStripMenuItem
            // 
            this.唯一值法渲染ToolStripMenuItem.Name = "唯一值法渲染ToolStripMenuItem";
            this.唯一值法渲染ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.唯一值法渲染ToolStripMenuItem.Text = "唯一值法渲染";
            this.唯一值法渲染ToolStripMenuItem.Click += new System.EventHandler(this.唯一值法渲染ToolStripMenuItem_Click);
            // 
            // 比例符号法渲染ToolStripMenuItem
            // 
            this.比例符号法渲染ToolStripMenuItem.Name = "比例符号法渲染ToolStripMenuItem";
            this.比例符号法渲染ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.比例符号法渲染ToolStripMenuItem.Text = "比例符号法渲染";
            this.比例符号法渲染ToolStripMenuItem.Click += new System.EventHandler(this.比例符号法渲染ToolStripMenuItem_Click);
            // 
            // 点状密度法渲染ToolStripMenuItem
            // 
            this.点状密度法渲染ToolStripMenuItem.Name = "点状密度法渲染ToolStripMenuItem";
            this.点状密度法渲染ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.点状密度法渲染ToolStripMenuItem.Text = "点状密度法渲染";
            this.点状密度法渲染ToolStripMenuItem.Click += new System.EventHandler(this.点状密度法渲染ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(208, 17);
            this.toolStripStatusLabel1.Text = "https://www.cnblogs.com/edcoder";
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(804, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.axLicenseControl1);
            this.splitContainer1.Size = new System.Drawing.Size(804, 394);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(231, 394);
            this.axTOCControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 394);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(561, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据制图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(555, 362);
            this.axMapControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(561, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局制图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(555, 362);
            this.axPageLayoutControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(468, 343);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 469);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "渲染专题地图";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简单符号法渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分等级法渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 唯一值法渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比例符号法渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点状密度法渲染ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem 添加地图元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指北针ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比例尺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文本ToolStripMenuItem;
    }
}

