using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PrisonManagementSystem
{
    public partial class ChiefofRecords_MainMenu : Form
    {
        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True";

        private void ChiefofRecords_MainMenu_Load(object sender, EventArgs e)
        {
            MainMenu_Username_Title_Label.Text = SignIn.loginname;
        }

        //-------------------------------------------------------------------CHIEF OF RECORDS' MAIN MENU-------------------------------------------------------------------//
        public ChiefofRecords_MainMenu()
        {
            InitializeComponent();

            fillCombo();

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Inmates", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Inmates_DataPanel.AutoGenerateColumns = false;
                MainMenu_Inmates_DataPanel.DataSource = sql_dt;
            }

            MainMenu_Inmates_DataPanel.Visible = true;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;
        }

        void fillCombo()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True";
            SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Inmates", connectionString);

            DataTable sql_dt = new DataTable();

            sql_da.Fill(sql_dt);

            for (int i = 0; i < sql_dt.Rows.Count; i++)
            {
                MainMenu_AddVisitor_Visiting_ComboBox.Items.Add(sql_dt.Rows[i]["PrisonerName"]);
            }
        }

        private void MainMenu_InmatesInfo_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Inmates", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Inmates_DataPanel.AutoGenerateColumns = false;
                MainMenu_Inmates_DataPanel.DataSource = sql_dt;
            }

            MainMenu_Inmates_DataPanel.Visible = true;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = "";      //INMATES' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value = System.DateTime.Now;
            MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = "Age";
            MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Clear();

            MainMenu_AddVisitor_VisitorsName_TextBox.Clear();      //VISITORS' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddVisitor_VisitorsAddress_TextBox.Clear();
            MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Clear();
        }

        private void MainMenu_AddAnInmate_Button_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = true;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = true;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            MainMenu_AddAnInmate_Panel1_SpouseName_Label.Visible = false;       //CONTROLS
            MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Visible = false;
            MainMenu_Field_Hint5.Visible = false;

            MainMenu_AddVisitor_VisitorsName_TextBox.Clear();      //VISITORS' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddVisitor_VisitorsAddress_TextBox.Clear();
            MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Clear();
        }

        private void MainMenu_AddVisitor_Button_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = true;
            MainMenu_Visitors_DataPanel.Visible = true;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = true;

            MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = "";      //INMATES' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value = System.DateTime.Now;
            MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = "Age";
            MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Clear();

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Visitors", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Visitors_DataPanel.AutoGenerateColumns = false;
                MainMenu_Visitors_DataPanel.DataSource = sql_dt;
            }
        }

        private void MainMenu_SignOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignIn signin_on_signout_button = new SignIn();

            signin_on_signout_button.Show();
        }

        //-------------------------------------------------------------------INMATE'S RECORD-------------------------------------------------------------------//
        string imageLocation = "";
        SqlCommand sql_com;
        private void MainMenu_AddAnInmate_Panel1_Browse_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();

                MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = imageLocation;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value.Year <= System.DateTime.Now.Year - 18)
            {
                MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = Convert.ToString(System.DateTime.Now.Year - MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value.Year);

                if (MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.TextLength >= 1)
                {
                    if (MainMenu_AddAnInmate_Panel1_Gender_ComboBox != null)
                    {
                        if ((MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Single" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widow" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widower") || (MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Married" && MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.TextLength >= 1))
                        {
                            if (MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem != null)
                            {
                                if (MainMenu_AddAnInmate_Panel1_CNIC_TextBox.TextLength == 13)
                                {
                                    MainMenu_Next_Button1.Enabled = true;
                                }
                                else
                                {
                                    MainMenu_Next_Button1.Enabled = false;
                                }
                            }
                            else
                            {
                                MainMenu_Next_Button1.Enabled = false;
                            }
                        }
                        else
                        {
                            MainMenu_Next_Button1.Enabled = false;
                        }
                    }
                    else
                    {
                        MainMenu_Next_Button1.Enabled = false;
                    }
                }
                else
                {
                    MainMenu_Next_Button1.Enabled = false;
                }
            }
            else
            {
                MainMenu_Next_Button1.Enabled = false;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Single" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widow" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widower")
            {
                MainMenu_AddAnInmate_Panel1_SpouseName_Label.Visible = false;
                MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Visible = false;
                MainMenu_Field_Hint5.Visible = false;

                MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Clear();
            }
            if (MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Married")
            {
                MainMenu_AddAnInmate_Panel1_SpouseName_Label.Visible = true;
                MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Visible = true;
                MainMenu_Field_Hint5.Visible = true;
            }
        }

        //PANEL 2 STARTS FROM HERE...
        private void MainMenu_AddAnInmate_Panel2_BloodType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel2_BloodType_ComboBox.SelectedItem != null)
            {
                if (MainMenu_AddAnInmate_Panel2_HairColor_ComboBox.SelectedItem != null)
                {
                    if (MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox.SelectedItem != null)
                    {
                        if (MainMenu_AddAnInmate_Panel2_Complexion_ComboBox.SelectedItem != null)
                        {
                            if (MainMenu_AddAnInmate_Panel2_Religion_ComboBox.SelectedItem != null)
                            {
                                if (MainMenu_AddAnInmate_Panel2_Height_TextBox.TextLength >= 1)
                                {
                                    if (MainMenu_AddAnInmate_Panel2_Weight_TextBox.TextLength >= 1)
                                    {
                                        if (MainMenu_AddAnInmate_Panel2_Built_ComboBox.SelectedItem != null)
                                        {
                                            MainMenu_Next_Button2.Enabled = true;
                                        }
                                        else
                                        {
                                            MainMenu_Next_Button2.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        MainMenu_Next_Button2.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MainMenu_Next_Button2.Enabled = false;
                                }
                            }
                            else
                            {
                                MainMenu_Next_Button2.Enabled = false;
                            }
                        }
                        else
                        {
                            MainMenu_Next_Button2.Enabled = false;
                        }
                    }
                    else
                    {
                        MainMenu_Next_Button2.Enabled = false;
                    }
                }
                else
                {
                    MainMenu_Next_Button2.Enabled = false;
                }
            }
            else
            {
                MainMenu_Next_Button2.Enabled = false;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_MOI1_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel2_MOI1_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI2_Label.Enabled = true;
                MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.Enabled = true;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI3_Label.Enabled = true;
                MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.Enabled = true;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI4_Label.Enabled = true;
                MainMenu_AddAnInmate_Panel2_MOI4_ComboBox.Enabled = true;
            }
        }

        //PANEL 3 STARTS FROM HERE...
        private void MainMenu_AddAnInmate_Panel3_Crime_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem != null)
            {
                if (MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.TextLength > 3)
                {
                    if (MainMenu_AddAnInmate_Panel3_LawyerName_TextBox.TextLength >= 1)
                    {
                        if (MainMenu_AddAnInmate_Panel3_LawyerHomeAddress_TextBox.TextLength >= 1)
                        {
                            if (MainMenu_AddAnInmate_Panel3_LawyerChamber_TextBox.TextLength >= 1)
                            {
                                if (MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox.TextLength == 11)
                                {
                                    if (MainMenu_AddAnInmate_Panel3_DateofConfinement_DateTimePicker.Value.Date <= System.DateTime.Now)
                                    {
                                        MainMenu_AddAnInmate_Submit_Button.Enabled = true;
                                    }
                                    else
                                    {
                                        MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                                    }
                                }
                                else
                                {
                                    MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                                }
                            }
                            else
                            {
                                MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                            }
                        }
                        else
                        {
                            MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                        }
                    }
                    else
                    {
                        MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                    }
                }
                else
                {
                    MainMenu_AddAnInmate_Submit_Button.Enabled = false;
                }
            }
            else
            {
                MainMenu_AddAnInmate_Submit_Button.Enabled = false;
            }
        }

        private void MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem == "Civil Court")
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = "CC_";
            }
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem == "High Court")
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = "HC_";
            }
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem == "Supreme Court")
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = "SC_";
            }
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem == "District Court")
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = "DC_";
            }
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem == "Special Court")
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = "SpcC_";
            }
        }

        //FIELD VALIDATIONS
        private void MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_FatherName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_MotherName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_SpouseName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_CNIC_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_Gender_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel1_City_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_Height_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != '\'' && ch != '"')
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_Weight_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_BloodType_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_HairColor_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_Complexion_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_Religion_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel2_Built_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel3_Crime_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel3_LawyerName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && !Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //LOWER PANEL BUTTONS
        private void MainMenu_Reset_Button1_Click(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation != "")
            {
                MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = "";
            }
            if (MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel1_FatherName_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel1_MotherName_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value.Year != System.DateTime.Now.Year)
            {
                MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value = System.DateTime.Now;
            }
            if (MainMenu_AddAnInmate_Panel1_Age_TextBox.Text != "Age")
            {
                MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = "Age";
            }
            if (MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Single" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widow" || MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Widower")
            {
                MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;
            }
            if ((MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Married") || (MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem == "Married" && MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.TextLength >= 1))
            {
                MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;

                MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel1_CNIC_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Text = String.Empty;
            }
        }

        private void MainMenu_Reset_Button2_Click(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel2_BloodType_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_BloodType_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_HairColor_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_HairColor_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_Complexion_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_Complexion_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_Religion_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_Religion_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_Built_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_Built_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_Height_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel2_Height_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel2_Weight_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel2_Weight_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI1_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI1_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel2_MOI4_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel2_MOI4_ComboBox.SelectedItem = null;
            }
        }

        private void MainMenu_Reset_Button3_Click(object sender, EventArgs e)
        {
            if (MainMenu_AddAnInmate_Panel3_Crime_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel3_Crime_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem != null)
            {
                MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem = null;
            }
            if (MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel3_DateofConfinement_DateTimePicker.Value.Date != System.DateTime.Now.Date)
            {
                MainMenu_AddAnInmate_Panel3_DateofConfinement_DateTimePicker.Value = System.DateTime.Now.Date;
            }
            if (MainMenu_AddAnInmate_Panel3_LawyerName_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel3_LawyerName_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel3_LawyerHomeAddress_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel3_LawyerHomeAddress_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel3_LawyerChamber_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel3_LawyerChamber_TextBox.Text = String.Empty;
            }
            if (MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox.TextLength >= 1)
            {
                MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox.Text = String.Empty;
            }
        }
        
        private void MainMenu_Back_Button1_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = true;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = true;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;

            MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = "";      //INMATES' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value = System.DateTime.Now;
            MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = "Age";
            MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Clear();
            MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Clear();
        }

        private void MainMenu_Next_Button1_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = true;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = true;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
        }

        private void MainMenu_Back_Button2_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = true;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = true;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
        }

        private void MainMenu_Next_Button2_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = true;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = true;
        }

        private void MainMenu_Back_Button3_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = true;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;     //BUTTONS
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = true;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
        }

        //SUBMITTING RECORD
        private void MainMenu_AddAnInmate_Submit_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                byte[] image = null;
                FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                image = br.ReadBytes((int)fs.Length);

                sql_con.Open();

                SqlCommand sql_com = new SqlCommand("AddInmate", sql_con);
                sql_com.CommandType = CommandType.StoredProcedure;

                sql_com.Parameters.Add("@Image", image);
                sql_com.Parameters.AddWithValue("@PrisonerName", MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@FatherName", MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@MotherName", MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@Gender", MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@DOB", MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value);
                sql_com.Parameters.AddWithValue("@CivilStatus", MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@SpouseName", MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@City", MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@CNIC", MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Text);
                sql_com.Parameters.AddWithValue("@BloodType", MainMenu_AddAnInmate_Panel2_BloodType_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@HairColor", MainMenu_AddAnInmate_Panel2_HairColor_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@EyeColor", MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@Complexion", MainMenu_AddAnInmate_Panel2_Complexion_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@Religion", MainMenu_AddAnInmate_Panel2_Religion_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@Height", MainMenu_AddAnInmate_Panel2_Height_TextBox.Text);
                sql_com.Parameters.AddWithValue("@Weight", MainMenu_AddAnInmate_Panel2_Weight_TextBox.Text);
                sql_com.Parameters.AddWithValue("@Built", MainMenu_AddAnInmate_Panel2_Built_ComboBox.SelectedItem);
                //sql_com.Parameters.AddWithValue("@MOI_1", MainMenu_AddAnInmate_Panel2_MOI1_ComboBox.SelectedItem);
                //sql_com.Parameters.AddWithValue("@MOI_2", MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.SelectedItem);
                //sql_com.Parameters.AddWithValue("@MOI_3", MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.SelectedItem);
                //sql_com.Parameters.AddWithValue("@MOI_4", MainMenu_AddAnInmate_Panel2_MOI4_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@Crime", MainMenu_AddAnInmate_Panel3_Crime_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@InCourtof", MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@CaseNo", MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text);
                sql_com.Parameters.AddWithValue("@DateofConfinement", MainMenu_AddAnInmate_Panel3_DateofConfinement_DateTimePicker.Value);
                sql_com.Parameters.AddWithValue("@AssignedLawyerName", MainMenu_AddAnInmate_Panel3_LawyerName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@LawyerAddress", MainMenu_AddAnInmate_Panel3_LawyerHomeAddress_TextBox.Text);
                sql_com.Parameters.AddWithValue("@LawyerChamber", MainMenu_AddAnInmate_Panel3_LawyerChamber_TextBox.Text);
                sql_com.Parameters.AddWithValue("@LawyerPhoneNo", MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox.Text);

                sql_com.ExecuteNonQuery();
            }

            MainMenu_Inmates_DataPanel.Visible = true;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;

            MessageBox.Show("Inmate's Record Successfully Uploaded!");

            MainMenu_AddAnInmate_Panel1_PrisonerPicture_PictureBox.ImageLocation = "";      //FIELDS CLEARING AFTER SUBMITTING RECORD
            MainMenu_AddAnInmate_Panel1_PrisonerName_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel1_FatherName_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel1_MotherName_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel1_Gender_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_DateOfBirth_DateTimePicker.Value = System.DateTime.Now.Date;
            MainMenu_AddAnInmate_Panel1_Age_TextBox.Text = "Age";
            MainMenu_AddAnInmate_Panel1_CivilStatus_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_SpouseName_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel1_City_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel1_CNIC_TextBox.Text = String.Empty;

            MainMenu_AddAnInmate_Panel2_BloodType_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_HairColor_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_EyeColor_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_Complexion_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_Religion_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_Height_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel2_Weight_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel2_Built_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_MOI1_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_MOI2_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_MOI3_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel2_MOI4_ComboBox.SelectedItem = null;

            MainMenu_AddAnInmate_Panel3_Crime_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel3_InCourtOf_ComboBox.SelectedItem = null;
            MainMenu_AddAnInmate_Panel3_CaseNumber_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel3_DateofConfinement_DateTimePicker.Value = System.DateTime.Now.Date;
            MainMenu_AddAnInmate_Panel3_LawyerName_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel3_LawyerHomeAddress_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel3_LawyerChamber_TextBox.Text = String.Empty;
            MainMenu_AddAnInmate_Panel3_LawyerPhoneNumber_TextBox.Text = String.Empty;

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Inmates", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Inmates_DataPanel.AutoGenerateColumns = false;
                MainMenu_Inmates_DataPanel.DataSource = sql_dt;
            }
        }
        
        //-------------------------------------------------------------------VISITOR'S RECORD-------------------------------------------------------------------//
        private void MainMenu_AddVisitor_Remove_Button_Click(object sender, EventArgs e)
        {
            if (MainMenu_AddVisitor_VisitorsName_TextBox.Text != "")
            {
                using (SqlConnection sql_con = new SqlConnection(connectionString))
                {
                    sql_con.Open();

                    SqlCommand sql_com = new SqlCommand("AddVisitor", sql_con);
                    sql_com.CommandText = "DELETE FROM Visitors WHERE VisitorName='" + MainMenu_AddVisitor_VisitorsName_TextBox.Text + "'";
                    sql_com.ExecuteNonQuery();

                    sql_con.Close();
                }
            }

            MessageBox.Show("Visitor Successfully Removed!");

            MainMenu_AddVisitor_VisitorsName_TextBox.Text = String.Empty;
            MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = null;

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Visitors", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Visitors_DataPanel.AutoGenerateColumns = false;
                MainMenu_Visitors_DataPanel.DataSource = sql_dt;
            }

            if (MainMenu_Visitors_DataPanel.RowCount == 0)
            {
                MainMenu_AddVisitor_Remove_Button.Enabled = false;
            }
        }

        private void MainMenu_AddVisitor_Add_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlCommand sql_com = new SqlCommand("AddVisitor", sql_con);
                sql_com.CommandType = CommandType.StoredProcedure;

                sql_com.Parameters.AddWithValue("@VisitorName", MainMenu_AddVisitor_VisitorsName_TextBox.Text);
                sql_com.Parameters.AddWithValue("@Visiting", MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@RelationToInmate", MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem);
                sql_com.Parameters.AddWithValue("@VisitorAddress", MainMenu_AddVisitor_VisitorsAddress_TextBox.Text);
                sql_com.Parameters.AddWithValue("@VisitorPhoneNo", MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Text);
                //sql_com.Parameters.AddWithValue("@Time_In", MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Text);
                //sql_com.Parameters.AddWithValue("@Time_Out", MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Text);
                
                sql_com.ExecuteNonQuery();
            }

            MessageBox.Show("Visitor's Record Successfully Uploaded!");

            MainMenu_AddVisitor_VisitorsName_TextBox.Clear();      //FIELDS CLEARING AFTER SUBMITTING RECORD
            MainMenu_AddVisitor_VisitorsAddress_TextBox.Clear();
            MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Clear();

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Visitors", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Visitors_DataPanel.AutoGenerateColumns = false;
                MainMenu_Visitors_DataPanel.DataSource = sql_dt;
            }
        }

        private void MainMenu_AddVisitor_Back_Button_Click(object sender, EventArgs e)
        {
            MainMenu_Inmates_DataPanel.Visible = true;      //PANELS
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddVisitor_Panel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = true;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            MainMenu_AddVisitor_VisitorsName_TextBox.Clear();      //VISITORS' FIELDS RESET ON CLICKING BACK BUTTON
            MainMenu_AddVisitor_VisitorsAddress_TextBox.Clear();
            MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = null;
            MainMenu_AddVisitor_VisitorPhoneNumber_TextBox.Clear();
        }

        private void MainMenu_AddVisitor_VisitorsName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddVisitor_VisitorPhoneNumber_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddVisitor_VisitingInmate_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddVisitor_RelationToInmate_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void MainMenu_AddAnInmate_VisitorsName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainMenu_AddVisitor_VisitorsName_TextBox.TextLength >= 1)
            {
                if (MainMenu_AddVisitor_VisitorsAddress_TextBox.TextLength >= 1)
                {
                    if (MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem != null)
                    {
                        if (MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem != null)
                        {
                            MainMenu_AddVisitor_Add_Button.Enabled = true;
                        }
                        else
                        {
                            MainMenu_AddVisitor_Add_Button.Enabled = false;
                        }
                    }
                    else
                    {
                        MainMenu_AddVisitor_Add_Button.Enabled = false;
                    }
                }
                else
                {
                    MainMenu_AddVisitor_Add_Button.Enabled = false;
                }
            }
            else
            {
                MainMenu_AddVisitor_Add_Button.Enabled = false;
            }
        }

        private void MainMenu_Visitors_DataPanel_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (MainMenu_Visitors_DataPanel.RowCount > 0)
            {
                MainMenu_AddVisitor_Remove_Button.Enabled = true;
            }
        }

        private void MainMenu_Visitors_DataPanel_DoubleClick(object sender, EventArgs e)
        {
            if (MainMenu_Visitors_DataPanel.CurrentRow.Index != -1)
            {
                MainMenu_AddVisitor_VisitorsName_TextBox.Text = MainMenu_Visitors_DataPanel.CurrentRow.Cells[1].Value.ToString();
                MainMenu_AddVisitor_Visiting_ComboBox.SelectedItem = MainMenu_Visitors_DataPanel.CurrentRow.Cells[2].Value.ToString();
                MainMenu_AddVisitor_RelationToInmate_ComboBox.SelectedItem = MainMenu_Visitors_DataPanel.CurrentRow.Cells[3].Value.ToString();
            }
        }

        //-------------------------------------------------------------------INMATE'S RECORD-------------------------------------------------------------------//
        private void MainMenu_InmatesInfo_ViewProfile_Button_Click(object sender, EventArgs e)
        {
            MainMenu_AccountType_Title_Label.Visible = false;
            MainMenu_Username_Title_Label.Visible = false;
            MainMenu_Logos_PictureBox.Visible = false;
            
            MainMenu_InmatesInfo_Button.Visible = false;
            MainMenu_AddAnInmate_Button.Visible = false;
            MainMenu_AddVisitor_Button.Visible = false;
            MainMenu_SignOut_Button.Visible = false;
            
            MainMenu_Inmates_DataPanel.Visible = false;
            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;
            
            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;

            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            SignIn_Footer_Panel.Visible = false;
            SignIn_Footer_MiniPanel.Visible = false;
            SignIn_Footer_Association_Label.Visible = false;
            SignIn_Footer_Copyright_Label.Visible = false;
            SignIn_Footer_CSharp_Label.Visible = false;
            SignIn_Footer_PG_Label.Visible = false;
            SignIn_Footer_PP_Label.Visible = false;
            SignIn_Footer_ProjectBy_Label.Visible = false;
            SignIn_Footer_SystemMadeIn_Label.Visible = false;
            SignIn_Footer_WindowsForms_Label.Visible = false;

            MainMenu_InmatesInfo_Profile_Panel.Visible = true;

            label2.Enabled = false;
            label4.Enabled = false;
            label6.Enabled = false;
            label8.Enabled = false;
            label10.Enabled = false;
            label12.Enabled = false;
            label14.Enabled = false;
            label16.Enabled = false;
            label18.Enabled = false;
            label20.Enabled = false;
            label22.Enabled = false;
            label24.Enabled = false;
            label26.Enabled = false;
            label28.Enabled = false;
            label30.Enabled = false;
            label32.Enabled = false;
            label34.Enabled = false;
            label36.Enabled = false;
            label38.Enabled = false;
            label40.Enabled = false;
            label42.Enabled = false;
            label44.Enabled = false;
            label46.Enabled = false;
            label48.Enabled = false;
            label50.Enabled = false;
            label52.Enabled = false;
            label54.Enabled = false;
            label56.Enabled = false;
            label58.Enabled = false;

            prisonername_textbox.Enabled = false;
            fathername_textbox.Enabled = false;
            mothername_textbox.Enabled = false;
            gender_combobox.Enabled = false;
            dob_textbox.Enabled = false;
            civilstatus_combobox.Enabled = false;
            spousename_textbox.Enabled = false;
            city_combobox.Enabled = false;
            cnic_textbox.Enabled = false;
            bloodtype_combobox.Enabled = false;
            haircolor_combobox.Enabled = false;
            eyecolor_combobox.Enabled = false;
            complexion_combobox.Enabled = false;
            built_combobox.Enabled = false;
            height_textbox.Enabled = false;
            weight_textbox.Enabled = false;
            moi1_combobox.Enabled = false;
            moi2_combobox.Enabled = false;
            moi3_combobox.Enabled = false;
            moi4_combobox.Enabled = false; 
            crime_combobox.Enabled = false;
            incourtof_combobox.Enabled = false;
            caseno_textbox.Enabled = false;
            doc_textbox.Enabled = false;
            religion_combobox.Enabled = false;
            lawyername_textbox.Enabled = false;
            lawyeraddress_textbox.Enabled = false;
            lawyerchamber_textbox.Enabled = false;
            lawyerphoneno_textbox.Enabled = false;
        }

        private void MainMenu_Inmates_DataPanel_Click(object sender, EventArgs e)
        {
            if (MainMenu_Inmates_DataPanel.CurrentRow.Index != -1)
            {
                MainMenu_InmatesInfo_ViewProfile_Button.Enabled = true;

                MainMenu_InmateProfile_Back_Button.Visible = true;
                MainMenu_InmateProfile_EditRecord_Button.Visible = true;
                MainMenu_InmateProfile_SaveEditting_Button.Visible = false;

                prisonername_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[2].Value.ToString();
                fathername_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[3].Value.ToString();
                mothername_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[4].Value.ToString();
                gender_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[5].Value.ToString();
                dob_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[6].Value.ToString();
                civilstatus_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[7].Value.ToString();
                spousename_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[8].Value.ToString();
                city_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[9].Value.ToString();
                cnic_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[10].Value.ToString();
                bloodtype_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[11].Value.ToString();
                haircolor_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[12].Value.ToString();
                eyecolor_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[13].Value.ToString();
                complexion_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[14].Value.ToString();
                religion_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[15].Value.ToString();
                height_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[16].Value.ToString();
                weight_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[17].Value.ToString();
                moi1_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[18].Value.ToString();
                moi2_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[19].Value.ToString();
                moi3_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[20].Value.ToString();
                moi4_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[21].Value.ToString();
                built_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[22].Value.ToString();
                crime_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[23].Value.ToString();
                incourtof_combobox.SelectedItem = MainMenu_Inmates_DataPanel.CurrentRow.Cells[24].Value.ToString();
                caseno_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[25].Value.ToString();
                doc_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[26].Value.ToString();
                lawyername_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[27].Value.ToString();
                lawyeraddress_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[28].Value.ToString();
                lawyerchamber_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[29].Value.ToString();
                lawyerphoneno_textbox.Text = MainMenu_Inmates_DataPanel.CurrentRow.Cells[30].Value.ToString();
            }
        }

        private void MainMenu_InmateProfile_Back_Button_Click(object sender, EventArgs e)
        {
            MainMenu_AccountType_Title_Label.Visible = true;
            MainMenu_Username_Title_Label.Visible = true;
            MainMenu_Logos_PictureBox.Visible = true;

            MainMenu_InmatesInfo_Button.Visible = true;
            MainMenu_AddAnInmate_Button.Visible = true;
            MainMenu_AddVisitor_Button.Visible = true;
            MainMenu_SignOut_Button.Visible = true;

            MainMenu_Inmates_DataPanel.Visible = true;
            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;

            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;

            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            SignIn_Footer_Panel.Visible = true;
            SignIn_Footer_MiniPanel.Visible = true;
            SignIn_Footer_Association_Label.Visible = true;
            SignIn_Footer_Copyright_Label.Visible = true;
            SignIn_Footer_CSharp_Label.Visible = true;
            SignIn_Footer_PG_Label.Visible = true;
            SignIn_Footer_PP_Label.Visible = true;
            SignIn_Footer_ProjectBy_Label.Visible = true;
            SignIn_Footer_SystemMadeIn_Label.Visible = true;
            SignIn_Footer_WindowsForms_Label.Visible = true;

            MainMenu_InmatesInfo_Profile_Panel.Visible = false;
        }

        private void MainMenu_InmatesInfo_Profile_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_InmateProfile_EditRecord_Button_Click(object sender, EventArgs e)
        {
            label2.Enabled = true;
            label4.Enabled = true;
            label6.Enabled = true;
            label8.Enabled = true;
            label10.Enabled = true;
            label12.Enabled = true;
            label14.Enabled = true;
            label16.Enabled = true;
            label18.Enabled = true;
            label20.Enabled = true;
            label22.Enabled = true;
            label24.Enabled = true;
            label26.Enabled = true;
            label28.Enabled = true;
            label30.Enabled = true;
            label32.Enabled = true;
            label34.Enabled = true;
            label36.Enabled = true;
            label38.Enabled = true;
            label40.Enabled = true;
            label42.Enabled = true;
            label44.Enabled = true;
            label46.Enabled = true;
            label48.Enabled = true;
            label50.Enabled = true;
            label52.Enabled = true;
            label54.Enabled = true;
            label56.Enabled = true;
            label58.Enabled = true;

            prisonername_textbox.Enabled = true;
            fathername_textbox.Enabled = true;
            mothername_textbox.Enabled = true;
            gender_combobox.Enabled = true;
            dob_textbox.Enabled = true;
            civilstatus_combobox.Enabled = true;
            spousename_textbox.Enabled = true;
            city_combobox.Enabled = true;
            cnic_textbox.Enabled = true;
            bloodtype_combobox.Enabled = true;
            haircolor_combobox.Enabled = true;
            eyecolor_combobox.Enabled = true;
            complexion_combobox.Enabled = true;
            built_combobox.Enabled = true;
            height_textbox.Enabled = true;
            weight_textbox.Enabled = true;
            moi1_combobox.Enabled = true;
            moi2_combobox.Enabled = true;
            moi3_combobox.Enabled = true;
            moi4_combobox.Enabled = true;
            crime_combobox.Enabled = true;
            incourtof_combobox.Enabled = true;
            caseno_textbox.Enabled = true;
            doc_textbox.Enabled = true;
            religion_combobox.Enabled = true;
            lawyername_textbox.Enabled = true;
            lawyeraddress_textbox.Enabled = true;
            lawyerchamber_textbox.Enabled = true;
            lawyerphoneno_textbox.Enabled = true;

            MainMenu_InmateProfile_EditRecord_Button.Visible = false;
            MainMenu_InmateProfile_SaveEditting_Button.Visible = true;
        }

        private void MainMenu_InmateProfile_SaveEditting_Button_Click(object sender, EventArgs e)
        {
            if (prisonername_textbox.Text != "")
            {
                using (SqlConnection sql_con = new SqlConnection(connectionString))
                {
                    sql_con.Open();

                    SqlCommand sql_com = new SqlCommand("AddInmate", sql_con);
                    //sql_com.CommandText = "UPDATE Inmates WHERE VisitorName='" + MainMenu_AddVisitor_VisitorsName_TextBox.Text + "'";

                    sql_com.CommandText = "UPDATE Inmates SET PrisonerName='" + prisonername_textbox.Text + "', FatherName='" + fathername_textbox.Text + "', MotherName='" + mothername_textbox.Text + "', Gender='" + gender_combobox.SelectedItem + "', DOB='" + dob_textbox.Text + "', CivilStatus='" + civilstatus_combobox.SelectedItem + "', SpouseName='" + spousename_textbox.Text + "', City='" + city_combobox.SelectedItem + "', CNIC='" + cnic_textbox.Text + "', BloodType='" + bloodtype_combobox.SelectedItem + "', HairColor='" + haircolor_combobox.SelectedItem + "', EyeColor='" + eyecolor_combobox.SelectedItem + "', Complexion='" + complexion_combobox.SelectedItem + "', Religion='" + religion_combobox.SelectedItem + "', Height='" + height_textbox.Text + "', Weight='" + weight_textbox.Text + "', Built='" + built_combobox.SelectedItem + "', Crime='" + crime_combobox.SelectedItem + "', InCourtof='" + incourtof_combobox.SelectedItem + "', CaseNo='" + caseno_textbox.Text + "', DateofConfinement='" + doc_textbox.Text + "', AssignedLawyerName='" + lawyername_textbox.Text + "', LawyerAddress='" + lawyeraddress_textbox.Text + "', LawyerChamber='" + lawyerchamber_textbox.Text + "', LawyerPhoneNo='" + lawyerphoneno_textbox.Text + "'";

                    sql_com.ExecuteNonQuery();

                    sql_con.Close();
                }
            }

            MessageBox.Show("Record Updated Successfully!");

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Inmates", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Inmates_DataPanel.AutoGenerateColumns = false;
                MainMenu_Inmates_DataPanel.DataSource = sql_dt;
            }

            MainMenu_AccountType_Title_Label.Visible = true;
            MainMenu_Username_Title_Label.Visible = true;
            MainMenu_Logos_PictureBox.Visible = true;

            MainMenu_InmatesInfo_Button.Visible = true;
            MainMenu_AddAnInmate_Button.Visible = true;
            MainMenu_AddVisitor_Button.Visible = true;
            MainMenu_SignOut_Button.Visible = true;

            MainMenu_Inmates_DataPanel.Visible = true;
            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;

            MainMenu_AddAnInmate_Panel1.Visible = false;
            MainMenu_AddAnInmate_Panel2.Visible = false;
            MainMenu_AddAnInmate_Panel3.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel1.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel2.Visible = false;
            MainMenu_AddAnInmate_Buttons_Panel3.Visible = false;

            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_AddVisitor_Button_Panel.Visible = false;

            SignIn_Footer_Panel.Visible = true;
            SignIn_Footer_MiniPanel.Visible = true;
            SignIn_Footer_Association_Label.Visible = true;
            SignIn_Footer_Copyright_Label.Visible = true;
            SignIn_Footer_CSharp_Label.Visible = true;
            SignIn_Footer_PG_Label.Visible = true;
            SignIn_Footer_PP_Label.Visible = true;
            SignIn_Footer_ProjectBy_Label.Visible = true;
            SignIn_Footer_SystemMadeIn_Label.Visible = true;
            SignIn_Footer_WindowsForms_Label.Visible = true;

            MainMenu_InmatesInfo_Profile_Panel.Visible = false;
        }
    }
}