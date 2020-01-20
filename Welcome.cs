using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonManagementSystem
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Continue_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignIn SignIn_On_Continue_Button = new SignIn();

            SignIn_On_Continue_Button.Show();
        }
    }
}
