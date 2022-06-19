using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HotelUI
{
    public partial class ChildRoom : Form
    {
        private int currentRoomType;
        private int currentRoom;
        private int count_Button_Add_Guest = 0;
        private SqlConnection cn;
        public string numeroHotel { get; set; }

        public ChildRoom()
        {
            InitializeComponent();
            loadRoomTypes();
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

        public void ControlosReserva() // Meter tudo só readOnly
        {
            listBox1.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            textBox12.Enabled = false;
        }

        public void ControlosGuest() // Meter tudo só readOnly
        {
            button2.Visible = true;
            button3.Visible = true;
            groupBox4.Visible = true;
            groupBox5.Visible = true;
        }

        private void loadRoomTypes()
        { 

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("Select * from Room_Type", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Room_Type A = new Room_Type();
                A.room_type_id = reader["room_type_id"].ToString();
                A.typology = reader["typology"].ToString();
                A.max_capacity = reader["max_capacity"].ToString();
                A.beds_no = reader["beds_no"].ToString();
                A.size = reader["size"].ToString();
                A.vista = reader["vista"].ToString();
                A.room_price = reader["room_price"].ToString();
                listBox1.Items.Add(A);
            }
            cn.Close();

            currentRoomType = 0;
        }

        private void loadRoomPackages()
        {

            if (!verifySGBDConnection())
                return;

            //SqlCommand cmd = new SqlCommand("Package_Consuante_RoomType", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@roomTypeID", str));
            SqlCommand cmd = new SqlCommand("Select *  From (Room_Type INNER JOIN Package ON Room_Type.room_type_id = Package.room_type_id) WHERE Room_Type.room_type_id = @roomTypeID", cn);
            cmd.Parameters.AddWithValue("@roomTypeID", ((Room_Type) listBox1.Items[currentRoomType]).room_type_id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                textBox3.Text = reader["free_breakfast"].ToString();
                textBox2.Text = reader["meals_included"].ToString();
                textBox5.Text = reader["package_ID"].ToString();
                textBox6.Text = reader["package_price"].ToString();

            }
            cn.Close();
        }

        private void calculoNoitesEprecoTotal()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("Select * FROM (Room_Type INNER JOIN Package ON Room_Type.room_type_id = Package.room_type_id) FULL JOIN Reservation ON Package.package_ID = Reservation.package_ID WHERE (Room_Type.room_type_id = @RoomType) AND (Package.package_ID = @PackageID) ORDER BY Room_Type.room_price, Package.package_price;", cn);
            cmd.Parameters.AddWithValue("@RoomType", ((Room_Type) listBox1.Items[currentRoomType]).room_type_id);
            cmd.Parameters.AddWithValue("@PackageID", textBox5.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                DateTime UltimaData = dateTimePicker1.Value;
                DateTime PrimeiraData = dateTimePicker2.Value;

                TimeSpan DiffData = UltimaData - PrimeiraData;
                int differenceInDays = DiffData.Days + 1;
                string differenceInDays_string = differenceInDays.ToString();

                textBox4.Text = differenceInDays_string;
                float preco_total = float.Parse(textBox6.Text) + (float.Parse(textBox12.Text) * differenceInDays);
                string preco_total_string = preco_total.ToString();

                txtPrice.Text = preco_total_string;

            }
            cn.Close();

        }

        private void QuartosDisponíveis()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("Select * FROM ((Room FULL JOIN Room_Type ON Room.room_type_id = Room_Type.room_type_id) FULL JOIN Package ON Room_Type.room_type_id = Package.room_type_id) FULL JOIN Reserved_Room ON Room.room_id = Reserved_Room.reserved_room_id WHERE (Reserved_Room.reservation_ID IS NULL) AND (@RoomType = Room_Type.room_type_id) AND (@PackageID = Package.package_ID);", cn);
            cmd.Parameters.AddWithValue("@RoomType", ((Room_Type)listBox1.Items[currentRoomType]).room_type_id);
            cmd.Parameters.AddWithValue("@PackageID", textBox5.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox5.Items.Clear();

            while (reader.Read())
            {
                Room R = new Room();
                R.nRNET = reader["nRNET"].ToString();
                R.room_id = reader["room_id"].ToString();
                R.room_no = reader["room_no"].ToString();
                R.room_type_id = reader["room_type_id"].ToString();
                listBox5.Items.Add(R);
            }
            cn.Close();

            currentRoom = 0;
        }

        private void CriarPessoa()// Isto vai ter de estar num botão para finalizar a reserva
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Person(firstname, lastname, CC, gender, age, cellphone) VALUES (@firstname, @lastname, @CC, @gender, @age, @cellphone);";
            cmd.Parameters.AddWithValue("@firstname", textBox7.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox8.Text);
            cmd.Parameters.AddWithValue("@CC", textBox9.Text);
            cmd.Parameters.AddWithValue("@gender", textBox13.Text);
            cmd.Parameters.AddWithValue("@age", textBox10.Text);
            cmd.Parameters.AddWithValue("@cellphone", textBox11.Text);
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

        private void CriarResorvor()// Isto vai ter de estar num botão para finalizar a reserva
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Reservor.reservor_id FROM Reservor ORDER BY Reservor.reservor_id DESC;", cn);

            cmd.CommandText = "INSERT INTO Reservor(reservor_id, CC, email) VALUES (@reservor_id, @CC, @email);";

            //https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=dotnet-plat-ext-6.0
            Int32 Reservor_ID = (Int32)cmdd.ExecuteScalar() + 1;

            cmd.Parameters.AddWithValue("@reservor_id", Reservor_ID); // Talvez tenha de passar para string (?)
            cmd.Parameters.AddWithValue("@CC", textBox9.Text);
            cmd.Parameters.AddWithValue("@email", textBox1.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o Reservor. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void GerarUmaBill()// Isto vai ter de estar num botão para finalizar a reserva
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Bill.Bill_ID FROM Bill ORDER BY Bill.Bill_ID DESC;", cn);

            Int32 BillID = (Int32)cmdd.ExecuteScalar() + 1;

            cmd.CommandText = "INSERT INTO Bill(Bill_ID, paydate, totalCoast) VALUES (@Bill_ID, @paydate, @totalCoast);";
            cmd.Parameters.AddWithValue("@Bill_ID", BillID);
            cmd.Parameters.AddWithValue("@paydate", DateTime.Today);
            cmd.Parameters.AddWithValue("@totalCoast", txtPrice.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar a Bill. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void GerarReserva()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Reservation.reservation_ID FROM Reservation ORDER BY Reservation.reservation_ID DESC;", cn);
            SqlCommand cmddd = new SqlCommand("SELECT TOP 1 Bill.Bill_ID FROM Bill ORDER BY Bill.Bill_ID DESC;", cn);
            SqlCommand cmdddd = new SqlCommand("SELECT TOP 1 Reservor.reservor_id FROM Reservor ORDER BY Reservor.reservor_id DESC;", cn);

            Int32 BillID = (Int32)cmddd.ExecuteScalar();
            Int32 Reservor_ID = (Int32)cmdddd.ExecuteScalar();
            Int32 ReservationID = (Int32)cmdd.ExecuteScalar() + 1;
            
            cmd.CommandText = "INSERT INTO Reservation(reservation_ID, package_ID, date_of_reservation, guest_num, reservor, bill_ID, date_in, date_out) VALUES (@reservation_ID, @package_ID, @date_of_reservation, @guest_num, @reservor, @bill_ID, @date_in, @date_out);";
            cmd.Parameters.AddWithValue("@reservation_ID", ReservationID);
            cmd.Parameters.AddWithValue("@package_ID", textBox5.Text);
            cmd.Parameters.AddWithValue("@date_of_reservation", DateTime.Today);
            cmd.Parameters.AddWithValue("@guest_num", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@reservor", Reservor_ID);
            cmd.Parameters.AddWithValue("@bill_ID", BillID);
            cmd.Parameters.AddWithValue("@date_in", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@date_out", dateTimePicker1.Value);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a reserva. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void GerarReservedRoom()
        {
            if (!verifySGBDConnection())
                return;

            Room Room = new Room();
            Room = (Room)listBox5.Items[currentRoom];

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Reservation.reservation_ID FROM Reservation ORDER BY Reservation.reservation_ID DESC;", cn);

            Int32 ReservationID = (Int32)cmdd.ExecuteScalar();

            cmd.CommandText = "INSERT INTO Reserved_Room(reserved_room_id, check_in, check_out, reservation_ID) VALUES (@reserved_room_id, @check_in, @check_out, @reservation_ID);";
            cmd.Parameters.AddWithValue("@reserved_room_id", Room.room_id);
            cmd.Parameters.AddWithValue("@check_in", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@check_out", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@reservation_ID", ReservationID);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar reserved room. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void CriarPessoa_Guest()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Person(firstname, lastname, CC, gender, age, cellphone) VALUES (@firstname, @lastname, @CC, @gender, @age, @cellphone);";
            cmd.Parameters.AddWithValue("@firstname", textBox14.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox15.Text);
            cmd.Parameters.AddWithValue("@CC", textBox16.Text);
            cmd.Parameters.AddWithValue("@gender", textBox17.Text);
            cmd.Parameters.AddWithValue("@age", textBox19.Text);
            cmd.Parameters.AddWithValue("@cellphone", textBox18.Text);
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

            Room Room = new Room();
            Room = (Room)listBox5.Items[currentRoom];

            Int32 GuestID = (Int32)cmdd.ExecuteScalar() + 1;

            cmd.CommandText = "INSERT INTO Guest(guest_id, CC, review, reserved_room_id) VALUES (@guest_id, @CC, @review, @reserved_room_id);";
            cmd.Parameters.AddWithValue("@guest_id", GuestID);
            cmd.Parameters.AddWithValue("@CC", textBox16.Text);
            cmd.Parameters.AddWithValue("@review", textBox20.Text);
            cmd.Parameters.AddWithValue("@reserved_room_id", Room.room_id);
            cmd.Connection = cn;

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

        private void GuestsAdicionados()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Guest WHERE Guest.reserved_room_id = @ReservedRoomID;", cn);

            Room Room = new Room();
            Room = (Room)listBox5.Items[currentRoom];

            cmd.Parameters.AddWithValue("@ReservedRoomID", Room.room_id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Guest G = new Guest();
                G.guest_id = reader["guest_id"].ToString();
                G.CC = reader["CC"].ToString();
                G.review = reader["review"].ToString();
                G.reserved_room_id = reader["reserved_room_id"].ToString();
                listBox2.Items.Add(G);
            }

        }

            public void showRoomType() // Função que mostra as coisas nas boxes
        {
            if (listBox1.Items.Count == 0 | currentRoomType < 0)
                return;
            Room_Type room = new Room_Type();
            room = (Room_Type) listBox1.Items[currentRoomType];
            txtRoomType.Text = room.typology;
            txtVista.Text = room.vista;
            txtBeds.Text = room.beds_no;
            textBox12.Text = room.room_price;
            loadRoomPackages();
            calculoNoitesEprecoTotal();
            QuartosDisponíveis();

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                currentRoomType = listBox1.SelectedIndex;
                showRoomType();
                
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBox5.SelectedIndex > -1)
            {
                currentRoom = listBox5.SelectedIndex;

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChildRoom_Load(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            CriarPessoa();
            CriarResorvor();
            GerarUmaBill();
            GerarReserva();
            GerarReservedRoom();
            ControlosReserva(); // Dá desable à reserva para nao serem feitas mais modificações
            ControlosGuest(); // Aparece a parte para adicionar guests

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reserva Concluida, Obrigado!");
            MainPage form = new MainPage();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room_Type room = new Room_Type();
            room = (Room_Type)listBox1.Items[currentRoomType];
            if (numericUpDown1.Value <= 0 || Int32.Parse(room.max_capacity) == 0 || count_Button_Add_Guest == numericUpDown1.Value) // Se o número de guests é menor ou igual a 0, o buttao fica desativado
            {
                button2.Enabled = false;
            }
            else
            {
                CriarPessoa_Guest();
                GerarGuest();
                GuestsAdicionados();
                count_Button_Add_Guest++;
            }
        }
    }
}
