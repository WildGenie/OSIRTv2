using System.Drawing.Printing;
using System.IO;
using TuesPechkin;

namespace OSIRT.Helpers
{
    public class HtmLtoPdf
    {

        private static IConverter converter =
                        new ThreadSafeConverter(
                                new PdfToolset(
                                        new Win32EmbeddedDeployment(
                                                new TempFolderDeployment())));


        private HtmLtoPdf(){ }

        /// <summary>
        /// Converts the specified string of HTML into a byte[]
        /// that can be saved as a PDF.
        /// </summary>
        /// <param name="html">The HTML to convert to a byte[]</param>
        public static byte[] Convert(string html)
        {
            return null;
        }

        /// <summary>
        /// Converts the specified HTML and saves the file as PDF
        /// to the specified location.
        /// </summary>
        /// <param name="html">The HTML to convert</param>
        /// <param name="filePath">The location where the PDF should be saved</param>
        /// <param name="documentTitle">The title of the PDF document</param>
        public static void SaveHtmltoPdf(string html, string GSCP, string documentTitle, string filePath)
        {
            var document = GetHtmlToPdfDocument(html, documentTitle, GSCP);
            byte[] result =  converter.Convert(document);
            File.WriteAllBytes(filePath, result);
        } 

        private static HtmlToPdfDocument GetHtmlToPdfDocument(string html, string documentTitle, string gscp)
        {
            var document = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = documentTitle,
                    PaperSize = PaperKind.A4,
                    Orientation = GlobalSettings.PaperOrientation.Landscape,

                    Margins =
                    {
                        All = 1.375,
                        Unit = Unit.Centimeters
                    }
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlText = html,
                        WebSettings = new WebSettings
                        {
                            LoadImages = true
                                
                        },
                        FooterSettings = new FooterSettings{LeftText = gscp, RightText = "[page]", FontSize = 8.0d},
                       
                       
                    }
                }
            };
            return document;
        }
    }
}
