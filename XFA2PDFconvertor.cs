using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Aspose.Pdf.Forms;
using Microsoft.Office.Interop.Excel;


namespace universalReader
{
    public static class XFA2PDFconvertor
    {
        public static void XFA2PDF(object sender, EventArgs e)
        {
            Document doc = new Document(@"C:\Users\ChernyshovKS\Desktop\temp_tester\PDF\test.pdf");
            string[] names = doc.Form.XFA.FieldNames;
            for (int count = 0; count < names.Length; count++)
            {
                var field = doc.Form.XFA.GetFieldTemplate(names[count]);
                string fieldName = doc.Form.XFA.GetFieldTemplate(names[count]).InnerText;
                string fieldValue = doc.Form.XFA[names[count]];

               if (!string.IsNullOrEmpty(fieldValue) && fieldValue != "0")
               {
                   Console.WriteLine("Field Name : " + field.Attributes["name"].Value);
                   //Console.WriteLine("Field Description : " + fieldName);
                   Console.WriteLine("Field Value : " + fieldValue);
                   Console.WriteLine();
               }
            }
            doc.Flatten();
            doc.Save(@"C:\Users\ChernyshovKS\Desktop\temp_tester\PDF\test_out.pdf");
        }

    }
}
