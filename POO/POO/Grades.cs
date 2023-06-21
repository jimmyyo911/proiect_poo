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


namespace POO
{
    public partial class Grades : Form
    {
        private MySqlConnection connection;

       

        public Grades()
        {
            InitializeComponent();
            string connectionString = "Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";
            connection = new MySqlConnection(connectionString);
        }

        private void Grades_Load(object sender, EventArgs e)
        {
            LoadData();
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
