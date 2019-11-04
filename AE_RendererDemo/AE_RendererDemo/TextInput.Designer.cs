namespace AE_RendererDemo
{
    partial class TextInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTypeface = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.txtOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTypeface
            // 
            this.txtTypeface.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTypeface.Location = new System.Drawing.Point(203, 21);
            this.txtTypeface.Name = "txtTypeface";
            this.txtTypeface.Size = new System.Drawing.Size(41, 23);
            this.txtTypeface.TabIndex = 11;
            this.txtTypeface.Text = "20";
            this.txtTypeface.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(127, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "字体大小：";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInput.Location = new System.Drawing.Point(203, 62);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(258, 23);
            this.txtInput.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(376, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.btnOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverwrite.Location = new System.Drawing.Point(250, 109);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(75, 30);
            this.btnOverwrite.TabIndex = 7;
            this.btnOverwrite.Text = "重新输入";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // txtOK
            // 
            this.txtOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Khaki;
            this.txtOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtOK.Location = new System.Drawing.Point(131, 109);
            this.txtOK.Name = "txtOK";
            this.txtOK.Size = new System.Drawing.Size(75, 30);
            this.txtOK.TabIndex = 8;
            this.txtOK.Text = "确定";
            this.txtOK.UseVisualStyleBackColor = true;
            this.txtOK.Click += new System.EventHandler(this.txtOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(87, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "请输入专题图名：";
            // 
            // TextInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 172);
            this.Controls.Add(this.txtTypeface);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.txtOK);
            this.Controls.Add(this.label1);
            this.Name = "TextInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTypeface;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button txtOK;
        private System.Windows.Forms.Label label1;
    }
}