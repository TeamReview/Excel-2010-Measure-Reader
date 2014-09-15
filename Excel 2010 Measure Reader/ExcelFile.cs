using System;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace Excel_2010_Measure_Reader
{    
    // An Excel xlsx file is a zipped file. Using ZipFile as its parent allows ExcelFile 
    // to be responsible for extracting its own items.

    internal class ExcelFile : ZipFile
    {
        public ExcelFile(string filePath) : base(filePath)
        {
        }

        public string GetMeasures()
        {
            // When unzipped, Excel 2010 files have their measures stored in an xml file located
            // under the customXml folder.  The name of the file will not always be exactly the
            // same, but will start with "Item" and have an extension of "xml". An additional 
            // criteria for finding the file is its size (almost always it is the largest file).

            var entries = SelectEntries(@"customXml\Item*.xml").AsEnumerable()
                .Where(entry => !entry.FileName.Contains("Props"))
                .OrderByDescending(entry => entry.UncompressedSize)
                .Select(entry => entry);

            var measures = string.Empty;

            foreach (var entry in entries)
            {
                using (var memoryStream = new MemoryStream())
                {
                    entry.Extract(memoryStream);
                    var text = MemoryStreamToText(memoryStream, 0);
                    var startIndex = text.IndexOf("CREATE MEASURE", StringComparison.Ordinal);

                    if (startIndex < 0) continue;

                    measures = text.Substring(startIndex);
                    var endIndex = measures.IndexOf("</Text>", StringComparison.Ordinal);

                    if (endIndex > 0)
                    {
                        measures = measures.Substring(0, endIndex);
                    }
                    break;
                }
            }

            return AlphaSort(Cleanse(measures));
        }

        private string Cleanse(string measures)
        {
            return measures.Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&amp;", "&")
                .Replace("CREATE MEASURE ", "");
        }

        private string AlphaSort(string measures)
        {
            // handle special cases where the zipped version of the Excel file contains more than one measure on a single line
            var measuresSeparated = measures.Split(';').AsEnumerable().Select(measure => measure.Trim());
            var measuresSorted = measuresSeparated.AsEnumerable().OrderBy(measure => measure.ToUpper()).Select(measure => measure);
            var measuresToString = "";

            foreach (var measure in measuresSorted)
            {
                if (! string.IsNullOrEmpty(measure.Trim()))
                {
                    measuresToString += measure.Trim() + ";" + Environment.NewLine;
                }
            }
            return measuresToString;
        }

        private string MemoryStreamToText(Stream stream, int startPosition)
        {
            stream.Position = startPosition;

            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}