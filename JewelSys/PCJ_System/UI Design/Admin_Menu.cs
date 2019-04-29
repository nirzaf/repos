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

namespace PCJ_System
{
    public partial class Admin_Menu : Form
    {

        //SqlConnection conn;
        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();
        public Admin_Menu()
        {

            InitializeComponent();
            //invoice_Certificate1.UserType = "Admin";
            //invoice_Certificate2.U
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login open = new Login();
            open.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
                      newUser1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
                      //outStanding_of_Stocks1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
        status_of_Stocks1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
          //outstandingstocks1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           invoice_Certificate2.BringToFront();
            //invoice_Certificate1.BringToFront();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            //stocks_Jewelry1.BringToFront();

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
           stocks_Jewelry1.BringToFront();
            
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
          stocks_Gems1.BringToFront();
      
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
          //outStanding_of_Stocks1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            hello.Text = GlobalVariablesClass.VariableOne;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            stocks_Jewelry1.BringToFront();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            stocks_Gems1.BringToFront();
        }

        private void dashBoard1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click_2(object sender, EventArgs e)
        {
            scStocks_Gems1.BringToFront();
        }

        private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
        {
            scStocks_Jewelry1.BringToFront();
        }

        private void bunifuFlatButton5_Click_3(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton5_Click_4(object sender, EventArgs e)
        {
            Foriegn_Currency_Update open = new Foriegn_Currency_Update();
            open.Show();
        }

        public void SetUserType(String usertype)
        {
            invoice_Certificate1.SetUserType(usertype);
            invoice_Certificate2.SetUserType(usertype);
        }

        private void bunifuFlatButton8_Click_2(object sender, EventArgs e)
        {
            //Outstandingstocks.BringToFront();
            outstandingstocks1.BringToFront();

        }
    }
    }


