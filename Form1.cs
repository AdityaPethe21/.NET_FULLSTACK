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

namespace CRUD_SP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aditya_DB;Persist Security Info=True;User ID=adi;Password=adi");
        private void button1_Click(object sender, EventArgs e)
        {
            int empid=int.Parse(textBox1.Text),age = int.Parse(textBox2.Text);  
            DateTime joindate=DateTime.Parse(dateTimePicker1.Text);
            string empname=textBox4.Text,city=comboBox1.Text,contact=textBox3.Text,sex="";
            if(radioButton1.Checked==true) { sex = "Male"; }else { sex = "Female"; }
            con.Open();
            SqlCommand cmd= new SqlCommand("exec InsertE_SP '" + empid + "','\"+ empname + \"','\"+ city + \"','\"+ age + \"','\"+ sex + \"','\"+ joindate + \"','\"+ contact + \"' ",con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted...");
            GetEmpList();
        }
        void GetEmpList()
        {
            SqlCommand cmd = new SqlCommand("exec ListE_SP ", con); 
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int empid = int.Parse(textBox1.Text), age = int.Parse(textBox2.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            string empname = textBox4.Text, city = comboBox1.Text, contact = textBox3.Text, sex = "";
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand cmd = new SqlCommand("exec UpdateE_SP '" + empid + "','\"+ empname + \"','\"+ city + \"','\"+ age + \"','\"+ sex + \"','\"+ joindate + \"','\"+ contact + \"' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated...");
            GetEmpList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete
            if (MessageBox.Show("Are you sure to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            { 
            int empid = int.Parse(textBox1.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec DeleteE_SP '" + empid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted...");
            GetEmpList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Load

            int empid = int.Parse(textBox1.Text);
            SqlCommand cmd = new SqlCommand("exec LoadE_SP '" + empid + "'", con);
            SqlDataAdapter sd= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
