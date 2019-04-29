using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace PCJ_System
{
    public partial class In_certi : Form
    {
        private string[] last_amount = { "", "", "", "" };
        private int nextNumber;
        private List<Image> pics = new List<Image>();
        private List<String> itemIDs = new List<String>();
        private List<String> itemNos = new List<String>();
        DataTable dt = new DataTable();
        public String UserType;

        private string invId = "001";
        private string invNo = "";

        SqlConnection conn;

        public In_certi()
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
            CalculateTotal();

            using (var cmd = new SqlCommand("SELECT * FROM dbo.[F_Currency]", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCurrency1.Items.Add(reader["FC_TYPE"].ToString());
                        cmbCurrency2.Items.Add(reader["FC_TYPE"].ToString());
                        cmbCurrency3.Items.Add(reader["FC_TYPE"].ToString());
                    }
                }
            }
            cmbCurrency1.SelectedIndex = 0;
            cmbCurrency2.SelectedIndex = 1;
            cmbCurrency3.SelectedIndex = 2;

           // btnFCupdate.Visible = false;

            using (var cmd = new SqlCommand("SELECT * FROM dbo.[Card_Vendor]", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCardTyp.Items.Add(reader["Vendor"].ToString());
                    }
                }
            }

            cmbPaymentTyp.SelectedIndex = 0;

            for (int i = 0; i < dgvItem.Columns.Count; ++i)
            {
                dt.Columns.Add(dgvItem.Columns[i].HeaderText);
            }

            dgvItem.AutoGenerateColumns = true;
            dgvItem.Columns.Clear();
            dgvItem.DataSource = dt;


        }
        private void CalculateTotal()
        {
            double x = 0;
            double rate1 = 1;
            double rate2 = 1;
            double rate3 = 1;
            double amt1 = 0;
            double amt2 = 0;
            double amt3 = 0;

            //adding the card amt 
            double cardamt = 0;


            if (txtRate1.Text != "")
                rate1 = Convert.ToDouble(txtRate1.Text);

            if (txtRate2.Text != "")
                rate2 = Convert.ToDouble(txtRate2.Text);

            if (txtRate3.Text != "")
                rate3 = Convert.ToDouble(txtRate3.Text);

            if (txtAmt1.Text != "")
                amt1 = Convert.ToDouble(txtAmt1.Text);

            if (txtAmt2.Text != "" && checkBox_disable.Checked)
                amt2 = Convert.ToDouble(txtAmt2.Text);

            if (txtAmt3.Text != "" && checkBox_disable.Checked)
                amt3 = Convert.ToDouble(txtAmt3.Text);

            // adding card 
            if (txtcardamt.Text != "" && cmbPaymentTyp.SelectedIndex > 0)
                cardamt = Convert.ToDouble(txtcardamt.Text);


            txtTot1.Text = Convert.ToString(amt1 * rate1 + cardamt);
            txtTot2.Text = Convert.ToString(amt2 * rate2);
            txtTot3.Text = Convert.ToString(amt3 * rate3);

            //adding card
            //.Text = Convert.ToString(cardamt);

            x = amt1 * rate1 + amt2 * rate2 + amt3 * rate3 + cardamt;
            txtTotalAmount.Text = x.ToString();

        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void In_certi_Load(object sender, EventArgs e)
        {
            btnPrntInvoice.Enabled = false;
            PrntInPre.Enabled = false;
        }

        private void checkBox_disable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_disable.Checked == true)
            {
                cmbCurrency2.Enabled = true;
                txtAmt2.Enabled = true;
                cmbCurrency3.Enabled = true;
                txtAmt3.Enabled = true;

            }
            if (checkBox_disable.Checked == false)
            {
                cmbCurrency2.Enabled = false;
                txtAmt2.Enabled = false;
                cmbCurrency3.Enabled = false;
                txtAmt3.Enabled = false;
            }

            CalculateTotal();
        }

        private void ST_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItmTyp.SelectedIndex == 0)
            {
                txtNoPieces.Visible = true;
                lblNoPieces.Visible = true;
                txtCost.Visible = true;
                lblCost.Visible = true;
                txtGemWeight.Visible = true;
                lblGemWeight.Visible = true;
                txtSpecification.Visible = false;
                lblSpecification.Visible = false;
                btnaddstock.Enabled = true;
                btnremovestock.Enabled = true;
            }
            else if (cmbItmTyp.SelectedIndex == 1)
            {
                txtNoPieces.Visible = false;
                lblNoPieces.Visible = false;
                txtCost.Visible = false;
                lblCost.Visible = false;
                txtGemWeight.Visible = false;
                lblGemWeight.Visible = false;
                txtSpecification.Visible = false;
                lblSpecification.Visible = false;
                btnremovestock.Enabled = true;
                btnaddstock.Enabled = true;
            }
            else
            {
                btnremovestock.Enabled = false;
                btnaddstock.Enabled = false;
                return;
            }

            textBox1.Text = "";
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnremovestock_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (cmbItmTyp.SelectedIndex == 0)
            {
                TextBox[] textboxes = { txtNoPieces, txtGemWeight, txtCost};
                bool isValid = true;

                foreach (TextBox t in textboxes)
                {
                    if (t.Text.Length <= 0)
                    {
                        errorProvider1.SetError(t, "Cannot be Empty!!");
                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    return;
                }
            }

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                if (dt.Rows[i][2].ToString() == textBox1.Text)
                {
                    dgvItem.Rows[i].Selected = true;
                    return;
                }
            }

            Match m = Regex.Match(textBox1.Text, "([a-zA-Z]+)([0-9]+)");
            if (m.Groups.Count < 3)
            {
                // do nothing
                return;
            }

            using (var command = new SqlCommand("SELECT * FROM AvailableItems WHERE StockNo=@StockNo AND StockID=@StockID", conn))
            {
                command.Parameters.AddWithValue("StockID", m.Groups[2].Value.ToString());
                command.Parameters.AddWithValue("StockNo", m.Groups[1].Value.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var row = dt.NewRow();
                        row[0] = dt.Rows.Count + 1;
                        row[1] = reader["StockType"].ToString();
                        row[2] = String.Format("{0}{1}", reader["StockNo"].ToString(), reader["StockID"]);

                        if (cmbItmTyp.SelectedIndex == 0)
                        {
                            // gem
                            row[3] = txtNoPieces.Text;
                            // row[4] = String.Format("{0} {1}cts ", reader["GemType"], txtGemWeight.Text);
                            row[4] = String.Format("{0}", reader["GemType"], txtGemWeight.Text);
                            row[5] = txtCost.Text;
                            row[6] = txtGemWeight.Text;
                            row[7] = txtSpecification.Text;

                            // MessageBox.Show(reader["No_of_pieces"].ToString());
                            bool noerrors = true;

                            if (Int32.Parse(row[3].ToString()) > Int32.Parse(reader["Quantity"].ToString()))
                            {
                            //    errorProvider1.SetError(txtNoPieces, "Entered Nr. of pieces is too high!");

                                MessageBox.Show(txtNoPieces, "Nr. of Pieces Entered is too high!!!");
                                noerrors = false;
                            }

                            if (Double.Parse(row[5].ToString()) > Double.Parse(reader["Cost"].ToString()))
                            {
                                //errorProvider1.SetError(txtCost, "Entered Cost is too high");
                                MessageBox.Show(txtCost, "Cost Entered is too high!!!");

                                noerrors = false;
                            }
                            if (Double.Parse(row[6].ToString()) > Double.Parse(reader["Weight"].ToString()))
                            {
                                MessageBox.Show(txtGemWeight, "Gem Weight Entered is too high!!!");
                                noerrors = false;
                            }
                            if (!noerrors)
                            {
                                return;
                            }
                        }
                        else if (cmbItmTyp.SelectedIndex == 1)
                        {
                            // jewellery
                            //string desc = String.Format("{0} {1} with {2} {3} {4}cts", reader["Description"], reader["ItemType"], reader["NoOfGems"], reader["GemType"], reader["Weight"]);
                            string desc = String.Format("{0} with {1} {2} {3}cts", reader["Description"], reader["NoOfGems"], reader["GemType"], reader["Weight"]);
                            if (Int32.Parse(reader["NoOfOtherGems"].ToString()) != 0)
                            {
                                desc = String.Format("{0} & {1} {2} {3}cts", desc, reader["NoOfOtherGems"], reader["OtherGemType"], reader["WeightOfOtherGems"]);
                            }
                            row[4] = desc;
                            row[5] = reader["Cost"];
                            row[3] = reader["Quantity"];
                        }

                        byte[] pic = reader["Image"] as byte[];
                        MemoryStream ms = new MemoryStream(pic);
                        pics.Add(Image.FromStream(ms));
                        itemIDs.Add(reader["StockID"].ToString());
                        itemNos.Add(reader["StockNo"].ToString());

                        ClearPurchase();
                        dt.Rows.Add(row);
                        dgvItem.RefreshEdit();
                    }
                }
            }
        }

        private void ClearPurchase()
        {
            cmbItmTyp.SelectedIndex = -1;
            textBox1.Text = "";
            txtNoPieces.Visible = false;
            lblNoPieces.Visible = false;
            txtCost.Visible = false;
            lblCost.Visible = false;
            txtGemWeight.Visible = false;
            lblGemWeight.Visible = false;
            txtSpecification.Visible = false;
            lblSpecification.Visible = false;

            textBox1.Enabled = false;
            txtSpecification.Text = "";
            txtGemWeight.Text = "";
            txtCost.Text = "";
            txtNoPieces.Text = "";
        }

        private void cmbPaymentTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentTyp.SelectedIndex > 0)
            {
                lblCardTyp.Visible = lblcardamt.Visible = cmbCardTyp.Visible = txtcardamt.Visible = true;
            }
            else if (cmbPaymentTyp.SelectedIndex == 0)
            {
                lblCardTyp.Visible = lblcardamt.Visible = cmbCardTyp.Visible = txtcardamt.Visible = false;
                txtcardamt.Text = "";
            }
        }

        private void cmbInvTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInvTyp.SelectedIndex == 0)
            {
                getNextNumber("FC");
                txtInvNo.Text = string.Format("CMB-{0:000}-FC", nextNumber);
            }
            else
            {
                getNextNumber("LC");
                txtInvNo.Text = string.Format("CMB-{0:000}-LC", nextNumber);
            }

            if (cmbInvTyp.Text == "LOCAL")
            {
                txtAddress.Text = "SRI LANKA";
            }
            else
            {
                txtAddress.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool noerrors = true;

            if (txtInvNo.Text.Length <= 0)
            {
                errorProvider1.SetError(txtInvNo, "Please select the invoice type!!");
                noerrors = false;
            }

            if (cmbTitle.Text.Length <= 0)
            {
                errorProvider1.SetError(cmbTitle, "Select the Customer Title");
                noerrors = false;
            }

            if (txtCusNm.Text.Length <= 0)
            {
                errorProvider1.SetError(txtCusNm, "Enter Customer Name");
                noerrors = false;
            }

            if (txtAddress.Text.Length <= 0)
            {
                errorProvider1.SetError(txtAddress, "Enter the Customer Address");
                noerrors = false;
            }

            if (txtTotalAmount.Text.Length <= 0)
            {
                errorProvider1.SetError(txtTotalAmount, "The Total Amount cannot be empty!!");
                noerrors = false;
            }

            if (dgvItem.RowCount == 0)
            {
                MessageBox.Show("Please Add the item to the Grid View");
                noerrors = false;
            }

            if (!noerrors)
            {
                return;
            }

            else
            {

                try
                {
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string invType = null;
                        if (cmbInvTyp.SelectedIndex == 0)
                        {
                            invType = "FC";
                        }
                        else if (cmbInvTyp.SelectedIndex == 1)
                        {
                            invType = "LC";
                        }

                        int id = nextNumber;

                        SqlCommand command = new SqlCommand("INSERT INTO Invoice (Invoice_No,Invoice_Date,Invoice_Type) VALUES (@id,@date,@type)", conn, transaction);
                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue("date", DateTime.Now.ToString());
                        command.Parameters.AddWithValue("type", invType);
                        command.ExecuteNonQuery();

                        command = new SqlCommand("INSERT INTO Customer VALUES(@id,@type,@name,@title,@address)", conn, transaction);
                        command.Parameters.AddWithValue("id", id);
                        command.Parameters.AddWithValue("type", invType);
                        command.Parameters.AddWithValue("name", txtCusNm.Text);
                        command.Parameters.AddWithValue("title", cmbTitle.SelectedItem.ToString());
                        command.Parameters.AddWithValue("address", txtAddress.Text);
                        command.ExecuteNonQuery();


                        // iterate over all purchases
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            float qty = (float)(dt.Rows[i][3].ToString() != "" ? Convert.ToDouble(dt.Rows[i][3].ToString()) : 0);
                            float weight = (float)(dt.Rows[i][6].ToString() != "" ? Convert.ToDouble(dt.Rows[i][6].ToString()) : 0);
                            float cost = (float)(dt.Rows[i][5].ToString() != "" ? Convert.ToDouble(dt.Rows[i][5].ToString()) : 0);

                            command = new SqlCommand("INSERT INTO Purchase VALUES(@inv,@type,@lino,@ItemID,@ItemNo,@cost,@qty,@weight,@spec)", conn, transaction);
                            command.Parameters.AddWithValue("inv", id);
                            command.Parameters.AddWithValue("type", invType);
                            command.Parameters.AddWithValue("lino", dt.Rows[i][0]);
                            command.Parameters.AddWithValue("ItemID", itemIDs[i]);
                            command.Parameters.AddWithValue("ItemNo", itemNos[i]);
                            command.Parameters.AddWithValue("cost", cost);
                            command.Parameters.AddWithValue("qty", qty);
                            command.Parameters.AddWithValue("weight", weight);
                            command.Parameters.AddWithValue("spec", dt.Rows[i][7]);
                            command.ExecuteNonQuery();

                            // update stock
                            command = new SqlCommand("UPDATE Status_Of_Stocks SET Qty=Qty-@qty, Weight=Weight-@weight, cost=cost-@cost WHERE StockId=@StockID AND StockNo=@StockNo", conn, transaction);
                            command.Parameters.AddWithValue("@StockID", itemIDs[i]);
                            command.Parameters.AddWithValue("@StockNo", itemNos[i]);
                            command.Parameters.AddWithValue("@cost", cost);
                            command.Parameters.AddWithValue("@qty", qty);
                            command.Parameters.AddWithValue("@weight", weight);
                            command.ExecuteNonQuery();
                        }

                        if (cmbPaymentTyp.SelectedIndex > 0 && cmbCardTyp.SelectedIndex != -1 && cmbCardTyp.Text.Length != 0)
                        {
                            command = new SqlCommand("INSERT INTO Card_Payment VALUES(@inv,@invoiceType,@vendor,@cardType,@amount)", conn, transaction);
                            command.Parameters.AddWithValue("inv", Convert.ToInt32(id));
                            command.Parameters.AddWithValue("invoiceType", invType);
                            command.Parameters.AddWithValue("amount", Convert.ToDouble(txtcardamt.Text));
                            command.Parameters.AddWithValue("vendor", cmbCardTyp.SelectedItem.ToString());
                            command.Parameters.AddWithValue("cardType", cmbPaymentTyp.SelectedItem.ToString());
                            command.ExecuteNonQuery();
                        }

                        if (txtAmt1.Text != "")
                        {
                            var cashPayments = new[] {
                            new { CurrencyType = cmbCurrency1.SelectedItem.ToString(), Amount = txtAmt1.Text, Rate = txtRate1.Text, Use = true, Number = 1},
                            new { CurrencyType = cmbCurrency2.SelectedItem.ToString(), Amount = txtAmt2.Text, Rate = txtRate2.Text, Use = checkBox_disable.Checked && txtAmt2.Text != "", Number = 2},
                            new { CurrencyType = cmbCurrency3.SelectedItem.ToString(), Amount = txtAmt3.Text, Rate = txtRate3.Text, Use = checkBox_disable.Checked && txtAmt3.Text != "" && txtAmt2.Text != "", Number = 3}
                        };

                            foreach (var cashPayment in cashPayments)
                            {
                                if (cashPayment.Use)
                                {
                                    SqlCommand cmd = new SqlCommand("Select * from F_Currency where FC_Type=@c_type", conn, transaction);
                                    cmd.Parameters.AddWithValue("c_type", cashPayment.CurrencyType);
                                    Double currencyid = -1;
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {

                                            currencyid = Double.Parse(reader[2].ToString());

                                        }
                                    }




                                    command = new SqlCommand("INSERT INTO Cash_Payment VALUES(@inv,@itype,@ctype,@rate,@amt)", conn, transaction);

                                    command.Parameters.AddWithValue("inv", Convert.ToInt32(id));
                                    command.Parameters.AddWithValue("itype", invType);
                                    command.Parameters.AddWithValue("ctype", Convert.ToInt32(currencyid));
                                    //command.Parameters.AddWithValue("cno", cashPayment.Number);
                                    command.Parameters.AddWithValue("rate", Convert.ToDouble(cashPayment.Rate));
                                    command.Parameters.AddWithValue("amt", Convert.ToDouble(cashPayment.Amount));
                                    command.ExecuteNonQuery();
                      
                                }
                            }

                        }

                        transaction.Commit();
                        // disable item stuff
                        groupBox2.Enabled = false;
                        groupBox4.Enabled = false;

                        // disable save button
                        btnPrntInvoice.Enabled = true;
                        PrntInPre.Enabled = true;
                        MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("" + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //   this.Hide();
                  
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void getNextNumber(string type)
        {
            using (var command = new SqlCommand("SELECT TOP 1 Invoice_No FROM dbo.Invoice WHERE Invoice_Type=@type ORDER BY Invoice_No DESC", conn))
            {
                command.Parameters.AddWithValue("@type", type);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nextNumber = Int32.Parse(reader[0].ToString()) + 1;
                        return;
                    }
                }
            }

            nextNumber = 1;
        }

        private void btnFCupdate_Click(object sender, EventArgs e)
        {
            //Foriegn_Currency_Update open = new Foriegn_Currency_Update();
            //open.Show();
        }

        private void cmbCurrency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txt;

            if (sender == cmbCurrency1)
            {
                txt = txtRate1;
            }
            else if (cmbCurrency2 == sender)
            {
                txt = txtRate2;
            }
            else
            {
                txt = txtRate3;
            }

            using (var cmd = new SqlCommand("SELECT [FC_Rate] FROM dbo.[F_Currency] WHERE [FC_TYPE]=@fc_type", conn))
            {
                cmd.Parameters.AddWithValue("fc_type", ((ComboBox)sender).SelectedItem.ToString());
                txt.Text = cmd.ExecuteScalar().ToString();
            }

            CalculateTotal();
        }

        private void btnaddstock_Click(object sender, EventArgs e)
        {
            //    const string query = "SELECT TOP 1 Stock_No,Image"
            Match m = Regex.Match(textBox1.Text, "([a-zA-Z]+)([0-9]+)");
            //if (m.Groups.Count != 2)
            if (m.Groups.Count < 3)
            {
                // do nothing
                return;
            }

            using (var command = new SqlCommand("SELECT TOP 1 * FROM dbo.AvailableItems WHERE StockNo=@StockNo AND StockID=@StockID AND StockType=@StockType", conn))
            {
                command.Parameters.AddWithValue("StockID", Int32.Parse(m.Groups[2].Value.ToString()));
                command.Parameters.AddWithValue("StockNo", m.Groups[1].Value.ToString());
                command.Parameters.AddWithValue("StockType", cmbItmTyp.SelectedItem.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int qty = Int32.Parse(reader["Quantity"].ToString());
                        if (qty <= 0)
                        {
                            MessageBox.Show("Out of Stock!");
                        }
                        else
                        {
                            //pictureBox1.
                            byte[] pic = reader["Image"] as byte[];
                            if (pic != null)
                            {
                                MemoryStream stream = new MemoryStream(pic);
                                pictureBox1.Image = Image.FromStream(stream);
                            }
                        }
                    }
                }
            }
        }

        private void cmbCardTyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAmt1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            //TextBox rate = null;
            //TextBox total = null;
            int index = 0;

            if (sender == txtAmt1)
            {
                //rate = txtRate1;
                //total = txtTot1;
            }
            else if (sender == txtAmt2)
            {
                ///rate = txtRate2;
                //total = txtTot2;
                index = 1;
            }
            else if (sender == txtAmt3)
            {
                //rate = txtRate3;
                //total = txtTot3;
                index = 2;
            }
            else if (sender == txtcardamt)
            {
                index = 3;
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

            last_amount[index] = txtBox.Text;

            CalculateTotal();
        }

        private void txtAmt1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgvItem_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvItem.SelectedRows.Count > 0)
            {
                pics.RemoveAt(dgvItem.CurrentRow.Index);
                itemIDs.RemoveAt(dgvItem.CurrentRow.Index);
                dgvItem.Rows.RemoveAt(dgvItem.CurrentRow.Index);
            }
        }

        private void dgvItem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {

            }

            //if (e.StateChanged == DataGridViewElementStates.)
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItem.CurrentRow.Index != -1)
            {
                pictureBox1.Image = pics[dgvItem.CurrentRow.Index];
            }
        }

        private void InvUpdate_Click(object sender, EventArgs e)
        {
            Match m = Regex.Match(txtInvNo.Text, "([A-Za-z]+)([0-9]+)");
            if (m.Groups.Count != 3)
            {
                return;
            }
            invId = m.Groups[2].Value;
            invNo = m.Groups[1].Value;

            try
            {
                conn.Close();
                conn.Open();
                String query;
                //String updateQuery = "Update Customer Set Customer_Name ='" + txtCusNm.Text + "', Customer_Title = '" + cmbTitle.Text + "', Customer_Address='" + txtAddress.Text + "';";

                query = "Update Customer set Customer_Name = @Customer_Name, Customer_Title = @Customer_Title, Customer_Address = @Customer_Address WHERE  Invoice_No = @Invoice_No AND Invoice_Type=@Invoice_Type";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("Invoice_No", invId);
                command.Parameters.AddWithValue("Invoice_Type", invNo);

                command.Parameters.Add("@Customer_Name", SqlDbType.NVarChar).Value = txtCusNm.Text;
                command.Parameters.Add("@Customer_Title", SqlDbType.NVarChar).Value = cmbTitle.Text;
                command.Parameters.Add("@Customer_Address", SqlDbType.Float).Value = txtAddress.Text;

                if (command.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Invdelete_Click(object sender, EventArgs e)
        {
            // CASH PAYMENT
            Match m = Regex.Match(txtInvNo.Text, "CMB-([0-9]+)-((LC|FC))");
            if (m.Groups.Count <2)
            {
                return;
            }
            invNo = m.Groups[1].Value;
            invId = m.Groups[2].Value;
            

            try
            {

                conn.Close();
                conn.Open();
                //cash table
                String DeleteQuery = "Delete from Cash_Payment where Invoice_No=@InvoiceNo AND Invoice_Type=@Invoicetype";
                SqlCommand command = new SqlCommand(DeleteQuery, conn);
                command.Parameters.AddWithValue("InvoiceNo", invNo);
                command.Parameters.AddWithValue("Invoicetype", invId);
                command.ExecuteNonQuery();

                //card table
                String card_pay = "Delete from Card_Payment where Invoice_No=@InvoiceNo AND Invoice_Type=@Invoicetype";
                SqlCommand cmd1 = new SqlCommand(card_pay, conn);
                cmd1.Parameters.AddWithValue("InvoiceNo", invNo);
                cmd1.Parameters.AddWithValue("Invoicetype", invId);
                cmd1.ExecuteNonQuery();


                // start
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    float qty = (float)(dt.Rows[i][3].ToString() != "" ? Convert.ToDouble(dt.Rows[i][3].ToString()) : 0);
                    float weight = (float)(dt.Rows[i][6].ToString() != "" ? Convert.ToDouble(dt.Rows[i][6].ToString()) : 0);
                    float cost = (float)(dt.Rows[i][5].ToString() != "" ? Convert.ToDouble(dt.Rows[i][5].ToString()) : 0);

                    // update stock
                    command = new SqlCommand("UPDATE Status_Of_Stocks SET Qty=Qty+@qty, Weight=Weight+@weight, cost=cost+@cost WHERE StockId=@StockID AND StockNo=@StockNo", conn);
                    command.Parameters.AddWithValue("@StockID", itemIDs[i]);
                    command.Parameters.AddWithValue("@StockNo", itemNos[i]);
                    command.Parameters.AddWithValue("@cost", cost);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@weight", weight);
                    command.ExecuteNonQuery();
                }
                //end


                // PURCHASE 
                String purchs = "Delete from Purchase where Invoice_No=@InvoiceNo AND Invoice_Type=@Invoicetype";
                SqlCommand cmd2 = new SqlCommand(purchs, conn);
                cmd2.Parameters.AddWithValue("InvoiceNo", invNo);
                cmd2.Parameters.AddWithValue("Invoicetype", invId);
                cmd2.ExecuteNonQuery();

                // CUSTOMER 
                String cus = "Delete from Customer where Invoice_No=@InvoiceNo AND Invoice_Type=@Invoicetype";
                SqlCommand cmd3 = new SqlCommand(cus, conn);
                cmd3.Parameters.AddWithValue("InvoiceNo", invNo);
                cmd3.Parameters.AddWithValue("Invoicetype", invId);
                cmd3.ExecuteNonQuery();


                // INVOICE
                String inv = "Delete from Invoice where Invoice_No=@InvoiceNo AND Invoice_Type=@Invoicetype";
                SqlCommand cmd4 = new SqlCommand(inv, conn);
                cmd4.Parameters.AddWithValue("InvoiceNo", invNo);
                cmd4.Parameters.AddWithValue("Invoicetype", invId);
                cmd4.ExecuteNonQuery();


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

        private void PrntCertPre_Click(object sender, EventArgs e)
        {
            //DVPrintDocument.DefaultPageSettings.Landscape = true;
            //DVPrintPreviewDialog.Document = DVPrintDocument;
            //DVPrintPreviewDialog.ShowDialog();
        }

        private void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawString("REF : " + cmbStockNo.Text + " " + txtInvNo.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("REF : " + dgvItem.CurrentRow.Cells[2].Value + " , " + txtInvNo.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("DATE : " + DateTime.Now.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 180));
            e.Graphics.DrawString("NAME               : " + cmbTitle.Text + " " + txtCusNm.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("ADDRESS       : " + txtAddress.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 270));

            e.Graphics.DrawString("ITEM DESCRIPTION", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(25, 350));

            e.Graphics.DrawString("NAME          : " + dgvItem.CurrentRow.Cells[4].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString("WEIGHT      : " + dgvItem.CurrentRow.Cells[6].Value + " Cts", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 440));

            //string txtSpecification = false;

            if (dgvItem.CurrentRow.Cells[7].Value == null)
            {
                // e.Graphics.DrawString("SPECIFICATION   : " + dgvItem.CurrentRow.Cells[7].Value) = false;
            }
            else
            {
                //e.Graphics.DrawString("SPECIFICATION   : " + txtSpecification.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 480));
                e.Graphics.DrawString("SPECIFICATION   : " + dgvItem.CurrentRow.Cells[7].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 480));
            }
        }

        private void btnPrntCertificate_Click(object sender, EventArgs e)
        {
            //DVPrintDocument.Print();
        }

        private void LoadPurchase(SqlDataReader reader)
        {
            var row = dt.NewRow();
            row[0] = dt.Rows.Count + 1;
            row[1] = reader["StockType"].ToString();
            row[2] = String.Format("{0}{1}", reader["StockNo"].ToString(), reader["StockID"]);
            row[3] = reader["Quantity"].ToString();
            row[4] = reader["Description"].ToString();
            row[5] = reader["Cost"].ToString();
            row[6] = reader["Weight"].ToString();
            row[7] = reader["Specification"].ToString();

            byte[] pic = reader["Image"] as byte[];
            MemoryStream ms = new MemoryStream(pic);
            pics.Add(Image.FromStream(ms));
            itemIDs.Add(reader["StockID"].ToString());
            itemNos.Add(reader["StockNo"].ToString());

            //ClearPurchase();
            dt.Rows.Add(row);
            dgvItem.RefreshEdit();
        }

        public void LoadInvoice(string invoiceNum, string invoiceTyp)
        {
            // Disable static data fields
            cmbInvTyp.Enabled = false;
            cmbItmTyp.Enabled = false;

            txtInvNo.Text = String.Format("CMB-{0:D3}-{1}", invoiceNum, invoiceTyp);
            // nextNumber = Convert.ToInt32(invoiceNum);

            // SELECT * FROM Purchase AS P
            // INNER JOIN Status_Of_Stocks SoS
            // ON P.Item_ID=SoS.StockID AND P.Item_No=SoS.StockNo 
            // WHERE P.Invoice_No=@Invoice_No AND P.Invoice_Type=@Invoice_Type
            String query = "SELECT SoS.StockNo AS StockNo, "
                + "SoS.StockId AS StockID, "
                + "SE.Stock_Type AS StockType, "
                + "SE.Item_Description AS Description, "
                + "P.Spec AS Specification, "
                + "P.Cost AS Cost, "
                + "P.Quantity AS Quantity, "
                + "P.Item_Weight AS Weight, "
                + "SE.Image AS Image "
                + "FROM Purchase AS P "
                + "INNER JOIN Status_Of_Stocks AS SoS "
                + "ON SoS.StockNo=P.Item_No AND SoS.StockID=P.Item_ID "
                + "INNER JOIN Stock_Entry AS SE "
                + "ON SoS.StockNo=SE.Stock_No AND SoS.StockID=SE.Stock_ID "
                + "WHERE P.Invoice_No=@Invoice_No AND P.Invoice_Type=@Invoice_Type";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Invoice_No", invoiceNum);
            command.Parameters.AddWithValue("@Invoice_Type", invoiceTyp);

            ClearPurchase();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    LoadPurchase(reader);
                }
            }

            dgvItem.DataSource = dt;
            dgvItem.RefreshEdit();
            //using (var )
            // create a reader
            // go over each row => while(reader.Read())
            //  check if it is reader["Item_Type"] is Gems or Jewellery
            //  fill datagridview according to item Type

            // Fetch from customer table and set fields

            // Payment 
        }

        private void INPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Customer Name    : ", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(150, 160));
            e.Graphics.DrawString("" + cmbTitle.Text + " " + txtCusNm.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 160));
            e.Graphics.DrawString("Customer Address : ", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(150, 200));
            e.Graphics.DrawString("" + txtAddress.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 200));
            e.Graphics.DrawString("Invoice No : " + txtInvNo.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 160));
            e.Graphics.DrawString("Date : " + DateTime.Now.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 200));
            e.Graphics.DrawString("Stock No", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(150, 300));
            e.Graphics.DrawString("" + dgvItem.CurrentRow.Cells[2].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(160, 335));
            e.Graphics.DrawString("Qty", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(230, 300));
            e.Graphics.DrawString("" + dgvItem.CurrentRow.Cells[3].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(240, 335));
            e.Graphics.DrawString("Description of Items", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(270, 300));
            e.Graphics.DrawString("" + dgvItem.CurrentRow.Cells[4].Value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, 335));
            e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(845, 300));
            e.Graphics.DrawString("Payment", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(150, 400));
            e.Graphics.DrawString("Information", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(150, 420));


            e.Graphics.DrawString("Paid in Cash by " + cmbCurrency1.Text + " " + txtAmt1.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, 410));


            e.Graphics.DrawString("Total (Rs) :", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(720, 410));

            e.Graphics.DrawString(Dashlabel.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(820, 380));
            e.Graphics.DrawString("" + txtTotalAmount.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(835, 410));
            e.Graphics.DrawString(Dashlabel.Text, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(820, 430));
        }

        private void PrntInPre_Click(object sender, EventArgs e)
        {
            INPrintDocument.DefaultPageSettings.Landscape = true;
            INPrintPreviewDialog.Document = INPrintDocument;
            INPrintPreviewDialog.ShowDialog();
        }

        private void btnPrntInvoice_Click(object sender, EventArgs e)
        {

            INPrintDocument.Print();
        }

        public void SetUserType(String usertype)
        {
            UserType = usertype;

            if (UserType == "Administrator") {
                Invdelete.Visible = true;
                InvUpdate.Visible = false;
                button3.Visible = true;

            }
            else if (UserType == "StockController")
            {
                Invdelete.Visible = false;
                InvUpdate.Visible = false;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            Login open = new Login();
            open.Show();
        }

        private void txtNoPieces_TextChanged(object sender, EventArgs e)
        {
            int index = 0;

            if (!Regex.IsMatch(txtNoPieces.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txtNoPieces.Text != "")
                {
                    txtNoPieces.Text = last_amount[index];
                }
            }

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
