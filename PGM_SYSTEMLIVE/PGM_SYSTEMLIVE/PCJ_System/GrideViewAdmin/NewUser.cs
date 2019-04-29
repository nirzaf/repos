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
using System.Security.Cryptography;


namespace PCJ_System
{
    public partial class NewUser : UserControl
    {
        SqlConnection conn;
        private static NewUser _instance;
        /*private int indexRow;*/

        public static NewUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NewUser();
                return _instance;
            }
        }
        public NewUser()
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
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            if (combo_usertype.Text.Length <= 0)
            {
                errorProvider1.SetError(combo_usertype, "This field cannot be empty");
            }
            else if (txtusername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtusername, "This field cannot be empty");
            }
            else if (txtpassword.Text.Length <= 0)
            {
                errorProvider1.SetError(txtpassword, "This field cannot be empty");
            }
            else if (txtcon_password.Text.Length <= 0)
            {
                errorProvider1.SetError(txtcon_password, "This field cannot be empty");
            }
            else if (txtpassword.Text != txtcon_password.Text)
            {
                errorProvider1.SetError(txtcon_password, "Password Mismatch");
            }
            else
            {
                try
                {
                    String password = txtpassword.Text;
                    // byte[] hash = null;

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        // sha1.Initialize();
                        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; ++i)
                        {
                            sb.Append(hash[i].ToString("x2"));
                        }
                        password = sb.ToString();
                    }

                    conn.Open();
                    String InsertQuery = "INSERT INTO New_User VALUES('" + combo_usertype.Text + "','" + txtusername.Text
                    + "', '" + password + "', '" + label11.Text + "')";

                    SqlDataAdapter execute = new SqlDataAdapter(InsertQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select ID,User_Type,User_Name,Create_Date from New_User", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    combo_usertype.Text = "";
                    txtusername.Text = "";
                    txtpassword.Text = "";
                   txtcon_password.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {

            }

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            txtbx_ID.Text = selectedRow.Cells[0].Value.ToString();
            combo_usertype.Text = selectedRow.Cells[1].Value.ToString();
            txtusername.Text = selectedRow.Cells[2].Value.ToString();
            txtpassword.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label11.Text = dateTime.ToString();

            try
            {
                conn.Close();
                conn.Open();
                SqlDataAdapter sda;
                DataTable dt1;
                sda = new SqlDataAdapter("select ID,User_Type,User_Name,Create_Date FROM New_User", conn);
                dt1 = new DataTable();
                sda.Fill(dt1);
                dataGridView1.DataSource = dt1;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (combo_usertype.Text == "" || txtusername.Text == "")
            {
                MessageBox.Show("Please select UserType to update changes!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtpassword.Text != txtcon_password.Text)
            {
                errorProvider1.SetError(txtcon_password, "Password Mismatch");
            }
            else
            {
                try
                {

                    conn.Close();
                    conn.Open();
                    String password = txtpassword.Text;
                    // byte[] hash = null;

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        // sha1.Initialize();
                        byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; ++i)
                        {
                            sb.Append(hash[i].ToString("x2"));
                        }
                        password = sb.ToString();
                    }


                    String UpdateQuery = "Update New_User set User_Type ='" + combo_usertype.Text + "',User_Name ='"
                        + txtusername.Text + "', Password ='" + password + "', Create_Date ='" + label11.Text + "'  where ID ='" + txtbx_ID.Text+ "';";

                    SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select ID,User_Type,User_Name,Create_Date from New_User", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    combo_usertype.Text = "";
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtcon_password.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            if (combo_usertype.Text == "" || txtusername.Text == "")
            {
                MessageBox.Show("Select the Row & Delete", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {
                    conn.Close();
                    conn.Open();
                    String DeleteQuery = "delete from New_User where ID ='" + txtbx_ID.Text + "';";
                    SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                    execute.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    SqlDataAdapter data = new SqlDataAdapter("Select ID,User_Type,User_Name,Create_Date from New_User", conn);
                    DataTable dt = new DataTable();
                    data.Fill(dt);
                    dataGridView1.DataSource = dt;

                    combo_usertype.Text = "";
                    txtusername.Text = "";
                    txtpassword.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            combo_usertype.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            combo_usertype.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
        }
    }
}
