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
            return new SqlConnection("Data Source=LAPTOP-8K6S8357;Initial Catalog=Hotel;Integrated Security=True");
        }
       

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, System.EventArgs e) // Reserva
        {
            cn = getSGBDConnection();
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            button5.Enabled = false;
            button3.Enabled = true;
            buttonReservas = true;
            buttonQuartos = false;
            buttonGuests = false;
            buttonReservors = false;
            ShowReservas(); 
        }

        private void ShowReservas() {
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reservation", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl;
            }
        }

        private void RemoveReservors() // remover um reservor
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "EXEC eliminar_Reservor @CC, @reservorID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", textBox2.Text);
            cmd.Parameters.AddWithValue("@reservorID", textBox1.Text);
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

        private void EditarReserva()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC editar_reserva @reservaID, @date_in, @date_out";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@reservaID", textBox3.Text);
            cmd.Parameters.AddWithValue("@date_in", DateTime.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@date_out", DateTime.Parse(textBox5.Text));
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

        private void button2_Click(object sender, System.EventArgs e) // Reserved room
        {
            cn = getSGBDConnection();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            button5.Enabled = false;
            button3.Enabled = false;
            buttonReservas = false;
            buttonQuartos = true;
            buttonGuests = false;
            buttonReservors = false;
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Reserved_Room", cn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridReservation.DataSource = dtbl;

            }
        }

        private void button6_Click(object sender, System.EventArgs e) // Guests
        {
            cn = getSGBDConnection();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            button5.Enabled = false;
            button3.Enabled = false;
            buttonReservas = false;
            buttonQuartos = false;
            buttonGuests = true;
            buttonReservors = false;
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

        private void button9_Click(object sender, System.EventArgs e) // Reservor
        {
            cn = getSGBDConnection();
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            button5.Enabled = true;
            button3.Enabled = false;
            buttonReservas = false;
            buttonQuartos = false;
            buttonGuests = false;
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

        private void button5_Click(object sender, EventArgs e) // Botão eliminar
        {
            cn = getSGBDConnection();
            using (cn)
            {
                cn.Open();
                if (buttonQuartos == true)
                {
                    buttonQuartos = false;
                }
                else if (buttonGuests == true)
                {
                    buttonGuests = false;
                }
                else if (buttonReservas == true)
                {
                    buttonReservas = false;
                }
                else if (buttonReservors == true)
                {
                    RemoveReservors();
                    buttonReservors = false;
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            using (cn)
            {
                cn.Open();
                if (buttonQuartos == true)
                {
                    buttonQuartos = false;
                }
                else if (buttonGuests == true)
                {
                    buttonGuests = false;
                }
                else if (buttonReservas == true)
                {
                    EditarReserva();
                    buttonReservas = false;
                }
                else if (buttonReservors == true)
                {
                    buttonReservors = false;
                }
            }
        }
    }
}
