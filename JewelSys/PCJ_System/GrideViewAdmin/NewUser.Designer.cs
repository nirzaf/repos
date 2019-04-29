namespace PCJ_System
{
    partial class NewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUser));
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btndelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnupdate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnsave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.combo_usertype = new System.Windows.Forms.ComboBox();
            this.txtcon_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtbx_ID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 31);
            this.label3.TabIndex = 29;
            this.label3.Text = "Manage New Users";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btndelete
            // 
            this.btndelete.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btndelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btndelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndelete.BorderRadius = 0;
            this.btndelete.ButtonText = "  Delete";
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.DisabledColor = System.Drawing.Color.Gray;
            this.btndelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btndelete.Iconimage = ((System.Drawing.Image)(resources.GetObject("btndelete.Iconimage")));
            this.btndelete.Iconimage_right = null;
            this.btndelete.Iconimage_right_Selected = null;
            this.btndelete.Iconimage_Selected = null;
            this.btndelete.IconMarginLeft = 0;
            this.btndelete.IconMarginRight = 0;
            this.btndelete.IconRightVisible = true;
            this.btndelete.IconRightZoom = 0D;
            this.btndelete.IconVisible = true;
            this.btndelete.IconZoom = 60D;
            this.btndelete.IsTab = false;
            this.btndelete.Location = new System.Drawing.Point(375, 96);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btndelete.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btndelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btndelete.selected = false;
            this.btndelete.Size = new System.Drawing.Size(136, 37);
            this.btndelete.TabIndex = 33;
            this.btndelete.Text = "  Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Textcolor = System.Drawing.Color.White;
            this.btndelete.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnupdate.BackColor = System.Drawing.Color.DarkCyan;
            this.btnupdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnupdate.BorderRadius = 0;
            this.btnupdate.ButtonText = "  Update";
            this.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupdate.DisabledColor = System.Drawing.Color.Gray;
            this.btnupdate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnupdate.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnupdate.Iconimage")));
            this.btnupdate.Iconimage_right = null;
            this.btnupdate.Iconimage_right_Selected = null;
            this.btnupdate.Iconimage_Selected = null;
            this.btnupdate.IconMarginLeft = 0;
            this.btnupdate.IconMarginRight = 0;
            this.btnupdate.IconRightVisible = true;
            this.btnupdate.IconRightZoom = 0D;
            this.btnupdate.IconVisible = true;
            this.btnupdate.IconZoom = 60D;
            this.btnupdate.IsTab = false;
            this.btnupdate.Location = new System.Drawing.Point(217, 96);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btnupdate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnupdate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnupdate.selected = false;
            this.btnupdate.Size = new System.Drawing.Size(136, 37);
            this.btnupdate.TabIndex = 32;
            this.btnupdate.Text = "  Update";
            this.btnupdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Textcolor = System.Drawing.Color.White;
            this.btnupdate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnsave
            // 
            this.btnsave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnsave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsave.BorderRadius = 0;
            this.btnsave.ButtonText = "   SAVE";
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.DisabledColor = System.Drawing.Color.Gray;
            this.btnsave.ForeColor = System.Drawing.Color.Coral;
            this.btnsave.Iconcolor = System.Drawing.Color.Transparent;
            this.btnsave.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnsave.Iconimage")));
            this.btnsave.Iconimage_right = null;
            this.btnsave.Iconimage_right_Selected = null;
            this.btnsave.Iconimage_Selected = null;
            this.btnsave.IconMarginLeft = 0;
            this.btnsave.IconMarginRight = 0;
            this.btnsave.IconRightVisible = true;
            this.btnsave.IconRightZoom = 0D;
            this.btnsave.IconVisible = true;
            this.btnsave.IconZoom = 60D;
            this.btnsave.IsTab = false;
            this.btnsave.Location = new System.Drawing.Point(53, 98);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Normalcolor = System.Drawing.Color.DarkCyan;
            this.btnsave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnsave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnsave.selected = false;
            this.btnsave.Size = new System.Drawing.Size(136, 37);
            this.btnsave.TabIndex = 31;
            this.btnsave.Text = "   SAVE";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Textcolor = System.Drawing.Color.White;
            this.btnsave.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // combo_usertype
            // 
            this.combo_usertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_usertype.FormattingEnabled = true;
            this.combo_usertype.Items.AddRange(new object[] {
            "StockController",
            "Administrator"});
            this.combo_usertype.Location = new System.Drawing.Point(247, 220);
            this.combo_usertype.Name = "combo_usertype";
            this.combo_usertype.Size = new System.Drawing.Size(156, 21);
            this.combo_usertype.TabIndex = 0;
            // 
            // txtcon_password
            // 
            this.txtcon_password.Location = new System.Drawing.Point(655, 253);
            this.txtcon_password.Name = "txtcon_password";
            this.txtcon_password.PasswordChar = '*';
            this.txtcon_password.Size = new System.Drawing.Size(156, 20);
            this.txtcon_password.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(467, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "*Confirm Password     : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(95, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "*User Type          : ";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(655, 215);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(156, 20);
            this.txtpassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(499, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "*Password          : ";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(247, 256);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(156, 20);
            this.txtusername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(98, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "*User Name        : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(31, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 128);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 331);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(824, 122);
            this.dataGridView1.TabIndex = 44;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtbx_ID
            // 
            this.txtbx_ID.Location = new System.Drawing.Point(244, 152);
            this.txtbx_ID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtbx_ID.Name = "txtbx_ID";
            this.txtbx_ID.Size = new System.Drawing.Size(156, 20);
            this.txtbx_ID.TabIndex = 4;
            this.txtbx_ID.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(814, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(860, 285);
            this.button_clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(86, 19);
            this.button_clear.TabIndex = 48;
            this.button_clear.Text = "CLEAR";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtbx_ID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.combo_usertype);
            this.Controls.Add(this.txtcon_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewUser";
            this.Size = new System.Drawing.Size(1193, 860);
            this.Load += new System.EventHandler(this.NewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btndelete;
        private Bunifu.Framework.UI.BunifuFlatButton btnupdate;
        private Bunifu.Framework.UI.BunifuFlatButton btnsave;
        private System.Windows.Forms.ComboBox combo_usertype;
        private System.Windows.Forms.TextBox txtcon_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtbx_ID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_clear;
    }
}
