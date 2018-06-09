using OpenTl.ClientApi.MtProto.Exceptions;
using OpenTl.Schema;
using OpenTl.Schema.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telecord
{
    public partial class Login : Form
    {
        private ISentCode hash;
        public Login()
        {
            InitializeComponent();

            grpLogin.Enabled = true;
            txtPhoneNumber.Enabled = true;
            btnTelegramLogin.Enabled = true;
        }

        private void btnSendVerification_Click(object sender, EventArgs e)
        {
            try
            {
                TUser user;
                try
                {
                    user = Task.Run(() => Telegram.clientApi.AuthService.SignInAsync(Properties.Settings.Default.PhoneNumber, hash, txtVerificationCode.Text)).Result;
                    this.Close();
                }
                // If the user has a cloud password
                catch (CloudPasswordNeededException)
                {
                    txtPassword.Enabled = true;
                    btnSendPassword.Enabled = true;
                    txtVerificationCode.Enabled = false;
                    btnSendVerification.Enabled = false;
                }
                // If the phone code is invalid

                //Task.Run(() => Telegram.Client.MakeAuthAsync(Properties.Settings.Default.PhoneNumber, hash, txtVerificationCode.Text)).Wait();
                //Telegram.StartAsync();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions[0].Message.ToLower().Contains("cloud password"))
                {
                    txtPassword.Enabled = true;
                    btnSendPassword.Enabled = true;
                    txtVerificationCode.Enabled = false;
                    btnSendVerification.Enabled = false;
                }
                else
                    MessageBox.Show(ex.InnerExceptions[0].Message, "Error");
            }
        }

        private void btnTelegramLogin_Click(object sender, EventArgs e)
        {
            try
            {
                hash = Task.Run(() => Telegram.clientApi.AuthService.SendCodeAsync(txtPhoneNumber.Text)).Result;
                Properties.Settings.Default.PhoneNumber = txtPhoneNumber.Text;
                Properties.Settings.Default.Save();
                txtVerificationCode.Enabled = true;
                btnSendVerification.Enabled = true;
                txtPhoneNumber.Enabled = false;
                btnTelegramLogin.Enabled = false;
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.InnerExceptions[0].Message, "Telecord");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Telecord");
            }
        }

        private void btnSendPassword_Click(object sender, EventArgs e)
        {
            try
            {
                //var p = Task.Run(() => Telegram.Client.GetPasswordSetting()).Result;
                var u = Task.Run(() => Telegram.clientApi.AuthService.CheckCloudPasswordAsync(txtPassword.Text)).Result;
                MessageBox.Show("Logged in as " + u.FirstName, "Welcome");
                grpLogin.Enabled = false;
                //Telegram.StartAsync();
                this.Close();
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("Invalid Password!\n" + ex.InnerExceptions[0].Message, "Error");
            }
        }
    }
}
