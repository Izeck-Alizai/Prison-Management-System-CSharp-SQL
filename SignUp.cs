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
    public partial class SignUp : Form
    {
        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True";

        public SignUp()
        {
            InitializeComponent();

            SignUp_Panel1.BackColor = Color.FromArgb(150, Color.White);

            SignUp_Panel2.Visible = false;
        }

        private void SignUp_Back_Button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignIn SignIn_On_Back_Button = new SignIn();

            SignIn_On_Back_Button.Show();
        }

        private void SignUp_FirstName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (SignUp_FirstName_TextBox.TextLength >= 1)
            {
                if (SignUp_LastName_TextBox.TextLength >= 1)
                {
                    if (SignUp_Address_TextBox.TextLength >= 1)
                    {
                        if (SignUp_CNIC_TextBox.TextLength == 13)
                        {
                            SignUp_Next_Button.Enabled = true;
                        }
                        else
                        {
                            SignUp_Next_Button.Enabled = false;
                        }
                    }
                    else
                    {
                        SignUp_Next_Button.Enabled = false;
                    }
                }
                else
                {
                    SignUp_Next_Button.Enabled = false;
                }
            }
            else
            {
                SignUp_Next_Button.Enabled = false;
            }
        }

        private void SignUp_Next_Button_Click(object sender, EventArgs e)
        {
            SignUp_Panel1.Visible = false;

            SignUp_Panel2.Visible = true;
        }

        private void SignUp_Reset_Button1_Click(object sender, EventArgs e)
        {
            if (SignUp_Address_TextBox.TextLength >= 1)
            {
                SignUp_Address_TextBox.Text = String.Empty;
            }
            if (SignUp_CNIC_TextBox.TextLength >= 1)
            {
                SignUp_CNIC_TextBox.Text = String.Empty;
            }
            if (SignUp_Email_TextBox.TextLength >= 1)
            {
                SignUp_Email_TextBox.Text = String.Empty;
            }
            if (SignUp_FirstName_TextBox.TextLength >= 1)
            {
                SignUp_FirstName_TextBox.Text = String.Empty;
            }
            if (SignUp_LastName_TextBox.TextLength >= 1)
            {
                SignUp_LastName_TextBox.Text = String.Empty;
            }
            if (SignUp_PhoneNumber_TextBox.TextLength >= 1)
            {
                SignUp_PhoneNumber_TextBox.Text = String.Empty;
            }
        }

        private void SignUp_PhoneNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void SignUp_FirstName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void SignUp_CNIC_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void SignUp_LastName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void SignUpRF_Submit_Button_Click(object sender, EventArgs e)
        {
            if (SignUp_Password_TextBox.Text != SignUp_ConfirmPassword_TextBox.Text)
            {
                string sample = "Passwords do not match.";
                MessageBox.Show(sample);
            }
            else
            {
                using (SqlConnection sql_con = new SqlConnection(connectionString))
                {
                    sql_con.Open();

                    SqlCommand sql_com = new SqlCommand("AddUser", sql_con);
                    sql_com.CommandType = CommandType.StoredProcedure;

                    sql_com.Parameters.AddWithValue("@FirstName", SignUp_FirstName_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@LastName", SignUp_LastName_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@Phone", SignUp_PhoneNumber_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@Email", SignUp_Email_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@CNIC", SignUp_CNIC_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@Address", SignUp_Address_TextBox.Text);
                    sql_com.Parameters.AddWithValue("@AccountType", SignUp_AccountType_ComboBox.SelectedItem);
                    sql_com.Parameters.AddWithValue("@Username", SignUp_Username_TextBox.Text.Trim());
                    sql_com.Parameters.AddWithValue("@Password", SignUp_Password_TextBox.Text.Trim());

                    sql_com.ExecuteNonQuery();
                }

                this.Hide();

                Welcome Welcome_On_Submit_Button = new Welcome();

                Welcome_On_Submit_Button.Show();
            }
        }

        private void SignUpRF_AccountType_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (SignUp_AccountType_ComboBox.SelectedItem != null)
            {
                if (SignUp_Password_TextBox.TextLength >= 1)
                {
                    if (SignUp_ConfirmPassword_TextBox.TextLength >= 1)
                    {
                        SignUp_Submit_Button.Enabled = true;
                    }
                    else
                    {
                        SignUp_Submit_Button.Enabled = false;
                    }
                }
                else
                {
                    SignUp_Submit_Button.Enabled = false;
                }
            }
            else
            {
                SignUp_Submit_Button.Enabled = false;
            }
        }

        private void SignUpRF_AccountType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SignUp_AccountType_ComboBox.SelectedItem == "Warden")
            {
                SqlConnection sql_con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True");

                SignUp_Username_TextBox.Text = "WRDN_" + SignUp_FirstName_TextBox.Text + SignUp_LastName_TextBox.Text;
            }
            if (SignUp_AccountType_ComboBox.SelectedItem == "Prison Guard")
            {
                SignUp_Username_TextBox.Text = "PG_" + SignUp_FirstName_TextBox.Text + SignUp_LastName_TextBox.Text;
            }
            if (SignUp_AccountType_ComboBox.SelectedItem == "Chief of Records")
            {
                SignUp_Username_TextBox.Text = "COR_" + SignUp_FirstName_TextBox.Text + SignUp_LastName_TextBox.Text;
            }
        }

        private void SignUpRF_Reset_Button2_Click(object sender, EventArgs e)
        {
            if (SignUp_AccountType_ComboBox.SelectedItem != null)
            {
                SignUp_AccountType_ComboBox.SelectedItem = null;
            }
            if (SignUp_ConfirmPassword_TextBox.TextLength >= 1)
            {
                SignUp_ConfirmPassword_TextBox.Text = String.Empty;
            }
            if (SignUp_Password_TextBox.TextLength >= 1)
            {
                SignUp_Password_TextBox.Text = String.Empty;
            }
            if (SignUp_Username_TextBox.TextLength >= 1)
            {
                SignUp_Username_TextBox.Text = String.Empty;
            }
        }

        private void SignUp_Back_Button2_Click(object sender, EventArgs e)
        {
            SignUp_Panel1.Visible = true;

            SignUp_Panel2.Visible = false;
        }
    }
}
