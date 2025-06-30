using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem.AllUserControls
{
    public partial class UC_UpdateItems : UserControl
    {

        function fn = new function();
        String query;

        public UC_UpdateItems()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            loadData(query);
        }

        public void loadData(String qur)
        {
            query = "select * from item";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Item where Name like '" + txtSearchItem.Text + "%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String Category = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int Price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtCategory.Text = Category;
            txtName.Text = Name;
            txtPrice.Text = Price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update Item set Name = '"+txtName.Text+"', Category = '"+txtCategory.Text+"', Price="+txtPrice.Text+" where id = "+id+"";
            fn.setData(query);
            loadData(query);

            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
        }
    }
}
