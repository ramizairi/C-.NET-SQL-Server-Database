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
namespace Last_Steps.UserControl
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void HidePass_Click(object sender, EventArgs e)
        {
        }

        private void SignIpBtn_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtVerPass.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=rami_zairi\\MSSQLSERVER01;Initial Catalog=ForgetPassword;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[user_info]
           ([email]
           ,[username]
           ,[password]
           ,[birthday])
     VALUES
           ('" + txtEmail.Text + "', '" + txtUser.Text + "', '" + txtPass.Text + "', '" + Birth.Value.ToString("yyyyddMM") + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registred Successfully", "Last Steps");
                Login lg = new Login();
                this.Hide();
                lg.Show();
            }
            else
            {
                MessageBox.Show("Please make sure that the two passwords are similar", "Last Steps");
            }
        }
    }
}
