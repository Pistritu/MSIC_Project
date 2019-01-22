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

namespace MedLab2
{
    public partial class AdaugareUtilizator : Office2007Form
    {
        public AdaugareUtilizator()
        {
            InitializeComponent();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            string utilizator = textBoxX1.Text;
            string parola = textBoxX2.Text;
            if (textBoxX1.Text.Length < 4 || textBoxX1.Text.Length >20) { MessageBoxEx.Show(" Numele utilizatorului si parola trebuie sa contina minim 4 caractere si maxim 20 caractere", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning); ok = false; }
            if (textBoxX2.Text.Length < 4 || textBoxX2.Text.Length > 20) { ok = false; MessageBoxEx.Show(" Numele utilizatorului si parola trebuie sa contina minim 4 caractere si maxim 20 caractere", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        // parola==conf parola
            if ((textBoxX2.Text == textBoxX3.Text) && ok)
            {
                if (checkBoxX1.Checked == false)
                {
                    try
                    {
                        OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");

                        //create the command object and store the sql query
                        OleDbCommand aCommand;



                        OleDbCommand myCommand = new OleDbCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator=@utilzator", aConnection);
                        myCommand.Parameters.Add("@utilizator", OleDbType.VarChar, 100, "NumeUtilizator").Value = utilizator;
                        string id = "";
                        aConnection.Open();
                        id = Convert.ToString(myCommand.ExecuteScalar());

                        Console.Write(id.ToString());
                        if (id == "")
                        {


                            Console.WriteLine("NU a mai fost adaugat " + id.ToString());
                            aCommand = new OleDbCommand("INSERT INTO Utilizatori (NumeUtilizator, Parola)" + "Values (@utilizator, @parola)", aConnection);
                            aCommand.Parameters.Add("@utilizator", OleDbType.VarChar, 100, "NumeUtilizator").Value = utilizator;
                            aCommand.Parameters.Add("@parola", OleDbType.VarChar, 100, "Parola").Value = parola;

                            aCommand.ExecuteNonQuery();
                            MessageBoxEx.Show("Utilizatorul a fost adaugat in baza de date.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            MessageBoxEx.Show("Utilizatorul este inregistrat deja in baza de date.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        aConnection.Close();

                    }

                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.ToString());
                    }
                }
                else
                {

                    try
                    {
                        OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");

                        //create the command object and store the sql query
                        OleDbCommand aCommand;



                        OleDbCommand myCommand = new OleDbCommand("SELECT * FROM MedicIntrodRez WHERE NumeMedic=@utilzator", aConnection);
                        myCommand.Parameters.Add("@utilizator", OleDbType.VarChar, 100, "NumeMedic").Value = utilizator;
                        string id = "";
                        aConnection.Open();
                        id = Convert.ToString(myCommand.ExecuteScalar());

                        Console.Write(id.ToString());
                        if (id == "")
                        {


                            Console.WriteLine("NU a mai fost adaugat " + id.ToString());
                            aCommand = new OleDbCommand("INSERT INTO MedicIntrodRez (NumeMedic, Parola)" + "Values (@utilizator, @parola)", aConnection);
                            aCommand.Parameters.Add("@utilizator", OleDbType.VarChar, 100, "NumeMedic").Value = utilizator;
                            aCommand.Parameters.Add("@parola", OleDbType.VarChar, 100, "Parola").Value = parola;

                            aCommand.ExecuteNonQuery();
                            MessageBoxEx.Show("Medicul a fost adaugat in baza de date.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            MessageBoxEx.Show("Medicul este inregistrat deja in baza de date.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        aConnection.Close();

                    }

                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.ToString());
                    }
                }
            }

            else
            {
                MessageBoxEx.Show("Reconfirmati parola.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonX2_Click(object sender, EventArgs e) => Close();
    }
}
