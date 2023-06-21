using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO
{
    public partial class Exams : Form
    {

        private MySqlConnection connection;
        public Exams()
        {
            InitializeComponent();
           
        }


        private void Exams_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string query = "SELECT * FROM nume";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            guna2DataGridView1.DataSource = dataTable;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
