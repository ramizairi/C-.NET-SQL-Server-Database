using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Last_Steps.UserControl
{
    public partial class Forgotpassword : Form
    {
        string randomcode;
        public static string to;
        public Forgotpassword()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "Email Here";
            pass = "Password Here";
            messageBody = "Your reset code is : " + randomcode;
            message.To.Add(to);
            message.From= new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Last Steps : Password reseting code";
            SmtpClient smtp = new SmtpClient("SMTP HERE");
            smtp.EnableSsl = true;
            smtp.Port = "Port Here";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Send Successfully", "Last Steps");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (randomcode == (txtVerCode.Text).ToString())
            {
                to = txtEmail.Text;
                ResetPassword rp = new ResetPassword();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code", "Last Steps");
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
