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
using System.Security.Cryptography;


namespace PCJ_System
{
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tbnlogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtusername.Text.Length <= 0)
            {
                errorProvider1.SetError(txtusername, "This field cannot be empty");
            }
            else if (txtpassword.Text.Length <= 0)
            {
                errorProvider1.SetError(txtpassword, "This field cannot be empty");
            }
            else
            {
                try
                {
                    SqlCommand selectCommand = new SqlCommand("Select * from New_User where User_Name=@USER_ID and Password=@PASS", conn);
                    selectCommand.Parameters.Add(new SqlParameter("USER_ID", txtusername.Text.ToString()));
                    String password = "";

                    using (SHA1 sha1 = SHA1.Create())
                    {
                        //sha1.Initialize();
                        byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(txtpassword.Text));
                        
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < data.Length; ++i)
                        {
                            sb.Append(data[i].ToString("x2"));
                        }
                        password = sb.ToString();
                    }

                    selectCommand.Parameters.Add(new SqlParameter("PASS", password));
                    string UserType = null;
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    bool rowfound = reader.HasRows;
                    if (rowfound)
                    {
                        while (reader.Read())
                        {
                            UserType = reader["User_Type"].ToString().Trim();

                            if (UserType == "Administrator")
                            {
                                GlobalVariablesClass.VariableOne = txtusername.Text;
                               // MessageBox.Show("Welcome ", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Admin_Menu frm = new Admin_Menu();
                                frm.SetUserType(UserType);
                                frm.bunifuFlatButton3.Visible = true;
                                frm.SC_JE.Visible = true;
                                frm.SC_JE.Visible = true;
                                frm.bunifuFlatButton5.Visible = true;
                                frm.Show();
                               
                                this.Hide();
                            }
                            else if (UserType == "StockController")
                            {
                                // GlobalVariablesClass.isAdmin = false;
                                GlobalVariablesClass.VariableOne = txtusername.Text;
                                MessageBox.Show("Welcome ", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Admin_Menu frm = new Admin_Menu();
                                frm.SetUserType(UserType);
                                frm.bunifuFlatButton3.Visible = false;
                                frm.bunifuFlatButton7.Visible = false;
                                frm.bunifuFlatButton6.Visible = false;
                                frm.SC_GEMS.Visible = true;
                                frm.SC_JEWLRY.Visible = true;
                                frm.Show();


                                this.Hide();
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show(" Invalid User Or Password ", "Login ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("error login " + ex);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            In_certi op = new In_certi();
            op.Show();
            this.Hide();

        }
    }
}