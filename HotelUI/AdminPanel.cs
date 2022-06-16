﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelUI
{
    public partial class AdminPanel : Form
    {
        private SqlConnection cn;
        public AdminPanel()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=LAPTOP-8K6S8357; Initial Catalog = Hotel; Integrated Security = True");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();

            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reservation", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                //method 2 : DG Columns
                dataGridReservation.AutoGenerateColumns = false;
                dataGridReservation.DataSource = dtbl;

            }
        }
    }
}
