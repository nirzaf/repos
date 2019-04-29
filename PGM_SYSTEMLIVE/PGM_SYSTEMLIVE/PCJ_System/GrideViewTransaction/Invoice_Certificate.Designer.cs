namespace PCJ_System
{
    partial class Invoice_Certificate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoice_Certificate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.invoice_Certificate1 = new System.Windows.Forms.DataGridView();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuMetroTextbox1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_Certificate1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(85, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 38);
            this.label3.TabIndex = 31;
            this.label3.Text = "Invoice";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.DarkCyan;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "  Add Stock";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.ForeColor = System.Drawing.Color.Coral;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 60D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(71, 121);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.DarkCyan;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(181, 46);
            this.bunifuFlatButton1.TabIndex = 33;
            this.bunifuFlatButton1.Text = "  Add Stock";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // invoice_Certificate1
            // 
            this.invoice_Certificate1.AllowUserToAddRows = false;
            this.invoice_Certificate1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.invoice_Certificate1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.invoice_Certificate1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.invoice_Certificate1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoice_Certificate1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.CustomerName,
            this.CustomerAddress,
            this.Date});
            this.invoice_Certificate1.Location = new System.Drawing.Point(71, 224);
            this.invoice_Certificate1.Margin = new System.Windows.Forms.Padding(4);
            this.invoice_Certificate1.Name = "invoice_Certificate1";
            this.invoice_Certificate1.Size = new System.Drawing.Size(1480, 761);
            this.invoice_Certificate1.TabIndex = 37;
            this.invoice_Certificate1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoice_Certificate1_CellDoubleClick);
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // CustomerAddress
            // 
            this.CustomerAddress.HeaderText = "Customer Address";
            this.CustomerAddress.Name = "CustomerAddress";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // bunifuMetroTextbox1
            // 
            this.bunifuMetroTextbox1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuMetroTextbox1.BorderColorFocused = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox1.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox1.BorderThickness = 1;
            this.bunifuMetroTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.bunifuMetroTextbox1.ForeColor = System.Drawing.Color.Silver;
            this.bunifuMetroTextbox1.isPassword = false;
            this.bunifuMetroTextbox1.Location = new System.Drawing.Point(1313, 114);
            this.bunifuMetroTextbox1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuMetroTextbox1.Name = "bunifuMetroTextbox1";
            this.bunifuMetroTextbox1.Size = new System.Drawing.Size(232, 38);
            this.bunifuMetroTextbox1.TabIndex = 38;
            this.bunifuMetroTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuMetroTextbox1.OnValueChanged += new System.EventHandler(this.bunifuMetroTextbox1_OnValueChanged);
            this.bunifuMetroTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bunifuMetroTextbox1_KeyUp);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnrefresh.BackColor = System.Drawing.Color.DarkCyan;
            this.btnrefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrefresh.BorderRadius = 0;
            this.btnrefresh.ButtonText = "   Refresh";
            this.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrefresh.DisabledColor = System.Drawing.Color.Gray;
            this.btnrefresh.Iconcolor = System.Drawing.Color.Transparent;
            this.btnrefresh.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnrefresh.Iconimage")));
            this.btnrefresh.Iconimage_right = null;
            this.btnrefresh.Iconimage_right_Selected = null;
            this.btnrefresh.Iconimage_Selected = null;
            this.btnrefresh.IconMarginLeft = 0;
            this.btnrefresh.IconMarginRight = 0;
            this.btnrefresh.IconRightVisible = true;
            this.btnrefresh.IconRightZoom = 0D;
            this.btnrefresh.IconVisible = true;
            this.btnrefresh.IconZoom = 60D;
            this.btnrefresh.IsTab = false;
            this.btnrefresh.Location = new System.Drawing.Point(269, 121);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btnrefresh.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnrefresh.OnHoverTextColor = System.Drawing.Color.White;
            this.btnrefresh.selected = false;
            this.btnrefresh.Size = new System.Drawing.Size(181, 46);
            this.btnrefresh.TabIndex = 39;
            this.btnrefresh.Text = "   Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Textcolor = System.Drawing.Color.White;
            this.btnrefresh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1148, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 64;
            this.label2.Text = "Search Stock  :";
            // 
            // Invoice_Certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.bunifuMetroTextbox1);
            this.Controls.Add(this.invoice_Certificate1);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Invoice_Certificate";
            this.Size = new System.Drawing.Size(1591, 989);
            this.Load += new System.EventHandler(this.Invoice_Certificate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_Certificate1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DataGridView invoice_Certificate1;
        private Bunifu.Framework.UI.BunifuMetroTextbox bunifuMetroTextbox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnrefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}
