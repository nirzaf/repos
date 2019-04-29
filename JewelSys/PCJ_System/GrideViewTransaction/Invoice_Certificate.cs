using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace PCJ_System
{
    public partial class Invoice_Certificate : UserControl
    {
        //const static String
        SqlConnection conn;
        //   SqlDataAdapter adapt;
        private const string select_query = "SELECT TOP 10 Customer.Invoice_No,Customer.Invoice_Type,Customer.Customer_Name,Customer.Customer_Title,Customer.Customer_Address,Invoice.Invoice_Date FROM Customer INNER JOIN Invoice ON Invoice.Invoice_No=Customer.Invoice_No AND Invoice.Invoice_Type=Customer.Invoice_Type ORDER BY Invoice_DATE DESC";
        private static Invoice_Certificate _instance;
        public string UserType;

        private void AddDataToGridView(SqlDataReader reader)
        {
            invoice_Certificate1.Rows.Clear();
            while (reader.Read())
            {
                //var row = dt.NewRow();
                var index = invoice_Certificate1.Rows.Add();
                var row = invoice_Certificate1.Rows[index];

                int Inv = Convert.ToInt32(reader["Invoice_No"].ToString());
                string InvTyp = reader["Invoice_Type"].ToString();

                // store so that the items can be fetched later
                //StockNoList.Add(sNo);
                //StockIdList.Add(sId);
                //string itemNo = String.Format("{0}{1}", Inv, InvTyp);
                string invoiceId = String.Format("CMB-{0:D3}-{1}", Inv, InvTyp);

                // string invoiceId = String.Format("CMB-{0:000}-{1}", reader["Invoice_No"], reader["Invoice_Type"]);

                row.Cells[0].Value = invoiceId;
                row.Cells[1].Value = reader["Customer_Title"].ToString() + reader["Customer_Name"].ToString();
                row.Cells[2].Value = reader["Customer_Address"].ToString();
                row.Cells[3].Value = reader["Invoice_Date"].ToString();

            }

            invoice_Certificate1.RefreshEdit();
        }

        public static Invoice_Certificate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Invoice_Certificate();
                return _instance;
            }
        }

        public Invoice_Certificate()
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
            DisplayData();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            In_certi open = new In_certi();
            open.SetUserType(UserType);
            //open.UserType = UserType;
            open.Show();
        }

        private void DisplayData()
        {
            invoice_Certificate1.Rows.Clear();
            // stockNoList.Clear();
            // stockItemList.Clear();
            // conn.Close();
            // conn.Open();

            try
            {
                var command = new SqlCommand(select_query, conn);
                using (var reader = command.ExecuteReader())
                {
                    AddDataToGridView(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*  public void DisplayData()
          {
              // Customer Details
              // For combining invoice ID
              // SELECT TOP 10 * FROM Customer ORDER BY Invoice_No DESC

              // create reader 
              // string invoiceId = String.Format("CMB-{0:000}-{1}", reader["Invoice_No"], reader["Invoice_Type"]);
          }*/

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void Invoice_Certificate_Load(object sender, EventArgs e)
        {

        }

        private void invoice_Certificate1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Match m = Regex.Match(invoice_Certificate1.CurrentRow.Cells[0].Value.ToString(), "CMB-([0-9]{3})-([A-Za-z]{2})");
            string invoiceType = m.Groups[2].Value.ToString();
            string invoiceNumber = m.Groups[1].Value.ToString();

            In_certi inc = new In_certi();
            inc.SetUserType(UserType);
            inc.button3.Visible = false;
            inc.LoadInvoice(invoiceNumber, invoiceType);
            inc.btnPrntInvoice.Enabled = true;
            inc.PrntInPre.Enabled = true;



            //  inc.cmbTitle.Text = this.invoice_Certificate1.CurrentRow.Cells[0].Value.ToString();
            //inc.txtCusNm.Text = this.invoice_Certificate1.CurrentRow.Cells[1].Value.ToString();


            inc.InvUpdate.Visible = true;
            inc.ShowDialog();


            /*    inc.txt_qty.Text = "1";

                myFormg.combo_itemk_description.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                myFormg.combo_item_type.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                myFormg.txt_no_of_gems.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                myFormg.txt_gem_type.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                myFormg.txt_gem_weight.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                myFormg.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

                myFormg.txt_no_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
                myFormg.txt_other_gems.Text = this.dataGridView1.CurrentRow.Cells[14].Value.ToString();
                myFormg.txt_weight_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[15].Value.ToString();

                //   myFormg.cmbStockType.Enabled = false;
                //  myFormg.txtstock_no.Enabled = false;

                using (var cmd = new SqlCommand("SELECT Image FROM Stock_Entry WHERE Stock_ID=@Stock_ID AND Stock_No= @Stock_No", conn))
                {
                    cmd.Parameters.AddWithValue("Stock_ID", stockId);
                    cmd.Parameters.AddWithValue("Stock_No", stockNo);
                    using (var Reader = cmd.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            MemoryStream ms = new MemoryStream(Reader["Image"] as byte[]);
                            myFormg.pb1.Image = Image.FromStream(ms);
                        }

                    }
                }*/
            //inc.ShowDialog();


        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //bunifuMetroTextbox1.Text = bunifuMetroTextbox1.Text.ToUpper();
            //CMB - ([0 - 9]{ 3})-([A - Za - z]{ 2})
            //CMB-{0:D3}-{1}
            //
            //var matches = Regex.Match(bunifuMetroTextbox1.Text, "CMB-([0-9]+)(-(LC|FC))");

            try
            {
                BindingSource DGV = new BindingSource
                {
                    DataSource = invoice_Certificate1.DataSource,
                    Filter = string.Format("`Customer.Invoice_No,Customer.Invoice_Type` LIKE '%{0}' OR `Customer.Invoice_No,Customer.Invoice_Type` LIKE '%{0}%'", bunifuMetroTextbox1.Text.Trim())
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //if (matches.Groups.Count < 2)
            //{
            //    DisplayData();
            //    return;
            //}

            //string invoiceType = null;
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;

            //if (matches.Groups.Count >= 4)
            //{
            //    invoiceType = matches.Groups[3].Value;
            //    cmd.CommandText = "SELECT TOP 10 Customer.Invoice_No,Customer.Invoice_Type,Customer.Customer_Name,Customer.Customer_Title,Customer.Customer_Address,Invoice.Invoice_Date FROM Customer INNER JOIN Invoice ON Invoice.Invoice_No=Customer.Invoice_No AND Invoice.Invoice_Type=Customer.Invoice_Type WHERE Invoice.Invoice_No LIKE @in_no AND Invoice.Invoice_Type LIKE @in_type ORDER BY Invoice_DATE DESC";
            //    cmd.Parameters.AddWithValue("@in_type", invoiceType + '%');
            //}
            //else
            //{
            //    cmd.CommandText = "SELECT TOP 10 Customer.Invoice_No,Customer.Invoice_Type,Customer.Customer_Name,Customer.Customer_Title,Customer.Customer_Address,Invoice.Invoice_Date FROM Customer INNER JOIN Invoice ON Invoice.Invoice_No=Customer.Invoice_No AND Invoice.Invoice_Type=Customer.Invoice_Type WHERE Invoice.Invoice_No LIKE @in_no ORDER BY Invoice_DATE DESC";
            //}

            //string invNo = matches.Groups[2].Value;
            //cmd.Parameters.AddWithValue("@in_no", invNo + '%');
            //using (var reader = cmd.ExecuteReader())
            //{
            //    AddDataToGridView(reader);
            //}

        }

        public void SetUserType(String usertype)
        {
            UserType = usertype;
        }

        private void bunifuMetroTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                BindingSource DGV = new BindingSource
                {
                    DataSource = invoice_Certificate1.DataSource,
                    Filter = string.Format("`Customer_Name` LIKE '%{0}' OR `Customer_Name` LIKE '%{0}%'", bunifuFlatButton1.Text.Trim())
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
