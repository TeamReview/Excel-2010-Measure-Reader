using System.IO;
using System.Text;

namespace Excel_2010_Measure_Reader
{
    public static class ExcelFiles
    {
        public static string ReadAllMeasures(ExcelTreeView directoryTree)
        {
            var measureText = new StringBuilder();

            foreach (string path in directoryTree.GetFilePaths())
            {
                measureText.AppendLine("File: " + Path.GetFileName(path));
                measureText.AppendLine("Path: " + Path.GetDirectoryName(path));
                measureText.AppendLine();

                try
                {
                    var excel = new ExcelFile(path);
                    string measures = (excel.GetMeasures());
                    measureText.AppendLine(string.IsNullOrEmpty(measures)
                        ? "Unable to extract measures from " + Path.GetFileName(path)
                        : measures);
                }

                catch (ExcelException ex)
                {
                    measureText.AppendLine(ex.Message);
                }

                measureText.AppendLine();
            }

            return measureText.ToString();
        }
    }
}