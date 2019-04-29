namespace PCJ_System
{
    partial class SCStocks_Gems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCStocks_Gems));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnrefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuMetroTextbox1 = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.stockEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pCJ_SYSTEM_DBDataSet2 = new PCJ_System.PCJ_SYSTEM_DBDataSet2();
            this.stock_EntryTableAdapter = new PCJ_System.PCJ_SYSTEM_DBDataSet2TableAdapters.Stock_EntryTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Stock_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Create_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.pictureBox1.TabIndex = 34;
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
            this.label3.Size = new System.Drawing.Size(230, 38);
            this.label3.TabIndex = 33;
            this.label3.Text = "Stocks [ Gem ]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.btnrefresh.TabIndex = 42;
            this.btnrefresh.Text = "   Refresh";
            this.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Textcolor = System.Drawing.Color.White;
            this.btnrefresh.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
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
            this.bunifuFlatButton1.TabIndex = 40;
            this.bunifuFlatButton1.Text = "  Add Stock";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // bunifuMetroTextbox1
            // 
            this.bunifuMetroTextbox1.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuMetroTextbox1.BorderColorFocused = System.Drawing.Color.AliceBlue;
            this.bunifuMetroTextbox1.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMetroTextbox1.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.bunifuMetroTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bunifuMetroTextbox1.BorderThickness = 1;
            this.bunifuMetroTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMetroTextbox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuMetroTextbox1.ForeColor = System.Drawing.Color.Black;
            this.bunifuMetroTextbox1.isPassword = false;
            this.bunifuMetroTextbox1.Location = new System.Drawing.Point(1317, 121);
            this.bunifuMetroTextbox1.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuMetroTextbox1.Name = "bunifuMetroTextbox1";
            this.bunifuMetroTextbox1.Size = new System.Drawing.Size(231, 33);
            this.bunifuMetroTextbox1.TabIndex = 63;
            this.bunifuMetroTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuMetroTextbox1.OnValueChanged += new System.EventHandler(this.bunifuMetroTextbox1_OnValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1152, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 23);
            this.label2.TabIndex = 65;
            this.label2.Text = "Search Stock  :";
            // 
            // stockEntryBindingSource
            // 
            this.stockEntryBindingSource.DataMember = "Stock_Entry";
            this.stockEntryBindingSource.DataSource = this.pCJ_SYSTEM_DBDataSet2;
            // 
            // pCJ_SYSTEM_DBDataSet2
            // 
            this.pCJ_SYSTEM_DBDataSet2.DataSetName = "PCJ_SYSTEM_DBDataSet2";
            this.pCJ_SYSTEM_DBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.Stock_ID,
            this.Item_Description,
            this.Quantity,
            this.Weight,
            this.Cost,
            this.ItemImage,
            this.Create_Date,
            this.UserID,
            this.Update_Date,
            this.Update_UserID});
            this.dataGridView1.Location = new System.Drawing.Point(71, 224);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1480, 800);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // Stock_ID
            // 
            this.Stock_ID.HeaderText = "StockNo";
            this.Stock_ID.Name = "Stock_ID";
            this.Stock_ID.ReadOnly = true;
            // 
            // Item_Description
            // 
            this.Item_Description.HeaderText = "Description";
            this.Item_Description.Name = "Item_Description";
            this.Item_Description.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
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
            this.Create_Date.HeaderText = "Create Date";
            this.Create_Date.Name = "Create_Date";
            this.Create_Date.ReadOnly = true;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // Update_Date
            // 
            this.Update_Date.HeaderText = "Update Date";
            this.Update_Date.Name = "Update_Date";
            this.Update_Date.ReadOnly = true;
            this.Update_Date.Visible = false;
            // 
            // Update_UserID
            // 
            this.Update_UserID.HeaderText = "Update UserID";
            this.Update_UserID.Name = "Update_UserID";
            this.Update_UserID.ReadOnly = true;
            this.Update_UserID.Visible = false;
            // 
            // SCStocks_Gems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bunifuMetroTextbox1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SCStocks_Gems";
            this.Size = new System.Drawing.Size(1591, 1058);
            this.Load += new System.EventHandler(this.SCStocks_Gems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCJ_SYSTEM_DBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton btnrefresh;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuMetroTextbox bunifuMetroTextbox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource stockEntryBindingSource;
        private PCJ_SYSTEM_DBDataSet2 pCJ_SYSTEM_DBDataSet2;
        private PCJ_SYSTEM_DBDataSet2TableAdapters.Stock_EntryTableAdapter stock_EntryTableAdapter;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewImageColumn ItemImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_UserID;
    }
}
