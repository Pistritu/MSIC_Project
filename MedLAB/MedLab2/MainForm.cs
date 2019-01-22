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
    public partial class MainForm : DevComponents.DotNetBar.Office2007Form
    {
        int nextID = 0;
        //costuri
        int[] t1 = { 22, 10, 17, 15, 10, 55, 45 };
        int[] t2 = { 7, 9, 7, 7, 9, 9, 28, 390, 390 };
        int[] t3 = { 18, 18, 13, 55, 45, 55 };
        int[] t4 = { 29, 51, 35, 35, 43, 44, 36, 29, 30, 29 };
        int nrH, nrB, nrIS, nrME;
        string curent_user = "admin";
        //hemat
        string[] s1 ={ "Leucocite    22 RON", "VSH    3 RON", "Fibrinogen     17 RON", "Timp trombina  15 RON", "Proteina S     55 RON", "Proteina C 45 RON" };
        //bioch
        string[] s2 = { "Ca ionic    7 RON", "Ca seric    9 RON", "Mg seric    7 RON", "Glucoza serica  7 RON", "Trigliceride    9 RON", "CK      9 RON", "Profil lipidic      28 RON", "ADNhepatitaC    390 RON", "ARNhepatitaB  390 RON" };
        // markeri enodocrini
        string[] s4 = { "AFP      29 RON", "Calcitonina 51 RON", "CA125  35 RON", "CA15-3 35 RON", "Ca72-4    43 RON", "SCC   44 RON", "ACTH   36 RON", "Cortisol   29 RON", "Prolactina 30 RON", "Insulina   29 RON" };
        //imun_ser
        string[] s3 = { "IgA    18 RON", "IgB    18 RON", "ASLO   13 RON", "ANA    55 RON", "AMA    45 RON", "Anticorpi_antiADN  55 RON" };
        double[] s1_valmin = { };
        double[] s2_valmin = { };
        double[] s3_valmin = { };
        double[] s4_valmin = { };
        //val max
        double[] s1_valmax = { };
        double[] s2_valmax = { };
        double[] s3_valmax = { };
        double[] s4_valmax = { };
        // UM
        string[] s1_UM = { };
        string[] s2_UM = { };
        string[] s3_UM = { };
        string[] s4_UM = { };

        Autentificare aut;
        public MainForm()
        {
            InitializeComponent();
            //Console.WriteLine(Width + "  " + Height);
            textBox7.Text = DateTime.Today.ToLongDateString();
            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
#pragma warning disable CS0219 // The variable 'i' is assigned but its value is never used
           int i=0;
#pragma warning restore CS0219 // The variable 'i' is assigned but its value is never used
            try
            {
                //aConnection.Open();
                //OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Hematologie", aConnection);
                //OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                //while (myreader.Read())
               // {
                //    s1[i++] = myreader.GetString(1)+"   "+myreader.GetString(5);
                    
               // }
                checkedListBox1.Items.AddRange(s1);

                checkedListBox2.Items.AddRange(s2);

                checkedListBox4.Items.AddRange(s4);

                checkedListBox3.Items.AddRange(s3);

            }

#pragma warning disable CS0168 // The variable 'exc' is declared but never used
            catch (Exception exc)
#pragma warning restore CS0168 // The variable 'exc' is declared but never used
            {
              
            }
                    dataGridViewX1.Columns.Add("nr_crt", "Nr crt");
            dataGridViewX1.Columns.Add("analize", "Examen clinic");
            dataGridViewX1.Columns.Add("rezultate", "Rezultat");
            PDFWriter pw = new PDFWriter();
            PDFWriter.write_pdf();
            aut = new Autentificare();

        }
        public static void Main()
        {
            Application.Run(new MainForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tabControlPanel2_Click(object sender, EventArgs e)
        {

        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {
            

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {

        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            //create the database connection
            textBox12.Text = nextID.ToString();
            string snume = textBox1.Text;
            string snrtel = textBox4.Text;
            //string svarsta = textBox6.Text;
            string semail = textBox5.Text;
            string sdanl = DateTime.Today.ToString();
            string sadr = textBox3.Text;
            string sspital = textBox9.Text;
            string smedic = textBox8.Text;
            string scnp = textBox2.Text;
            string sdn = dateTimePicker1.Value.ToLongDateString();
            string snrtel_spital = textBox10.Text;
            string sH = "anlz";
            string sB = "anlz";
            string sIS = "anlz";
            string sME = "anlz";
            string stotal = "total=";
            string srezH = "rez=", srezB = "rez=", srezIS = "rez=", srezME = "rez=";
#pragma warning disable CS0219 // The variable 'smedicintrodrez' is assigned but its value is never used
            string smedicintrodrez = " ";
#pragma warning restore CS0219 // The variable 'smedicintrodrez' is assigned but its value is never used
            int t = 0;
#pragma warning disable CS0219 // The variable 'ok' is assigned but its value is never used
            bool ok = true;
#pragma warning restore CS0219 // The variable 'ok' is assigned but its value is never used
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            { sB += checkedListBox2.Items.IndexOf(itemChecked).ToString() + ";"; t += t2[checkedListBox2.Items.IndexOf(itemChecked)]; }
            foreach (object itemChecked in checkedListBox3.CheckedItems)
            { sIS += checkedListBox3.Items.IndexOf(itemChecked).ToString() + ";"; t += t3[checkedListBox3.Items.IndexOf(itemChecked)]; };
            foreach (object itemChecked in checkedListBox4.CheckedItems)
            { sME += checkedListBox4.Items.IndexOf(itemChecked).ToString() + ";"; t += t4[checkedListBox4.Items.IndexOf(itemChecked)]; }

            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            { sH += indexChecked.ToString() + ";"; t += t1[indexChecked]; }
            stotal = t.ToString();
            textBox11.Text = t.ToString();
            if (snume == "" || snrtel == "" || semail == ""
                || sspital == "" || sadr == "" || sdanl == "" || smedic == "" ||
                scnp == "" || sdn == "" || snrtel_spital == "" || sH == "" || sB == "" || sME == "")
            {
                MessageBoxEx.Show("Fiecare camp trbuie completat cu informatii valide", "MedLAB", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ok = false;
            }

            try
            {
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");

                //create the command object and store the sql query
                OleDbCommand aCommand;


                nextID++;
                OleDbCommand myCommand = new OleDbCommand("SELECT * FROM PACIENTI WHERE Cnp=@scnp", aConnection);
                myCommand.Parameters.Add("@scnp", OleDbType.VarChar, 100, "Cnp").Value = scnp;
                long id;
                aConnection.Open();
                id = Convert.ToInt64(myCommand.ExecuteScalar());
                if (id == 0)
                {
                    
                    aCommand = new OleDbCommand("INSERT INTO PACIENTI (Nume, Cnp, NrTelefon, Email, Adresa, DataNasterii)" + "Values (@snume, @scnp, @snrtel, @semail, @sadr, @sdn)", aConnection);
                    aCommand.Parameters.Add("@snume", OleDbType.VarChar, 100, "Nume").Value = snume;
                    aCommand.Parameters.Add("@scnp", OleDbType.VarChar, 100, "Cnp").Value = scnp;
                    aCommand.Parameters.Add("@snrtel", OleDbType.VarChar, 100, "NrTelefon").Value = snrtel;
                    aCommand.Parameters.Add("@semail", OleDbType.VarChar, 100, "Email").Value = semail;
                    aCommand.Parameters.Add("@sadr", OleDbType.VarChar, 100, "Adresa").Value = sadr;
                    aCommand.Parameters.Add("@sdn", OleDbType.VarChar, 100, "DataNasterii").Value = sdn;
                    aCommand.ExecuteNonQuery();
                }
                else
                {
                   
                }

                aCommand = new OleDbCommand("INSERT INTO INREGISTRARI (Cnp, Utilizator, Medic, Nume, DataAnalizelor, MedicIntrodRez, Spital, NrTelefonSpital, Hematologie, ImunologieSerologie, Biochimie, MarkeriEndocrini, Total, RezultateH, RezultateIS, RezultateB, RezultateME)" + "Values (@scnp, @curent_user, @smedicintrodrez, @snume, @sdanl, @smedic, @sspital, @snrtel_spital, @sH, @sIS, @sB, @sME, @stotal, @srezH, @srezIS, @srezB, @srezME)", aConnection);
                aCommand.Parameters.Add("@scnp", OleDbType.VarChar, 100, "Cnp").Value = scnp;
                aCommand.Parameters.Add("@curent_user", OleDbType.VarChar, 100, "Utilizator").Value = curent_user;
                aCommand.Parameters.Add("@smedic", OleDbType.VarChar, 100, "Medic").Value = smedic;
                aCommand.Parameters.Add("@snume", OleDbType.VarChar, 100, "Nume").Value = snume = textBox1.Text;
                aCommand.Parameters.Add("@sdanl", OleDbType.VarChar, 100, "DataAnalizeor").Value = sdanl;
                aCommand.Parameters.Add("@smedicintrodrez", OleDbType.VarChar, 100, "MedicIntrodRez").Value = " ";
                aCommand.Parameters.Add("@sspital", OleDbType.VarChar, 100, "Spital").Value = sspital;
                aCommand.Parameters.Add("@snrtel_spital", OleDbType.VarChar, 100, "NrTelefonSpital").Value = snrtel_spital;
                aCommand.Parameters.Add("@sH", OleDbType.VarChar, 100, "Hematologie").Value = sH;
                aCommand.Parameters.Add("@sIS", OleDbType.VarChar, 100, "ImunologieSerologie").Value = sIS;
                aCommand.Parameters.Add("@sB", OleDbType.VarChar, 100, "Biochimie").Value = sB;
                aCommand.Parameters.Add("@sME", OleDbType.VarChar, 100, "MarkeriEndocrini").Value = sME;
                aCommand.Parameters.Add("@stotal", OleDbType.VarChar, 100, "Total").Value = stotal;
                aCommand.Parameters.Add("@srezH", OleDbType.VarChar, 100, "RezultateH").Value = srezH;
                aCommand.Parameters.Add("@srezIS", OleDbType.VarChar, 100, "RezultateIS").Value = srezIS;
                aCommand.Parameters.Add("@srezB", OleDbType.VarChar, 100, "RezultateB").Value = srezB;
                aCommand.Parameters.Add("@srezME", OleDbType.VarChar, 100, "RezultateME").Value = srezME;

                aCommand.ExecuteNonQuery();
                aConnection.Close();

            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
               
            }


        }



        OleDbDataReader cautare_codInregistrare(long cod)
        {
            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");

            //create the command object and store the sql query
            OleDbCommand aCommand = new OleDbCommand("SELECT * FROM INREGISTRARI WHERE IDCerere=@cod", aConnection);
            aCommand.Parameters.Add("@cod", OleDbType.Integer, 100, "IDCerere").Value = cod;
            OleDbDataReader myreader;
            try
            {
                aConnection.Open();
                myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                // cod=Convert.ToInt64(aCommand.ExecuteScalar());
                //  aConnection.Close();

                return myreader;

            }

                            //Some usual exception handling
            catch (OleDbException exc)
            {
                MessageBox.Show("Error: {0}", exc.Errors[0].Message);
                
            }

            return null;
        }
        void cautare_nume(String nume)
        {
        }
        void cautare_cnp(String cnp)
        {
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbDataReader myreader = cautare_codInregistrare(Convert.ToInt64(textBox6.Text));
                String cnp;
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                aConnection.Open();
                while (myreader.Read())
                {
                    rez_cnp.Text = cnp = myreader.GetString(1);
                    OleDbCommand aCommand = new OleDbCommand("SELECT * FROM PACIENTI WHERE Cnp=@cnp", aConnection);
                    aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;

                    OleDbDataReader myreader2 = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myreader2.Read())
                    {
                        rez_dn.Text = myreader2.GetString(5);
                        rez_danlz.Text = myreader.GetString(7);

                        rez_medic.Text = myreader.GetString(4);


                        dataGridViewX1.Rows.Clear();
                        dataGridViewX1.Enabled = true;
                        int i, nr = 0, nr_crt = 0;
                        Object[] obj = new Object[3];

                        nrH = nrB = nrIS = nrME = 0;
                        string Hemat = myreader.GetString(9);
                        string ImSer = myreader.GetString(10);
                        string Bioch = myreader.GetString(11);
                        string Mend = myreader.GetString(12);

                        

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
                        nrME = nr_crt - (nrIS + nrH + nrB);

                    }

                }


                myreader.Close();
                //myreader2.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
            //  rez_danlz.Text = myreader.GetString(2);
            //  rez_dn.Text = myreader.GetString(3);
            //  rez_medic.Text = myreader.GetString(4);


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int j;
            string rezH, rezB, rezIS, rezME;
            rezH = rezB = rezIS = rezME = "rezultate";


            for (j = 0; j < nrH; j++) rezH += dataGridViewX1.Rows[j].Cells[2].Value.ToString() + ";";
            for (j = nrH; j < nrB + nrH; j++) rezB += dataGridViewX1.Rows[j].Cells[2].Value.ToString() + ";";
            for (j = nrB + nrH; j < nrIS + nrB + nrH; j++) rezIS += dataGridViewX1.Rows[j].Cells[2].Value.ToString() + ";";
            for (j = nrIS + nrH + nrB; j < dataGridViewX1.Rows.Count - 1; j++) rezME += dataGridViewX1.Rows[j].Cells[2].Value.ToString() + ";";
            //UpdateContact(m_XmlDocument, myc.ContactID, myc.Nume, myc.Nrtel, myc.Email, myc.Spital, myc.Adr, myc.Danl, myc.Medic, myc.Cnp, myc.Dn, myc.Nrtel_spital, myc.Hemat, myc.Bioch, myc.ImSer, myc.Mend, rezH, rezB, rezIS, rezME, myc.Total);
            
            dataGridViewX1.Enabled = false;


        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\WINWORD.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\EXCEL.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
              
            }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\OUTLOOK.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
              
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\POWERPNT.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
         
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\WINDOWS\System32\Calc.exe");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
         
            }
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\WINWORD.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
      
            }
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\EXCEL.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
               
            }
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\OUTLOOK.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\Office11\PowerPnt.EXE");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\WINDOWS\System32\Calc.exe");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
        }

        private void groupPanel5_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            Cautare_nume cn = new Cautare_nume();
            cn.ShowDialog();
            cn.Dispose();
            cn.Focus();
        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            Cautare_nume cn = new Cautare_nume();
            cn.ShowDialog();
            cn.Dispose();
            cn.Focus();

        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            Cautare_cnp cp = new Cautare_cnp();
            cp.ShowDialog();
            cp.Dispose();
            cp.Focus();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            Cautare_ID cid = new Cautare_ID();
            cid.ShowDialog();
            cid.Dispose();
            cid.Focus();
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {
            Stergere_pacienti sp = new Stergere_pacienti();
            sp.ShowDialog();
            sp.Dispose();
            sp.Focus();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
                string cnp = rez_cnp.Text;
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Pacienti WHERE Cnp=@cnp", aConnection);
                aCommand.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;
                
                OleDbDataReader myreader;



                aConnection.Open();
                myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
                myreader.Read();
                string email = myreader.GetString(3);
                Console.WriteLine("aici");
                GmailSender.SendMail("dumitrescu.evelina@gmail.com", "andreia90", email, "MedLab", "Acestea sunt rezultatele analizelor.");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                
            }
        }

        
        
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Print.printare(Convert.ToInt32(textBox6.Text), rez_cnp.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
                Console.WriteLine(exc.ToString());
            }
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            Cautare_cnp cp = new Cautare_cnp();
            cp.ShowDialog();
            cp.Dispose();
            cp.Focus();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            Cautare_ID cid = new Cautare_ID();
            cid.ShowDialog();
            
            cid.Dispose();
            cid.Focus();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            Stergere_pacienti sp = new Stergere_pacienti();
            sp.ShowDialog();
            sp.Dispose();
            sp.Focus();
 
        }

        private void buttonItem44_Click(object sender, EventArgs e)
        {
            SuportTehnic st = new SuportTehnic();
            st.ShowDialog();
            
            st.Dispose();
           
            st.Focus();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            AdaugareUtilizator au = new AdaugareUtilizator();
            au.ShowDialog();
            au.Dispose();
            au.Focus();

        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            SuportTehnic st = new SuportTehnic();
            st.ShowDialog();

            st.Dispose();

            st.Focus();

        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            About_MedLab am = new About_MedLab();
            am.ShowDialog();
            am.Dispose();
            am.Focus();
        }

        private void buttonItem46_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem47_Click(object sender, EventArgs e)
        {
            Cautare_nume cn = new Cautare_nume();
            cn.ShowDialog();
            cn.Dispose();
            cn.Focus();
        }

        private void buttonItem49_Click(object sender, EventArgs e)
        {
            Cautare_cnp cp = new Cautare_cnp();
            cp.ShowDialog();
            cp.Dispose();
            cp.Focus();
        }

        private void buttonItem50_Click(object sender, EventArgs e)
        {
            Cautare_ID cid = new Cautare_ID();
            cid.ShowDialog();
            cid.Dispose();
            cid.Focus();
        }

        private void buttonItem51_Click(object sender, EventArgs e)
        {
            Stergere_pacienti sp = new Stergere_pacienti();
            sp.ShowDialog();
            sp.Dispose();
            
            sp.Focus();
        }

        private void buttonItem57_Click(object sender, EventArgs e)
        {
            SuportTehnic st = new SuportTehnic();
            st.ShowDialog();
            st.Dispose();
            st.Focus();
        }

        private void buttonItem59_Click(object sender, EventArgs e)
        {
            About_MedLab am = new About_MedLab();
            am.ShowDialog();
            am.Dispose();
            am.Focus();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (aut.enter == false)
            {
                aut.enter = true;
                aut.ShowDialog();
                aut.Dispose();
                aut.Focus();
            }
            labelItem1.Text = aut.user;
           labelItem2.Text = DateTime.Today.ToLongDateString();
            

        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
           
        }

        private void buttonItem52_Click(object sender, EventArgs e)
        {
            AdaugareUtilizator au = new AdaugareUtilizator();
            au.ShowDialog();
            au.Dispose();
            au.Focus();
        }

        private void buttonItem53_Click(object sender, EventArgs e)
        {
            StergereUtilizator stutlz = new StergereUtilizator();
            stutlz.ShowDialog();
            stutlz.Dispose();
            stutlz.Focus();
        }

        private void buttonItem54_Click(object sender, EventArgs e)
        {
            SchimbareParolaUtilizator spu = new SchimbareParolaUtilizator();
            spu.ShowDialog();
            spu.Dispose();
            spu.Focus();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            StergereUtilizator stutlz = new StergereUtilizator();
            stutlz.ShowDialog();
            stutlz.Dispose();
            stutlz.Focus();

        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            SchimbareParolaUtilizator spu = new SchimbareParolaUtilizator();
            spu.ShowDialog();
            spu.Dispose();
            spu.Focus();

        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            Autentificare aut = new Autentificare();
            aut.ShowDialog();
            aut.Dispose();
            aut.Focus();
        }

        private void ribbonBar3_ItemClick(object sender, EventArgs e)
        {

        }
    }
}