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
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button5.Enabled = true;
            button3.Enabled = true;
            buttonReservas = true;
            buttonQuartos = false;
            buttonGuests = false;
            buttonReservors = false;
            groupBox3.Visible = false;
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
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button5.Enabled = true;
            button3.Enabled = true;
            buttonReservas = true;
            buttonQuartos = false;
            buttonGuests = false;
            buttonReservors = false;
            groupBox3.Visible = false;
            ShowReservas(); 
        }

        private void ShowReservas() {
            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT firstname, lastname, Reservation.reservation_ID, email, Reserved_Room.reserved_room_id, date_in, date_out, check_in, check_out FROM Person inner join (Reservor inner join (Reservation inner join Reserved_Room on Reservation.reservation_ID = Reserved_Room.reservation_ID) on reservor = reservor_id) on Person.CC = Reservor.CC", cn);
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
            groupBox3.Visible = true; 


            using (cn)
            {
                cn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Room join Room_Type on Room.room_type_id=Room_Type.room_type_id", cn);
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
            groupBox3.Visible = false;

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
            groupBox3.Visible = false;
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
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            using (cn)
            {
                cn.Open();
                if (buttonQuartos == true)
                {
                    EditarQuarto();
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
            }
        }

        private void EditarQuarto()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC editar_preço_quarto @tipoquartoID,  @novopreco";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tipoquartoID", textBox8.Text);
            cmd.Parameters.AddWithValue("@novopreco", float.Parse(textBox7.Text));
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
    }
}
