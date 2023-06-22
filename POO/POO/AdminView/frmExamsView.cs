using POO.AdminModel;
using POO.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.AdminView
{
    public partial class frmExamsView : TemplateView
    {
        public frmExamsView()
        {
            InitializeComponent();
        }

        public void GetData() {
            string qry = "Select * From Examene where Nume like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvCourse);
            lb.Items.Add(dgvDue);
            lb.Items.Add(dgvPlace);
            lb.Items.Add(dgvCredits);
            lb.Items.Add(dgvID);
            MainClass.LoadData(qry, dataGridView1, lb);
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }
        public override void btnAdd_Click_1(object sender, EventArgs e)
        {
            frmExamsAdd frm = new frmExamsAdd();
            frm.ShowDialog();
            GetData();
        }

        private void frmCategoryView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmExamsAdd frm = new frmExamsAdd();
                frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value);
                frm.txtCourse.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvCourse"].Value);
                frm.txtDue.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvDue"].Value);
                frm.txtPlace.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvPlace"].Value);
                frm.txtCredits.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvCredits"].Value);
                frm.ShowDialog();
                GetData();
            }
            if(dataGridView1.CurrentCell.OwningColumn.Name == "dgvDelete") 
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvID"].Value); 
                string qry = "Delete from Examene where ExamID = " + id;
                Hashtable ht = new Hashtable();
                MainClass.SQl(qry, ht);

                MessageBox.Show("Deleted successfully!");
                GetData();
            }
        }
    }
}
