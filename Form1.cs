using CrudMySQL.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudMySQL
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BUTTON SAVE CREAR
            CREATE();
            READ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BUTTON SAVE UPDATE
            UPDATE();
            READ();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //BUTTON SAVE DELETE
            DELETE();
            READ();
        }

        //READ function
        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_data();
            dataGridView1.DataSource = crud.dt;
        }

        //CREATE function
        public void CREATE()
        {
            crud.id_status = Int32.Parse(textBox1.Text);
            crud.status = textBox2.Text;
            crud.Create_data();
            textBox1.Clear();
            textBox2.Clear();
        }

        //UPDATE function
        public void UPDATE()
        {
            try
            {
                crud.id_status = Int32.Parse(textBox3.Text);
                crud.status = textBox4.Text;
                crud.Update_data();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("id_user is empty", e);
                MessageBox.Show("id_user is empty");
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        //DELETE function
        public void DELETE()
        {
            try
            {
                crud.id_status = Int32.Parse(textBox3.Text);
                crud.Delete_data();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("id_user is empty", e);
                MessageBox.Show("id_user is empty");
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        //GET DATA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    textBox1.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textBox2.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("NO SE PUDO MOSTRAR");
            }
        }
    }
}