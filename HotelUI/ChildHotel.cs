using System.Windows.Forms;
using System.Data; 
using System.Data.SqlClient;
using System.Diagnostics;
using System;
using System.Drawing;

namespace HotelUI
{
    public partial class ChildHotel : Form
    {
        private SqlConnection cn; 
        public ChildHotel()
        {
            InitializeComponent();
        }

        private void ChildHotel_Load(object sender, System.EventArgs e)
        {
            cn = getSGBDConnection();
            DreamEscape_groupbox.Visible = false; 
            loadHotelChoices(); 
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

        private void loadHotelChoices() 
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("Select * from Hotel", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            hotel_dropdown.Items.Clear();

            while (reader.Read())
            {
                Hotel A = new Hotel();
                A.nRNET = reader["nRNET"].ToString();
                A.nome = reader["nome"].ToString();
                A.descrição = reader["descrição"].ToString(); 
                A.rating = reader["rating"].ToString();
                hotel_dropdown.Items.Add(A);
                description_box.Text = A.descrição.ToString();
            }
            cn.Close();
        }

        private void hotel_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DreamEscape_groupbox.Visible = true;
            //chosenHotel = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //public int MyVar
        //{
        //    get
        //    {
        //        return chosenHotel;
        //    }
        //    set
        //    {
        //        if (chosenHotel != value)
        //            chosenHotel = value;
        //    }
        //}
    }
}
