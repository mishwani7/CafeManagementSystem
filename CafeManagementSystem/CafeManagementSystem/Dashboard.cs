using CafeManagementSystem.AllUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(String user)
        {
            InitializeComponent();

            if (user == "Guest")
            {
                btnAddItems.Hide();
                btnUpdateItems.Hide();
                btnRemoveItems.Hide();
            }
            else if (user == "Admin")
            {
                btnAddItems.Show();
                btnUpdateItems.Show();
                btnRemoveItems.Show();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Initially hide the uC_AddItems1 control
            uC_AddItems1.Visible = false;
            uC_UpdateItems1.Visible = false;
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            // Set the background color and text color for the clicked button
            btnAddItems.BackColor = Color.White;
            btnAddItems.ForeColor = Color.Black;

            // Reset the background color and text color for other buttons
            btnUpdateItems.BackColor = Color.FromArgb(0, 118, 255);
            btnUpdateItems.ForeColor = Color.White;
            btnRemoveItems.BackColor = Color.FromArgb(0, 118, 255);
            btnRemoveItems.ForeColor = Color.White;
            btnPlaceOrder.BackColor = Color.FromArgb(0, 118, 255);
            btnPlaceOrder.ForeColor = Color.White;

            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void btnUpdateItems_Click(object sender, EventArgs e)
        {
            // Set the background color and text color for the clicked button
            btnUpdateItems.BackColor = Color.White;
            btnUpdateItems.ForeColor = Color.Black;

            // Reset the background color and text color for other buttons
            btnAddItems.BackColor = Color.FromArgb(0, 118, 255);
            btnAddItems.ForeColor = Color.White;
            btnRemoveItems.BackColor = Color.FromArgb(0, 118, 255);
            btnRemoveItems.ForeColor = Color.White;
            btnPlaceOrder.BackColor = Color.FromArgb(0, 118, 255);
            btnPlaceOrder.ForeColor = Color.White;

            uC_UpdateItems1.Visible = true;
            uC_UpdateItems1.BringToFront();
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            // Set the background color and text color for the clicked button
            btnRemoveItems.BackColor = Color.White;
            btnRemoveItems.ForeColor = Color.Black;

            // Reset the background color and text color for other buttons
            btnAddItems.BackColor = Color.FromArgb(0, 118, 255);
            btnAddItems.ForeColor = Color.White;
            btnUpdateItems.BackColor = Color.FromArgb(0, 118, 255);
            btnUpdateItems.ForeColor = Color.White;
            btnPlaceOrder.BackColor = Color.FromArgb(0, 118, 255);
            btnPlaceOrder.ForeColor = Color.White;

            uC_RemoveItem1.Visible = true;
            uC_RemoveItem1.BringToFront();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Set the background color and text color for the clicked button
            btnPlaceOrder.BackColor = Color.White;
            btnPlaceOrder.ForeColor = Color.Black;

            // Reset the background color and text color for other buttons
            btnAddItems.BackColor = Color.FromArgb(0, 118, 255);
            btnAddItems.ForeColor = Color.White;
            btnUpdateItems.BackColor = Color.FromArgb(0, 118, 255);
            btnUpdateItems.ForeColor = Color.White;
            btnRemoveItems.BackColor = Color.FromArgb(0, 118, 255);
            btnRemoveItems.ForeColor = Color.White;

            uC_PlaceOrder1.Visible = true;
            uC_PlaceOrder1.BringToFront();
        }
    }
}
