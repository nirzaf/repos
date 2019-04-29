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
    public partial class SCStocks_Jewelry : UserControl
    {
        SqlConnection conn;
        // bool showUser;
        // SqlCommand cmd;
        // SqlDataAdapter adapt;
        private const string select_query = "SELECT TOP 10 * FROM Stock_Entry WHERE Stock_Type = 'Jewellery' ORDER BY Create_Date DESC";
        // DataTable dataset;


        private static SCStocks_Jewelry _instance;
        private void AddDataToGridView(SqlDataReader reader)
        {
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                //var row = dt.NewRow();
                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];

                string sNo = reader["Stock_No"].ToString();
                string sId = reader["Stock_ID"].ToString();

                // store so that the items can be fetched later
                //StockNoList.Add(sNo);
                //StockIdList.Add(sId);
                string itemNo = String.Format("{0}{1}", sNo, sId);

                row.Cells[0].Value = itemNo;
                row.Cells[1].Value = reader["No_of_Pieces"].ToString();
                row.Cells[2].Value = reader["Item_Description"].ToString();
                row.Cells[3].Value = reader["Item_Type"].ToString();
                row.Cells[4].Value = reader["No_of_Gems"].ToString();
                row.Cells[5].Value = reader["Gem_Type"].ToString();
                row.Cells[6].Value = reader["Weight"].ToString();
                row.Cells[7].Value = reader["Cost"].ToString();
                //MemoryStream ms = new MemoryStream(reader["Image"] as byte[]);
                //row.Cells[8].Value = Image.FromStream(ms);
                row.Cells[8].Value = Image.FromFile(reader["currentImagePath"].ToString());

                row.Cells[9].Value = reader["Create_Date"].ToString();
                row.Cells[10].Value = reader["UserID"].ToString();
                row.Cells[11].Value = reader["Update_Date"].ToString();
                row.Cells[12].Value = reader["Update_UserID"].ToString();

                row.Cells[13].Value = reader["No_of_other_Gems"].ToString();
                row.Cells[14].Value = reader["Other_Gems"].ToString();
                row.Cells[15].Value = reader["Weight_of_other_Gems"].ToString();
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)

                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }
            dataGridView1.RefreshEdit();
        }


        private void DisplayData()
        {
            dataGridView1.Rows.Clear();
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

        public static SCStocks_Jewelry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SCStocks_Jewelry();
                return _instance;
            }
        }

        public SCStocks_Jewelry()
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
            S_Jewelry open = new S_Jewelry();
            open.btnupdate.Visible = false;
            open.btn_delete.Visible = false;
            open.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {

            }

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

        }

        private void SCStocks_Jewelry_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             S_Jewelry myForm = new S_Jewelry();

            myForm.btn_Refresh.Visible = false;
            myForm.btnsave.Visible = false;


            // myForm.txt_ID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.Stock_Type.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
              myForm.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

              myForm.txt_qty.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
              myForm.txt_gem_type.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
              myForm.txt_gem_weight.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
              myForm.combo_itemk_description.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
              myForm.combo_item_type.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

              myForm.txt_no_of_gems.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
              myForm.txt_no_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
              myForm.txt_other_gems.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
              myForm.txt_weight_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();

              byte[] pic = this.dataGridView1.CurrentRow.Cells[12].Value as byte[];
              if (pic != null)
              {
            //      MemoryStream stream = new MemoryStream(pic);
                  //myForm.pb1.Image = Image.FromStream(stream);
              }
              else
              //    myForm.pb1.Image = null;

              //  myForm.pb1.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
              myForm.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
              myForm.ShowDialog();





              /*S_Gems myFormg = new S_Gems();
              myFormg.Stock_Type.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
              myFormg.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
              myFormg.txtno_of_peices.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
              myFormg.txt_gems.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
              myFormg.txt_weight.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

              byte[] picg = this.dataGridView1.CurrentRow.Cells[12].Value as byte[];
              if (picg != null)
              {
                  MemoryStream stream = new MemoryStream(picg);
                  myFormg.pb1.Image = Image.FromStream(stream);
              }
              else
                  myFormg.pb1.Image = null;

              myFormg.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
              //  myForm.hello.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
              myFormg.Hide();*/


        }

        private void textbox1_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP 1 * FROM Stock_Entry Where Stock_No like ('" + textbox1.Text + "%') ORDER BY ID DESC ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Match m = Regex.Match(dataGridView1.CurrentRow.Cells[0].Value.ToString(), "([A-Za-z]+)([0-9]+)");
            if (m.Groups.Count != 3)
            {
                return;
            }
            string stockId = m.Groups[2].Value;
            string stockNo = m.Groups[1].Value;

            S_Jewelry myFormg = new S_Jewelry();

            myFormg.radioButton1.Checked = false;
            myFormg.radioButton1.Enabled = false;

            myFormg.btn_Refresh.Visible = false;
            myFormg.btnsave.Visible = false;

            myFormg.Stock_Type.Text = "Jewellery";

            myFormg.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myFormg.txt_qty.Text = "1";

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
                    //    MemoryStream ms = new MemoryStream(Reader["Image"] as byte[]);
                   //     myFormg.pb1.Image = Image.FromStream(ms);
                    }

                }
            }
            myFormg.ShowDialog();
        }

        private void textbox1_OnValueChanged(object sender, EventArgs e)
        {
            var matches = Regex.Match(textbox1.Text, "([A-Za-z]+)([0-9]+)");

            if (matches.Groups.Count < 3)
            {
                DisplayData();
                return;
            }

            string stockNo = matches.Groups[1].Value;
            string stockId = matches.Groups[2].Value;

            const string query = "SELECT TOP 1 * FROM Stock_Entry WHERE Stock_Type='Jewellery' AND Stock_No LIKE @StockNo AND Stock_ID LIKE @StockID ORDER BY Stock_ID DESC";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StockNo", stockNo + '%');
                cmd.Parameters.AddWithValue("@StockID", stockId + '%');

                using (var reader = cmd.ExecuteReader())
                {
                    AddDataToGridView(reader);
                }
            }
        }
    }
}
