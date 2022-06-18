using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelUI
{
    public partial class Booking : Form
    {
      
            private Button currentButton;
            private Form activeForm;
            public Booking()
            {
                InitializeComponent();
            }

            private void button4_Click(object sender, EventArgs e)
            {
                MainPage form = new MainPage();
                form.Show();
                this.Hide();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                OpenChildForm(new ChildHotel(), sender);
            }

            private void button2_Click(object sender, EventArgs e)
            {
                OpenChildForm(new ChildRoom(), sender);
            }

            private void button3_Click(object sender, EventArgs e)
            {
                OpenChildForm(new ChildCheckout(), sender);
            }

            private void OpenChildForm(Form childForm, object btnSender)
            {
                if (activeForm != null)
                    activeForm.Close();
                ActivateButton(btnSender);
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(childForm);
                this.panelDesktopPane.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
                lblTitle.Text = childForm.Text;
            }

            private void ActivateButton(object btnSender)
            {
                if (btnSender != null)
                {
                    if (currentButton != (Button)btnSender)
                    {
                        DisableButton();
                        Color color = Color.White;
                        currentButton = (Button)btnSender;
                        currentButton.BackColor = color;
                        currentButton.ForeColor = Color.White;
                        currentButton.Font = new System.Drawing.Font("Segoe UI", 11F);
                        currentButton.ForeColor = Color.SlateBlue;
                    }
                }
            }
            private void DisableButton()
            {
                foreach (Control previousBtn in panelMenu.Controls)
                {
                    if (previousBtn.GetType() == typeof(Button))
                    {
                        previousBtn.BackColor = Color.SlateBlue; 
                        previousBtn.ForeColor = Color.White;
                        previousBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
                    }
                }
            }

    }
}

