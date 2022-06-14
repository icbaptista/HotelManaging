using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace HotelUI
{
    public partial class AdminLogin : Form
    {
        private SqlConnection cn;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            form.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.Show();
            this.Hide(); 
        }
        private void AdminPanel_Load()
        {
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=CCWIN8\\SQL2012EXPRESS;integrated security=true;initial catalog=Hotel");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (listBox1.SelectedIndex > 0)
             {
                if (!verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Reservation", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox1.Items.Clear();

                while (reader.Read())
                {
                    Reservation C = new Reservation();
                    C = reader["reservation_ID"].ToString();
                    listBox1.Items.Add(C);
                }

                cn.Close();
            }
        }

    }
}
