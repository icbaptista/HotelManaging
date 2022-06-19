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
        private SqlConnection cn;
        private int currentReservation = 100004;
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

        private void calculoNoites()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("Select * FROM (Room_Type INNER JOIN Package ON Room_Type.room_type_id = Package.room_type_id) FULL JOIN Reservation ON Package.package_ID = Reservation.package_ID WHERE (Room_Type.room_type_id = @RoomType) AND (Package.package_ID = @PackageID) ORDER BY Room_Type.room_price, Package.package_price;", cn);
            cmd.Parameters.AddWithValue("@RoomType", ((Room_Type) listBox1.Items[currentRoomType]).room_type_id);
            cmd.Parameters.AddWithValue("@PackageID", textBox5.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                //DateTime UltimaData = DateTime.Parse(reader["date_out"].ToString());
                //DateTime PrimeiraData = DateTime.Parse(reader["date_in"].ToString());

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
            calculoNoites();
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

        private void button1_Click(object sender, EventArgs e) // Botao de adicionar os dados do resevor
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmdd = new SqlCommand("SELECT TOP 1 Reservor.reservor_id FROM Reservor ORDER BY Reservor.reservor_id DESC;"); // Vai buscar o ultimo ID do reservor

            if (!cmd.Parameters.Contains(textBox9.Text)) // Se o CC nao existir criamos
            {
                
                cmd.CommandText = "INSERT INTO Hotel.Person(firstname,lastname,CC,gender,age,cellphone) VALUES ( @firstname, @lastname, @CC, @gender, @age, @cellphone)";
                cmd.Parameters.AddWithValue("@firstname", textBox7.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox8.Text);
                cmd.Parameters.AddWithValue("@CC", textBox9.Text);
                cmd.Parameters.AddWithValue("@gender", textBox13.Text);
                cmd.Parameters.AddWithValue("@age", textBox10.Text);
                cmd.Parameters.AddWithValue("@cellphone", textBox11.Text);

                cmdd.CommandText = "INSERT INTO Hotel.Reservor(reservor_id,CC,email) VALUES (@reservor_id,@CC,@email)";
                cmdd.Parameters.AddWithValue("@CC", textBox9.Text);
                cmdd.Parameters.AddWithValue("@email", textBox1.Text);

                cn.Open();
                object ReservorID = cmdd.ExecuteScalar(); // ESTÁ A DAR ERRO AQUI
                int ReservorID_int = Convert.ToInt32(ReservorID);
                // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/obtaining-a-single-value-from-a-database
                cmdd.Parameters.AddWithValue("@reservor_id", ReservorID_int + 1);

            }
            else // Se existir eliminamoos e metemos again
            {
                cmd.CommandText = "EXEC eliminar_Reservor @CC";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CC", textBox9.Text);
                cmd.Connection = cn;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu Um erro. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
