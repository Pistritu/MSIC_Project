using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace MedLab2
{
   public  class Print
    {
        static int[] t1 = { 22, 10, 17, 15, 10, 55, 45 };
        static int[] t2 = { 7, 9, 7, 7, 9, 9, 28, 390, 390 };
        static int[] t3 = { 18, 18, 13, 55, 45, 55 };
        static int[] t4 = { 29, 51, 35, 35, 43, 44, 36, 29, 30, 29 };
#pragma warning disable CS0169 // The field 'Print.nrME' is never used
#pragma warning disable CS0169 // The field 'Print.nrH' is never used
#pragma warning disable CS0169 // The field 'Print.nrIS' is never used
#pragma warning disable CS0169 // The field 'Print.nrB' is never used
        static int nrH, nrB, nrIS, nrME;
#pragma warning restore CS0169 // The field 'Print.nrB' is never used
#pragma warning restore CS0169 // The field 'Print.nrIS' is never used
#pragma warning restore CS0169 // The field 'Print.nrH' is never used
#pragma warning restore CS0169 // The field 'Print.nrME' is never used
        
        //hemat
        static string[] s1 = { "Leucocite    22", "Rh    10", "Fibrinogen     17", "Timp trombina  15", "Grup sanguin   10", "Proteina S     55", "Proteina C 45" };
        //bioch
        static string[] s2 = { "Ca ionic    7", "Ca seric    9", "Mg seric    7", "Glucoza serica  7", "Trigliceride    9", "CK      9", "Profil lipidic      28", "ADNhepatitaC    390", "ArnhepatitaB  390" };
        // markeri enodocrini
        static string[] s4 = { "AFP      29", "Calcitonina 51", "CA125  35", "CA15-3 35", "Ca72-4    43", "SCC   44", "ACTH   36", "Cortisol   29", "Prolactina 30", "Insulina   29" };
        //imun_ser
        static string[] s3 = { "IgA    18", "IgB    18", "ASLO   13", "ANA    55", "AMA    45", "Anticorpi_antiADN  55" };
        
     public static  void printare(int index, string cnp)
       {
         try{
           FileStream f = new FileStream("Print.doc", FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
           //f = new FileStream("Print.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);

           StreamWriter f_out = new StreamWriter(f);
           int i, nr = 0, nr_crt = 0, i1 = "rezultate_H".Length, j;
           string s;

           string nume, dn, danlz, adresa, nrtel, email, medic, nrtel_spital, spital, H, IS, B, ME, rezH, rezIS, rezB, rezME;
           OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
           aConnection.Open();
           OleDbCommand aCommand = new OleDbCommand("SELECT * FROM INREGISTRARI WHERE IDCerere=@index", aConnection);
           aCommand.Parameters.Add("@index", OleDbType.Integer, 100, "IDCerere").Value = index;

           OleDbDataReader myreader = aCommand.ExecuteReader(CommandBehavior.CloseConnection);
           myreader.Read();
           medic = myreader.GetString(4);
           nume = myreader.GetString(2);
           spital = myreader.GetString(5);
           danlz = myreader.GetString(7);
           nrtel_spital = myreader.GetString(8);
           H = myreader.GetString(9);
           IS = myreader.GetString(10);
           B = myreader.GetString(11);
           ME = myreader.GetString(12);
           rezH = myreader.GetString(14);
           rezIS = myreader.GetString(15);
           rezB = myreader.GetString(16);
           rezME = myreader.GetString(17);

           myreader.Close();
           OleDbConnection aConnection2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MedLab_DataBase.mdb");
           aConnection2.Open();
           OleDbCommand aCommand2 = new OleDbCommand("SELECT * FROM Pacienti WHERE Cnp=@cnp", aConnection2);
           aCommand2.Parameters.Add("@cnp", OleDbType.VarChar, 100, "Cnp").Value = cnp;

           OleDbDataReader myreader2 = aCommand2.ExecuteReader(CommandBehavior.CloseConnection);
           myreader2.Read();
           nrtel = myreader2.GetString(2);
           email = myreader2.GetString(3);
           adresa = myreader2.GetString(4);
           dn = myreader2.GetString(5);

           try
           {
               s = "\t\t\t\tBULETIN DE ANALIZE\n\n\n\n\n";
               f_out.Write(s);
               s = "\tNUME PACIENT\t\t\t" + nume + "\n" + "\tDATA NASTERII\t\t\t" + dn + "\n" + "\tCNP\t\t\t\t" + cnp + "\n" + "\tADRESA\t\t\t\t" + adresa + "\n" + "\tTELEFON\t\t\t\t" + nrtel + "\n" + "\tEMAIL\t\t\t\t" + email + "\n\n" + "\tMEDIC\t\t\t\t" + medic + "\n" + "\tINSTITUTIE\t\t\t\t" + spital + "\n\n" + "\tDATA EFECTUARII ANALIZELOR\t" + danlz + "\n\n\n\n\n";
               f_out.Write(s);

               s = ".............................................................................\n";
               f_out.Write(s);
               s = "DENUMIRE\t\tREZULTAT\tUM\tVALORI DE REFERINTA\n";
               f_out.Write(s);
               s = ".............................................................................\n";
               f_out.Write(s);
               if (H.Length > 4)
               {
                   s = "HEMATOLOGIE\n";
                   f_out.Write(s);
                   for (i = 4; i < H.Length; i++)
                   {
                       if (H[i] != ';')
                       {
                           nr = nr * 10 + int.Parse(H[i].ToString());
                       }
                       else
                       {
                           nr_crt++;
                           s = nr_crt.ToString() + "." + s1[nr].Substring(0, s1[nr].IndexOf(' '));
                           nr = 0;
                           f_out.Write(s);
                           //i1=i2= "rezultate_h".Length;
                           s = "";
                           for (j = i1; j < rezH.Length; j++)
                           {
                               if (rezH[j] != ';')
                               {
                                   s += rezH[j].ToString();


                               }
                               else { s += "\n"; f_out.Write(s); i1 = j; j = rezH.Length; s = ""; }


                           }

                           // f_out.Write("\n");



                       }
                   }
               }




               if (IS.Length > 4)
               {
                   s = "IMUNOLOGIE SI SEROLOGIE\n";
                   f_out.Write(s);
                   for (i = 4; i < IS.Length; i++)
                   {
                       if (IS[i] != ';')
                       {
                           nr = nr * 10 + int.Parse(IS[i].ToString());
                       }
                       else
                       {
                           nr_crt++;
                           s = nr_crt.ToString() + "." + s3[nr].Substring(0, s3[nr].IndexOf(' ')) + "\n";
                           nr = 0;
                           f_out.Write(s);
                       }
                   }
               }







               if (ME.Length > 4)
               {
                   s = "MARKERI ENDOCRINI\n";
                   f_out.Write(s);
                   for (i = 4; i < ME.Length; i++)
                   {
                       if (ME[i] != ';')
                       {
                           nr = nr * 10 + int.Parse(ME[i].ToString());
                       }
                       else
                       {
                           nr_crt++;
                           s = nr_crt.ToString() + "." + s4[nr].Substring(0, s4[nr].IndexOf(' ')) + "\n";
                           nr = 0;
                           f_out.Write(s);
                       }
                   }
               }
               if (B.Length > 4)
               {
                   s = "BIOCHIMIE\n";
                   f_out.Write(s);
                   for (i = 4; i < B.Length; i++)
                   {
                       if (B[i] != ';')
                       {
                           nr = nr * 10 + int.Parse(B[i].ToString());
                       }
                       else
                       {
                           nr_crt++;
                           s = nr_crt.ToString() + "." + s2[nr].Substring(0, s2[nr].IndexOf(' ')) + "\n";
                           nr = 0;
                           f_out.Write(s);
                       }
                   }




               }
           }
           catch (IOException exc)
           {
               Console.WriteLine(exc.Message + "print");
           }
           f_out.Close();




       
               // Get the path that stores user documents.
               string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
               PrintDialog pd = new PrintDialog();
               System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
               docToPrint.DocumentName = "Print.doc";


               pd.Dispose();

               pd.Document = docToPrint;

               DialogResult result = pd.ShowDialog();

               // If the result is OK then print the document.
               if (result == DialogResult.OK)
               {
                   docToPrint.Print();
               }


           }
           catch (Exception exc)
           {

               Console.WriteLine(exc.Message.ToString());


           }

       }
    }
}
