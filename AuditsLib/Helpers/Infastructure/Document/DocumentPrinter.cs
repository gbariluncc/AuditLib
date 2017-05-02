using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Xps;

namespace Audits.Infastructure.Document
{
    public static class DocumentPrinter
    {
        public static void Print(FlowDocument document, string title = "Printing Document.")
        {
            document.Name = "TestDoc";
            PrintDialog pd = new PrintDialog();

            document.PageWidth = pd.PrintableAreaWidth;
            document.PageHeight = pd.PrintableAreaHeight;
            IDocumentPaginatorSource idpSource = document;

            pd.PrintDocument(idpSource.DocumentPaginator, title);
        }
    }
}
