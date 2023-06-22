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
    public partial class Schedule : Form
    {
        private MySqlConnection connection;
        public Schedule()
        {
           
            InitializeComponent();

            string connectionString = "Server=sql7.freesqldatabase.com;Database=sql7627550;Uid=sql7627550;Pwd=xJfICE3bHl;";
            connection = new MySqlConnection(connectionString);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                // Connection was successful
                Console.WriteLine("Connection successful!");



            }
            else
            {
                // Connection failed
                Console.WriteLine("Connection failed!");
            }
            connection.Close();

            LoadData();
        }

        private void Schedule_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {


            string query = "SELECT `Interval`, tip, course, locatie, profesor FROM Schedule";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Define columns for the DataGridView
            guna2DataGridView1.Columns.Clear(); // Clear existing columns if any

            // Define column for "Nume"
            DataGridViewTextBoxColumn numeColumn = new DataGridViewTextBoxColumn();
            numeColumn.DataPropertyName = "Interval"; // Specify the corresponding column name in the DataTable
            numeColumn.HeaderText = "Interval"; // Header text for the column
            guna2DataGridView1.Columns.Add(numeColumn);
            
            // Define column for "Due"
            DataGridViewTextBoxColumn dueColumn = new DataGridViewTextBoxColumn();
            dueColumn.DataPropertyName = "Tip";
            dueColumn.HeaderText = "Tip";
            guna2DataGridView1.Columns.Add(dueColumn);

            // Define column for "Place"
            DataGridViewTextBoxColumn placeColumn = new DataGridViewTextBoxColumn();
            placeColumn.DataPropertyName = "Course";
            placeColumn.HeaderText = "Course";
            guna2DataGridView1.Columns.Add(placeColumn);

            // Define column for "Credits"
            DataGridViewTextBoxColumn creditsColumn = new DataGridViewTextBoxColumn();
            creditsColumn.DataPropertyName = "Locatie";
            creditsColumn.HeaderText = "Locatie";
            guna2DataGridView1.Columns.Add(creditsColumn);

            DataGridViewTextBoxColumn ProfesorColumn = new DataGridViewTextBoxColumn();
            creditsColumn.DataPropertyName = "Profesor";
            creditsColumn.HeaderText = "Profesor";
            guna2DataGridView1.Columns.Add(ProfesorColumn);

            // Set the data source and refresh the DataGridView
            guna2DataGridView1.DataSource = dataTable;

        }

        //CNP, INITIALA TATALUI,NR MATRICOL,SPECIALIZE,FACULTATE,IESC
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
