using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace MedLab2
{
    public partial class StergereUtilizator : Office2007Form
    {
        public StergereUtilizator()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult dlr =MessageBox.Show("Sunteti sigur ca doriti sa stergeti utilizatorul selectat?", "MedLAB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlr.ToString() == DialogResult.Yes.ToString()) MessageBox.Show("Utilizatorul a fost sters din baza de date", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#pragma warning disable CS0642 // Possible mistaken empty statement
            else ;
#pragma warning restore CS0642 // Possible mistaken empty statement
            
        }
    }
}
