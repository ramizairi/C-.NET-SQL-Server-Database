using Last_Steps.UserControl;
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

namespace Last_Steps
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=rami_zairi\MSSQLSERVER01;Initial Catalog=ForgetPassword;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp forgform = new SignUp();
            forgform.Show();
            
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            Forgotpassword fp = new Forgotpassword();
            this.Hide();
            fp.Show();
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txtUser.Text;
            user_password = txtPass.Text;

            try
            {
                string querry = "SELECT * FROM user_info WHERE username = '" + txtUser.Text + "' and password = '" + txtPass.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtb = new DataTable();
                sda.Fill(dtb);

                if(dtb.Rows.Count > 0)
                {
                    username = txtUser.Text;
                    user_password = txtPass.Text;

                    MessageBox.Show("Logged successfully", "Last Steps");
                }
                else
                {
                    MessageBox.Show("Invalid user or pass", "Last Steps");
                    txtPass.Clear();
                }
            }
            catch {
                MessageBox.Show("Error", "Last Steps");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
