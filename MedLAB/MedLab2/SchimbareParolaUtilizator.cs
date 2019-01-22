using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using System.Windows.Forms;

namespace MedLab2
{
    public partial class SchimbareParolaUtilizator : Office2007Form
    {
        public SchimbareParolaUtilizator()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0642 // Possible mistaken empty statement
            if (textBox3.Text == textBox4.Text) ;
#pragma warning restore CS0642 // Possible mistaken empty statement
            if(textBox3.Text.Length<=4||textBox4.Text.Length>=20)MessageBox.Show(" Numele utilizatorului si parola trebuie sa contina minim 4 caractere si maxim 20 caractere", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
