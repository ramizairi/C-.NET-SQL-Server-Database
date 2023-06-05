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
using System.Net;
using System.Net.Mail;

namespace Last_Steps.UserControl
{
    public partial class ResetPassword : Form
    {
        string username = Forgotpassword.to;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (txtResetPass.Text == txtResetPassVer.Text)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=rami_zairi\MSSQLSERVER01;Initial Catalog=ForgetPassword;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[forgetpassword] SET [password] = @NewPassword WHERE username = @Username", conn);
                cmd.Parameters.AddWithValue("@NewPassword", txtResetPassVer.Text);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Password Reset Successfully", "Last Steps");
            }
            else
            {
                MessageBox.Show("Please make sure that the two passwords are similar", "Last Steps");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }
    }
}
 