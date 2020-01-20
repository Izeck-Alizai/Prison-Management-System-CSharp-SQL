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
    public partial class PrisonGuard_MainMenu : Form
    {
        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\EyeZek Alixai\Desktop\PMS_Project\PrisonManagementSystem\PrisonManagementSystem\My_Database.mdf;Integrated Security=True";

        public PrisonGuard_MainMenu()
        {
            InitializeComponent();

            using (SqlConnection sql_con = new SqlConnection(connectionString))
            {
                sql_con.Open();

                SqlDataAdapter sql_da = new SqlDataAdapter("SELECT * FROM Visitors", sql_con);

                DataTable sql_dt = new DataTable();

                sql_da.Fill(sql_dt);

                MainMenu_Visitors_DataPanel.AutoGenerateColumns = false;
                MainMenu_Visitors_DataPanel.DataSource = sql_dt;
            }

            MainMenu_TimeOut_Button.Visible = false;

            MainMenu_TimeIn_Button.Visible = false;

            MainMenu_Visitors_DataPanel.Visible = true;
        }

        private void MainMenu_SignOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            SignIn SignIn_On_Back_Button = new SignIn();

            SignIn_On_Back_Button.Show();
        }

        private void MainMenu_CheckVisitor_Button_Click(object sender, EventArgs e)
        {
            MainMenu_TimeOut_Button.Visible = true;

            MainMenu_TimeIn_Button.Visible = true;

            MainMenu_Visitors_DataPanel.Visible = true;

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

        private void MainMenu_VisitorsInfo_Button_Click(object sender, EventArgs e)
        {
            MainMenu_TimeOut_Button.Visible = false;

            MainMenu_TimeIn_Button.Visible = false;

            MainMenu_Visitors_DataPanel.Visible = true;

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

        private void PrisonGuard_MainMenu_Load(object sender, EventArgs e)
        {
            MainMenu_Username_Title_Label.Text = SignIn.loginname;
        }
    }
}
