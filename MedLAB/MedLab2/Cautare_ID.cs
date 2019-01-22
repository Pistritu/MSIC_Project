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
    public partial class Cautare_ID : DevComponents.DotNetBar.Office2007Form
    {
        public Cautare_ID()
        {
            InitializeComponent();
            dataGridViewX1.Columns.Add("nr_crt", "Nr crt");
            dataGridViewX1.Columns.Add("analize", "Examen clinic");
            dataGridViewX1.Columns.Add("rezultate", "Rezultat");

        
        }

        private void Date_cautare_Load(object sender, EventArgs e)
        {

        }

        private void reflectionLabel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s1 = { "Leucocite    22", "Rh    10", "Fibrinogen     17", "Timp trombina  15", "Grup sanguin   10", "Proteina S     55", "Proteina C 45" };
                //bioch
                string[] s2 = { "Ca ionic    7", "Ca seric    9", "Mg seric    7", "Glucoza serica  7", "Trigliceride    9", "CK      9", "Profil lipidic      28", "ADNhepatitaC    390", "ArnhepatitaB  390" };
                // markeri enodocrini
                string[] s4 = { "AFP      29", "Calcitonina 51", "CA125  35", "CA15-3 35", "Ca72-4    43", "SCC   44", "ACTH   36", "Cortisol   29", "Prolactina 30", "Insulina   29" };
                //imun_ser
                string[] s3 = { "IgA    18", "IgB    18", "ASLO   13", "ANA    55", "AMA    45", "Anticorpi_antiADN  55" };

                string cnp;
                string index = textBoxX1.Text;
                
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM INREGISTRARI WHERE IDCerere=@index", aConnection);
                aCommand.Parameters.Add("@index", OleDbType.Integer, 100, "IDCerere").Value = index;

                OleDbDataReader myreader2 = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                

                string[] str = new string[4];

                
                myreader2.Read();


                textBox1.Text = myreader2.GetString(2);
                textBox2.Text = cnp=myreader2.GetString(1);

                textBox8.Text = myreader2.GetString(4);
                textBox9.Text = myreader2.GetString(5);
                textBox10.Text = myreader2.GetString(6);

                string Hemat;
                string ImSer;
                string Bioch;
                string Mend;


                Hemat = myreader2.GetString(9);
                ImSer = myreader2.GetString(10);
                Bioch = myreader2.GetString(11);
                Mend = myreader2.GetString(12);

                textBox7.Text = myreader2.GetString(7);
                textBox8.Text = myreader2.GetString(4);
                textBox9.Text = myreader2.GetString(5);
                textBox10.Text = myreader2.GetString(6);


                Object[] obj;
                int nr_crt = 0, nr = 0;
#pragma warning disable CS0219 // The variable 'nrME' is assigned but its value is never used
                int nrH, nrB, nrIS, nrME;
#pragma warning restore CS0219 // The variable 'nrME' is assigned but its value is never used
                nrH = nrB = nrIS = nrME = 0;

                obj = new object[3];



                //Console.WriteLine("nume" + myc.Nume + "\nadr" + myc.Adr + "\nhemat" + myc.Hemat + "\nbio" + myc.Bioch + "\ncnp" + myc.Cnp + "\ndanl" + myc.Danl + "\ndn" + myc.Dn + "\nemail" + myc.Email + "\nimser" + myc.ImSer + "\nmedic" + myc.Medic + "\nmend" + myc.Mend + "\nnrtel" + myc.Nrtel + "\nnrsp" + myc.Nrtel_spital + "\nsp" + myc.Spital);
                int i;
                for (i = 4; i < Hemat.Length; i++)
                {
                    if (Hemat[i] != ';')
                    {
                        nr = nr * 10 + int.Parse(Hemat[i].ToString());
                    }
                    else
                    {
                        nr_crt++;
                        obj = new Object[3];
                        obj[0] = nr_crt;
                        obj[1] = s1[nr].Substring(0, s1[nr].IndexOf(' '));
                        obj[2] = " ";
                        dataGridViewX1.Rows.Add(obj);
                        nr = 0;

                    }
                }
                nrH = nr_crt;
                nr = 0;
                //nr_crt = 0;
                for (i = 4; i < Bioch.Length; i++)
                {
                    if (Bioch[i] != ';')
                    {
                        nr = nr * 10 + int.Parse(Bioch[i].ToString());
                    }
                    else
                    {
                        nr_crt++;
                        obj = new Object[3];
                        obj[0] = nr_crt;
                        obj[1] = s2[nr].Substring(0, s2[nr].IndexOf(' '));
                        obj[2] = " ";
                        dataGridViewX1.Rows.Add(obj);
                        nr = 0;

                    }
                }
                nrB = nr_crt - nrH;
                nr = 0;
                // nr_crt = 0;
                for (i = 4; i < ImSer.Length; i++)
                {
                    if (ImSer[i] != ';')
                    {
                        nr = nr * 10 + int.Parse(ImSer[i].ToString());
                    }
                    else
                    {
                        nr_crt++;
                        obj = new Object[3];
                        obj[0] = nr_crt;
                        obj[1] = s3[nr].Substring(0, s3[nr].IndexOf(' '));
                        obj[2] = " ";
                        dataGridViewX1.Rows.Add(obj);
                        nr = 0;

                    }
                }
                nrIS = nr_crt - (nrB + nrH);
                nr = 0;
                //nr_crt = 0;

                //nr_crt = 0;
                for (i = 4; i < Mend.Length; i++)
                {
                    if (Mend[i] != ';')
                    {
                        nr = nr * 10 + int.Parse(Mend[i].ToString());
                    }
                    else
                    {
                        nr_crt++;
                        obj = new Object[3];
                        obj[0] = nr_crt;
                        obj[1] = s4[nr].Substring(0, s4[nr].IndexOf(' '));
                        obj[2] = " ";
                        dataGridViewX1.Rows.Add(obj);
                        nr = 0;

                    }
                }
                //  nrME = nr_crt - (nrIS + nrH + nrB);







           
                
                myreader2.Close();
                
                aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                aCommand = new OleDbCommand("SELECT * FROM Pacienti WHERE Cnp=@cnp", aConnection);
                aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;
                OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (myreader.Read())
                {


                    textBox6.Text = myreader.GetString(5);
                    textBox3.Text = myreader.GetString(4);
                    textBox4.Text = myreader.GetString(2);
                    textBox5.Text = myreader.GetString(3);
                }
                myreader.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Print.printare(Convert.ToInt32(textBoxX1.Text),textBox2.Text);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string email = textBox5.Text;
            GmailSender.SendMail("laurentiu.pistritu95@gmail.com", "Laurentiu", email, "MedLab", "Acestea sunt rezultatele analizelor.");
        }
    }
}
