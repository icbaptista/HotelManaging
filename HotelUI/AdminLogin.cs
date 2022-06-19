using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelUI
{
    public partial class AdminLogin : Form
    {
        private SqlConnection con; 
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-CIMKDJM; Initial Catalog = Hotel; Integrated Security = True";
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select * from Staff where username like @username and passe = @password;", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();

            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (loginSuccessful)
            {
                MessageBox.Show("Login bem sucedido!"); 
                AdminPanel form = new AdminPanel();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login inválido: verifique o username e a password!");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.Show();
            this.Hide(); 
        }
    }
}
