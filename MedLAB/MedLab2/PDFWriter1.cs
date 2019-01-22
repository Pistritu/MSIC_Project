using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace MedLab2
{
    public class PDFWriter
    {


    public    static void write_pdf()
        {
            string sFilePDF="myFile.pdf";

           

            // step 1: creation of a document-object

            Document document = new Document();

            try
            {
                // step 2:

                // we create a writer that listens to the document

                // and directs a PDF-stream to a file


                PdfWriter writer = PdfWriter.GetInstance(document,
                                   new FileStream(sFilePDF, FileMode.Create));

                // step 3: we open the document

                document.Open();

                // step 4: we create a table and add it to the document

                Table aTable = new Table(2, 2);    // 2 rows, 2 columns

                aTable.AddCell("0.0");
               
                aTable.AddCell("0.1");
                aTable.AddCell("1.0");
                aTable.AddCell("1.1");
                document.Add(aTable);

                
            }
            catch (DocumentException de)
            {
                Console.WriteLine(de.ToString());
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
            }

            // step 5: we close the document

            document.Close();

            

           
        }
    }
}