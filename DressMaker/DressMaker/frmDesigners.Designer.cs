﻿namespace SimplyFashionAdmin
{
    partial class frmDesigners
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
            this.lstDesigners = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenSelectedDesigner = new System.Windows.Forms.Button();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.btnOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDesigners
            // 
            this.lstDesigners.FormattingEnabled = true;
            this.lstDesigners.ItemHeight = 16;
            this.lstDesigners.Items.AddRange(new object[] {
            "designerNames"});
            this.lstDesigners.Location = new System.Drawing.Point(39, 44);
            this.lstDesigners.Name = "lstDesigners";
            this.lstDesigners.Size = new System.Drawing.Size(225, 116);
            this.lstDesigners.Sorted = true;
            this.lstDesigners.TabIndex = 0;
            this.lstDesigners.DoubleClick += new System.EventHandler(this.lstDesigners_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(285, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "DesignerZ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Value:";
            // 
            // btnOpenSelectedDesigner
            // 
            this.btnOpenSelectedDesigner.Location = new System.Drawing.Point(285, 124);
            this.btnOpenSelectedDesigner.Name = "btnOpenSelectedDesigner";
            this.btnOpenSelectedDesigner.Size = new System.Drawing.Size(73, 36);
            this.btnOpenSelectedDesigner.TabIndex = 8;
            this.btnOpenSelectedDesigner.Text = "Open";
            this.btnOpenSelectedDesigner.UseVisualStyleBackColor = true;
            this.btnOpenSelectedDesigner.Click += new System.EventHandler(this.btnOpenSelectedDesigner_Click);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Location = new System.Drawing.Point(164, 170);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(100, 23);
            this.lblTotalValue.TabIndex = 9;
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(39, 211);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(225, 36);
            this.btnOrders.TabIndex = 10;
            this.btnOrders.Text = "Check Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // frmDesigners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 272);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.btnOpenSelectedDesigner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstDesigners);
            this.Name = "frmDesigners";
            this.Text = "Simply Fashion";
            this.Load += new System.EventHandler(this.frmDesigners_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenSelectedDesigner;
        private System.Windows.Forms.Label lblTotalValue;
        internal System.Windows.Forms.ListBox lstDesigners;
        private System.Windows.Forms.Button btnOrders;
    }
}

