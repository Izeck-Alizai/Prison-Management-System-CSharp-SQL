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

namespace PrisonManagementSystem
{
    public partial class SignIn : Form
    {
        public static string loginname;

        public SignIn()
        {
            InitializeComponent();

            SignIn_Panel.BackColor = Color.FromArgb(150, Color.White);
            
            SignIn_ForgotPassword_Link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;

            SignIn_RegisterNow_Link.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void SignIn_RegisterNow_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            SignUp SignUp_On_Register_Link = new SignUp();

            SignUp_On_Register_Link.Show();
        }

        private void SignIn_SignIn_Button_Click(object sender, EventArgs e)
        {
            SqlConnection sql_con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True");

            string query = "SELECT * FROM SignUp WHERE Username = '" + Username_TextBox.Text.Trim() + "' AND Password = '" + Password_TextBox.Text.Trim() + "'";

            SqlDataAdapter sql_da = new SqlDataAdapter(query, sql_con);

            DataTable sql_dt = new DataTable();
            
            sql_da.Fill(sql_dt);

            if (sql_dt.Rows.Count == 1 && Username_TextBox.Text.Substring(0,4) == "WRDN")
            {
                loginname = Username_TextBox.Text.ToUpper();

                this.Hide();

                Warden_MainMenu Warden_Menu_On_SignIn_Button = new Warden_MainMenu();

                Warden_Menu_On_SignIn_Button.Show();
            }
            else if (sql_dt.Rows.Count == 1 && Username_TextBox.Text.Substring(0, 2) == "PG")
            {
                loginname = Username_TextBox.Text.ToUpper();

                this.Hide();

                PrisonGuard_MainMenu PrisonGuard_Menu_On_SignIn_Button = new PrisonGuard_MainMenu();

                PrisonGuard_Menu_On_SignIn_Button.Show();
            }
            else if (sql_dt.Rows.Count == 1 && Username_TextBox.Text.Substring(0, 3) == "COR")
            {
                loginname = Username_TextBox.Text.ToUpper();

                this.Hide();

                ChiefofRecords_MainMenu ChiefofRecords_Menu_On_SignIn_Button = new ChiefofRecords_MainMenu();

                ChiefofRecords_Menu_On_SignIn_Button.Show();
            }
            else
            {
                string sample = "Invalid username and password.\nPlease make sure you enter your username and password correctly.";
                MessageBox.Show(sample);
            }
        }
    }
}
