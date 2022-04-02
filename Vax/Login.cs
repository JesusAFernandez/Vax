using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vax
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (user.UserName == usernameBox.Text && user.Password == passwordBox.Text)
            {
                 this.Hide();
                 Engine engine = new Engine();
                 engine.ShowDialog();
                 this.Close();
              
            }
            else
            {
                label.Text = "Wrong Username or Password";
                usernameBox.Text = passwordBox.Text = "";
            }
        }

        private void usernameBox_Click(object sender, EventArgs e)
        {

            if (usernameBox.Text == "Username")
            {
                usernameBox.Text = "";
                passwordBox.Text = "";
            }

        }

        private void passwordBox_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == "Password")
                passwordBox.Text = "";
        }


    }
}
