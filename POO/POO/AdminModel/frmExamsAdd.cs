﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.AdminModel
{
    public partial class frmExamsAdd : TemplateAdd
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        public frmExamsAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0) 
            {
                qry = "Insert into Examene Values(@Course, @Due, @Place, @Credits)";
            }
            else { 
                qry = "Update Examene Set Nume = @Course, Due = @Due, Place = @Place, Credits = @Credits where ExamID = @ID";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@ID", id);
            ht.Add("@Course", txtCourse.Text);
            ht.Add("@Due", txtDue.Text);
            ht.Add("@Place", txtPlace.Text);
            ht.Add("@Credits", txtCredits.Text);

            if (MainClass.SQl(qry, ht) > 0) {
                MessageBox.Show("Saved successfully!");
                id = 0;

                txtCourse.Text = "";
                txtCourse.Focus();
                txtDue.Text = "";
                txtDue.Focus();
                txtPlace.Text = "";
                txtPlace.Focus();
                txtCredits.Text = "";
                txtCredits.Focus();
            }
        }

        private void adminDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void adminDashboard_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void adminDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void frmExamsAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
