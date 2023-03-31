using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Replace this value with the path to your PDF file
        string inputPdf = "input.pdf";

        // Create a reader object to read the input PDF file
        using (PdfReader reader = new PdfReader(inputPdf))
        {
            // Create a StringBuilder object to store the extracted text
            StringBuilder text = new StringBuilder();

            // Iterate through each page of the PDF and extract its text content
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                // Create a location object to define the text extraction region
                Rectangle rect = new Rectangle(0, 0, 1000, 1000);

                // Create a RenderFilter object to filter out images and other non-text content
                RenderFilter filter = new RegionTextRenderFilter(rect);

                // Create a text extraction strategy object using the filter and region
                ITextExtractionStrategy strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);

                // Extract the text content from the page using the strategy object
                string pageText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);

                // Append the page text to the StringBuilder object
                text.Append(pageText);
            }

            // Close the reader object
            reader.Close();

            // Use the extracted text for further processing
            Console.WriteLine(text.ToString());
        }
    }
}
