using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace PCJ_System
{
    public partial class S_Jewelry : Form
    {
        private string[] last_amount = { "", "", "" };
        int xy;
        SqlConnection conn;

        int currentPicture;

        Label[] pictureBorders;

        PictureBox[] pictureBoxes;
        string[] picturePaths;
        string stockNo;
        string stockId;
        bool[] pictureIsNew;


        ///SqlCommand cmd;
        public S_Jewelry()
        {
            try
            {

                DB_CONNECTION dbObj = new DB_CONNECTION();
                conn = dbObj.getConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Can't Open Connection!! " + ex);
            }

            InitializeComponent();

            // create array of pixtureboxes so that it is easier to iterate

            pictureBoxes = new PictureBox[10];
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;
            pictureBoxes[6] = pictureBox7;
            pictureBoxes[7] = pictureBox8;
            pictureBoxes[8] = pictureBox9;
            pictureBoxes[9] = pictureBox10;

            picturePaths = new string[pictureBoxes.Length];
            pictureIsNew = new bool[pictureBoxes.Length];

            for (int i = 0; i < pictureIsNew.Length; ++i)
            {
                pictureIsNew[i] = false;
            }



            radioButton1.Checked = true;





            pictureBorders = new Label[pictureBoxes.Length];
            pictureBorders[0] = currentimage1;
            pictureBorders[1] = currentimage2;
            pictureBorders[2] = currentimage3;
            pictureBorders[3] = currentimage4;
            pictureBorders[4] = currentimage5;
            pictureBorders[5] = currentimage6;
            pictureBorders[6] = currentimage7;
            pictureBorders[7] = currentimage8;
            pictureBorders[8] = currentimage9;
            pictureBorders[9] = currentimage10;

            foreach (var border in pictureBorders)
            {
                border.Visible = false;
            }
            

        }

        //cmbCurrency1.SelectedIndex = 0;
        

        private void UpdateStockNo()
        {
            if (radioButton1.Checked == true)
            {
                string stockGroup = "M";
                //string metal = "";
                string itemType = "";
               // string gemType;
                string otherGemType = "";

                if (radioButton2.Checked)
                {
                    stockGroup = "U";
                }

                if (combo_item_type.SelectedIndex != -1)
                {
                    switch (combo_item_type.SelectedItem.ToString())
                    {
                        case "RING":
                            itemType = "R";
                            break;
                        case "PENDANT":
                            itemType = "P";
                            break;
                        case "NECKLACE":
                            itemType = "N";
                            break;
                        case "BRACELET":
                            itemType = "BR";
                            break;
                        case "CUFFLINK":
                            itemType = "CF";
                            break;
                        case "EARRING":
                            itemType = "E";
                            break;
                        case "BROACH":
                            itemType = "B";
                            break;
                        case "TIE-PIN":
                            itemType = "T";
                            break;
                    }
                }


               /* if (txt_gem_type.SelectedIndex != -1 && txt_no_of_gems.Text.Length != 0)
                {
                    if (txt_gem_type.SelectedItem.ToString() == "DIAMOND")
                    {
                        //gemType = "D";
                    }
                    else
                    {
                      //  gemType = "";
                    }
                }
                else
                {
                   // gemType = "";
                }*/

                if (txt_other_gems.SelectedIndex != -1)
                {
                    if (txt_other_gems.SelectedItem.ToString() == "DIAMONDS")
                    {
                        otherGemType = "D";
                    }
                }
                else if (combo_itemk_description.SelectedIndex != -1 && combo_itemk_description.SelectedItem.ToString() == "SILVER")
                {
                    otherGemType = "S";
                }

                //else
                //{
                //    otherGemType = "";
                //}

                conn.Close();
                conn.Open();

                stockNo = String.Format("{0}{1}{2}", stockGroup, otherGemType, itemType);
                stockNo = stockNo.Substring(0, Math.Min(3, stockNo.Length));
                stockId = "001";

                //there was an errror throwing
                using (var command = new SqlCommand("SELECT TOP 1 Stock_ID FROM Stock_Entry WHERE Stock_No=@StockNo ORDER BY Stock_ID DESC", conn))
                {
                    command.Parameters.AddWithValue("StockNo", stockNo);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stockId = String.Format("{0:D3}", (Int32.Parse(reader["Stock_ID"].ToString()) + 1));
                        }
                    }
                }
                txtstock_no.Text = String.Format("{0}{1}", stockNo, stockId);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtstock_no.Text.Length <= 0)
            {
                errorProvider1.SetError(txtstock_no, "Select the other fields to genereate the stock No");
            }
            else if (combo_item_type.Text.Length <= 0)
            {
                errorProvider1.SetError(combo_item_type, "This field cannot be empty");
            }
            else if (txt_no_of_gems.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_no_of_gems, "This field cannot be empty");
            }
            else if (combo_itemk_description.Text.Length <= 0)
            {
                errorProvider1.SetError(combo_itemk_description, "This field cannot be empty");
            }


            else if (txt_gem_type.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_gem_type, "This field cannot be empty");
            }

            else if (txt_gem_weight.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_gem_weight, "This field cannot be empty");
            }


            else if (txt_other_gems.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_other_gems, "This field cannot be empty");
            }

            else if (txt_weight_of_other_gems.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_weight_of_other_gems, "This field cannot be empty");
            }

            else if (txt_cost.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_cost, "This field cannot be empty");
            }
            else if (!atLeastOneImage())
            {
                // errorProvider1.SetError(pb1, "Please add an Image");
                errorProvider1.SetError(pictureBox1, "Please add an Image");
            }
            /*    else if (pb1.Image == null)
                {
                    errorProvider1.SetError(pb1, "Please add an Image");
                }*/

            else
            {
                try
                {
                    conn.Close();
                    conn.Open();
                    var tx = conn.BeginTransaction();

                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO Status_Of_Stocks(StockID,StockNo,StockType,Qty,Weight,Cost) VALUES(@StockID,@StockNo,@StockType,@Qty,@Weight,@Cost)", conn, tx);
                        command.Parameters.AddWithValue("@StockNo", stockNo);
                        command.Parameters.AddWithValue("@StockID", stockId);
                        command.Parameters.AddWithValue("@StockType", "Jewellery");
                        command.Parameters.AddWithValue("@Qty", txt_qty.Text);
                        command.Parameters.AddWithValue("@Weight", txt_gem_weight.Text);
                        command.Parameters.AddWithValue("@Cost", txt_cost.Text);
                        command.ExecuteNonQuery();

                        string commandText = "INSERT INTO Stock_Entry VALUES(@StockId,@StockNo,@StockType,@Quantity,@Gem_Type,@Gem_Weight,@Item_Description,@Item_Type,@No_of_Gems,@No_of_other_Gems,@Other_Gems,@Weight_of_other_Gems,@Cost,@Created_Date,@Updated_Date,@User_ID,@Update_UserID,@Imagepath,@CurrentImagePath)";
                        command = new SqlCommand(commandText, conn, tx);

                        command.Parameters.AddWithValue("@StockNo", stockNo);
                        command.Parameters.AddWithValue("@StockId", stockId);

                        command.Parameters.Add("@StockType", SqlDbType.VarChar);
                        command.Parameters["@StockType"].Value = Stock_Type.Text;

                        command.Parameters.Add("@Quantity", SqlDbType.Int);
                        command.Parameters["@Quantity"].Value = txt_qty.Text;

                        command.Parameters.Add("@Gem_Weight", SqlDbType.Float);
                        command.Parameters["@Gem_Weight"].Value = txt_gem_weight.Text;

                        command.Parameters.Add("@Item_Description", SqlDbType.NVarChar);
                        command.Parameters["@Item_Description"].Value = combo_itemk_description.Text;

                        command.Parameters.Add("@Item_Type", SqlDbType.NVarChar);
                        command.Parameters["@Item_Type"].Value = combo_item_type.Text;

                        command.Parameters.Add("@No_of_Gems", SqlDbType.Int);
                        command.Parameters["@No_of_Gems"].Value = txt_no_of_gems.Text;

                        command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar);
                        command.Parameters["@Gem_Type"].Value = txt_gem_type.Text;

                        command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int);
                        command.Parameters["@No_of_other_Gems"].Value = txt_no_of_other_gems.Text;

                        command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar);
                        command.Parameters["@Other_Gems"].Value = txt_other_gems.Text;

                        command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float);
                        command.Parameters["@Weight_of_other_Gems"].Value = txt_weight_of_other_gems.Text;

                 /*       if (pb1.Image != null)
                        {
                            MemoryStream stream = new MemoryStream();
                            pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] pic = stream.ToArray();
                            command.Parameters.Add("@image", SqlDbType.Image);
                            command.Parameters["@image"].Value = pic;
                            //command.Parameters.AddWithValue("@image", pic);
                            stream.Dispose();
                        }

                        else
                        {
                            SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                            imageParameter.Value = DBNull.Value;
                            command.Parameters.Add(imageParameter);
                        }*/

                        command.Parameters.Add("@Cost", SqlDbType.Decimal);
                        command.Parameters["@Cost"].Value = txt_cost.Text;

                        command.Parameters.Add("@Created_Date", SqlDbType.DateTime);
                        command.Parameters["@Created_Date"].Value = label11.Text;

                        command.Parameters.Add("@Updated_Date", SqlDbType.DateTime);
                        command.Parameters["@Updated_Date"].Value = label11.Text;

                        command.Parameters.Add("@User_ID", SqlDbType.NVarChar);
                        command.Parameters["@User_ID"].Value = hello.Text;

                        command.Parameters.Add("@Update_UserID", SqlDbType.NVarChar);
                        command.Parameters["@Update_UserID"].Value = "";

                        /*  command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);
                          command.Parameters["@Imagepath"].Value = TB_File_Path.Text + txtstock_no.Text + "\\";


                          String path = TB_File_Path.Text + txtstock_no.Text + "\\";*/

                        command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);

                        String path = TB_File_Path.Text + txtstock_no.Text + "\\";
                        command.Parameters["@Imagepath"].Value = path;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        command.Parameters.Add("@CurrentImagePath", SqlDbType.NVarChar);
                        for (int i = 0; i < pictureBoxes.Length; ++i)
                        {
                            if (pictureIsNew[i])
                            {
                                string targetPath = String.Format("{0}img-{1:D4}{2}", path, i, Path.GetExtension(picturePaths[i]));

                                if (i == currentPicture)
                                {
                                    command.Parameters["@CurrentImagePath"].Value = targetPath;
                                }

                                File.Copy(picturePaths[i], targetPath, true);
                            }
                        }
                        command.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }

                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //
                }
            }
        }

        private void S_Jewelry_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label11.Text = dateTime.ToString();
            hello.Text = GlobalVariablesClass.VariableOne;


            String path = (TB_File_Path.Text + txtstock_no.Text + "\\");

            currentPicture = 0;

            // TODO: CurrentImagePath from the Database

            string currentImagePath = "";
            conn.Close();
            conn.Open();
            using (var command = new SqlCommand("SELECT currentImagePath FROM Stock_Entry WHERE Stock_No=@StockNo AND Stock_ID=@Stock_Id", conn))
            {

                command.Parameters.AddWithValue("@StockNo", stockNo);
                command.Parameters.AddWithValue("@Stock_Id", stockId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentImagePath = reader.GetString(0);
                    }
                }
            }

            if (!String.IsNullOrEmpty(currentImagePath))
            {
                pictureBoxes[0].Image = Image.FromFile(currentImagePath);
                picturePaths[0] = currentImagePath;
                pictureBorders[0].Visible = true;
            }

            try
            {
                string[] imgs = Directory.GetFiles(path, "*.Jpg");

                for (int i = 1; i < imgs.Length && i < pictureBoxes.Length; ++i)
                {
                    if (picturePaths[i] != picturePaths[0])
                    {
                        pictureBoxes[i].Image = Image.FromFile(imgs[i]);
                        picturePaths[i] = imgs[i];
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString(), "Error Message: No Images", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            /*  String path = (TB_File_Path.Text + txtstock_no.Text + "\\");
               //string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();

               try {
                   string[] imgs = Directory.GetFiles(path, "*.Jpg");

                   for (xy = 0; xy < imgs.Length && xy < pictureBoxes.Length; ++xy)
                   {
                       pictureBoxes[xy].Image = Image.FromFile(imgs[xy]);
                       picturePaths[xy] = imgs[xy];
                   }
               } catch (Exception ex)
               {
                   MessageBox.Show(ex.ToString(), "Error Message: NO images", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }*/

            txt_no_of_gems.GotFocus += new EventHandler(this.TextGotFocus1);
            txt_no_of_gems.LostFocus += new EventHandler(this.TextLostFocus1);

            txt_gem_weight.GotFocus += new EventHandler(this.TextGotFocus);
            txt_gem_weight.LostFocus += new EventHandler(this.TextLostFocus);

            txt_no_of_other_gems.GotFocus += new EventHandler(this.TextGotFocus1);
            txt_no_of_other_gems.LostFocus += new EventHandler(this.TextLostFocus1);

            txt_weight_of_other_gems.GotFocus += new EventHandler(this.TextGotFocus);
            txt_weight_of_other_gems.LostFocus += new EventHandler(this.TextLostFocus);

            txt_cost.GotFocus += new EventHandler(this.TextGotFocus);
            txt_cost.LostFocus += new EventHandler(this.TextLostFocus);

        }

        public void TextGotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0.0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        public void TextGotFocus1(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus1(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
                tb.ForeColor = Color.Brown;
            }
        }

        public void TextLostFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0.0";
                tb.ForeColor = Color.Brown;
            }
        }


        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();
            dlgOpenFileDialog.Filter = "jpg files(*.jpg|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
                pb1.Image = image;

            }*/
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Match m = Regex.Match(txtstock_no.Text, "([a-zA-Z]+)([0-9]+)");
            if (m.Groups.Count < 3)
            {
                // do nothing
                MessageBox.Show(m.Groups.Count.ToString());
                return;
            }
            stockId = m.Groups[2].Value;
            stockNo = m.Groups[1].Value;

            try
            {
                conn.Close();
                conn.Open();
                SqlCommand command = new SqlCommand("Update Stock_Entry set Stock_Type = @Stock_Type, No_of_Pieces = @No_of_Pieces, Gem_Type = @Gem_Type, Weight = @Gem_Weight, Item_Description = @Item_Description, Item_Type = @Item_Type, No_of_Gems = @No_of_Gems,  No_of_other_Gems = @No_of_other_Gems , Other_Gems = @Other_Gems , Weight_of_other_Gems = @Weight_of_other_Gems , Cost = @Cost, Update_Date = @Update_Date, Update_UserID = @Update_UserID, Imagepath= @Imagepath, CurrentImagePath=@CurrentImagePath WHERE  Stock_No = @Stock_No AND Stock_ID=@Stock_ID", conn);


                command.Parameters.AddWithValue("Stock_No", stockNo);
                command.Parameters.AddWithValue("Stock_ID", stockId);

                command.Parameters.Add("@Stock_Type", SqlDbType.VarChar).Value = Stock_Type.Text;
                command.Parameters.Add("@No_of_Pieces", SqlDbType.Int).Value = txt_qty.Text;
                command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar).Value = txt_gem_type.Text;
                command.Parameters.Add("@Gem_Weight", SqlDbType.Float).Value = txt_gem_weight.Text;
                command.Parameters.Add("@Item_Description", SqlDbType.NVarChar).Value = combo_itemk_description.Text;
                command.Parameters.Add("@Item_Type", SqlDbType.NVarChar).Value = combo_item_type.Text;
                command.Parameters.Add("@No_of_Gems", SqlDbType.Int).Value = txt_no_of_gems.Text;

                command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int).Value = txt_no_of_other_gems.Text;
                command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar).Value = txt_other_gems.Text;
                command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float).Value = txt_weight_of_other_gems.Text;


                using (MemoryStream ms = new MemoryStream())
                {
                    //pb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                   // command.Parameters.Add("@Image", SqlDbType.Image).Value = ms.ToArray();
                }


                command.Parameters.Add("@Cost", SqlDbType.Decimal).Value = txt_cost.Text;

                command.Parameters.Add("@Update_Date", SqlDbType.DateTime).Value = label11.Text;


                command.Parameters.Add("@Update_UserID", SqlDbType.NVarChar).Value = hello.Text;

                command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);
                command.Parameters.Add("@CurrentImagePath", SqlDbType.NVarChar);
                command.Parameters["@Imagepath"].Value = TB_File_Path.Text + txtstock_no.Text + "\\";

                String path = TB_File_Path.Text + txtstock_no.Text + "\\";
                for (int i = 0; i < pictureBoxes.Length; ++i)
                {
                    if (pictureIsNew[i])
                    {
                        string targetPath = String.Format("{0}img-{1:D4}{2}", path, i, Path.GetExtension(picturePaths[i]));
                        if (i == currentPicture)
                        {
                            command.Parameters["@CurrentImagePath"].Value = targetPath;
                        }
                        File.Copy(picturePaths[i], targetPath, true);
                    }
                }

                command.ExecuteNonQuery();

                String query2;
                query2 = "Update Status_of_stocks set Qty = @No_of_pieces, Weight = @Weight, Cost = @Cost WHERE StockNo=@Stock_No AND StockID=@Stock_ID";
                SqlCommand cmd = new SqlCommand(query2, conn);
                cmd.Parameters.AddWithValue("Stock_No", stockNo);
                cmd.Parameters.AddWithValue("Stock_ID", stockId);

                cmd.Parameters.Add("@No_of_pieces", SqlDbType.Int).Value = txt_qty.Text;
                cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = txt_gem_weight.Text;
                cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = txt_cost.Text;
                cmd.ExecuteReader();


                MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
            this.Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Match m = Regex.Match(txtstock_no.Text, "([A-Za-z]+)([0-9]+)");
            if (m.Groups.Count < 3)
            {
                return;
            }
            stockId = m.Groups[2].Value;
            stockNo = m.Groups[1].Value;

            try
            {
                conn.Close();
                conn.Open();
                String DeleteQuery = "Delete from Stock_Entry where Stock_No=@Stock_No AND Stock_ID=@Stock_ID";
                SqlCommand command = new SqlCommand(DeleteQuery, conn);
                command.Parameters.AddWithValue("Stock_No", stockNo);
                command.Parameters.AddWithValue("Stock_ID", stockId);
                command.ExecuteNonQuery();

                String DeleteQ2 = "Delete from Status_of_Stocks where StockNo=@StockNo AND StockID=@StockID";
                SqlCommand command2 = new SqlCommand(DeleteQ2, conn);
                command2.Parameters.AddWithValue("StockNo", stockNo);
                command2.Parameters.AddWithValue("StockID", stockId);

                String path = TB_File_Path.Text + txtstock_no.Text + "\\";

                
                command2.ExecuteNonQuery();
                MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();



        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            /*try
            {
                xy %= pictureBoxes.Length;
                OpenFileDialog opFile = new OpenFileDialog();
                opFile.Filter = "JPEG Files (*.jpg)|*.jpg";

                if (opFile.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxes[xy].Image = Image.FromFile(opFile.FileName);
                    picturePaths[xy] = opFile.FileName;
                    pictureIsNew[xy] = true;
                    xy += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
                UpdateStockNo();
        }

        private void combo_item_type_SelectedIndexChanged(object sender, EventArgs e)
        {
                UpdateStockNo();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            combo_item_type.Text = "";
            txt_no_of_gems.Text = "";
            combo_itemk_description.Text = "";
            txt_gem_type.Text = "";

            txt_gem_weight.Text = "";
            txt_no_of_other_gems.Text = "";
            txt_other_gems.Text = "";
            txt_weight_of_other_gems.Text = "";
            txt_cost.Text = "";
            txtstock_no.Text = "";

            /*pb1.Image = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;*/
        }

        private void txt_no_of_gems_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txt_no_of_gems.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_no_of_gems.Text != "")
                {
                    txt_no_of_gems.Text = last_amount[index];
                }
            }
        }

        private void txt_gem_weight_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txt_gem_weight.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_gem_weight.Text != "")
                {
                    txt_gem_weight.Text = last_amount[index];
                }
            }
        }

        private void txt_no_of_other_gems_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txt_no_of_other_gems.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_no_of_other_gems.Text != "")
                {
                    txt_no_of_other_gems.Text = last_amount[index];
                }
            }
        }

        private void txt_cost_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txt_cost.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_cost.Text != "")
                {
                    txt_cost.Text = last_amount[index];
                }
            }
        }

        private void txt_weight_of_other_gems_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txt_weight_of_other_gems.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_weight_of_other_gems.Text != "")
                {
                    txt_weight_of_other_gems.Text = last_amount[index];
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login open = new Login();
            open.Show();

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();
            dlgOpenFileDialog.Filter = "jpg files(*.jpg|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";

            if (dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
                pictureBox.Image = image;

                for (int i = 0; i < pictureBoxes.Length; ++i)
                {
                    if (pictureBoxes[i] == pictureBox)
                    {
                        picturePaths[i] = dlgOpenFileDialog.FileName;
                        pictureIsNew[i] = true;
                    }
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < pictureBoxes.Length; ++i)
            {
                if (pictureBoxes[i] == sender)
                {
                    // HINT: Use an array of Labels and make the label visible for the current image

                    // TODO: reset pictureBoxes[currentPicture] border style
                    pictureBorders[currentPicture].Visible = false;

                    currentPicture = i;
                    pictureBorders[i].Visible = true;

                    // TODO: set pictureBoxes[currentPicture] border style



                }
            }
        }

        private bool atLeastOneImage()
        {
            foreach (var pictureBox in pictureBoxes)
            {
                if (pictureBox.Image != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}