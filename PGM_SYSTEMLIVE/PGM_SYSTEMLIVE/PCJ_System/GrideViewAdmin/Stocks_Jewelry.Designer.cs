namespace PCJ_System
{
    partial class Stocks_Jewelry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stocks_Jewelry));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.stockEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pCJ_SYSTEM_DBDataSet5 = new PCJ_System.PCJ_SYSTEM_DBDataSet5();
            this.textbox1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.stock_EntryTableAdapter = new PCJ_System.PCJ_SYSTEM_DBDataSet5TableAdapters.Stock_EntryTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Stock_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_of_pieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_of_Gems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gem_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Create_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_of_other_Gems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Other_Gems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight_of_other_Gems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 31);
            this.label1.TabIndex = 55;
            this.label1.Text = "Stocks [ Jewelry ]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(53, 98);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.DarkCyan;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(136, 37);
            this.bunifuFlatButton1.TabIndex = 58;
            this.bunifuFlatButton1.Text = "  Add Stock";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
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
            this.btnrefresh.Location = new System.Drawing.Point(202, 98);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btnrefresh.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnrefresh.OnHoverTextColor = System.Drawing.Color.White;
            this.btnrefresh.selected = false;
            this.btnrefresh.Size = new System.Drawing.Size(136, 37);
            this.btnrefresh.TabIndex = 60;
            this.btnrefresh.Text = "   Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Textcolor = System.Drawing.Color.White;
            this.btnrefresh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // stockEntryBindingSource
            // 
            this.stockEntryBindingSource.DataMember = "Stock_Entry";
            this.stockEntryBindingSource.DataSource = this.pCJ_SYSTEM_DBDataSet5;
            // 
            // pCJ_SYSTEM_DBDataSet5
            // 
            this.pCJ_SYSTEM_DBDataSet5.DataSetName = "PCJ_SYSTEM_DBDataSet5";
            this.pCJ_SYSTEM_DBDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textbox1
            // 
            this.textbox1.BackColor = System.Drawing.SystemColors.Control;
            this.textbox1.BorderColorFocused = System.Drawing.Color.Blue;
            this.textbox1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textbox1.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.textbox1.BorderThickness = 1;
            this.textbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textbox1.ForeColor = System.Drawing.Color.Silver;
            this.textbox1.isPassword = false;
            this.textbox1.Location = new System.Drawing.Point(988, 102);
            this.textbox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(174, 27);
            this.textbox1.TabIndex = 62;
            this.textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textbox1.OnValueChanged += new System.EventHandler(this.textbox1_OnValueChanged);
            this.textbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(864, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Search Stock  :";
            // 
            // stock_EntryTableAdapter
            // 
            this.stock_EntryTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stock_No,
            this.No_of_pieces,
            this.Item_Description,
            this.Item_Type,
            this.No_of_Gems,
            this.Gem_Type,
            this.Weight,
            this.Cost,
            this.ItemImage,
            this.Create_Date,
            this.Update_Date,
            this.UserID,
            this.Update_UserID,
            this.No_of_other_Gems,
            this.Other_Gems,
            this.Weight_of_other_Gems});
            this.dataGridView1.Location = new System.Drawing.Point(53, 182);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1110, 650);
            this.dataGridView1.TabIndex = 68;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // Stock_No
            // 
            this.Stock_No.HeaderText = "StockNo";
            this.Stock_No.Name = "Stock_No";
            this.Stock_No.ReadOnly = true;
            // 
            // No_of_pieces
            // 
            this.No_of_pieces.HeaderText = "Quantity";
            this.No_of_pieces.Name = "No_of_pieces";
            this.No_of_pieces.ReadOnly = true;
            // 
            // Item_Description
            // 
            this.Item_Description.HeaderText = "Metal";
            this.Item_Description.Name = "Item_Description";
            this.Item_Description.ReadOnly = true;
            // 
            // Item_Type
            // 
            this.Item_Type.HeaderText = "Item Type";
            this.Item_Type.Name = "Item_Type";
            this.Item_Type.ReadOnly = true;
            // 
            // No_of_Gems
            // 
            this.No_of_Gems.HeaderText = "Nr of Gems";
            this.No_of_Gems.Name = "No_of_Gems";
            this.No_of_Gems.ReadOnly = true;
            // 
            // Gem_Type
            // 
            this.Gem_Type.HeaderText = "Gem Type";
            this.Gem_Type.Name = "Gem_Type";
            this.Gem_Type.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // ItemImage
            // 
            this.ItemImage.HeaderText = "Image";
            this.ItemImage.Name = "ItemImage";
            this.ItemImage.ReadOnly = true;
            // 
            // Create_Date
            // 
            this.Create_Date.HeaderText = "Created Date";
            this.Create_Date.Name = "Create_Date";
            this.Create_Date.ReadOnly = true;
            // 
            // Update_Date
            // 
            this.Update_Date.HeaderText = "Created User";
            this.Update_Date.Name = "Update_Date";
            this.Update_Date.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "Updated Date";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // Update_UserID
            // 
            this.Update_UserID.HeaderText = "Update User";
            this.Update_UserID.Name = "Update_UserID";
            this.Update_UserID.ReadOnly = true;
            // 
            // No_of_other_Gems
            // 
            this.No_of_other_Gems.HeaderText = "Nr of other Gems";
            this.No_of_other_Gems.Name = "No_of_other_Gems";
            this.No_of_other_Gems.ReadOnly = true;
            this.No_of_other_Gems.Visible = false;
            // 
            // Other_Gems
            // 
            this.Other_Gems.HeaderText = "Other Gems";
            this.Other_Gems.Name = "Other_Gems";
            this.Other_Gems.ReadOnly = true;
            this.Other_Gems.Visible = false;
            // 
            // Weight_of_other_Gems
            // 
            this.Weight_of_other_Gems.HeaderText = "Weight of other Gems";
            this.Weight_of_other_Gems.Name = "Weight_of_other_Gems";
            this.Weight_of_other_Gems.ReadOnly = true;
            this.Weight_of_other_Gems.Visible = false;
            // 
            // Stocks_Jewelry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Stocks_Jewelry";
            this.Size = new System.Drawing.Size(1193, 860);
            this.Load += new System.EventHandler(this.Stocks_Jewelry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btnrefresh;
        private Bunifu.Framework.UI.BunifuMetroTextbox textbox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource stockEntryBindingSource;
        private PCJ_SYSTEM_DBDataSet5 pCJ_SYSTEM_DBDataSet5;
        private PCJ_SYSTEM_DBDataSet5TableAdapters.Stock_EntryTableAdapter stock_EntryTableAdapter;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_of_pieces;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_of_Gems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gem_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewImageColumn ItemImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_of_other_Gems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Other_Gems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight_of_other_Gems;
    }
}
