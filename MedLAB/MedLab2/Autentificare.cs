using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Rendering;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MedLab2
{
    public partial class Autentificare : Office2007Form
    { public bool enter=false;
    public string user;
        public Autentificare()
        {
            InitializeComponent();
            textBox3.Text = DateTime.Today.ToLongDateString();
            
        }


       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reflectionImage3_Click(object sender, EventArgs e)
        {

        }

        private void reflectionImage3_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ADMIN" && textBox2.Text == "ADMIN") this.Close();
            user = textBox1.Text;
            bool ok = false;
                try
                {
                    OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                    aConnection.Open();
                    string NumeUtilizator = textBox1.Text;
                    //create the command object and store the sql query
                    OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator=@NumeUtilizator", aConnection);
                    aCommand.Parameters.Add("@NumeUtilizator", OleDbType.VarChar, 100, "NumeUtilizator").Value = NumeUtilizator;
                    OleDbDataReader myreader;



                    
                   
                    string Password;
                   
                    string verif = "";
                    verif = Convert.ToString(aCommand.ExecuteScalar());
                    aCommand = new OleDbCommand("SELECT * FROM Utilizatori WHERE NumeUtilizator=@NumeUtilizator", aConnection);
                    aCommand.Parameters.Add("@NumeUtilizator", OleDbType.VarChar, 100, "NumeUtilizator").Value = NumeUtilizator;
                   
                    myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    myreader.Read();
                    if (verif != "")
                    {
                        Password = myreader.GetString(1);
                        if (Password == textBox2.Text)
                        {
                            ok = true;
                            if (textBox1.Text == "ADMIN") MessageBoxEx.Show("Sunteti logat ca administrator. Aveti posibilitatea sa:\n-adaugati utilizatori\n-stergeti utilizatori\n-schimbati parola administratorului\n-sa accesati meniul instrumente", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else  MessageBoxEx.Show("Sunteti logat ca asistent medical. Aveti posibilitatea sa:\n-introduceti datele pacientilor in baza de date\n-cautati pacientii in baza de date\n-stergeti pacientii din baza de date\n-accesati meniul instrumente ","MedLAB",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            myreader.Close(); this.Close(); }
                    }
                    else
                    {
                        aConnection.Close();
                        myreader.Close();

                        aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                        aConnection.Open();
                        aCommand = new OleDbCommand("SELECT * FROM MedicIntrodRez WHERE NumeMedic=@NumeUtilizator", aConnection);
                        aCommand.Parameters.Add("@NumeUtilizator", OleDbType.VarChar, 100, "NumeMedic").Value = NumeUtilizator;


                        verif = Convert.ToString(aCommand.ExecuteScalar());

                        aCommand = new OleDbCommand("SELECT * FROM MedicIntrodRez WHERE NumeMedic=@NumeUtilizator", aConnection);
                        aCommand.Parameters.Add("@NumeUtilizator", OleDbType.VarChar, 100, "NumeMedic").Value = NumeUtilizator;

                        myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        myreader.Read();
                        if (verif != "")
                        {
                            Password = myreader.GetString(1);
                            if (Password == textBox2.Text) 
                            { ok = true;
                            MessageBoxEx.Show("Sunteti logat ca medic. Aveti posibilitatea sa:\n--introduceti datele pacientilor in baza de date\n-cautati pacientii in baza de date\n-stergeti pacientii din baza de date\n-introduceti rezultatele analizelor pacientilor,sa le printati sau sa le trimiteti prin e-mail \n-accesati meniul instrumente\n","MedLAB",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                myreader.Close(); 
                                this.Close();
                            }
                        }
                        }
                    if (!ok) MessageBoxEx.Show("Numele utilizatorului sau parola nu sunt valide.", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Hand);


                    myreader.Close();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            
            Application.Exit();
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {

        }

        
    }
}
