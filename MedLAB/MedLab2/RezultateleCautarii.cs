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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;


namespace MedLab2
{
    public partial class RezultateleCautarii : DevComponents.DotNetBar.Office2007Form
    {
       public  int index ;
        public RezultateleCautarii()
        {
            InitializeComponent();
            dataGridViewX1.Columns.Add("nr_crt", "Nr crt");
            dataGridViewX1.Columns.Add("analize", "Examen clinic");
            dataGridViewX1.Columns.Add("rezultate", "Rezultat");

        }

        private void RezultateleCautarii_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            

            Print.printare(index, textBox2.Text);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
          string   email = textBox5.Text;
            GmailSender.SendMail("dumitrescu.evelina@gmail.com", "andreia90", email, "MedLab", "Acestea sunt rezultatele analizelor.");
        }
    }
}
