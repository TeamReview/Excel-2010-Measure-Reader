using System;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace Excel_2010_Measure_Reader
{
    internal class ExcelFile : ZipFile
    {
        public ExcelFile(string filePath) : base(filePath)
        {
        }

        public string GetMeasures()
        {
            IOrderedEnumerable<ZipEntry> entries = from entry in SelectEntries(@"customXml\Item*.xml").AsEnumerable()
                where !entry.FileName.Contains("Props")
                orderby entry.UncompressedSize descending
                select entry;

            string measures = string.Empty;

            foreach (ZipEntry entry in entries)
            {
                using (var memoryStream = new MemoryStream())
                {
                    entry.Extract(memoryStream);
                    string text = MemoryStreamToText(memoryStream, 0);
                    int startIndex = text.IndexOf("CREATE MEASURE", StringComparison.Ordinal);

                    if (startIndex < 0) continue;

                    measures = text.Substring(startIndex);
                    int endIndex = measures.IndexOf("</Text>", StringComparison.Ordinal);

                    if (endIndex > 0)
                    {
                        measures = measures.Substring(0, endIndex);
                    }
                    break;
                }
            }

            return Cleanse(measures);
        }

        private string Cleanse(string measures)
        {
            return measures.Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&amp;", "&")
                .Replace("CREATE MEASURE ", "");
        }

        private static string MemoryStreamToText(MemoryStream memoryStream, int startPosition)
        {
            memoryStream.Position = startPosition;

            using (var streamReader = new StreamReader(memoryStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }

    public class ExcelException : ZipException
    {
    }
}