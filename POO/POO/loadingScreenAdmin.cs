﻿using System;
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
    public partial class loadingScreenAdmin : Form
    {
        public loadingScreenAdmin()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 700)
            {
                timer1.Stop();
                adminDashboard adminDashboard = new adminDashboard();
                adminDashboard.Show();
                this.Hide();
            }
        }
    }
}
