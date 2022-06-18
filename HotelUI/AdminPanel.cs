using System.Data;
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

                dataGridReservation.DataSource = dtbl; 

            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();

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
    }
}
