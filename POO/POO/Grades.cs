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

        string query;
        int sum = 0;
      

        public Grades()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;

            string connectionString = "Server=sql7.freesqldatabase.com;Database=sql7627550;Uid=sql7627550;Pwd=xJfICE3bHl;";
            connection = new MySqlConnection(connectionString);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection successful!");
            }
            else
            {
                Console.WriteLine("Connection failed!");
            }


            LoadData();
        }

        private void Grades_Load(object sender, EventArgs e)
        {
            // LoadData();
        }
        private void LoadData()
        {


            query = "SELECT Nume, Date, Score, Credits FROM Grades";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Define columns for the DataGridView
            guna2DataGridView1.Columns.Clear(); // Clear existing columns if any

            // Define column for "Nume"
            DataGridViewTextBoxColumn numeColumn = new DataGridViewTextBoxColumn();
            numeColumn.DataPropertyName = "Nume"; // Specify the corresponding column name in the DataTable
            numeColumn.HeaderText = "Nume"; // Header text for the column
            guna2DataGridView1.Columns.Add(numeColumn);

            // Define column for "Due"
            DataGridViewTextBoxColumn dueColumn = new DataGridViewTextBoxColumn();
            dueColumn.DataPropertyName = "Due";
            dueColumn.HeaderText = "Due";
            guna2DataGridView1.Columns.Add(dueColumn);

            // Define column for "Place"
            DataGridViewTextBoxColumn placeColumn = new DataGridViewTextBoxColumn();
            placeColumn.DataPropertyName = "Score";
            placeColumn.HeaderText = "Score";
            guna2DataGridView1.Columns.Add(placeColumn);

            // Define column for "Credits"
            DataGridViewTextBoxColumn creditsColumn = new DataGridViewTextBoxColumn();
            creditsColumn.DataPropertyName = "Credits";
            creditsColumn.HeaderText = "Credits";
            guna2DataGridView1.Columns.Add(creditsColumn);

            // Set the data source and refresh the DataGridView
            guna2DataGridView1.DataSource = dataTable;

            sum = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                int credits = Convert.ToInt32(row["Credits"]);
                sum += credits;
            }
          //  Console.WriteLine("Sum of credits: " + sum);


        }


    


    





    private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRestanta_Click(object sender, EventArgs e)
        {
            label1.Text = "Nr Credite: " + sum.ToString();
            if (sum >= 40)
            {
                label3.Visible = true;
            }
            else
            {
                label2.Visible = true;
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
