using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HotelUI
{
    public partial class AdminPanel : Form
    {
        private bool buttonReservas = false;
        private bool buttonQuartos = false;
        private bool buttonGuests = false;
        private bool buttonReservors = false;

        private SqlConnection cn;
        public AdminPanel()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-CIMKDJM; Initial Catalog = Hotel; Integrated Security = True");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();
            buttonReservas = true;
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reservation", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl; 

            }
        }

        private void RemoveReservation()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC eliminar_Resorvors @CC";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", textBox1.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a eliminar o Reservor. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();
            buttonQuartos = true;
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reserved_Room", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl;

            }
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();
            buttonGuests = true;
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM (Guest inner join Person on Guest.CC=Person.CC)", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl;

            }
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            MainPage f = new MainPage();
            f.Show();
            this.Hide(); 
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            ChildRoom CR = new ChildRoom();
            CR.Show();
            this.Hide();
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();
            groupBox1.Visible = true;
            buttonReservors = true;
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reservor", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) // Para eliminar
        {
            if (buttonQuartos == true)
            {
                //RemoveQuatos();
                buttonQuartos = false;
            }
            else if (buttonGuests == true)
            {
                //RemoveGuests();
                buttonGuests = false;
            }
            else if (buttonReservas == true)
            {
                //RemoveReservation();
                buttonReservas = false;
            }
            else if (buttonReservors == true)
            {
                //RemoveReservors();
                buttonReservors = false;
            }
        }
    }
}
