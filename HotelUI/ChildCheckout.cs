using System.Windows.Forms;

namespace HotelUI
{
    public partial class ChildCheckout : Form
    {
        public ChildCheckout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ShowMyDialogBox();
        }

        public void ShowMyDialogBox()
        {
            PopUp testDialog = new PopUp();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                Guest g = new Guest(); 
                // Read the contents of testDialog's TextBox.
                //string textBox1 = testDialog.TextBox1.Text;

            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }
    }

  
}
