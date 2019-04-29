using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PCJ_System
{
    public partial class Stocks_Gems : UserControl
    {
        SqlConnection conn;
        // SqlDataAdapter adapt;
        private const string select_query = "SELECT TOP 10 * FROM Stock_Entry WHERE Stock_Type = 'Gems' ORDER BY Create_Date DESC";
        
        // DataTable dataset;

        private static Stocks_Gems _instance;

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
                row.Cells[1].Value = reader["Gem_Type"].ToString();
                row.Cells[2].Value = reader["No_of_Pieces"].ToString();
                // row.Cells[3].Value = reader["Item_Type"].ToString();
                row.Cells[3].Value = reader["Weight"].ToString();
                row.Cells[4].Value = reader["Cost"].ToString();

                // 31.3.19 Today
                /* MemoryStream ms = new MemoryStream(reader["currentImagePath"] as byte[]);
                 row.Cells[5].Value = Image.FromStream(ms);*/
                row.Cells[5].Value = Image.FromFile(reader["currentImagePath"].ToString());

                row.Cells[6].Value = reader["Create_Date"].ToString();
                row.Cells[7].Value = reader["UserID"].ToString();
                row.Cells[8].Value = reader["Update_Date"].ToString();
                row.Cells[9].Value = reader["Update_UserID"].ToString();
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

        public static Stocks_Gems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stocks_Gems();
                return _instance;
            }
        }
        public Stocks_Gems()
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
            S_Gems open = new S_Gems();
            open.btnupdate.Visible = false;
            open.bunifuFlatButton3.Visible = false;
            open.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Match m = Regex.Match(dataGridView1.CurrentRow.Cells[0].Value.ToString(), "([A-Za-z]+)([0-9]+)");
            if (m.Groups.Count != 3)
            {
                return;
            }

            string stockId = m.Groups[2].Value;
            string stockNo = m.Groups[1].Value;

            S_Gems myFormg = new S_Gems();

            myFormg.btnrefresh.Visible = false;
            myFormg.btnsave.Visible = false;

            myFormg.Stock_Type.Text = "Gems";

            myFormg.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myFormg.txtno_of_peices.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            myFormg.txt_gems.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myFormg.txt_weight.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            myFormg.cmbStockType.Enabled = false;
            myFormg.txtstock_no.Enabled = false;
            // Today 2

            string currentImagePath = "";
            using (var cmd = new SqlCommand("SELECT currentImagePath FROM Stock_Entry WHERE Stock_ID=@Stock_ID AND Stock_No= @Stock_No", conn))
            {
                cmd.Parameters.AddWithValue("Stock_ID", stockId );
                cmd.Parameters.AddWithValue("Stock_No", stockNo);

                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()){
                        // MemoryStream ms = new MemoryStream(Reader["Image"] as byte[]); ****
                        // myFormg.pb1.Image =  Image.FromStream(ms);
                        
                        currentImagePath = reader.GetString(0);

                    }
                }
            }

            myFormg.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myFormg.stockId = stockId;
            myFormg.ShowDialog();
            

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void Stocks_Gems_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
     

        private void bunifuMetroTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
       
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            var matches = Regex.Match(bunifuMetroTextbox1.Text, "([A-Za-z]+)([0-9]+)");

            if (matches.Groups.Count < 3)
            {
                DisplayData();
                return;
            }

            string stockNo = matches.Groups[1].Value;
            string stockId = matches.Groups[2].Value;

            const string query = "SELECT TOP 10 * FROM Stock_Entry WHERE Stock_Type='Gems' AND Stock_No LIKE @StockNo AND Stock_ID LIKE @StockID ORDER BY Stock_ID DESC";
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
