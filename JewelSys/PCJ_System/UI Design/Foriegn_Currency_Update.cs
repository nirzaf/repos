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
    public partial class Foriegn_Currency_Update : Form
    {
        public Foriegn_Currency_Update()
        {
            InitializeComponent();

            using (var conn = new DB_CONNECTION().getConnection())
            {
                using (var cmd = new SqlCommand("SELECT [FC_TYPE] FROM dbo.[F_Currency]", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            comboBox1.Items.Add(reader["FC_TYPE"].ToString());
                        }
                    }
                }
            }
        }

        private void Updatebt_Click(object sender, EventArgs e)
        {

            DB_CONNECTION x = new DB_CONNECTION();
            SqlConnection conn = x.getConnection();
            String UpdateQuery = "Update F_Currency set FC_Rate ='" + textBox1.Text + "' where FC_TYPE ='" + comboBox1.Text + "';";
            SqlDataAdapter execute = new SqlDataAdapter(UpdateQuery, conn);
            execute.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                DB_CONNECTION x = new DB_CONNECTION();
                using (SqlConnection conn = x.getConnection())
                {
                    Console.WriteLine(comboBox1.Text);
                    using (var command = new SqlCommand("SELECT [FC_RATE] FROM dbo.[F_Currency] where [FC_TYPE]=@FC_Type", conn))
                    {
                        //Combo
                        command.Parameters.AddWithValue("FC_Type", comboBox1.Text);
                        textBox1.Text = command.ExecuteScalar().ToString();
                    }
                }
                
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Foriegn_Currency_Update_Load(object sender, EventArgs e)
        {

        }
    }
}
