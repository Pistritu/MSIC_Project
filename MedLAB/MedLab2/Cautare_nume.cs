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
    public partial class Cautare_nume : DevComponents.DotNetBar.Office2007Form
    {
        public Cautare_nume()
        {
            InitializeComponent();


        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        void cautare_cnp(string cnp)
        {
            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
            aConnection.Open();
            OleDbCommand aCommand = new OleDbCommand("SELECT * FROM INREGISTRARI WHERE Cnp=@cnp", aConnection);
            aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;


            OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (myreader.Read())
            {
                ;
            }


        }
        void cautare_nume(string nume)
        {
            try
            {   OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM INREGISTRARI", aConnection);
                OleDbDataReader myreader2 = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                ListViewItem l;
                string[] str = new string[4];
                while (myreader2.Read())
                {   if (myreader2.GetString(2).Contains(nume))
                    {   str[0] = myreader2.GetInt32(0).ToString();
                        str[1] = myreader2.GetString(2);
                        str[2] = myreader2.GetString(1);
                        str[3] = myreader2.GetString(7);
                           l = new ListViewItem(str);
                        listViewEx1.Items.Add(l);
                    }
                }
                myreader2.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());

            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

            if (textBoxX1.Text != "")
            {
                listViewEx1.Items.Clear();
                cautare_nume(textBoxX1.Text);
            }
        }

        private void listViewEx1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RezultateleCautarii rc = new RezultateleCautarii();
            string cnp = listViewEx1.SelectedItems[0].SubItems[2].Text;
           
            string index = listViewEx1.SelectedItems[0].SubItems[0].Text;
            string[] s1 = { "Leucocite    22", "Rh    10", "Fibrinogen     17", "Timp trombina  15", "Grup sanguin   10", "Proteina S     55", "Proteina C 45" };
            //bioch
            string[] s2 = { "Ca ionic    7", "Ca seric    9", "Mg seric    7", "Glucoza serica  7", "Trigliceride    9", "CK      9", "Profil lipidic      28", "ADNhepatitaC    390", "ArnhepatitaB  390" };
            // markeri enodocrini
            string[] s4 = { "AFP      29", "Calcitonina 51", "CA125  35", "CA15-3 35", "Ca72-4    43", "SCC   44", "ACTH   36", "Cortisol   29", "Prolactina 30", "Insulina   29" };
            //imun_ser
            string[] s3 = { "IgA    18", "IgB    18", "ASLO   13", "ANA    55", "AMA    45", "Anticorpi_antiADN  55" };

            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
            aConnection.Open();
            OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Pacienti WHERE Cnp=@cnp", aConnection);
            aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;
            OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (myreader.Read())
            {
                rc.textBox1.Text = myreader.GetString(1);
                rc.textBox2.Text = myreader.GetString(0);
                rc.textBox3.Text = myreader.GetString(4);
                rc.textBox4.Text = myreader.GetString(2);
                rc.textBox5.Text = myreader.GetString(3);
                rc.textBox6.Text = myreader.GetString(5);

            }
            myreader.Close();
            
                OleDbConnection aConnection2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection2.Open();
                OleDbCommand aCommand2 = new OleDbCommand("SELECT * FROM INREGISTRARi WHERE IDCerere=@index", aConnection2);
                aCommand2.Parameters.Add("@index", OleDbType.VarChar, 100, "Cnp").Value = index;
                OleDbDataReader myreader2 = aCommand2.ExecuteReader(CommandBehavior.CloseConnection);
            

                string Hemat;
                string ImSer;
                string Bioch;
                string Mend;
                myreader2.Read();

                Hemat = myreader2.GetString(9);
                ImSer = myreader2.GetString(10);
                Bioch = myreader2.GetString(11);
                Mend = myreader2.GetString(12);

                rc.textBox7.Text = myreader2.GetString(7);
                rc.textBox8.Text = myreader2.GetString(4);
                rc.textBox9.Text= myreader2.GetString(5);
                rc.textBox10.Text = myreader2.GetString(6);
     
            
            Object[] obj;
            int nr_crt = 0, nr = 0;
            int nrH, nrB, nrIS, nrME;
            nrH = nrB = nrIS = nrME = 0;
            
            obj = new object[18];
            


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
                    rc.dataGridViewX1.Rows.Add(obj);
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
                    rc.dataGridViewX1.Rows.Add(obj);
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
                    rc.dataGridViewX1.Rows.Add(obj);
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
                    rc.dataGridViewX1.Rows.Add(obj);
                    nr = 0;

                }
            }
          //  nrME = nr_crt - (nrIS + nrH + nrB);







           
            myreader2.Close();
            rc.index = Convert.ToInt32(index);
          
            rc.ShowDialog();
            rc.Dispose();
            rc.Focus();
        }

        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}