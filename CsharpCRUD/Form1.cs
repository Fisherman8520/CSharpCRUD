using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; 

namespace CsharpCRUD
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; User Id=root;password=nani;Database=db_csharpcrud"); // Forbinder til database serveren.
        MySqlDataAdapter adapter = new MySqlDataAdapter(); 
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Add knap
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into tbl_names (firstname, lastname, address, occupation) VALUES ('" + textBox1.Text +"','"+ textBox2.Text +"','" + textBox3.Text + "', '" + textBox4.Text + "')", conn);
            adapter.Fill(ds, "tbl_names");
            MessageBox.Show("Added!");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            GetRecords();

        }

        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from tbl_names",conn);
            adapter.Fill(ds, "tbl_names");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_names";

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) // Edit knap
        {
            int i = dataGridView1.CurrentRow.Index;

            label5.Text = dataGridView1[0, i].Value.ToString();
            textBox1.Text = dataGridView1[1, i].Value.ToString();
            textBox2.Text = dataGridView1[2, i].Value.ToString();
            textBox3.Text = dataGridView1[3, i].Value.ToString();
            textBox4.Text = dataGridView1[4, i].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e) // update knap
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update tbl_names set firstname = '" + textBox1.Text + "', lastname = '" + textBox2.Text + "', address = '" + textBox3.Text + "', occupation = '" + textBox4.Text + "' where id = " + label5.Text, conn);
            adapter.Fill(ds, "tbl_names");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label5.Text = "";
            GetRecords();
        }

        private void button4_Click(object sender, EventArgs e) // delete knap
        {
            int i = dataGridView1.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from tbl_names where id = " + dataGridView1[0, i].Value.ToString(), conn);
            adapter.Fill(ds, "tbl_names");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label5.Text = "";
            GetRecords();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
