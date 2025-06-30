using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class UC_PlaceOrder : UserControl
    {

        function fn = new function();
        String query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboCategory.Text;
            string query = "SELECT Name FROM Item WHERE Category = '" + category + "' AND Name LIKE '%" + txtSearchBox.Text + "%'";
            DataSet ds = fn.getData(query); // Call the getData method from the fn object
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboCategory.Text;
            string query = "SELECT Name FROM Item WHERE Category = '" + category + "'";
            DataSet ds = fn.getData(query); // Call the getData method from the fn object
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "select Price FROM Item where Name = '" + text + "'";
            DataSet ds = fn.getData(query);
            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuantity.Value.ToString());
            Int64 price = Int64.Parse(txtPrice.Text);
            txtTotal.Text = (quan*price).ToString();
        }

        protected int n, total = 0;

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(selectedIndex);

                    // Update the total after removing the item
                    total -= amount;
                    labelTotal.Text = "Rs. " + total;
                }
                else
                {
                    MessageBox.Show("Please select a row to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Check if the DataGridView has no rows or contains no cell data
            if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows.Cast<DataGridViewRow>().All(row => row.Cells.Cast<DataGridViewCell>().All(cell => cell.Value == null || cell.Value.ToString() == "")))
            {
                MessageBox.Show("There are no items to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without printing
            }

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount : " + labelTotal.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

            total = 0;
            dataGridView1.Rows.Clear();
            labelTotal.Text = "Rs. " + total;
        }



        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text) || txtQuantity.Value == 0)
            {
                MessageBox.Show("Please select an item and specify a valid quantity before adding it to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method without adding the item
            }

            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
            dataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
            dataGridView1.Rows[n].Cells[2].Value = txtQuantity.Value;
            dataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

            total = total + int.Parse(txtTotal.Text);
            labelTotal.Text = "Rs. " + total;

            // Clear item name and quantity after adding an item
            txtItemName.Clear();
            txtQuantity.Value = 0;
        }
    }
}
