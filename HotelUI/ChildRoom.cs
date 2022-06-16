using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelUI
{
    public partial class ChildRoom : Form
    {
        private int currentRoomType;
        private SqlConnection cn;
        public ChildRoom()
        {
            InitializeComponent();
            loadRoomTypes();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=LAPTOP-8K6S8357; Initial Catalog = Hotel; Integrated Security = True");
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

        public void showRoomType()
        {
            if (listBox1.Items.Count == 0 | currentRoomType < 0)
                return;
            Room_Type room = new Room_Type();
            room = (Room_Type) listBox1.Items[currentRoomType];
            txtRoomType.Text = room.typology;
            txtVista.Text = room.vista;
            txtPrice.Text = room.room_price;
            txtBeds.Text = room.beds_no; 
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                currentRoomType = listBox1.SelectedIndex;
                showRoomType();
            }
        }
    }
}
