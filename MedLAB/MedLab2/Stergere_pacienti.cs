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
using System.Data.OleDb;
using System.Data.SqlClient;


namespace MedLab2
{
    public partial class Stergere_pacienti : DevComponents.DotNetBar.Office2007Form
    {
       
        public Stergere_pacienti()
        {
            InitializeComponent();
        }

        private void Stergere_pacienti_Load(object sender, EventArgs e)
        {

        }
        void stergere_ID(int index)
        {
            try
            {
               
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("DELETE FROM INREGISTRARI WHERE IDCerere=@index", aConnection);
                aCommand.Parameters.Add("@index", OleDbType.Integer, 100, "IDCerere").Value = index;


                OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                MessageBoxEx.Show("       Inregistrarea  a fost stearsa din baza de date       ", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                myreader.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        
        }
        void stergere_nume(string nume)
        {
            try
            {
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();

                OleDbCommand aCommand = new OleDbCommand("DELETE FROM INREGISTRARI WHERE Nume=@nume", aConnection);
                aCommand.Parameters.Add("@nume", OleDbType.VarChar, 100, "Nume").Value = nume;
                OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                
                aCommand = new OleDbCommand("DELETE FROM PACIENTI WHERE Nume=@nume", aConnection);
                aCommand.Parameters.Add("@nume", OleDbType.VarChar, 100, "Nume").Value = nume;
                myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                
                
                MessageBoxEx.Show("       Inregistrarea  a fost stearsa din baza de date       ", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                myreader.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
        void stergere_cnp(string cnp)
        {
            try
            {
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("DELETE FROM INREGISTRARI WHERE Cnp=@cnp", aConnection);
                aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;
                OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
               
                aCommand = new OleDbCommand("DELETE FROM PACIENTI WHERE Cnp=@cnp", aConnection);
                aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;
                myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                myreader.Close();
                
                MessageBoxEx.Show("       Inregistrarea  a fost stearsa din baza de date       ", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DialogResult dlr =MessageBox.Show("Sunteti sigur ca doriti sa stergeti pacientul din baza de date?", "MedLAB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlr.ToString() == DialogResult.Yes.ToString())
            {
                try
                {
                    if (radioButton1.Checked)
                    {
                        stergere_ID(Convert.ToInt32(textBox1.Text));
                    }
                    if (radioButton2.Checked)
                    {
                        stergere_nume(textBox1.Text);
                    }
                    if (radioButton3.Checked)
                    {
                        stergere_cnp(textBox1.Text);
                    }

                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
            }
        }
    }
}
