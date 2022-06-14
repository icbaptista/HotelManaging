using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace HotelUI
{
    public partial class AdminPanel : Form
    {
        private SqlConnection cn;
        public AdminPanel()
        {
            InitializeComponent();
            checkedListBox1.Items.Add("Sunday", CheckState.Checked);
            checkedListBox1.Items.Add("Monday", CheckState.Unchecked);
            checkedListBox1.Items.Add("Tuesday", CheckState.Indeterminate);
        }

        private void AdminPanel_Load() 
        {
            cn = getSGBDConnection();
            
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source=CCWIN8\\SQL2012EXPRESS;integrated security=true;initial catalog=Hotel");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
      
    }
}
