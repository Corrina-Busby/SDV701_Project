namespace WinForm_admin
{
    partial class frmItem
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstDescription = new System.Windows.Forms.ListBox();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Item: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Style / SKU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last Date Modified:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Qty:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 432);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "NZ$:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description:";
            // 
            // lstDescription
            // 
            this.lstDescription.FormattingEnabled = true;
            this.lstDescription.ItemHeight = 16;
            this.lstDescription.Items.AddRange(new object[] {
            "    Prada Boutique print T-shirt",
            "",
            "    Off-white cotton jersey",
            "    Prada Boutique, Web and Horsebit print",
            "    Crewneck",
            "    Oversize fit",
            "    Length: 72cm based on a size small",
            "    100% cotton",
            "",
            "    Made in Italy"});
            this.lstDescription.Location = new System.Drawing.Point(115, 115);
            this.lstDescription.Name = "lstDescription";
            this.lstDescription.Size = new System.Drawing.Size(398, 196);
            this.lstDescription.TabIndex = 7;
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSell.Location = new System.Drawing.Point(466, 432);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(142, 33);
            this.btnSell.TabIndex = 8;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(466, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(115, 52);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(162, 22);
            this.txtSKU.TabIndex = 10;
            this.txtSKU.Text = "TEE-01-WHI";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(115, 24);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(162, 22);
            this.txtItem.TabIndex = 11;
            this.txtItem.Text = "Shirt";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(115, 396);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 22);
            this.txtQuantity.TabIndex = 13;
            this.txtQuantity.Text = "2";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(115, 432);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPrice.TabIndex = 14;
            this.txtPrice.Text = "500";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 460);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "05/05/2020";
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 525);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lstDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmItem";
            this.Text = "Item ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstDescription;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox textBox1;
    }
}