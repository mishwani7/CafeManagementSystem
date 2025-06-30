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

namespace CafeManagementSystem.AllUserControls
{
    public partial class UC_RemoveItem : UserControl
    {
        function fn = new function();
          string query;

        public UC_RemoveItem()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_RemoveItem_Load(object sender, EventArgs e)
        {
            DelItem.Text = "How To Delete?";
            loadData();

            // Add a Click event handler to the label
            DelItem.Click += (s, args) =>
            {
                // Display an information message when the label is clicked
                MessageBox.Show("To delete an item, click on its row in the table and press the Delete key.", "How to Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }


        public void loadData()
        {
            query = "select * from Item";
           DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from item where Name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource= ds.Tables[0];

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not a header cell and if it's a valid row index
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the ID of the item you want to delete from the DataGridView
                int itemIdToDelete = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                // Show a confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the row from the DataGridView
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    // Delete the corresponding record from your database by ID
                    string deleteQuery = "DELETE FROM Item WHERE ID = @ItemIDToDelete";

                    using (SqlConnection connection = new SqlConnection())
                    {
                        // Create an instance of the 'function' class
                        function fn = new function();

                        connection.ConnectionString = "data source = DESKTOP-KM6QKUN;database = mycafe; integrated security = True";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            connection.Open();
                            cmd.Parameters.AddWithValue("@ItemIDToDelete", itemIdToDelete);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void DelItem_Click(object sender, EventArgs e)
        {

        }
    }
}
