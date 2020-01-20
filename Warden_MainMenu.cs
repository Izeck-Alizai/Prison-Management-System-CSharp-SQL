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
    public partial class Warden_MainMenu : Form
    {
        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True";

        public Warden_MainMenu()
        {
            InitializeComponent();

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
            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_SystemUsers_DataPanel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_ViewProfile_Button.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_Update_Button.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = false;
            MainMenu_SystemUsers_Buttons_Panel.Visible = false;
        }

        private void MainMenu_Warden_InmatesInfo_Button_Click(object sender, EventArgs e)
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
            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_SystemUsers_DataPanel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_ViewProfile_Button.Visible = true;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_Update_Button.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = false;
            MainMenu_SystemUsers_Buttons_Panel.Visible = false;
        }

        private void MainMenu_SignOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignIn SignIn_On_Back_Button = new SignIn();

            SignIn_On_Back_Button.Show();
        }

        private void MainMenu_VisitorsInfo_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Visitors", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Visitors_DataPanel.AutoGenerateColumns = false;
                MainMenu_Visitors_DataPanel.DataSource = sql_dt;
            }

            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_Visitors_DataPanel.Visible = true;
            MainMenu_SystemUsers_DataPanel.Visible = false;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_ViewProfile_Button.Visible = false;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_Update_Button.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = true;
            MainMenu_SystemUsers_Buttons_Panel.Visible = false;
        }

        private void MainMenu_SystemUsers_Button_Click(object sender, EventArgs e)
        {
            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM SignUp", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_SystemUsers_DataPanel.AutoGenerateColumns = false;
                MainMenu_SystemUsers_DataPanel.DataSource = sql_dt;
            }

            MainMenu_Inmates_DataPanel.Visible = false;      //PANELS
            MainMenu_Visitors_DataPanel.Visible = false;
            MainMenu_SystemUsers_DataPanel.Visible = true;
            MainMenu_InmatesInfo_Profile_Panel.Visible = false;

            MainMenu_InmatesInfo_ViewProfile_Button.Visible = false;     //BUTTONS
            MainMenu_InmatesInfo_ViewProfile_Button.Enabled = false;
            MainMenu_Update_Button.Visible = true;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = false;
            MainMenu_SystemUsers_Buttons_Panel.Visible = true;
        }

        private void Warden_MainMenu_Load(object sender, EventArgs e)
        {
            MainMenu_Username_Title_Label.Text = SignIn.loginname;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (MainMenu_Inmates_DataPanel.CurrentRow.Index != -1)
            {
                MainMenu_InmatesInfo_ViewProfile_Button.Enabled = true;
            }
        }

        private void MainMenu_InmateProfile_Back_Button_Click(object sender, EventArgs e)
        {
            MainMenu_AccountType_Title_Label.Visible = true;
            MainMenu_Username_Title_Label.Visible = true;
            MainMenu_Logos_PictureBox.Visible = true;

            MainMenu_InmatesInfo_Button.Visible = true;
            MainMenu_VisitorsInfo_Button.Visible = true;
            MainMenu_SystemUsers_Button.Visible = true;
            MainMenu_SignOut_Button.Visible = true;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = false;
            MainMenu_SystemUsers_Buttons_Panel.Visible = false;

            MainMenu_Inmates_DataPanel.Visible = true;
            MainMenu_Visitors_DataPanel.Visible = false;

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

        private void MainMenu_InmateProfile_Delete_Button_Click(object sender, EventArgs e)
        {
            if (prisonername_textbox.Text != "")
            {
                using (SqlConnection sql_con = new SqlConnection(connectionString))
                {
                    sql_con.Open();

                    SqlCommand sql_com = new SqlCommand("AddInmate", sql_con);
                    sql_com.CommandText = "DELETE FROM Inmates WHERE PrisonerName='" + prisonername_textbox.Text + "'";
                    sql_com.ExecuteNonQuery();

                    sql_con.Close();
                }
            }

            MessageBox.Show("Prisoner Successfully Removed!");

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
            MainMenu_VisitorsInfo_Button.Visible = true;
            MainMenu_SystemUsers_Button.Visible = true;
            MainMenu_SignOut_Button.Visible = true;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = true;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = true;
            MainMenu_SystemUsers_Buttons_Panel.Visible = true;

            MainMenu_Inmates_DataPanel.Visible = true;
            MainMenu_Visitors_DataPanel.Visible = true;

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

        private void MainMenu_Inmates_DataPanel_Click(object sender, EventArgs e)
        {
            if (MainMenu_Inmates_DataPanel.CurrentRow.Index != -1)
            {
                MainMenu_InmatesInfo_ViewProfile_Button.Enabled = true;

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

        private void MainMenu_InmatesInfo_ViewProfile_Button_Click(object sender, EventArgs e)
        {
            MainMenu_AccountType_Title_Label.Visible = false;
            MainMenu_Username_Title_Label.Visible = false;
            MainMenu_Logos_PictureBox.Visible = false;

            MainMenu_InmatesInfo_Button.Visible = false;
            MainMenu_VisitorsInfo_Button.Visible = false;
            MainMenu_SystemUsers_Button.Visible = false;
            MainMenu_SignOut_Button.Visible = false;

            MainMenu_InmatesInfo_Buttons_Panel.Visible = false;
            MainMenu_VisitorsInfo_Buttons_Panel.Visible = false;
            MainMenu_SystemUsers_Buttons_Panel.Visible = false;

            MainMenu_Inmates_DataPanel.Visible = false;
            MainMenu_Visitors_DataPanel.Visible = false;

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
    }
}