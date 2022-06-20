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

namespace HotelUI
{
    public partial class PopUp : Form
    {
        private SqlConnection cn; 
        public PopUp()
        {
            InitializeComponent();
        }
        /*
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = LAPTOP-8K6S8357; Initial Catalog = Hotel; Integrated Security = True");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }


        private void CriarPessoa_Guest()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Person(firstname, lastname, CC, gender, age, cellphone) VALUES (@firstname, @lastname, @CC, @gender, @age, @cellphone);";
            cmd.Parameters.AddWithValue("@firstname", textFN.Text);
            cmd.Parameters.AddWithValue("@lastname", textLN.Text);
            cmd.Parameters.AddWithValue("@CC", textCC.Text);
            cmd.Parameters.AddWithValue("@gender", textS.Text);
            cmd.Parameters.AddWithValue("@age", textA.Text);
            cmd.Parameters.AddWithValue("@cellphone", textCell.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a Pessoa. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void GerarGuest()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Guest.guest_id FROM Guest ORDER BY Guest.guest_id DESC;", cn);

            Int32 GuestID = (Int32)cmdd.ExecuteScalar() + 1;

            cmd.CommandText = "INSERT INTO Guest(guest_id, CC, review, reserved_room_id) VALUES (@guest_id, @CC, @review, @reserved_room_id);";
            cmd.Parameters.AddWithValue("@guest_id", GuestID.ToString());
            cmd.Parameters.AddWithValue("@CC", textCC.Text);
            cmd.Parameters.AddWithValue("@review", textP.Text);
            cmd.Parameters.AddWithValue("@reserved_room_id", null);
            cmd.Connection = cn;

            Guest g = new Guest(GuestID.ToString, textCC.Text, textP.Text, null); 

            ChildRoom.receiveData(g);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Gerar Guest. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CriarPessoa_Guest();
            GerarGuest();
        }*/
    }
}
