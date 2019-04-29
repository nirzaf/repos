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
using System.Text.RegularExpressions;
using System.IO;

namespace PCJ_System
{
    public partial class S_Gems : Form
    {
        private string[] last_amount = { "", "", "" };

        // int xy;
        int currentPicture;
        SqlConnection conn;
        Label[] pictureBorders;
        PictureBox[] pictureBoxes;
        string[] picturePaths;

        bool[] pictureIsNew;

        public string stockId = "001";
        private string stockNo = ""; 


        public static class GlobalValue
        {

            //public static int UserCreated = 0;
        }

        public S_Gems()
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

    
                cmbStockType.SelectedIndex = 0;
    
                
            
            
           
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

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtstock_no.Text.Length <= 0)
            {
                errorProvider1.SetError(txtstock_no, "This field cannot be empty, Select a Stock No (UG/MG)");
            }
            else if (txtno_of_peices.Text.Length <= 0)
            {
                errorProvider1.SetError(txtno_of_peices, "This field cannot be empty, Qauntity of Gems");
            }
            else if (txt_gems.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_gems, "Cannot be empty, Select Gem Type");
            }
            else if (txt_weight.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_weight, "This field cannot be empty, Enter the Weight of Gems");
            }
            else if (txt_cost.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_cost, "Cannot be empty, Enter the Cost of Gems");
            }
            else if (!atLeastOneImage())
            {
                // errorProvider1.SetError(pb1, "Please add an Image");
                errorProvider1.SetError(pictureBox1, "Please add an Image");
            }
            else
            {
                conn.Close();
                conn.Open();
              
                var tx = conn.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Status_Of_Stocks VALUES (@StockID,@StockNo,@StockType,@Qty,@Weight,@Cost)", conn, tx);
                    command.Parameters.AddWithValue("@StockNo", stockNo);
                    command.Parameters.AddWithValue("@StockID", stockId);
                    command.Parameters.AddWithValue("@StockType", "Gems");
                    command.Parameters.AddWithValue("@Qty", txtno_of_peices.Text);
                    command.Parameters.AddWithValue("@Weight", txt_weight.Text);
                    command.Parameters.AddWithValue("@Cost", txt_cost.Text);
                    command.ExecuteNonQuery();

                    String query;
                    S_Jewelry sel = new S_Jewelry();

                    command.Parameters.AddWithValue("@StockNo", stockNo);
                    command.Parameters.AddWithValue("@StockId", stockId);

                    query = "INSERT INTO Stock_Entry VALUES(@StockID,@stock_no,@Stock_Type,@No_of_pieces,@Gem_Type,@Weight,@Item_Description,@Item_Type,@No_of_Gems,@No_of_other_Gems,@Other_Gems,@Weight_of_other_Gems,@Cost,@Created_Date,@Updated_Date,@User_ID,@Update_UserID,@Imagepath,@CurrentImagePath)";
                    command = new SqlCommand(query, conn, tx);
                    command.Parameters.AddWithValue("@StockID", stockId);
                    command.Parameters.AddWithValue("@stock_no", stockNo);
                  
                    //combining the stockID
                    command.Parameters.Add("@Stock_Type", SqlDbType.VarChar);
                    command.Parameters["@Stock_Type"].Value = Stock_Type.Text;

                    command.Parameters.Add("@No_of_pieces", SqlDbType.Int);
                    command.Parameters["@No_of_pieces"].Value = Convert.ToInt32(txtno_of_peices.Text);

                    command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar);
                    command.Parameters["@Gem_Type"].Value = txt_gems.Text;

                    command.Parameters.Add("@Weight", SqlDbType.Float);
                    command.Parameters["@Weight"].Value = Convert.ToDouble(txt_weight.Text);

                    command.Parameters.Add("@Item_Description", SqlDbType.NVarChar);
                    command.Parameters["@Item_Description"].Value = sel.combo_itemk_description.Text;

                    command.Parameters.Add("@Item_Type", SqlDbType.NVarChar);
                    command.Parameters["@Item_Type"].Value = sel.combo_item_type.Text;

                    command.Parameters.Add("@No_of_Gems", SqlDbType.Int);
                    command.Parameters["@No_of_Gems"].Value = 0;

                    command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int);
                    command.Parameters["@No_of_other_Gems"].Value = 0;

                    command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar);
                    command.Parameters["@Other_Gems"].Value = "";

                    command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float);
                    command.Parameters["@Weight_of_other_Gems"].Value = 0.0;
                    
                    //MemoryStream stream = new MemoryStream();
                    //pictureBoxes[currentPicture].Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //byte[] pic = stream.ToArray();
                    //command.Parameters.Add("@image", SqlDbType.Binary);
                    //command.Parameters["@image"].Value = pic;

                    command.Parameters.Add("@Cost", SqlDbType.Decimal);
                    command.Parameters["@Cost"].Value = Convert.ToDouble(txt_cost.Text);

                    command.Parameters.Add("@Created_Date", SqlDbType.DateTime);
                    command.Parameters["@Created_Date"].Value = label11.Text;

                    command.Parameters.Add("@Updated_Date", SqlDbType.DateTime);
                    command.Parameters["@Updated_Date"].Value = label11.Text;

                    command.Parameters.Add("@User_ID", SqlDbType.NVarChar);
                    command.Parameters["@User_ID"].Value = hello.Text;

                    command.Parameters.Add("@Update_UserID", SqlDbType.NVarChar);
                    command.Parameters["@Update_UserID"].Value = "";

                    command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);

                    String path = TB_File_Path.Text + txtstock_no.Text + "\\";
                    command.Parameters["@Imagepath"].Value = path;

                    // ADD the currentimagepath
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
                    //command.Parameters["@CurrentImagePath"].Value = TB_File_Path.Text + txtstock_no.Text + "\\" + Path.GetFileName(picturePaths[currentPicture]); 
                    //command.Parameters["@CurrentImagePath"].Value = picturePaths[currentPicture];
  

                    

                    command.ExecuteNonQuery();
                    tx.Commit();
                    conn.Close();

                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();
            //dlgOpenFileDialog.Filter = "jpg files(*.jpg|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            //if (dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
            //    pb1.Image = image;
            //}
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Match m = Regex.Match(txtstock_no.Text, "([A-Za-z]+)([0-9]+)");
            if (m.Groups.Count != 3)
            {
                return;
            }
            stockId = m.Groups[2].Value;
            stockNo = m.Groups[1].Value;

            try
            {
                conn.Close();
                conn.Open();
                String query;
                String query2;

                // if (pb1.Image == null)
                // {
                //     query = "Update Stock_Entry  set No_of_pieces = @No_of_pieces, Gem_Type = @Gem_Type, Weight = @Weight, Cost = @Cost, Update_Date = @Update_Date, Update_UserID=@Update_UserID, Imagepath= @Imagepath WHERE  Stock_No = @Stock_No AND Stock_ID=@Stock_ID";
                // }
                // else
                // {
                query = "Update Stock_Entry  set No_of_pieces = @No_of_pieces, Gem_Type = @Gem_Type, Weight = @Weight, Cost = @Cost, Update_Date = @Update_Date, Update_UserID=@Update_UserID, Imagepath= @Imagepath, CurrentImagePath=@CurrentImagePath WHERE  Stock_No = @Stock_No AND Stock_ID=@Stock_ID";
                // }

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@Stock_Type", SqlDbType.VarChar).Value = Stock_Type.Text;
                command.Parameters.AddWithValue("Stock_No", stockNo);
                command.Parameters.AddWithValue("Stock_ID", stockId);
                command.Parameters.Add("@No_of_pieces", SqlDbType.Int).Value = txtno_of_peices.Text;
                command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar).Value = txt_gems.Text;
                command.Parameters.Add("@Weight", SqlDbType.Float).Value = txt_weight.Text;
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
                

                //MemoryStream stream = new MemoryStream();
                //pictureBoxes[currentPicture].Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] pic = stream.ToArray();
                //command.Parameters.Add("@Image", SqlDbType.Binary);
                //command.Parameters["@Image"].Value = pic;

                

               

                if (command.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                query2 = "Update Status_of_stocks set Qty = @No_of_pieces, Weight = @Weight, Cost = @Cost WHERE StockNo=@Stock_No AND StockID=@Stock_ID";
                SqlCommand cmd = new SqlCommand(query2, conn);
                cmd.Parameters.AddWithValue("Stock_No", stockNo);
                cmd.Parameters.AddWithValue("Stock_ID", stockId);

                cmd.Parameters.Add("@No_of_pieces", SqlDbType.Int).Value = txtno_of_peices.Text;
                cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = txt_weight.Text;
                cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = txt_cost.Text;
                cmd.ExecuteReader();
                
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
            if (m.Groups.Count != 3)
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

                String DeleteQ2 = "Delete from Status_of_Stocks where StockNo=@StockNo AND StockID=@StockID";
                SqlCommand command2 = new SqlCommand(DeleteQ2, conn);
                command2.Parameters.AddWithValue("StockNo", stockNo);
                command2.Parameters.AddWithValue("StockID", stockId);

                String path = TB_File_Path.Text + txtstock_no.Text + "\\";
                command.ExecuteNonQuery();
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

        private void getLastNumbers()
        {
            try
            {
                conn.Close();
                conn.Open();

                String selectQuery = "SELECT TOP 1 StockID FROM Status_Of_Stocks WHERE StockNo='" + stockNo + "' ORDER BY StockID DESC";

                SqlDataAdapter execute = new SqlDataAdapter(selectQuery, conn);
                SqlDataReader reader = execute.SelectCommand.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    stockId = String.Format("{0:D3}", (Int32.Parse(reader.GetString(0))) + 1);
                }
                else
                {
                    stockId = "001";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStockType.SelectedIndex == 0)
                stockNo = "UG";
            else
                stockNo = "MG";

            getLastNumbers();

            txtstock_no.Text = stockNo + stockId;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        public void S_Gems_Load_1(object sender, EventArgs e)
        {
            //getLastNumbers();
            DateTime dateTime = DateTime.Now;
            this.label11.Text = dateTime.ToString();
            hello.Text = GlobalVariablesClass.VariableOne;


            /*FileStream fs = new System.IO.FileStream(path, FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();*/

            String path = (TB_File_Path.Text + txtstock_no.Text + "\\");

            currentPicture = 0;

            // var query = "SELECT currentImagePath FROM Stock_Entry WHERE stock_Id=@StockId AND stock_No=@Stock_No";

            // TODO: CurrentImagePath from the Database
            

            string currentImagePath = "";
            // add  conn.Close();


          //  conn.Close();
            conn.Open();
            using (var command = new SqlCommand("SELECT currentImagePath FROM Stock_Entry WHERE Stock_No=@StockNo AND Stock_ID=@Stock_Id", conn))
            {
                                                                                                //  Stock_No = @StockNo ORDER BY Stock_ID DESC
                command.Parameters.AddWithValue("@StockNo", stockNo);
                command.Parameters.AddWithValue("@Stock_Id", stockId);
               
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        currentImagePath = reader.GetString(0);
                      //  stockId = String.Format("{0:D3}", (Int32.Parse(reader["Stock_ID"].ToString()) + 1));

                    }
                }
            }

            if (!String.IsNullOrEmpty(currentImagePath))
            {
                pictureBoxes[0].Image = Image.FromFile(currentImagePath);
                picturePaths[0] = currentImagePath;
                pictureBorders[0].Visible = true;
            }

            //string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();

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


            txtno_of_peices.GotFocus += new EventHandler(this.TextGotFocus);
            txtno_of_peices.LostFocus += new EventHandler(this.TextGotFocus);

            txt_weight.GotFocus += new EventHandler(this.TextGotFocus);
            txt_weight.LostFocus += new EventHandler(this.TextLostFocus);

            txt_cost.GotFocus += new EventHandler(this.TextGotFocus);
            txt_cost.LostFocus += new EventHandler(this.TextLostFocus);
        }

        public void TextGotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
                tb.ForeColor = Color.Brown;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            /*  if (txtno_of_peices.Text == "")
              {
                  txtno_of_peices.GotFocus += new EventHandler(this.TextGotFocus);
                  txtno_of_peices.LostFocus += new EventHandler(this.TextGotFocus);
              }
              else if (txt_weight.Text != null)
              {

                  txt_weight.GotFocus += new EventHandler(this.TextGotFocus);
                  txt_weight.LostFocus += new EventHandler(this.TextLostFocus);
              }
              else if (txt_cost.Text != null)
              {
                  txt_cost.GotFocus += new EventHandler(this.TextGotFocus);

                  txt_cost.LostFocus += new EventHandler(this.TextLostFocus);
              }*/
            txtno_of_peices.Text = "";
            txt_weight.Text = "";
            txt_cost.Text = "";
            txt_gems.Text = "";
            cmbStockType.Text = "";
            //    txtstock_no.Text = "";
            //pb1.Image = null;
            foreach (var pictureBox in pictureBoxes)
            {
                pictureBox.Image = null;
            }

            for (int i = 0; i < picturePaths.Length; ++i)
            {
                picturePaths[i] = "";
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtno_of_peices_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            //TextBox rate = null;
            //TextBox total = null;
            int index = 0;
            float indexf = 0;
            double indexd = 0;
            if (sender == txtno_of_peices)
            {
                //rate = txtRate1;
                //total = txtTot1;
            }
            else if (sender == txt_weight)
            {
                ///rate = txtRate2;
                //total = txtTot2;
                indexf = 1;
            }
            else if (sender == txt_cost)
            {
                //rate = txtRate3;
                //total = txtTot3;
                indexd = 2;
            }

            if (!Regex.IsMatch(txtBox.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txtBox.Text != "")
                {
                    txtBox.Text = last_amount[index];
                    return;
                }
            }

        }

        private void txt_weight_TextChanged(object sender, EventArgs e)
        {
            /*int index = 0;

            if (!Regex.IsMatch(txt_weight.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_weight.Text != "")
                {
                    txt_weight.Text = last_amount[index];
                }
            }*/
        }

        private void txt_cost_TextChanged(object sender, EventArgs e)
        {
            /*int index = 0;

            if (!Regex.IsMatch(txt_cost.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txt_cost.Text != "")
                {
                    txt_cost.Text = last_amount[index];
                }
            }*/
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

        private void pictureBoxMouseSingleClick(object sender, MouseEventArgs e)
        {
           
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

        private void txt_weight_TextChanged_1(object sender, EventArgs e)
        {
       
        }

        private void txt_cost_TextChanged_1(object sender, EventArgs e)
        {
           
        }
    }
}
